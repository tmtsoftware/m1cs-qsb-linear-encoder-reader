using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSBLinearEncoderReader
{
    /// <summary>
    /// Immutable class that represents the current encoder count with 
    /// auxiliary information.
    /// </summary>
    internal class EncoderCount
    {
        public EncoderCount(
            int rawCount,
            int zeroPositionCount,
            decimal resolution_nm,
            EncoderCountStatistics statistics)
        {
            RawCount = rawCount;
            ZeroPositionCount = zeroPositionCount;
            ResolutionInNanometers = resolution_nm;
            PositionInMillimeters = (rawCount - zeroPositionCount) * resolution_nm * 1e-6M;
            Statistics = statistics;
        }

        public int RawCount { get; }
        public decimal PositionInMillimeters { get; }
        public decimal ResolutionInNanometers { get; }

        public int ZeroPositionCount { get; }

        public EncoderCountStatistics Statistics { get; }

    }
}
