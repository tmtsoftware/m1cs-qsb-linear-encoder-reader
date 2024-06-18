using System;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace QSBLinearEncoderReader
{
    internal class DeviceController
    {
        private IConnectionStatusListener _connectionStateListener;

        private Qsb _qsb;
        private ConnectionState _connectionState;
        private EncoderCountProcessor _processor;
        private EncoderCountStatistics _statistics;

        /// <summary>
        /// This class handles RS-232 communication with an QSB-D.
        /// 
        /// The command and response format is explained in QSB Command List
        /// (Document Version 1.28, 5/5/2021):
        /// https://www.usdigital.com/media/gwqpsnym/qsb-commands-list.pdf
        /// </summary>
        public DeviceController(
            IConnectionStatusListener connectionStateListener,
            IStatisticsStateListener statisticsStateListener)
        {
            _connectionStateListener = connectionStateListener;
            _qsb = new Qsb(connectionStateListener);
            _processor = new EncoderCountProcessor();
            _statistics = new EncoderCountStatistics(statisticsStateListener);
        }

        /// <summary>
        /// Connect to an QSB-D through a serial port and start getting the encoder count.
        /// </summary>
        public void Connect(
            string portName,
            int baudRate,
            QuadratureMode quadratureMode,
            EncoderDirection encoderDirection,
            int encoderZeroPositionCount,
            decimal encoderResolution_nm,
            ulong numberOfSamplesToStopStatistics)
        {
            _qsb.Connect(portName, baudRate, quadratureMode, encoderDirection);
            _processor.Reset(encoderZeroPositionCount, encoderResolution_nm);
            _statistics.Start(encoderZeroPositionCount, encoderResolution_nm, numberOfSamplesToStopStatistics);

            Thread encoderCountReaderThread = new Thread(new ThreadStart(EncoderCountReaderLoop));
            encoderCountReaderThread.Start();
        }

        public void Disconnect()
        {
            _statistics.Stop();
            _qsb.Disconnect();
        }

        /// <summary>
        /// This method is supposed to be called as a separate thread. It is an infinite
        /// loop until disconnected.
        /// </summary>
        private void EncoderCountReaderLoop()
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            try
            {
                Logger.Log("Started EncoderCountReaderLoop.");

                while (_qsb.ConnectionState == ConnectionState.Connected)
                {
                    int encoderCount;
                    uint timestamp;

                    _qsb.ReadEncoderCount(out encoderCount, out timestamp);
                    _processor.AddNewSample(encoderCount);
                    _statistics.AddNewSample(encoderCount);
                }
            }
            catch (Exception ex)
            {
                // Terminate this thread when it encouters an exception.
                Logger.Log(ex.ToString());
                Logger.Log("Terminating EncoderCountReaderLoop because of the exception above.");
                Disconnect();
                return;
            }
        }

        /// <summary>
        /// Set the current encoder count as the zero position.
        /// </summary>
        /// <returns>New encoder count of the zero position.</returns>
        public int Zero()
        {
            int newZeroPositionCount = _processor.Zero();
            _statistics.Reset(newZeroPositionCount);

            return newZeroPositionCount;
        }

        public void StartStatistics(ulong numberOfSamplesToStop)
        {
            _statistics.Start(
                _processor.ZeroPositionCount,
                _processor.ResolutionInNanometers,
                numberOfSamplesToStop);
        }

        public void StopStatistics()
        {
            _statistics.Stop();
        }

        public void ResetStatistics()
        {
            _statistics.Reset();
        }
    }
}
