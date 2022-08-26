using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace QSBLinearEncoderReader
{
    public partial class MainForm : Form
    {
        private object _controllerLock = new object();
        private DeviceController _controller = null;   // not null if this application is connected to a QSB-D.

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AppendOneLineLogMessage("Trace log is in " + Logger.TraceLogPath);
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            ConnectForm connectDialog = new ConnectForm();
            DialogResult dialogResult = connectDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                bool connected = Connect(
                    connectDialog.PortName,
                    connectDialog.QuadratureMode,
                    connectDialog.Resolution_nm,
                    connectDialog.ZeroPositionCount,
                    connectDialog.Direction);

                // Save the successful configuration values as the default settings.
                if (connected)
                {
                    Properties.Settings.Default.PortName = connectDialog.PortName;
                    Properties.Settings.Default.QuadratureMode = connectDialog.QuadratureMode;
                    Properties.Settings.Default.Resolution_nm = connectDialog.Resolution_nm;
                    Properties.Settings.Default.ZeroPositionCount = connectDialog.ZeroPositionCount;
                    Properties.Settings.Default.Direction = connectDialog.Direction;
                    Properties.Settings.Default.Save();
                }
            }

            connectDialog.Dispose();
        }
        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }

        private void buttonSetZero_Click(object sender, EventArgs e)
        {
            Zero();
        }

        private void buttonStartRecording_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StartRecording(saveFileDialog.FileName);
            }
        }

        private void buttonStopRecording_Click(object sender, EventArgs e)
        {
            StopRecording();
        }

        private void timerDisplayUpdateLoop_Tick(object sender, EventArgs e)
        {
            // TODO: check the controller connection and recording status.
            UpdateEncoderReadingDisplay();
        }

        private void UpdateEncoderReadingDisplay()
        {
            decimal position_mm;

            lock (_controllerLock)
            {
                if (_controller != null)
                {
                    position_mm = _controller.GetPositionInMillimeters();
                }
                else
                {
                    return;
                }
            }

            labelEncoderReading.Text = position_mm.ToString("0.00000000");
        }

        private void Zero()
        {
            int newEncoderZeroPositionCount;

            lock (_controllerLock)
            {
                if (_controller != null)
                {
                    newEncoderZeroPositionCount = _controller.Zero();
                }
                else
                {
                    return;
                }
            }

            AppendOneLineLogMessage("New encoder zero position count: " + newEncoderZeroPositionCount);
            UpdateEncoderReadingDisplay();
        }

        private bool Connect(
            String portName,
            QuadratureMode quadratureMode,
            decimal resolution_nm,
            int zeroPositionCount,
            EncoderDirection direction)
        {
            bool failed = false;
            string failureMessage = "";

            lock (_controllerLock)
            {
                if (_controller != null)
                {
                    // Already connected. Do nothing.
                    return false;
                }

                textBoxStatus.AppendText("Connecting to an US Digital QSB-D Encoder Reader via " + portName + " ... ");

                try
                {
                    // TODO: make the baud rate configurable
                    _controller = new DeviceController(portName, 230400, quadratureMode, direction, zeroPositionCount, resolution_nm);
                    _controller.Connect();
                }
                catch (Exception e)
                {
                    _controller = null;
                    failed = true;
                    failureMessage = e.Message;
                }
            }

            if (failed)
            {
                AppendOneLineLogMessage("FALIED!!!");
                AppendOneLineLogMessage(failureMessage);
                return false;
            }

            AppendOneLineLogMessage("OK");

            // Enable buttons that can be clicked when connected.
            buttonSetZero.Enabled = true;
            buttonStartRecording.Enabled = true;
            buttonDisconnect.Enabled = true;

            // Disable the button that cannot be clicked when connected.
            buttonConnect.Enabled = false;

            return true;
        }

        private void Disconnect()
        {
            lock (_controllerLock)
            {
                if (_controller == null)
                {
                    // Not connected. Do nothing.
                    return;
                }

                // TODO: stop recording if the recording is in progress

                _controller.Disconnect();
                _controller = null;
            }

            AppendOneLineLogMessage("Disconnected from the US Digital QSB-D Encoder Reader.");

            // Disable buttons that cannot be clicked when disconnected.
            buttonSetZero.Enabled = false;
            buttonStartRecording.Enabled = false;
            buttonDisconnect.Enabled = false;

            // Disable the button that can be clicked when disconnected.
            buttonConnect.Enabled = true;
        }

        private void StartRecording(String fileName)
        {
            // TODO: confirm that the device is not recording

            // TODO: start recording

            // TODO: add a log message

            buttonStartRecording.Enabled = false;
            buttonStopRecording.Enabled = true;
        }

        private void StopRecording()
        {
            // TODO: confirm that the device is recording

            // TODO: stop recording

            AppendOneLineLogMessage("Stopped recording.");

            buttonStartRecording.Enabled = true;
            buttonStopRecording.Enabled = false;
        }

        private void AppendOneLineLogMessage(String message)
        {
            textBoxStatus.AppendText(message + Environment.NewLine);
        }
    }
}
