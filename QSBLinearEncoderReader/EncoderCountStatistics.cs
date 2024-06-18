using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSBLinearEncoderReader
{
    /// <summary>
    /// Immutable class that represents the statistics of the encoder
    /// count.
    /// </summary>
    public class EncoderCountStatistics
    {
        public EncoderCountStatistics() :
            this(StatisticsState.Stopped, 0, 0.0M, 0.0M, 0.0M, 0.0M)
        {
        }

        public EncoderCountStatistics(
            StatisticsState state,
            ulong numberOfSamples,
            decimal average_mm,
            decimal stdev_mm,
            decimal max_mm,
            decimal min_mm)
        {
            State = state;
            NumberOfSamples = numberOfSamples;
            DurationInSeconds = numberOfSamples / 512.0M;
            AverageInMillimeters = average_mm;
            StdevInMillimeters = stdev_mm;
            MaximumInMillimeters = max_mm;
            MinimumInMillimeters = min_mm;
        }

        public StatisticsState State { get; }
        public ulong NumberOfSamples { get; }
        public decimal DurationInSeconds { get;  }
        public decimal AverageInMillimeters { get; }
        public decimal StdevInMillimeters { get; }
        public decimal MaximumInMillimeters { get; }
        public decimal MinimumInMillimeters { get; }
    }
}
