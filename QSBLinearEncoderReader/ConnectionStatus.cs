using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSBLinearEncoderReader
{
    /// <summary>
    /// Immutable class that represents the connection status (conneciton state,
    /// connection configuration, serial number, firmware version, product type)
    /// of a QSB device.
    /// </summary>
    public class ConnectionStatus
    {
        public ConnectionStatus() : this(ConnectionState.Disconnected)
        {
        }

        public ConnectionStatus(ConnectionState connectionState) :
            this(connectionState, "", 0, QuadratureMode.X1, EncoderDirection.CountUp)
        {
        }

        public ConnectionStatus(
            ConnectionState connectionState,
            string portName,
            int baudRate,
            QuadratureMode quadratureMode,
            EncoderDirection encoderDirection)
        {
            ConnectionState = connectionState;
            PortName = portName;
            BaudRate = baudRate;
            QuadratureMode = quadratureMode;
            EncoderDirection = encoderDirection;
            SerialNumber = 0;
            ProductType = "QSB-D";
            FirmwareVersion = 0;
        }

        public ConnectionStatus(
            ConnectionState connectionState,
            string portName,
            int baudRate,
            QuadratureMode quadratureMode,
            EncoderDirection encoderDirection,
            uint versionResponse)
        {
            ConnectionState = connectionState;
            PortName = portName;
            BaudRate = baudRate;
            QuadratureMode = quadratureMode;
            EncoderDirection = encoderDirection;

            SerialNumber = (versionResponse & 0xFFFFF000) >> 12;
            uint productTypeCode = (versionResponse & 0x00000F00) >> 8;
            FirmwareVersion = versionResponse & 0x000000FF;

            switch (productTypeCode)
            {
                case 0:
                    ProductType = "QSB-D";
                    break;
                case 1:
                    ProductType = "QSB-M";
                    break;
                case 2:
                    ProductType = "QSB-S";
                    break;
                default:
                    ProductType = "Unknown";
                    break;
            }
        }

        public ConnectionState ConnectionState { get; }
        public string PortName { get; }
        public int BaudRate { get; }
        public QuadratureMode QuadratureMode { get;  }
        public EncoderDirection EncoderDirection { get; }
        public uint SerialNumber { get; }
        public uint FirmwareVersion { get; }
        public string ProductType { get; }
    }
}
