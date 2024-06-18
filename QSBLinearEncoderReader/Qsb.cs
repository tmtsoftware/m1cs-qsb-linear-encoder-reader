using System;
using System.IO.Ports;
using static System.Windows.Forms.AxHost;

namespace QSBLinearEncoderReader
{
    internal class Qsb
    {
        private object _lock = new object();

        private ConnectionStatus _connectionStatus = new ConnectionStatus();
        private IConnectionStatusListener _connectionStatusListener = null;

        // The instance variables below are valid only when the 
        // _connectionState is ConnectionState.Connected.
        private SerialPort _serialPort = null;
        private ConnectionStatus _connectionInfo = new ConnectionStatus();

        // If this is not null, the device is simulated (= simulation mode).
        private QsbSimulator _simulator = null;

        /// <summary>
        /// This class represents a connection to one QSB device.
        /// This class is thread-safe. Public methods and members can
        /// be called or accessed from multiple threads.
        /// </summary>
        public Qsb(IConnectionStatusListener connectionStatusListener)
        {
            _connectionStatusListener = connectionStatusListener;
        }

        /// <summary>
        /// Connect to an QSB-D through a serial port and start the streaming mode.
        /// </summary>
        public void Connect(
            string portName,
            int baudRate,
            QuadratureMode quadratureMode,
            EncoderDirection encoderDirection)
        {
            // Check arguments.
            if (String.IsNullOrEmpty(portName))
            {
                throw new InvalidConnectionSettingException("Port name must not be null or empty.");
            }

            if (baudRate <= 0)
            {
                throw new InvalidConnectionSettingException("Baud rate must be positive.");
            }

            uint quadratureModeValue;
            switch (quadratureMode)
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
                    throw new InvalidConnectionSettingException("Unexpected quadrature mode: " + quadratureMode);
            }

            uint encoderDirectionValue;
            switch (encoderDirection)
            {
                case EncoderDirection.CountUp:
                    encoderDirectionValue = 0x00;
                    break;
                case EncoderDirection.CountDown:
                    encoderDirectionValue = 0x80;
                    break;
                default:
                    throw new InvalidConnectionSettingException("Unexpected encoder encoderDirection: " + encoderDirection);
            }

