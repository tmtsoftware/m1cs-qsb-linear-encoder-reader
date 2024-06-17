using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSBLinearEncoderReader
{
    /// <summary>
    /// Immutable class that represents the information (serial number, firmware version
    /// and product type) of a QSB device.
    /// </summary>
    internal class ConnectionInfo
    {
        public ConnectionInfo()
        {
            PortName = "";
            BaudRate = 0;
            QuadratureMode = QuadratureMode.X1;
            EncoderDirection = EncoderDirection.CountUp;
            SerialNumber = 0;
            FirmwareVersion = 0;
            ProductType = "Unknown";
        }

        public ConnectionInfo(
            string portName,
            int baudRate,
            QuadratureMode quadratureMode,
            EncoderDirection encoderDirection,
            uint versionResponse)
        {
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

        public string PortName { get; }
        public int BaudRate { get; }
        public QuadratureMode QuadratureMode { get;  }
        public EncoderDirection EncoderDirection { get; }
        public uint SerialNumber { get; }
        public uint FirmwareVersion { get; }
        public string ProductType { get; }
    }
}
