using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QSBLinearEncoderReader
{
    internal class Recorder
    {
        private object _lock = new object();

        private IRecorderStatusListener _listener = null;

        private ulong _sessionSequenceId = 0;
        private RecorderState _state = RecorderState.Stopped;

        private string _outputDirectory = Properties.Settings.Default.OutputDirectory;
        private string _filenameBase = Properties.Settings.Default.CSVFilename;
        private uint _recordingInterval = Properties.Settings.Default.RecordingInterval;
        private uint _maxRecordsPerFile = Properties.Settings.Default.MaxRecordsPerFile;
        private ulong _listenerTriggerInterval = Properties.Settings.Default.DisplayUpdateInterval;
        private uint _serialNumber = 0;

        private ulong _totalNumberOfSamples = 0;
        private ulong _totalNumberOfRecords = 0;
        private ulong _numberOfRecordsInFile = 0;
        private string _currentRecordingPath = "";

        private StreamWriter _writer = null;

        private ulong _startTimestamp = 0;

        private uint _flushInterval_s = 10;
        private DateTime _lastFlushTime = DateTime.MinValue;

        /// <summary>
        /// This class handles recording of sampled encoder values.
        /// </summary>
        public Recorder(IRecorderStatusListener listener)
        {
            _listener = listener;
            _sessionSequenceId = 0;
        }

        public void Start(
            string outputDirectory,
            string filenameBase,
            uint recordingInterval,
            uint maxRecordsPerFile,
            ulong listenerTriggerInterval,
            uint flushInterval_s,
            uint serialNumber)
        {
            lock (_lock)
            {
                if (_state == RecorderState.Recording)
                {
                    return;
                }

                _outputDirectory = outputDirectory;
                _filenameBase = filenameBase;
                _recordingInterval = recordingInterval;
                _maxRecordsPerFile = maxRecordsPerFile;
                _listenerTriggerInterval = listenerTriggerInterval;
                _flushInterval_s = flushInterval_s;
                _serialNumber = serialNumber;
                _totalNumberOfSamples = 0;
                _totalNumberOfRecords = 0;
                _numberOfRecordsInFile = 0;
                _currentRecordingPath = "";
                _writer = null;
                _sessionSequenceId += 1;
                _lastFlushTime = DateTime.Now;

                UpdateState(RecorderState.Recording);
            }
        }

        public void Stop()
        {
            lock (_lock)
            {
                if (_state != RecorderState.Recording)
                {
                    return;
                }

                try
                {
                    CloseWriter();
                    UpdateState(RecorderState.Stopped);
                }
                catch (Exception ex)
                {
                    UpdateState(RecorderState.Error, ex);
                }
            }
        }

        public void AddNewSample(int encoderCount, uint timestamp, decimal position_mm)
        {
            bool triggerListener = false;

            lock (_lock)
            {
                if (_state != RecorderState.Recording)
                {
                    return;
                }

                try
                {

                    if (_totalNumberOfSamples == 0)
                    {
                        _startTimestamp = timestamp;
                    }

                    if (_totalNumberOfSamples % _recordingInterval == 0)
                    {
                        // Record this sample.

                        if (_numberOfRecordsInFile == 0)
                        {
                            // Open a new file.
                            DateTime startTime = DateTime.Now;
                            string filename = Util.FormatFilename(_filenameBase, startTime).Replace("%N", _serialNumber.ToString());

                            Directory.CreateDirectory(_outputDirectory);

                            _currentRecordingPath = Path.Combine(_outputDirectory, filename);

                            if (File.Exists(_currentRecordingPath))
                            {
                                throw new IOException("File exists: " + _currentRecordingPath);
                            }
                            _writer = new StreamWriter(_currentRecordingPath);

                            // Write header.
                            _writer.WriteLine("# Created: " + startTime.ToString("yyyy-MM-dd HH:mm:ss"));
                            _writer.WriteLine("# Serial number: " + _serialNumber.ToString());

                            decimal startTimestamp_s = (decimal)_startTimestamp / 512.0M;

                            _writer.WriteLine("# Start absolute timestamp [s]: " + startTimestamp_s.ToString("0.000000000"));
                            _writer.WriteLine("# Relative timestamp [s], Raw Count, Position [mm]");

                            triggerListener = true;
                        }

                        long relativeTimestamp = (long)timestamp - (long)_startTimestamp;
                        decimal relativeTimestamp_s = (decimal)relativeTimestamp / 512.0M;
                        _writer.WriteLine(
                            String.Format("{0}, {1}, {2}",
                            relativeTimestamp_s.ToString("0.000000000"),
                            encoderCount,
                            position_mm.ToString("0.000000")));

                        DateTime now = DateTime.Now;
                        if ((now - _lastFlushTime).TotalSeconds > _flushInterval_s)
                        {
                            _writer.Flush();
                            _lastFlushTime = now;
                        }

                        _numberOfRecordsInFile += 1;
                        _totalNumberOfRecords += 1;

                        if (_numberOfRecordsInFile >= _maxRecordsPerFile)
                        {
                            CloseWriter();
                            _numberOfRecordsInFile = 0;
                        }
                    }

                    _totalNumberOfSamples += 1;

                    if (_totalNumberOfSamples % _listenerTriggerInterval == 0)
                    {
                        triggerListener = true;
                    }

                    if (triggerListener)
                    {
                        _listener.RecorderStatusChanged(
                            new RecorderStatus(_state, _sessionSequenceId, _currentRecordingPath, _numberOfRecordsInFile, _totalNumberOfRecords));
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        CloseWriter();
                    }
                    catch (Exception)
                    {
                    }

                    UpdateState(RecorderState.Error, ex);
                }
            }
        }

        private void UpdateState(RecorderState newState)
        {
            lock (_lock)
            {
                UpdateState(newState, null);
            }
        }

        private void UpdateState(RecorderState newState, Exception ex)
        {
            lock (_lock)
            {
                string errMsg = null;

                Logger.Log("Recorder: switching to \"" + newState + "\" state.");
                if (ex != null)
                {
                    Logger.Log(ex.ToString());
                    errMsg = ex.Message;
                }

                _state = newState;
                _listener.RecorderStatusChanged(
                    new RecorderStatus(_state, _sessionSequenceId, _currentRecordingPath, _numberOfRecordsInFile, _totalNumberOfRecords, errMsg));
            }
        }

        private void CloseWriter()
        {
            lock (_lock)
            {
                if (_writer != null)
                {
                    try
                    {
                        _writer.Close();
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(ex.Message);
                        throw ex;
                    }
                    finally
                    {
                        _writer = null;
                    }
                }
            }
        }
    }
}
