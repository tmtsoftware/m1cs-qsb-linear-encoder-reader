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
    internal class QsbInfo
    {
        public QsbInfo()
        {
            SerialNumber = 0;
            FirmwareVersion = 0;
            ProductType = "Unknown";
        }

        public QsbInfo(uint versionResponse)
        {
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

        public uint SerialNumber { get; }
        public uint FirmwareVersion { get; }
        public string ProductType { get; }
    }
}
