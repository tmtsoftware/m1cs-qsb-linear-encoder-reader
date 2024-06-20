using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSBLinearEncoderReader
{
    /// <summary>
    /// Immutable class that represents the current recording status.
    /// </summary>
    public class RecorderStatus
    {
        public RecorderStatus() : this(RecorderState.Stopped, "", 0, 0)
        {
        }

        public RecorderStatus(
            RecorderState recordingState,
            string currentOutputPath,
            ulong numberOfRecordsInCurrentFile,
            ulong totalNumberOfRecords) : this (
                recordingState,
                currentOutputPath,
                numberOfRecordsInCurrentFile,
                totalNumberOfRecords,
                String.Empty)
        {
        }

        public RecorderStatus(
            RecorderState recordingState,
            string currentOutputPath,
            ulong numberOfRecordsInCurrentFile,
            ulong totalNumberOfRecords,
            string errorMessage)
        {
            RecordingState = recordingState;
            CurrentOutputPath = currentOutputPath;
            NumberOfRecordsInCurrentFile = numberOfRecordsInCurrentFile;
            TotalNumberOfRecords = totalNumberOfRecords;
            ErrorMessage = errorMessage;
        }

        public RecorderState RecordingState { get; }
        public String CurrentOutputPath { get; }
        public ulong NumberOfRecordsInCurrentFile { get; }
        public ulong TotalNumberOfRecords { get; }
        public string ErrorMessage { get; }
    }
}