            lock (_lock)
            {
                if (_connectionStatus.ConnectionState != ConnectionState.Disconnected)
                {
                    throw new InvalidConnectionStateException(
                        _connectionStatus.ConnectionState,
                        "New connection can be made only when the connection state is \"Disconnected\".");
                }

                UpdateConnectionStatus(new ConnectionStatus(ConnectionState.Connecting));

                try
                {
                    Logger.Log(String.Format("Connecting to {0}. (Baud rate: {1})", portName, baudRate));

                    if (portName == "Simulated Device")
                    {
                        // Simulation mode.
                        Logger.Log("Starting the simulation mode.");
                        _simulator = new QsbSimulator();
                        _simulator.Connect();
                        UpdateConnectionStatus(new ConnectionStatus(
                                ConnectionState.Connected,
                                portName,
                                baudRate,
                                quadratureMode,
                                encoderDirection));
                        Logger.Log("Started the simulation mode.");
                        return;
                    }
                    else
                    {
                        _serialPort = new SerialPort();
                        _serialPort.PortName = portName;
                        _serialPort.BaudRate = baudRate;
                        _serialPort.Parity = Parity.None;
                        _serialPort.DataBits = 8;
                        _serialPort.StopBits = StopBits.One;
                        _serialPort.Handshake = Handshake.None;
                        _serialPort.RtsEnable = true;
                        _serialPort.NewLine = "\r\n";

                        _serialPort.ReadTimeout = 1000;
                        _serialPort.WriteTimeout = 1000;

                        _serialPort.Open();
                        Logger.Log(String.Format("Connected to {0}.", portName));

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
                        ConnectionStatus intermediateConnectionStatus =
                            new ConnectionStatus(
                                ConnectionState.Connecting,
                                portName,
                                baudRate,
                                quadratureMode,
                                encoderDirection,
                                versionResponse);
                        Logger.Log(
                            String.Format("Product Type: {0}, Serial Number: {1}, Firmware Version: {2}",
                            intermediateConnectionStatus.ProductType,
                            intermediateConnectionStatus.SerialNumber,
                            intermediateConnectionStatus.FirmwareVersion));

                        // Set quadratue mode (x1, x2 or x4).
                        WriteCommand(0x03, quadratureModeValue);

                        // Set encoder direction.
                        WriteCommand(0x04, encoderDirectionValue);

                        // Set the threshold to 0 meaning that the encoder count will be reported regardless of the count difference from the previous one.
                        WriteCommand(0x0B, 0x00000000);

                        // Set the output interval to 1/512 x 1 Hz (1.953125 ms)
                        WriteCommand(0x0C, 0x00000001);

                        // Reset the 32-bit timestamp register to minimize the chance of rollover (every 94.5 days).
                        WriteCommand(0x0D, 0x00000001);

                        // Start streaming the encoder count at the specified interval.
                        StreamCommand(0x0E);

                        ConnectionStatus finalConnectionStatus =
                            new ConnectionStatus(
                                ConnectionState.Connected,
                                portName,
                                baudRate,
                                quadratureMode,
                                encoderDirection,
                                versionResponse);
                        UpdateConnectionStatus(finalConnectionStatus);
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

        public void Disconnect()
        {
            lock (_lock)
            {
                if (_connectionStatus.ConnectionState == ConnectionState.Disconnecting
                    || _connectionStatus.ConnectionState == ConnectionState.Disconnected)
                {
                    InvalidConnectionStateException ex = new InvalidConnectionStateException(
                        _connectionStatus.ConnectionState,
                        "No need to disconnect.");
                    Logger.Log(ex.ToString());
                    throw ex;
                }

                UpdateConnectionStatus(new ConnectionStatus(ConnectionState.Disconnecting));

                if (_simulator != null)
                {
                    // Simulation mode.
                    Logger.Log("Stopping the simulation mode.");
                    _simulator.Disconnect();
                    _simulator = null;
                    UpdateConnectionStatus(new ConnectionStatus(ConnectionState.Disconnected));
                    Logger.Log("Stopped the simulation mode.");
                }
                else
                {
                    string portName = _serialPort.PortName;
                    try
                    {
                        if (_serialPort.IsOpen)
                        {
                            Logger.Log(String.Format("Disconnecting from {0}.", portName));
                            _serialPort.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(ex.ToString());
                        throw ex;
                    }
                    finally
                    {
                        UpdateConnectionStatus(new ConnectionStatus(ConnectionState.Disconnected));
                        Logger.Log(String.Format("Disconnected from {0}.", portName));
                    }

                }
            }
        }

        public void ReadEncoderCount(out int encoderCount, out uint timestamp)
        {
            lock (_lock)
            {
                if (_connectionStatus.ConnectionState != ConnectionState.Connected)
                {
                    InvalidConnectionStateException ex = new InvalidConnectionStateException(
                        _connectionStatus.ConnectionState,
                        "ReadEncoderCount() can be called only when the connection state is \"Connected\".");
                    Logger.Log(ex.ToString());
                    throw ex;
                }

                if (_simulator != null)
                {
                    _simulator.ReadEncoderCount(out encoderCount, out timestamp);
                }
                else
                {
                    try
                    {
                        string response = _serialPort.ReadLine();
                        ParseEncoderCountStreamResponse(response, out encoderCount, out timestamp);
                    }
                    catch (TimeoutException e)
                    {
                        Logger.Log(e.ToString());
                        throw new TimeoutException("The device didn't have an encoder value in the stream buffer.", e);
                    }
                    catch (Exception e)
                    {
                        Logger.Log(e.ToString());
                        throw e;
                    }
                }
            }
        }

        private void WriteCommand(byte register, uint data)
        {
            lock (_lock)
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
                    throw new TimeoutException("The device didn't respond to command '" + command + "'.", e);
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
            lock (_lock)
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
            lock (_lock)
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

        private static void ParseEncoderCountStreamResponse(string response, out int encoderCount, out uint timestamp)
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
                encoderCount = int.Parse(fields[2], System.Globalization.NumberStyles.HexNumber);
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

        private void UpdateConnectionStatus(ConnectionStatus newStatus)
        {
            Logger.Log("Switching to \"" + newStatus.ConnectionState.ToString() + "\" state");
            _connectionStatus = newStatus;
            _connectionStatusListener.ConnectionStatusChanged(newStatus);
        }

        public ConnectionState ConnectionState { get { lock (_lock){ return _connectionStatus.ConnectionState; } } }
    }
}
