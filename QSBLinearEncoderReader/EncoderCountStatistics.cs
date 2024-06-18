using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSBLinearEncoderReader
{
    internal class EncoderCountStatistics
    {
        private object _lock = new object();

        private StatisticsState _state = StatisticsState.Stopped;
        private IStatisticsStateListener _listener;

        decimal _resolution_nm;
        int _zeroPositionCount;

        public const ulong Indefinite = 0;

        private ulong _numberOfSamplesToStop = Indefinite;
        private ulong _numberOfSamples = 0;
        private decimal _sum = 0.0M;
        private decimal _squareSum = 0.0M;
        private decimal _minimum = 0.0M;
        private decimal _maximum = 0.0M;

        public EncoderCountStatistics(IStatisticsStateListener listener)
        {
            _listener = listener;
        }

        public void Start(int zeroPositionCount, decimal resolution_nm, ulong numberOfSamplesToStop)
        {
            Logger.Log("Start statistics");

            lock (_lock)
            {
                _zeroPositionCount = zeroPositionCount;
                _resolution_nm = resolution_nm;
                _numberOfSamplesToStop = numberOfSamplesToStop;
                _numberOfSamples = 0;
                _sum = 0.0M;       // in raw encoder count
                _squareSum = 0.0M; // in raw encoder count
                _minimum = 0.0M;   // in raw encoder count
                _maximum = 0.0M;   // in raw encoder count

                UpdateState(StatisticsState.Ongoing);
            }
        }

        public void Stop()
        {
            Logger.Log("Stop statistics");

            lock (_lock)
            {
                UpdateState(StatisticsState.Stopped);
            }
        }

        public void Reset()
        {
            Reset(_zeroPositionCount);
        }

        public void Reset(int zeroPositionCount)
        {
            Logger.Log("Reset statistics");

            lock (_lock)
            {
                _zeroPositionCount = zeroPositionCount;
                _numberOfSamples = 0;
                _sum = 0.0M;       // in raw encoder count
                _squareSum = 0.0M; // in raw encoder count
                _minimum = 0.0M;   // in raw encoder count
                _maximum = 0.0M;   // in raw encoder count
            }
        }

        private void UpdateState(StatisticsState newState)
        {
            _state = newState;
            _listener.StatisticsStateChanged(newState);
        }

        public void AddNewSample(int encoderCount)
        {
            lock (_lock)
            {
                if (_state == StatisticsState.Stopped)
                {
                    return;
                }

                _numberOfSamples += 1;
                _sum += encoderCount;
                _squareSum += (decimal)encoderCount * (decimal)encoderCount;
                if (_numberOfSamples == 1)
                {
                    _minimum = encoderCount;
                    _maximum = encoderCount;
                }
                else
                {
                    if (encoderCount > _maximum)
                    {
                        _maximum = encoderCount;
                    }

                    if (encoderCount < _minimum)
                    {
                        _minimum = encoderCount;
                    }
                }

                if (_numberOfSamplesToStop != Indefinite && _numberOfSamples >= _numberOfSamplesToStop)
                {
                    Stop();
                }
            }
        }

        public void GetAll(
            out ulong numberOfSamples,
            out decimal duration_s,
            out decimal average_mm,
            out decimal stdev_mm,
            out decimal maximum_mm,
            out decimal minimum_mm,
            out decimal p2p_mm)
        {
            lock (_lock)
            {
                numberOfSamples = _numberOfSamples;
                duration_s = numberOfSamples / 512M;

                if (numberOfSamples == 0)
                {
                    average_mm = 0.0M;
                    stdev_mm = 0.0M;
                    maximum_mm = 0.0M;
                    minimum_mm = 0.0M;
                    p2p_mm = 0.0M;
                }
                else
                {
                    decimal average_count = _sum / _numberOfSamples;
                    decimal stdev_count = (decimal)Math.Sqrt(decimal.ToDouble(_squareSum / _numberOfSamples - average_count * average_count));

                    average_mm = (average_count - _zeroPositionCount) * _resolution_nm * 1e-6M;
                    stdev_mm = stdev_count * _resolution_nm * 1e-6M;
                    maximum_mm = _maximum * _resolution_nm * 1e-6M;
                    minimum_mm = _minimum * _resolution_nm * 1e-6M;
                    p2p_mm = maximum_mm - minimum_mm;
                }
            }
        }

        public StatisticsState CurrentState { get { lock(_lock) { return _state; } } }
    }
}
