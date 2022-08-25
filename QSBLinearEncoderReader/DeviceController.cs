using System;
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
        private object _lockSerialPort = new object();

        public DeviceController(
            string portName,
            int baudRate,
            QuadratureMode quadratureMode,
            EncoderDirection encoderDirection)
        {
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

            _serialPort = null;
        }

        /// <summary>
        /// Connect to an QSB-D through a serial port and start getting the encoder count in the streaming mode.
        /// </summary>
        public void Connect()
        {
            lock (_lockSerialPort)
            {
                if (_serialPort != null)
                {
                    throw new InvalidOperationException("Cannot reconnect using the same instance.");
                }

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
                    _serialPort.ReadLine();
                }
                catch (TimeoutException e)
                {
                    // ignore
                }
                catch (Exception e)
                {
                    Disconnect();
                    throw e;
                }

                try
                {
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
                    //    (26 bytes in totla)
                    //
                    WriteCommand(0x15, 0x0000000F);

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

                    // Start streaming the encoder count at the specified interval.
                    StreamCommand(0x0E);

                    Thread readEncoderCountLoopThread = new Thread(new ThreadStart(ReadEncoderCountLoop));
                    readEncoderCountLoopThread.Start();
                }
                catch (Exception e)
                {
                    Disconnect();
                    throw e;
                }
            }
        }

        private void WriteCommand(byte register, uint data)
        {
            lock (_lockSerialPort)
            {
                string registerStr = register.ToString("X2");
                string dataStr = data.ToString("X8");

                string command = "W" + registerStr + dataStr;
                _serialPort.WriteLine(command);

                try
                {
                    string response = _serialPort.ReadLine();
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

        private void StreamCommand(byte register)
        {
            lock (_lockSerialPort)
            {
                string registerStr = register.ToString("X2");

                string command = "S" + registerStr;
                _serialPort.WriteLine(command);

                try
                {
                    string response = _serialPort.ReadLine();
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
            lock (_lockSerialPort)
            {
                try
                {
                    if (_serialPort != null)
                    {
                        _serialPort.Close();
                    }
                }
                catch (Exception e)
                {
                    // Ignore any exception. Just try to close the connection.
                }

                _serialPort = null;
            }
        }

        /// <summary>
        /// This method is supposed to be called as a separate thread. It is an infinite
        /// loop and exits after <see cref="Disconnect()"/> is called.
        /// </summary>
        private void ReadEncoderCountLoop()
        {
            // TODO: handle exception

            while (true)
            {
                string response;

                lock (_lockSerialPort)
                {
                    // The serial port was disconnected. Terminate this thread.
                    if (_serialPort == null)
                    {
                        return;
                    }

                    response = _serialPort.ReadLine();
                }

                int count;
                uint timestamp;

                ParseEncoderCountStreamResponse(response, out count, out timestamp);
                System.Diagnostics.Debug.WriteLine("Timestamp: " + timestamp + ", Count: " + count);
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
    }
}
