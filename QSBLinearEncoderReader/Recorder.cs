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

        private RecorderState _state = RecorderState.Stopped;

        private string _outputDirectory = Properties.Settings.Default.OutputDirectory;
        private string _filenameBase = Properties.Settings.Default.CSVFilename;
        private uint _recordingInterval = Properties.Settings.Default.RecordingInterval;
        private uint _maxRecordsPerFile = Properties.Settings.Default.MaxRecordsPerFile;
        private ulong _listenerTriggerInterval = Properties.Settings.Default.DisplayUpdateInterval;

        private ulong _totalNumberOfSamples = 0;
        private ulong _totalNumberOfRecords = 0;
        private ulong _numberOfRecordsInFile = 0;
        private string _currentRecordingPath = "";

        private ulong _startTimestamp = 0;

        /// <summary>
        /// This class handles recording of sampled encoder values.
        /// </summary>
        public Recorder(IRecorderStatusListener listener)
        {
            _listener = listener;
        }

        public void Start(
            string outputDirectory,
            string filenameBase,
            uint recordingInterval,
            uint maxRecordsPerFile,
            ulong listenerTriggerInterval)
        {
            lock (_lock)
            {
                _outputDirectory = outputDirectory;
                _filenameBase = filenameBase;
                _recordingInterval = recordingInterval;
                _maxRecordsPerFile = maxRecordsPerFile;
                _listenerTriggerInterval = listenerTriggerInterval;
                _totalNumberOfSamples = 0;
                _totalNumberOfRecords = 0;
                _numberOfRecordsInFile = 0;
                _currentRecordingPath = "";
                _state = RecorderState.Recording;

                Logger.Log("Switching to \"" + _state + "\" recorder state.");
                _listener.RecorderStatusChanged(
                    new RecorderStatus(_state, "", 0, 0));
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
                _state = RecorderState.Stopped;

                Logger.Log("Switching to \"" + _state + "\" recorder state.");
                _listener.RecorderStatusChanged(
                    new RecorderStatus(_state, _currentRecordingPath, _numberOfRecordsInFile, _totalNumberOfRecords));
            }
        }

        public void AddNewSample(int encoderCount, uint timestamp)
        {
            bool triggerListener = false;

            lock (_lock)
            {
                if (_state != RecorderState.Recording)
                {
                    return;
                }

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
                        string filename = Util.FormatFilename(_filenameBase, startTime);
                        _currentRecordingPath = Path.Combine(_outputDirectory, filename);

                        // TODO: actually open the file.
                        // TODO: handle I/O error

                        triggerListener = true;
                    }

                    // TODO: write this sample to the file.
                    // TODO: handle I/O error

                    _numberOfRecordsInFile += 1;
                    _totalNumberOfRecords += 1;

                    if (_numberOfRecordsInFile >= _maxRecordsPerFile)
                    {
                        // TODO: close the current file.
                        // TODO: handle I/O error
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
                        new RecorderStatus(_state, _currentRecordingPath, _numberOfRecordsInFile, _totalNumberOfRecords));
                }
            }
        }
    }
}
