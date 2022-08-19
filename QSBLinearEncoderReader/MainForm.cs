using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using USDigital;

namespace QSBLinearEncoderReader
{
    public partial class MainForm : Form
    {
        private QSB_D _qsb;
        private double _resolution_nm = 5.0 / 4;
        private int _zeroCount = 0;
        private int _latestCount = 0;
        private bool _connected = false;
        private bool _recording = false;
        private StreamWriter _recordingStream;

        public MainForm()
        {
            InitializeComponent();
            _qsb = new QSB_D();
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            // TODO: remove the hard-coded COM port name.
            connect("COM6");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            disconnect();
        }

        private void buttonSetZero_Click(object sender, EventArgs e)
        {
            zero();
        }

        private void buttonStartRecording_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                startRecording(saveFileDialog.FileName);
            }
        }

        private void buttonStopRecording_Click(object sender, EventArgs e)
        {
            stopRecording();
        }

        private void timerEncoderReaderLoop_Tick(object sender, EventArgs e)
        {
            updateEncoderReadingDisplay();
            recordCurrentEncoderReading();
        }

        private void updateEncoderReadingDisplay()
        {
            try
            {
                _latestCount = (int)_qsb.GetCount();
                double displacement_mm = (_latestCount - _zeroCount) * _resolution_nm * 1e-6;
                labelEncoderReading.Text = displacement_mm.ToString("0.00000000");
            }
            catch (Exception ex)
            {
                disconnect();
                
                // TODO: show the exception message and stack trace in the status text box, not in the message box.
                MessageBox.Show(ex.Message);
            }
        }

        private void zero()
        {
            _zeroCount = _latestCount;
            updateEncoderReadingDisplay();
            appendOneLineLogMessage("Set the encoder zero position count to " + _zeroCount);
        }

        private void connect(String portName)
        {
            if (_connected)
            {
                return;
            }

            // Connect to the QSB encoder reader.
            textBoxStatus.AppendText("Connecting to an US Digital QSB-D Encoder Reader via " + portName + " ... ");
            _qsb.Open(portName);

            if (_qsb.IsOpen)
            {
                appendOneLineLogMessage("OK");
            }
            else
            {
                appendOneLineLogMessage("FALIED!!!");
                appendOneLineLogMessage("Check that the port name '" + portName + "' is correct and no other application uses the same port.");
                return;
            }

            // Configure the QSB encoder reader.
            //
            // TODO: remove hard-coded configuration values below and allow the user to change them
            _qsb.SetQuadratureMode(QuadratureMode.X4);
            appendOneLineLogMessage("Quadrature mode: X4 Multiplier");

            _qsb.SetCounterMode(CounterMode.FreeRunningCounter);
            appendOneLineLogMessage("Counter mode: Free Running");

            _qsb.SetDirection(EncoderDirection.CountingUp);
            appendOneLineLogMessage("Direction: positive");

            _resolution_nm = 5.0 / 4;
            appendOneLineLogMessage("Encoder resolution: " + _resolution_nm.ToString("0.00") + " nm/count");

            _zeroCount = 0;
            appendOneLineLogMessage("Set the encoder zero position count to " + _zeroCount);

            // Update the encoder reading display.
            updateEncoderReadingDisplay();

            // Start reading the encoder count.
            _connected = true;
            timerEncoderReaderLoop.Enabled = true;

            // Enable buttons that can be clicked when connected.
            buttonSetZero.Enabled = true;
            buttonStartRecording.Enabled = true;

            // Disable the button that cannot be clicked when connected.
            buttonConnect.Enabled = false;
        }

        private void disconnect()
        {
            if (!_connected)
            {
                return;
            }

            if (_recording)
            {
                stopRecording();
            }

            // Stop reading the encoder count.
            timerEncoderReaderLoop.Enabled = false;
            _connected = false;

            // Disconnect from the QSB encoder reader.
            _qsb.Close();
            appendOneLineLogMessage("Disconnected from the US Digital QSB-D Encoder Reader.");

            // Disable buttons that cannot be clicked when disconnected.
            buttonSetZero.Enabled = false;
            buttonStartRecording.Enabled = false;

            // Disable the button that can be clicked when disconnected.
            buttonConnect.Enabled = true;
        }

        private void startRecording(String fileName)
        {
            if (_recording)
                return;

            try
            {
                _recordingStream = new StreamWriter(path: fileName, append: false, encoding: Encoding.UTF8);
                recordHeader();
            }
            catch (Exception ex)
            {
                appendOneLineLogMessage("Falied to open " + fileName + " ... " + ex.Message);
                return;
            }

            _recording = true;
            appendOneLineLogMessage("Started recording to " + fileName );

            buttonStartRecording.Enabled = false;
            buttonStopRecording.Enabled = true;
        }

        private void recordHeader()
        {
            _recordingStream.WriteLineAsync("Timestamp,Count,Displacement [mm]");
        }

        private void recordCurrentEncoderReading()
        {
            if (_recording)
            {
                try
                {
                    int count = (int)_qsb.GetCount();
                    double displacement = (count - _zeroCount) * _resolution_nm * 1e-6;
                    _recordingStream.WriteLineAsync(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "," + count + "," + displacement.ToString("0.00000000"));
                }
                catch (Exception ex)
                {
                    // ignore the exception and try to keep recording
                }
            }
        }


        private void stopRecording()
        {
            if (!_recording)
                return;

            _recording = false;
            _recordingStream.Close();

            appendOneLineLogMessage("Stopped recording.");

            buttonStartRecording.Enabled = true;
            buttonStopRecording.Enabled = false;
        }

        private void appendOneLineLogMessage(String message)
        {
            textBoxStatus.AppendText(message + Environment.NewLine);
        }
    }
}
