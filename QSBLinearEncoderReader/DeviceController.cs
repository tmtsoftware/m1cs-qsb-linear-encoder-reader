using System;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace QSBLinearEncoderReader
{
    /// <summary>
    /// This class handles RS-232 communication with an QSB-D.
    /// 
    /// The command and response format is explained in QSB Command List
    /// (Document Version 1.28, 5/5/2021):
    /// https://www.usdigital.com/media/gwqpsnym/qsb-commands-list.pdf
    /// </summary>
    internal class DeviceController
    {
        private string _portName;
        private int _baudRate;
        private QuadratureMode _quadratureMode;
        private EncoderDirection _encoderDirection;

        private SerialPort _serialPort;
        private object _serialPortLock = new object();

        private bool _connected;
        private object _connectionStatusLock = new object();

        private int _encoderCount = 0;
        private int _encoderZeroPositionCount;
        private decimal _encoderResolution_nm;
        private object _encoderCountLock = new object();

        private uint _serialNumber = 0;
        private uint _firmwareVersion = 0;
        private string _productType = "Not Connected";
        private object _statusLock = new object();

        private StreamWriter _recorder;
        private long _recorderNumOfLine = 0;
        private uint _recorderFirstTimestamp = 0;
        private object _recorderLock = new object();

        private bool _statisticsOngoing = false;
        private ulong _statisticsNumberOfSamples = 0;
        private decimal _statisticsAverage = 0.0M;
        private decimal _statisticsMinimum = 0.0M;
        private decimal _statisticsMaximum = 0.0M;
        private object _statisticsLock = new object();

        public DeviceController(
            string portName,
            int baudRate,
            QuadratureMode quadratureMode,
            EncoderDirection encoderDirection,
            int encoderZeroPositionCount,
            decimal encoderResolution_nm)
        {
            Logger.Log("portName = " + portName);
            Logger.Log("baudRate = " + baudRate);
            Logger.Log("quadratureMode = " + quadratureMode);
            Logger.Log("encoderDirection = " + encoderDirection);
            Logger.Log("encoderZeroPositionCount = " + encoderZeroPositionCount);
            Logger.Log("encoderResolution_nm = " + encoderResolution_nm);

            if (String.IsNullOrEmpty(portName))
            {
                throw new InvalidConnectionSettingException("Port name must not be null or empty.");
            }

            if (baudRate <= 0)
            {
                throw new InvalidConnectionSettingException("Baud rate must be positive.");
            }

            _portName = portName;
            _baudRate = baudRate;
            _quadratureMode = quadratureMode;
            _encoderDirection = encoderDirection;
            _encoderZeroPositionCount = encoderZeroPositionCount;
            _encoderResolution_nm = encoderResolution_nm;

            _serialPort = null;
            _connected = false;
        }

        /// <summary>
        /// Connect to an QSB-D through a serial port and start getting the encoder count in the streaming mode.
        /// </summary>
        public void Connect()
        {
            lock (_serialPortLock)
            {
                try
                {
                    if (_serialPort != null)
                    {
                        throw new InvalidOperationException("Cannot reconnect using the same DeviceController instance.");
                    }

                    Logger.Log(String.Format("Connecting to {0}. (Baud rate: {1})", _portName, _baudRate));

                    _serialPort = new SerialPort();
                    _serialPort.PortName = _portName;
                    _serialPort.BaudRate = _baudRate;
                    _serialPort.Parity = Parity.None;
                    _serialPort.DataBits = 8;
                    _serialPort.StopBits = StopBits.One;
                    _serialPort.Handshake = Handshake.None;
                    _serialPort.RtsEnable = true;
                    _serialPort.NewLine = "\r\n";

                    _serialPort.ReadTimeout = 1000;
                    _serialPort.WriteTimeout = 1000;

                    _serialPort.Open();
                    Logger.Log(String.Format("Connected to {0}.", _portName));

                    // high-low-high transition on the DTR line resets the QSB-D.
                    _serialPort.DtrEnable = true;
                    _serialPort.DtrEnable = false;
                    _serialPort.DtrEnable = true;

                    // When QSB-D is reset, QSB-D first sends one line message "QSB-D  0E!\r\n",
                    // but this is not a documented behavior. So, first try to read one line (=
                    // wait until "\r\n" is received) and if it times out, simply proceed to
                    // the next step.
                    try
                    {
                        string firstLine = _serialPort.ReadLine();
                        Logger.Log(String.Format("Received '{0}'.", firstLine));
                    }
                    catch (TimeoutException)
                    {
                        Logger.Log("Didn't receive the first line.");
                    }

                    // Change the reply format. All respnoses from the QSB-D from here on are
                    // in the format of 
                    //
                    //   +---------------------------+-------------------+---------------------+-------------------+
                    //   | Command Response [1 byte] | whitespace (0x20) | Register [2 bytes]  | whitespace (0x20) |
                    //   +---------------------------+-------------------+---------------------+-------------------+
                    //   | Data [8 bytes]            | whitespace (0x20) | Timestamp [8 bytes] | whitespace (0x20) |
                    //   +---------------------------+-------------------+---------------------+-------------------+
                    //   | ! (0x21)                  | \r (0x0D)         | \n (0x0A)           |
                    //   +---------------------------+-------------------+---------------------+
                    //
                    //    (26 bytes in total)
                    //
                    WriteCommand(0x15, 0x0000000F);

                    // Get the product type, serial number and firmware version.
                    uint versionResponse = ReadCommand(0x14);

                    lock (_statusLock)
                    {
                        _serialNumber = (versionResponse & 0xFFFFF000) >> 12;
                        uint productTypeCode = (versionResponse & 0x00000F00) >> 8;
                        _firmwareVersion = versionResponse & 0x000000FF;

                        switch (productTypeCode)
                        {
                            case 0:
                                _productType = "QSB-D";
                                break;
                            case 1:
                                _productType = "QSB-M";
                                break;
                            case 2:
                                _productType = "QSB-S";
                                break;
                            default:
                                _productType = "Unknown";
                                break;
                        }

                        Logger.Log(
                            String.Format("Product Type: {0}, Serial Number: {1}, Firmware Version: {2}",
                            _productType, _serialNumber, _firmwareVersion));
                    }

                    // Set quadratue mode (x1, x2 or x4).
                    uint quadratureModeValue;
                    switch (_quadratureMode)
                    {
                        case QuadratureMode.X1:
                            quadratureModeValue = 1;
                            break;
                        case QuadratureMode.X2:
                            quadratureModeValue = 2;
                            break;
                        case QuadratureMode.X4:
                            quadratureModeValue = 3;
                            break;
                        default:
                            throw new Exception("Unexpected quadrature mode: " + _quadratureMode);
                    }
                    WriteCommand(0x03, quadratureModeValue);

                    // Set encoder direction.
                    uint encoderDirectionValue;
                    switch (_encoderDirection)
                    {
                        case EncoderDirection.CountUp:
                            encoderDirectionValue = 0x00;
                            break;
                        case EncoderDirection.CountDown:
                            encoderDirectionValue = 0x80;
                            break;
                        default:
                            throw new Exception("Unexpected encoder encoderDirection: " + _encoderDirection);
                    }
                    WriteCommand(0x04, encoderDirectionValue);

                    // Set the threshold to 0 meaning that the encoder count will be reported regardless of the count difference from the previous one.
                    WriteCommand(0x0B, 0x00000000);

                    // Set the output interval to 1/512 x 1 Hz (1.953125 ms)
                    WriteCommand(0x0C, 0x00000001);

                    // Reset the 32-bit timestamp register to minimize the chance of rollover (every 94.5 days).
                    WriteCommand(0x0D, 0x00000001);

                    // Start streaming the encoder count at the specified interval.
                    StreamCommand(0x0E);

                    Thread readEncoderCountLoopThread = new Thread(new ThreadStart(EncoderCountReaderLoop));
                    readEncoderCountLoopThread.Start();

                    // Change the connection status.
                    lock (_connectionStatusLock)
                    {
                        _connected = true;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log(ex.ToString());
                    Disconnect();
                    throw ex;
                }
            }
        }

        private void WriteCommand(byte register, uint data)
        {
            lock (_serialPortLock)
            {
                string registerStr = register.ToString("X2");
                string dataStr = data.ToString("X8");

                string command = "W" + registerStr + dataStr;
                Logger.Log(String.Format("Sending command '{0}'.", command));
                _serialPort.WriteLine(command);

                try
                {
                    string response = _serialPort.ReadLine();
                    Logger.Log(String.Format("Received response '{0}'.", response));

                    string[] fields = response.Split(' ');
                    if (fields.Length != 5)
                    {
                        throw new UnexpectedResponseException("The response was expected to have 5 single white spaces.", command, response);
                    }
                    else if (fields[0] != "w")
                    {
                        throw new UnexpectedResponseException("The first field in the respnose was expected to be 'w'.", command, response);
                    }
                    else if (fields[1] != registerStr)
                    {
                        throw new UnexpectedResponseException("The second field in the response was expected to be '" + registerStr + "'.", command, response);
                    }
                    else if (fields[2] != dataStr)
                    {
                        throw new UnexpectedResponseException("The third field in the response was expected to be '" + dataStr + "'.", command, response);
                    }
                    else if (fields[3].Length != 8)
                    {
                        throw new UnexpectedResponseException("The fourth field in the response was expected to be 8 bytes.", command, response);
                    }
                    else if (fields[4] != "!")
                    {
                        throw new UnexpectedResponseException("The fifth field in the response was expected to be '!'.", command, response);
                    }
                }
                catch (TimeoutException e)
                {
                    throw new TimeoutException("The device didn't respond to command '" + command + "'." , e);
                }
            }
        }

        private uint ReadCommand(byte register)
        {
            uint timestamp;
            return ReadCommand(register, out timestamp);
        }

        private uint ReadCommand(byte register, out uint timestamp)
        {
            lock (_serialPortLock)
            {
                string registerStr = register.ToString("X2");

                string command = "R" + registerStr;
                Logger.Log(String.Format("Sending command '{0}'.", command));
                _serialPort.WriteLine(command);

                try
                {
                    string response = _serialPort.ReadLine();
                    Logger.Log(String.Format("Received response '{0}'.", response));

                    string[] fields = response.Split(' ');
                    if (fields.Length != 5)
                    {
                        throw new UnexpectedResponseException("The response was expected to have 5 single white spaces.", command, response);
                    }
                    else if (fields[0] != "r")
                    {
                        throw new UnexpectedResponseException("The first field in the respnose was expected to be 'r'.", command, response);
                    }
                    else if (fields[1] != registerStr)
                    {
                        throw new UnexpectedResponseException("The second field in the response was expected to be '" + registerStr + "'.", command, response);
                    }
                    else if (fields[2].Length != 8)
                    {
                        throw new UnexpectedResponseException("The third field in the response was expected to be 8 bytes.", command, response);
                    }
                    else if (fields[3].Length != 8)
                    {
                        throw new UnexpectedResponseException("The fourth field in the response was expected to be 8 bytes.", command, response);
                    }
                    else if (fields[4] != "!")
                    {
                        throw new UnexpectedResponseException("The fifth field in the response was expected to be '!'.", command, response);
                    }

                    try
                    {
                        timestamp = uint.Parse(fields[3], System.Globalization.NumberStyles.HexNumber);
                    }
                    catch (Exception e)
                    {
                        throw new UnexpectedResponseException("The fourth field in the respnose was expected to be an 8-digit hex.", command, response, e);
                    }

                    try
                    {
                        return uint.Parse(fields[2], System.Globalization.NumberStyles.HexNumber);
                    }
                    catch (Exception e)
                    {
                        throw new UnexpectedResponseException("The third field in the respnose was expected to be an 8-digit hex.", command, response, e);
                    }
                }
                catch (TimeoutException e)
                {
                    throw new TimeoutException("The device didn't respond to command '" + command + "'.", e);
                }
            }
        }

        private void StreamCommand(byte register)
        {
            lock (_serialPortLock)
            {
                string registerStr = register.ToString("X2");

                string command = "S" + registerStr;
                Logger.Log(String.Format("Sending command '{0}'.", command));
                _serialPort.WriteLine(command);

                try
                {
                    string response = _serialPort.ReadLine();
                    Logger.Log(String.Format("Received response '{0}'.", response));

                    string[] fields = response.Split(' ');
                    if (fields.Length != 5)
                    {
                        throw new UnexpectedResponseException("The response was expected to have 5 single white spaces.", command, response);
                    }
                    else if (fields[0] != "s")
                    {
                        throw new UnexpectedResponseException("The first field in the respnose was expected to be 's'.", command, response);
                    }
                    else if (fields[1] != registerStr)
                    {
                        throw new UnexpectedResponseException("The second field in the response was expected to be '" + registerStr + "'.", command, response);
                    }
                    else if (fields[2].Length != 8)
                    {
                        throw new UnexpectedResponseException("The third field in the response was expected to be 8 bytes.", command, response);
                    }
                    else if (fields[3].Length != 8)
                    {
                        throw new UnexpectedResponseException("The fourth field in the response was expected to be 8 bytes.", command, response);
                    }
                    else if (fields[4] != "!")
                    {
                        throw new UnexpectedResponseException("The fifth field in the response was expected to be '!'.", command, response);
                    }
                }
                catch (TimeoutException e)
                {
                    throw new TimeoutException("The device didn't respond to command '" + command + "'.", e);
                }
            }
        }

        public void Disconnect()
        {
            lock (_serialPortLock)
            {
                lock (_connectionStatusLock)
                {
                    _connected = false;
                }

                try
                {
                    if (_serialPort != null && _serialPort.IsOpen)
                    {
                        Logger.Log(String.Format("Disconnecting from {0}.", _portName));
                        _serialPort.Close();
                        Logger.Log(String.Format("Disconnected from {0}.", _portName));
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log(ex.ToString());
                }

                _serialPort = null;
            }
        }

        public bool IsConnected
        {
            get
            {
                return _connected;
            }
        }

        public uint SerialNumber
        {
            get
            {
                lock (_statusLock)
                {
                    return _serialNumber;
                }
            }
        }

        public uint FirmwareVersion
        {
            get
            {
                lock (_statusLock)
                {
                    return _firmwareVersion;
                }
            }
        }

        public string ProductType
        {
            get
            {
                lock (_statusLock)
                {
                    return _productType;
                }
            }
        }

        /// <summary>
        /// This method is supposed to be called as a separate thread. It is an infinite
        /// loop and exits after <see cref="Disconnect()"/> is called.
        /// </summary>
        private void EncoderCountReaderLoop()
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            try
            {
                Logger.Log("Started EncoderCountReaderLoop.");

                while (true)
                {
                    string response;

                    lock (_serialPortLock)
                    {
                        // The serial port was disconnected. Terminate this thread.
                        if (_serialPort == null || !_serialPort.IsOpen)
                        {
                            Logger.Log("Terminating EncoderCountReaderLoop.");
                            return;
                        }

                        response = _serialPort.ReadLine();
                    }

                    int encoderCount;
                    int encoderZeroPositionCount;
                    uint timestamp;

                    ParseEncoderCountStreamResponse(response, out encoderCount, out timestamp);

                    lock (_encoderCountLock)
                    {
                        _encoderCount = encoderCount;
                        encoderZeroPositionCount = _encoderZeroPositionCount;
                    }

                    long encoderOffsetCount = (long)encoderCount - (long)encoderZeroPositionCount;
                    decimal position_mm = encoderOffsetCount * _encoderResolution_nm * (decimal)1e-6;

                    lock (_recorderLock)
                    {
                        if (IsRecording)
                        {
                            if (_recorderNumOfLine == 0)
                            {
                                _recorderFirstTimestamp = timestamp;
                                Logger.Log("First timestamp of this recording session: " + timestamp);
                            }

                            long relativeTimestamp = (long)timestamp - _recorderFirstTimestamp;
                            decimal relativeTimestamp_ms = relativeTimestamp * (decimal)(1000.0 / 512.0);

                            _recorder.WriteLine(
                                String.Format("{0}, {1}, {2}",
                                relativeTimestamp_ms.ToString("0.000000"),
                                encoderCount,
                                position_mm.ToString("0.00000000")
                                ));

                            _recorderNumOfLine++;
                        }
                    }

                    lock (_statisticsLock)
                    {
                        if (IsStatisticsOngoing)
                        {
                            // TODO: update the statistics
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Terminate this thread when it encouters an exception.
                Logger.Log(ex.ToString());
                Logger.Log("Terminating EncoderCountReaderLoop because of the exception above.");
                Disconnect();
                return;
            }
        }

        private void ParseEncoderCountStreamResponse(string response, out int count, out uint timestamp)
        {
            string[] fields = response.Split(' ');
            if (fields.Length != 5)
            {
                throw new UnexpectedResponseException("The stream response was expected to have 5 single white spaces.", response);
            }
            else if (fields[0] != "s")
            {
                throw new UnexpectedResponseException("The first field in the stream respnose was expected to be 's'.", response);
            }
            else if (fields[1] != "0E")
            {
                throw new UnexpectedResponseException("The second field in the stream response was expected to be '0E'.", response);
            }
            else if (fields[2].Length != 8)
            {
                throw new UnexpectedResponseException("The third field in the stream response was expected to be 8 bytes.", response);
            }
            else if (fields[3].Length != 8)
            {
                throw new UnexpectedResponseException("The fourth field in the stream response was expected to be 8 bytes.", response);
            }
            else if (fields[4] != "!")
            {
                throw new UnexpectedResponseException("The fifth field in the stream response was expected to be '!'.", response);
            }

            try
            {
                count = int.Parse(fields[2], System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception e)
            {
                throw new UnexpectedResponseException("The third field in the stream respnose was expected to be an 8-digit hex.", response, e);
            }

            try
            {
                timestamp = uint.Parse(fields[3], System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception e)
            {
                throw new UnexpectedResponseException("The fourth field in the stream respnose was expected to be an 8-digit hex.", response, e);
            }
        }

        /// <summary>
        /// Get the current position in millimeters.
        /// </summary>
        /// <returns>Current position in millimeters</returns>
        public decimal GetPositionInMillimeters()
        {
            int encoderCount;
            int encoderZeroPositionCount;

            lock (_encoderCountLock)
            {
                encoderCount = _encoderCount;
                encoderZeroPositionCount = _encoderZeroPositionCount;
            }

            long encoderOffsetCount = (long)encoderCount - (long)encoderZeroPositionCount;
            return encoderOffsetCount * _encoderResolution_nm * (decimal)1e-6;
        }

        public Tuple<ulong, decimal, decimal, decimal, decimal> GetStatistics()
        {
            ulong numberOfSamples = 0;
            decimal duration_s = 0.0M;
            decimal average_mm = 0.0M;
            decimal maximum_mm = 0.0M;
            decimal minimum_mm = 0.0M;

            lock (_statisticsLock)
            {
                numberOfSamples = _statisticsNumberOfSamples;
                average_mm = _statisticsAverage * _encoderResolution_nm * (decimal)1e-6;
                maximum_mm = _statisticsMaximum * _encoderResolution_nm * (decimal)1e-6;
                minimum_mm = _statisticsMinimum * _encoderResolution_nm * (decimal)1e-6;
            }

            duration_s = numberOfSamples / 512;

            return Tuple.Create(numberOfSamples, duration_s, average_mm, maximum_mm, minimum_mm);
        }

        /// <summary>
        /// Set the current encoder count as the zero position.
        /// </summary>
        /// <returns>New encoder count of the zero position.</returns>
        public int Zero()
        {
            int newEncoderZeroPositionCount;

            Logger.Log("Setting a new encoder zero position.");

            lock (_encoderCountLock)
            {
                newEncoderZeroPositionCount = _encoderCount;
                _encoderZeroPositionCount = newEncoderZeroPositionCount;
            }

            Logger.Log("New encoder zero position count: " + newEncoderZeroPositionCount);

            // TODO: restart the statistics

            return newEncoderZeroPositionCount;
        }

        public void StartRecording(String fileName)
        {
            try
            {
                lock (_recorderLock)
                {
                    if (_recorder != null)
                    {
                        throw new InvalidOperationException("Recording is in progress.");
                    }

                    Logger.Log("Starting recording in " + fileName);

                    _recorder = new StreamWriter(fileName);
                    _recorderNumOfLine = 0;

                    // Write a header.
                    _recorder.WriteLine("Timestamp [ms], Raw Count, Position [mm]");

                    Logger.Log("Started recording in " + fileName);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw ex;
            }
        }

        public void StopRecording()
        {
            lock (_recorderLock)
            {
                try
                {
                    Logger.Log("Terminating the recording.");
                    _recorder.Close();
                    Logger.Log("Terminated the recording.");
                }
                catch (Exception ex)
                {
                    Logger.Log(ex.ToString());
                }

                _recorder = null;
            }
        }

        public bool IsRecording
        {
            get
            {
                lock (_recorderLock)
                {
                    return _recorder != null;
                }
            }
        }

        public void StartStatistics()
        {
            lock (_statisticsLock)
            {
                _statisticsNumberOfSamples = 0;
                _statisticsAverage = 0.0M;
                _statisticsMinimum = 0.0M;
                _statisticsMaximum = 0.0M;
                _statisticsOngoing = true;
            }
        }

        public void StopStatistics()
        {
            lock (_statisticsLock)
            {
                _statisticsOngoing = false;
            }
        }

        private bool IsStatisticsOngoing
        {
            get
            {
                lock (_statisticsLock)
                {
                    return _statisticsOngoing;
                }
            }
        }
    }

    [Serializable]
    public enum QuadratureMode
    {
        X1,
        X2,
        X4,
    }

    [Serializable]
    public enum EncoderDirection
    {
        CountUp,
        CountDown,
    }

    public class InvalidConnectionSettingException : Exception
    {
        public InvalidConnectionSettingException(string message)
            : base(message)
        {
        }
    }
    public class UnexpectedResponseException : Exception
    {
        public UnexpectedResponseException(string message)
            : base(message)
        {
        }

        public UnexpectedResponseException(string message, string response)
            : base(message + " (Response: " + response + ")")
        {
        }

        public UnexpectedResponseException(string message, string response, Exception innerException)
            : base(message + " (Response: " + response + ")", innerException)
        {
        }

        public UnexpectedResponseException(string message, string command, string response)
            : base(message + " (Command: " + command + ", response: " + response + ")")
        {
        }

        public UnexpectedResponseException(string message, string command, string response, Exception innerException)
            : base(message + " (Command: " + command + ", response: " + response + ")", innerException)
        {
        }
    }
}
