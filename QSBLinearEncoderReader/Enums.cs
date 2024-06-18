using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSBLinearEncoderReader
{
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

    public enum ConnectionState
    {
        Disconnected,
        Connecting,
        Connected,
        Disconnecting,
    }

    public enum StatisticsState
    {
        Ongoing,
        Stopped,
    }

    public enum RecorderState
    {
        Recording,
        Stopped,
        Error,
    }
}
