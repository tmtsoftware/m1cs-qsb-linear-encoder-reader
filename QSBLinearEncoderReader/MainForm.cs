using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace QSBLinearEncoderReader
{
    public partial class MainForm : Form
    {
        private object _controllerLock = new object();
        private DeviceController _controller = null;   // not null if this application is connected to a QSB-D.
        private bool _connected = false;
        private bool _recording = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string appName = Assembly.GetExecutingAssembly().GetName().Name;
            string appVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            AppendOneLineLogMessage(appName + " " + appVersion);
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
                    connectDialog.BaudRate,
                    connectDialog.QuadratureMode,
                    connectDialog.Resolution_nm,
                    connectDialog.ZeroPositionCount,
                    connectDialog.Direction);

                // Save the successful configuration values as the default settings.
                if (connected)
                {
                    Properties.Settings.Default.PortName = connectDialog.PortName;
                    Properties.Settings.Default.BaudRate = connectDialog.BaudRate;
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
            if (textBoxCSVOutputPath.Text.Length > 0)
            {
                StartRecording(textBoxCSVOutputPath.Text);
            }
            else
            {
                MessageBox.Show(
                    "Set the CSV output path before you start recording.",
                    "Empty CSV Output Path",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonStopRecording_Click(object sender, EventArgs e)
        {
            StopRecording();
        }

        private void buttonSetCSVOutputPath_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxCSVOutputPath.Text = saveFileDialog.FileName;
                SetStartRecordingButtonState();
            }
        }

        private void timerDisplayUpdateLoop_Tick(object sender, EventArgs e)
        {
            lock (_controllerLock)
            {
                if (_controller != null && !_controller.IsConnected)
                {
                    // The controller was disconnected unexpectedly.
                    AppendOneLineLogMessage("Connection was closed unexpectedly. See more details in " + Logger.TraceLogPath);
                    Disconnect();
                }
            }

            UpdateEncoderReadingDisplay();
        }

        private void UpdateEncoderReadingDisplay()
        {
            decimal position_mm;

            position_mm = (decimal)(0.0);

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

            labelEncoderReading.Text = position_mm.ToString("0.000000");
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

            AppendOneLineLogMessage("Set the encoder zero position count: " + newEncoderZeroPositionCount);
            UpdateEncoderReadingDisplay();
        }

        private bool Connect(
            String portName,
            int baudRate,
            QuadratureMode quadratureMode,
            decimal resolution_nm,
            int zeroPositionCount,
            EncoderDirection encoderDirection)
        {
            bool failed = false;
            string failureMessage = "";

            buttonConnect.Enabled = false;

            lock (_controllerLock)
            {
                if (_controller != null)
                {
                    // Already connected. Do nothing.
                    return false;
                }

                textBoxStatus.AppendText(String.Format("Connecting to an US Digital QSB-D Encoder Reader via '{0}' (baud rate: {1}) ...", portName, baudRate));

                try
                {
                    _controller = new DeviceController(portName, baudRate, quadratureMode, encoderDirection, zeroPositionCount, resolution_nm);
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
                buttonConnect.Enabled = true;
                AppendOneLineLogMessage("FALIED!!!");
                AppendOneLineLogMessage(failureMessage);
                return false;
            }

            AppendOneLineLogMessage("OK");

            // Show product type, serial number and firmware version.
            string productType = _controller.ProductType;
            AppendOneLineLogMessage(String.Format("Product Type: {0}", productType));
            if (productType != "QSB-D")
            {
                AppendOneLineLogMessage(String.Format("Warning: this application was not tested with '{0}'.", productType));
            }

            AppendOneLineLogMessage(String.Format("Serial Number: {0}", _controller.SerialNumber));
            AppendOneLineLogMessage(String.Format("Firmware Version: {0}", _controller.FirmwareVersion));

            // Show configuration
            AppendOneLineLogMessage(String.Format("Quadrature Mode: {0}", quadratureMode));
            AppendOneLineLogMessage(String.Format("Encoder Direction: {0}", encoderDirection));
            AppendOneLineLogMessage(String.Format("Encoder resolution: {0} nm/count", resolution_nm.ToString("0.00")));
            AppendOneLineLogMessage("Set the encoder zero position count: " + zeroPositionCount);

            // Enable buttons that can be clicked when connected.
            buttonSetZero.Enabled = true;
            buttonDisconnect.Enabled = true;

            // Disable the button that cannot be clicked when connected.
            buttonConnect.Enabled = false;

            _connected = true;
            SetStartRecordingButtonState();

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

                if (_recording)
                {
                    StopRecording();
                }

                _controller.Disconnect();
                _controller = null;
            }

            AppendOneLineLogMessage("Disconnected from the US Digital QSB-D Encoder Reader.");

            // Disable buttons that cannot be clicked when disconnected.
            buttonSetZero.Enabled = false;
            buttonDisconnect.Enabled = false;

            // Disable the button that can be clicked when disconnected.
            buttonConnect.Enabled = true;

            _connected = false;
            SetStartRecordingButtonState();
        }

        private void StartRecording(String fileName)
        {
            bool failed = false;
            string failureMessage = "";

            buttonStartRecording.Enabled = false;
            buttonSetCSVOutputPath.Enabled = false;

            lock (_controllerLock)
            {

                if (_controller == null)
                {
                    AppendOneLineLogMessage("Not connected so cannot start recording.");
                    return;
                }

                try
                {
                    _controller.StartRecording(fileName);
                    _recording = true;
                }
                catch (Exception ex)
                {
                    failed = true;
                    failureMessage = ex.Message;
                }
            }

            if (failed)
            {
                SetStartRecordingButtonState();
                buttonSetCSVOutputPath.Enabled = true;
                AppendOneLineLogMessage("Failed to start recording to " + fileName);
                AppendOneLineLogMessage(failureMessage);
                return;
            }

            AppendOneLineLogMessage("Started recording to " + fileName);

            SetStartRecordingButtonState();
            buttonStopRecording.Enabled = true;
            buttonSetCSVOutputPath.Enabled = false;
        }

        private void StopRecording()
        {
            lock (_controllerLock)
            {
                if (_recording)
                {
                    _controller.StopRecording();
                    _recording = false;
                }
                else
                {
                    return;
                }
            }

            AppendOneLineLogMessage("Stopped recording.");

            SetStartRecordingButtonState();
            buttonStopRecording.Enabled = false;
            buttonSetCSVOutputPath.Enabled = true;
        }

        private void AppendOneLineLogMessage(String message)
        {
            textBoxStatus.AppendText(message + Environment.NewLine);
        }

        private void SetStartRecordingButtonState()
        {
            if (_connected && !_recording && textBoxCSVOutputPath.Text.Length > 0)
            {
                buttonStartRecording.Enabled = true;
            }
            else
            {
                buttonStartRecording.Enabled = false;
            }
        }
    }
}
