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
        private Recorder _recorder;

        private uint _acceptableInvalidMessagesInARow = 0;
        private uint _invalidMessagesInARow = 0;

        /// <summary>
        /// This class handles RS-232 communication with an QSB-D.
        /// 
        /// The command and response format is explained in QSB Command List
        /// (Document Version 1.28, 5/5/2021):
        /// https://www.usdigital.com/media/gwqpsnym/qsb-commands-list.pdf
        /// </summary>
        public DeviceController(
            IConnectionStatusListener connectionStateListener,
            IEncoderCountListener encoderCountListener,
            IRecorderStatusListener recorderListener)
        {
            _connectionStateListener = connectionStateListener;
            _qsb = new Qsb(connectionStateListener);
            _processor = new EncoderCountProcessor(encoderCountListener);
            _recorder = new Recorder(recorderListener);
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
            ulong numberOfSamplesToStopStatistics,
            ulong listenerTriggerInterval,
            uint acceptableInvalidMessagesInARow)
        {
            _acceptableInvalidMessagesInARow = acceptableInvalidMessagesInARow;
            _invalidMessagesInARow = 0;

            _qsb.Connect(portName, baudRate, quadratureMode, encoderDirection, acceptableInvalidMessagesInARow);
            _processor.Reset(
                encoderZeroPositionCount,
                encoderResolution_nm,
                numberOfSamplesToStopStatistics,
                listenerTriggerInterval);

            Thread encoderCountReaderThread = new Thread(new ThreadStart(EncoderCountReaderLoop));
            encoderCountReaderThread.Start();
        }

        public void Disconnect()
        {
            _processor.StopStatistics();
            _recorder.Stop();
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

                    try
                    {
                        _qsb.ReadEncoderCount(out encoderCount, out timestamp);
                        decimal position_mm = _processor.AddNewSample(encoderCount);
                        _recorder.AddNewSample(encoderCount, timestamp, position_mm);

                        _invalidMessagesInARow = 0;
                    }
                    catch (UnexpectedResponseException ure)
                    {
                        _invalidMessagesInARow += 1;
                        if (_invalidMessagesInARow > _acceptableInvalidMessagesInARow)
                        {
                            throw ure;
                        }

                        // TODO: notify the GUI of this exception
                    }
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

            return newZeroPositionCount;
        }

        public void StartStatistics(ulong numberOfSamplesToStop)
        {
            _processor.StartStatistics(numberOfSamplesToStop);
        }

        public void StopStatistics()
        {
            _processor.StopStatistics();
        }

        public void ResetStatistics()
        {
            _processor.ResetStatistics();
        }

        public void StartRecording(
            string outputDirectory,
            string filenameBase,
            uint recordingInterval,
            uint maxRecordsPerFile,
            ulong listenerTriggerInterval,
            uint serialNumber)
        {
            _recorder.Start(
                outputDirectory,
                filenameBase,
                recordingInterval,
                maxRecordsPerFile,
                listenerTriggerInterval,
                serialNumber);
        }

        public void StopRecording()
        {
            _recorder.Stop();
        }
    }
}
