using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QSBLinearEncoderReader
{
    internal class EncoderCountProcessor
    {
        private object _lock = new object();

        private IEncoderCountListener _listener;

        private decimal _resolution_nm;
        private int _zeroPositionCount;
        private int _currentCount;
        private ulong _totalNumberOfSamples;
        private ulong _listenerTriggerInterval;

        public const ulong Indefinite = 0;
        private ulong _statisticsNumberOfSamplesToStop;

        private StatisticsState _statisticsState;
        private ulong _statisticsNumberOfSamples;
        private decimal _statisticsSum;
        private decimal _statisticsSquareSum;
        private int _statisticsMax;
        private int _statisticsMin;

        /// <summary>
        /// This class converts a raw encoder value to a physical unit in mm.
        /// This class is thread-safe. Public methods and members can
        /// be called or accessed from multiple threads.
        /// </summary>
        public EncoderCountProcessor(IEncoderCountListener listener)
        {
            _listener = listener;

            _zeroPositionCount = 0;
            _resolution_nm = 5.0M;
            _currentCount = 0;
            _totalNumberOfSamples = 0;
            _listenerTriggerInterval = 64;

            _statisticsState = StatisticsState.Stopped;
            _statisticsNumberOfSamplesToStop = Indefinite;
            _statisticsNumberOfSamples = 0;
            _statisticsSum = 0.0M;
            _statisticsSquareSum = 0.0M;
            _statisticsMax = 0;
            _statisticsMin = 0;
        }

        private void TriggerListener()
        {
            lock (_lock)
            {
                decimal average_mm;
                decimal stdev_mm;
                decimal max_mm;
                decimal min_mm;

                if (_statisticsNumberOfSamples == 0)
                {
                    average_mm = 0.0M;
                    stdev_mm = 0.0M;
                    max_mm = 0.0M;
                    min_mm = 0.0M;
                }
                else
                {
                    decimal average_count = _statisticsSum / _statisticsNumberOfSamples;
                    decimal stdev_count = (decimal)Math.Sqrt(decimal.ToDouble(_statisticsSquareSum / _statisticsNumberOfSamples - average_count * average_count));
                    average_mm = (average_count - _zeroPositionCount) * _resolution_nm * 1e-6M;
                    stdev_mm = stdev_count * _resolution_nm * 1e-6M;
                    max_mm = (_statisticsMax - _zeroPositionCount) * _resolution_nm * 1e-6M;
                    min_mm = (_statisticsMin - _zeroPositionCount) * _resolution_nm * 1e-6M;
                }


                EncoderCount cnt = new EncoderCount(
                    _currentCount,
                    _zeroPositionCount,
                    _resolution_nm,
                    new EncoderCountStatistics(
                        _statisticsState,
                        _statisticsNumberOfSamples,
                        average_mm,
                        stdev_mm,
                        max_mm,
                        min_mm));
                _listener.EncoderCountChanged(cnt);
            }
        }

        public void Reset(
            int zeroPositionCount,
            decimal resolution_nm,
            ulong statisticsNumberOfSamplesToStop,
            ulong listenerTriggerInterval)
        {
            lock (_lock)
            {
                _zeroPositionCount = zeroPositionCount;
                _resolution_nm = resolution_nm;
                _currentCount = 0;
                _totalNumberOfSamples = 0;
                _listenerTriggerInterval = listenerTriggerInterval;

                _statisticsState = StatisticsState.Ongoing;
                _statisticsNumberOfSamplesToStop = statisticsNumberOfSamplesToStop;
                _statisticsNumberOfSamples = 0;
                _statisticsSum = 0.0M;
                _statisticsSquareSum = 0.0M;
                _statisticsMax = 0;
                _statisticsMin = 0;
                TriggerListener();
            }
        }

        /// <summary>
        /// Set the given sample as the current encoder count.
        /// Returns the current position in mm;
        /// </summary>
        public decimal AddNewSample(int encoderCount)
        {
            bool triggerListener = false;

            lock (_lock)
            {
                _currentCount = encoderCount;
                _totalNumberOfSamples += 1;
                if (_totalNumberOfSamples % _listenerTriggerInterval == 0)
                {
                    triggerListener = true;
                }

                if (_statisticsState == StatisticsState.Ongoing)
                {
                    _statisticsNumberOfSamples += 1;
                    _statisticsSum += encoderCount;
                    _statisticsSquareSum += (decimal)encoderCount * (decimal)encoderCount;
                    if (_statisticsNumberOfSamples == 1)
                    {
                        _statisticsMax = encoderCount;
                        _statisticsMin = encoderCount;
                    }
                    else
                    {
                        if (encoderCount > _statisticsMax)
                        {
                            _statisticsMax = encoderCount;
                        }
                        if (encoderCount < _statisticsMin)
                        {
                            _statisticsMin = encoderCount;
                        }
                    }

                    if (_statisticsNumberOfSamplesToStop != Indefinite &&
                        _statisticsNumberOfSamples >= _statisticsNumberOfSamplesToStop)
                    {
                        Logger.Log("Automatically stopped statistics.");
                        _statisticsState = StatisticsState.Stopped;
                        triggerListener = true;
                    }
                }

                if (triggerListener)
                {
                    TriggerListener();
                }

                return (_currentCount - _zeroPositionCount) * _resolution_nm * 1e-6M;
            }
        }

        public void StartStatistics(ulong statisticsNumberOfSamplesToStop)
        {
            Logger.Log("Start statistics");

            lock (_lock)
            {
                if (_statisticsState == StatisticsState.Stopped)
                {
                    _statisticsState = StatisticsState.Ongoing;
                    _statisticsNumberOfSamplesToStop = statisticsNumberOfSamplesToStop;
                    _statisticsNumberOfSamples = 0;
                    _statisticsSum = 0.0M;
                    _statisticsSquareSum = 0.0M;
                    _statisticsMax = 0;
                    _statisticsMin = 0;
                    TriggerListener();
                }
            }
        }

        public void StopStatistics()
        {
            Logger.Log("Stop statistics");

            lock (_lock)
            {
                if (_statisticsState == StatisticsState.Ongoing)
                {
                    _statisticsState = StatisticsState.Stopped;
                    TriggerListener();
                }
            }
        }

        public void ResetStatistics()
        {
            Logger.Log("Reset statistics");

            lock (_lock)
            {
                _statisticsNumberOfSamples = 0;
                _statisticsSum = 0.0M;
                _statisticsSquareSum = 0.0M;
                _statisticsMax = 0;
                _statisticsMin = 0;
                TriggerListener();
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

                ResetStatistics();

                return _zeroPositionCount;
            }
        }
    }
}
