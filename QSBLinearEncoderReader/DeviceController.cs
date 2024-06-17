using System;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace QSBLinearEncoderReader
{
    /// <summary>
    /// This class handles RS-232 communication with an QSB-D.
    /// 
    /// The command and response format is explained in QSB Command List
    /// (Document Version 1.28, 5/5/2021):
    /// https://www.usdigital.com/media/gwqpsnym/qsb-commands-list.pdf
    /// </summary>
    internal class DeviceController
    {
        private Qsb _qsb;

        private int _encoderCount = 0;
        private int _encoderZeroPositionCount;
        private decimal _encoderResolution_nm;
        private object _encoderCountLock = new object();

        private StreamWriter _recorder;
        private long _recorderTotalNumOfRecords = 0;
        private uint _recorderFirstTimestamp = 0;
        private string _recorderOutputDir;
        private string _recorderFilenameBase;
        private string _recorderCurrentFilePath;
        private long _recorderNumOfRecordsForFile = 0;
        private int _recorderRecordingInterval = 1;
        private int _recorderMaxRecordsPerFile = 1024;
        private object _recorderLock = new object();

        private bool _statisticsOngoing = false;
        private ulong _statisticsStopCount = 0; // 0 means indefinite
        private ulong _statisticsNumberOfSamples = 0;
        private decimal _statisticsSum = 0.0M;
        private decimal _statisticsSquareSum = 0.0M;
        private decimal _statisticsMinimum = 0.0M;
        private decimal _statisticsMaximum = 0.0M;
        private object _statisticsLock = new object();

        public DeviceController(
            string portName,
            int baudRate,
            QuadratureMode quadratureMode,
            EncoderDirection encoderDirection,
            int encoderZeroPositionCount,
            decimal encoderResolution_nm)
        {
            Logger.Log("Instantiating DeviceController class:");
            Logger.Log("  portName = " + portName);
            Logger.Log("  baudRate = " + baudRate);
            Logger.Log("  quadratureMode = " + quadratureMode);
            Logger.Log("  encoderDirection = " + encoderDirection);
            Logger.Log("  encoderZeroPositionCount = " + encoderZeroPositionCount);
            Logger.Log("  encoderResolution_nm = " + encoderResolution_nm);

            _encoderZeroPositionCount = encoderZeroPositionCount;
            _encoderResolution_nm = encoderResolution_nm;

            _qsb = new Qsb(portName, baudRate, quadratureMode, encoderDirection);
        }

        /// <summary>
        /// Connect to an QSB-D through a serial port and start getting the encoder count.
        /// </summary>
        public void Connect()
        {
            try
            {
                _qsb.Connect();
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                _qsb.Disconnect();
                throw ex;
            }

            Thread readEncoderCountLoopThread = new Thread(new ThreadStart(EncoderCountReaderLoop));
            readEncoderCountLoopThread.Start();
        }

        public void Disconnect()
        {
            try
            {
                _qsb.Disconnect();
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
            }
        }

        /// <summary>
        /// This method is supposed to be called as a separate thread. It is an infinite
        /// loop and exits after <see cref="Disconnect()"/> is called.
        /// </summary>
        private void EncoderCountReaderLoop()
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            try
            {
                Logger.Log("Started EncoderCountReaderLoop.");

                while (true)
                {
                    int encoderCount;
                    int encoderZeroPositionCount;
                    uint timestamp;

                    string response;

                    lock (_serialPortLock)
                    {
                        // The serial port was disconnected. Terminate this thread.
                        if (_serialPort == null || !_serialPort.IsOpen)
                        {
                            Logger.Log("Terminating EncoderCountReaderLoop.");
                            return;
                        }

                        response = _serialPort.ReadLine();
                    }

                    ParseEncoderCountStreamResponse(response, out encoderCount, out timestamp);

                    lock (_encoderCountLock)
                    {
                        _encoderCount = encoderCount;
                        encoderZeroPositionCount = _encoderZeroPositionCount;
                    }

                    long encoderOffsetCount = (long)encoderCount - (long)encoderZeroPositionCount;
                    decimal position_mm = encoderOffsetCount * _encoderResolution_nm * (decimal)1e-6;

                    lock (_recorderLock)
                    {
                        if (IsRecording)
                        {
                            if (_recorderTotalNumOfRecords == 0)
                            {
                                _recorderFirstTimestamp = timestamp;
                                Logger.Log("First timestamp of this recording session: " + timestamp);
                            }

                            long relativeTimestamp = (long)timestamp - _recorderFirstTimestamp;
                            decimal relativeTimestamp_s = relativeTimestamp / 512.0M;

                            if (relativeTimestamp % _recorderRecordingInterval == 0)
                            {
                                _recorder.WriteLine(
                                    String.Format("{0}, {1}, {2}",
                                    relativeTimestamp_s.ToString("0.000000000"),
                                    encoderCount,
                                    position_mm.ToString("0.00000000")
                                    ));

                                _recorderTotalNumOfRecords++;
                                _recorderNumOfRecordsForFile++;

                                if (_recorderNumOfRecordsForFile >= _recorderMaxRecordsPerFile)
                                {
                                    CreateNewRecorder();
                                }
                            }
                        }
                    }

                    lock (_statisticsLock)
                    {
                        if (IsStatisticsOngoing)
                        {
                            ulong n = _statisticsNumberOfSamples;
                            decimal N = (decimal)n;
                            _statisticsNumberOfSamples = n + 1;
                            _statisticsSum = _statisticsSum + encoderCount;
                            _statisticsSquareSum = _statisticsSquareSum + encoderCount * encoderCount;
                            if (n == 0)
                            {
                                _statisticsMaximum = encoderCount;
                                _statisticsMinimum = encoderCount;
                            }
                            else
                            {
                                if (encoderCount > _statisticsMaximum)
                                {
                                    _statisticsMaximum = encoderCount;
                                }
                                if (encoderCount < _statisticsMinimum)
                                {
                                    _statisticsMinimum = encoderCount;
                                }
                            }

                            if (_statisticsStopCount > 0 && _statisticsNumberOfSamples >= _statisticsStopCount)
                            {
                                StopStatistics();
                            }
                        }
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
        /// Get the current position in millimeters.
        /// </summary>
        /// <returns>Current position in millimeters</returns>
        public decimal GetPositionInMillimeters()
        {
            int encoderCount;
            int encoderZeroPositionCount;

            lock (_encoderCountLock)
            {
                encoderCount = _encoderCount;
                encoderZeroPositionCount = _encoderZeroPositionCount;
            }

            long encoderOffsetCount = (long)encoderCount - (long)encoderZeroPositionCount;
            return encoderOffsetCount * _encoderResolution_nm * (decimal)1e-6;
        }

        public Tuple<ulong, decimal, decimal, decimal, decimal, decimal> GetStatistics()
        {
            ulong numberOfSamples = 0;
            decimal duration_s = 0.0M;
            decimal average_mm = 0.0M;
            decimal stdev_mm = 0.0M;
            decimal maximum_mm = 0.0M;
            decimal minimum_mm = 0.0M;
            decimal encoderZeroPositionCount = 0;

            lock (_encoderCountLock)
            {
                encoderZeroPositionCount = _encoderZeroPositionCount;
            }

            lock (_statisticsLock)
            {
                decimal averageCount = 0.0M;
                decimal stdevCount = 0.0M;

                if (numberOfSamples > 0)
                {
                    averageCount = _statisticsSum / numberOfSamples;
                    stdevCount = (decimal)Math.Sqrt(decimal.ToDouble(_statisticsSquareSum / numberOfSamples - averageCount * averageCount));
                }

                numberOfSamples = _statisticsNumberOfSamples;
                average_mm = (averageCount - encoderZeroPositionCount) * _encoderResolution_nm * 1e-6M;
                stdev_mm = stdevCount * _encoderResolution_nm * 1e-6M;
                maximum_mm = (_statisticsMaximum - encoderZeroPositionCount) * _encoderResolution_nm * 1e-6M;
                minimum_mm = (_statisticsMinimum - encoderZeroPositionCount) * _encoderResolution_nm * 1e-6M;
            }

            duration_s = (decimal)numberOfSamples / 512;

            return Tuple.Create(numberOfSamples, duration_s, average_mm, stdev_mm, maximum_mm, minimum_mm);
        }

        /// <summary>
        /// Set the current encoder count as the zero position.
        /// </summary>
        /// <returns>New encoder count of the zero position.</returns>
        public int Zero()
        {
            int newEncoderZeroPositionCount;

            Logger.Log("Setting a new encoder zero position.");

            lock (_encoderCountLock)
            {
                newEncoderZeroPositionCount = _encoderCount;
                _encoderZeroPositionCount = newEncoderZeroPositionCount;
            }

            Logger.Log("New encoder zero position count: " + newEncoderZeroPositionCount);

            // Reset the statistics
            lock (_statisticsLock)
            {
                if (_statisticsOngoing) {
                    StopStatistics();
                    StartStatistics(_statisticsStopCount);
                }
            }

            return newEncoderZeroPositionCount;
        }

        public void StartRecording(String outputDir, string filenameBase, int recordingInterval, int maxRecordsPerFile)
        {
            try
            {
                string outputDirFull = Path.GetFullPath(outputDir);
                Directory.CreateDirectory(outputDirFull);

                lock (_recorderLock)
                {
                    if (_recorder != null)
                    {
                        throw new InvalidOperationException("Recording is in progress.");
                    }

                    Logger.Log("Starting recording in " + _recorderOutputDir + ".");

                    _recorderOutputDir = outputDirFull;
                    _recorderFilenameBase = filenameBase;
                    _recorderRecordingInterval = recordingInterval;
                    _recorderMaxRecordsPerFile = maxRecordsPerFile;
                    _recorderTotalNumOfRecords = 0;
                    _recorderNumOfRecordsForFile = 0;
                    _recorderCurrentFilePath = null;

                    CreateNewRecorder();
                }
            }
            catch (Exception ex)
            {
                _recorder = null;
                Logger.Log(ex.ToString());
                throw ex;
            }
        }

        private void CreateNewRecorder()
        {
            lock (_recorderLock)
            {
                if (_recorder != null)
                {
                    Logger.Log("Closing " + _recorderCurrentFilePath);
                    _recorder.Close();
                    Logger.Log("Closed " + _recorderCurrentFilePath);
                }

                DateTime startTime = DateTime.Now;
                string filename = Util.FormatFilename(_recorderFilenameBase, startTime);
                _recorderCurrentFilePath = Path.Combine(_recorderOutputDir, filename);
                _recorderNumOfRecordsForFile = 0;

                Logger.Log("Opening " + _recorderCurrentFilePath);

                // TODO: do not overwrite the existing file.

                _recorder = new StreamWriter(_recorderCurrentFilePath);

                // Write the product type, serial number and start time.
                _recorder.WriteLine("# Product: " + _productType);
                _recorder.WriteLine("# Serial number: " + _serialNumber);
                _recorder.WriteLine("# Start time: " + startTime.ToString("yyyy-MM-dd HH:mm:ss.ffffff"));

                // Write a header.
                _recorder.WriteLine("Timestamp [s], Raw Count, Position [mm]");

                Logger.Log("Opened " + _recorderCurrentFilePath);
            }
        }

        public void StopRecording()
        {
            lock (_recorderLock)
            {
                if (_recorder == null)
                {
                    return;
                }

                try
                {
                    Logger.Log("Terminating the recording");
                    _recorder.Close();
                    Logger.Log("Terminated the recording.");
                }
                catch (Exception ex)
                {
                    Logger.Log(ex.ToString());
                }

                _recorder = null;
            }
        }

        public bool IsRecording
        {
            get
            {
                lock (_recorderLock)
                {
                    return _recorder != null;
                }
            }
        }

        public string CurrentRecordingFilePath
        {
            get
            {
                lock (_recorderLock)
                {
                    return _recorderCurrentFilePath;
                }
            }
        }

        public void StartStatistics(ulong stopCount)
        {
            lock (_statisticsLock)
            {
                _statisticsStopCount = stopCount;
                _statisticsNumberOfSamples = 0;
                _statisticsSum = 0.0M;
                _statisticsSquareSum = 0.0M;
                _statisticsMinimum = 0.0M;
                _statisticsMaximum = 0.0M;
                _statisticsOngoing = true;
            }
        }

        public void StopStatistics()
        {
            lock (_statisticsLock)
            {
                _statisticsOngoing = false;
            }
        }

        public bool IsStatisticsOngoing
        {
            get
            {
                lock (_statisticsLock)
                {
                    return _statisticsOngoing;
                }
            }
        }
    }
}
