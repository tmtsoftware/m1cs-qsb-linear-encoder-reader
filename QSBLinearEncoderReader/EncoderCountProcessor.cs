using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSBLinearEncoderReader
{
    internal class EncoderCountProcessor
    {
        private object _lock = new object();

        decimal _resolution_nm;
        int _zeroPositionCount;
        int _currentCount;

        /// <summary>
        /// This class converts a raw encoder value to a physical unit in mm.
        /// This class is thread-safe. Public methods and members can
        /// be called or accessed from multiple threads.
        /// </summary>
        public EncoderCountProcessor()
        {
            _zeroPositionCount = 0;
            _resolution_nm = 5.0M;
            _currentCount = 0;
        }

        public void Reset(int zeroPositionCount, decimal resolution_nm)
        {
            _zeroPositionCount = zeroPositionCount;
            _resolution_nm = resolution_nm;
            _currentCount = 0;
        }

        /// <summary>
        /// Set the given sample as the current encoder count.
        /// </summary>
        public void AddNewSample(int count)
        {
            lock (_lock)
            {
                _currentCount = count;
            }
        }

        /// <summary>
        /// Set the current encoder count as the zero position.
        /// </summary>
        /// <returns>New encoder count of the zero position.</returns>
        public int Zero()
        {
            Logger.Log("Setting a new encoder zero position.");

            lock (_lock)
            {
                _zeroPositionCount = _currentCount;

                Logger.Log("New encoder zero position count: " + _zeroPositionCount);

                return _zeroPositionCount;
            }
        }

        public int ZeroPositionCount { get { lock (_lock) { return _zeroPositionCount; } } }
        public decimal ResolutionInNanometers { get { lock (_lock) { return _resolution_nm; } } }
        public decimal CurrentPositionInMillimeters {
            get
            {
                lock (_lock)
                {
                    long offsetCount = (long)_currentCount - (long)_zeroPositionCount;
                    return offsetCount * _resolution_nm * 1e-6M;
                }
            }
        }
    }
}
