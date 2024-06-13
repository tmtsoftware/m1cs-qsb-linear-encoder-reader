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
        private bool _takingStatistics = false;

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

                // Start statistics automatically.
                if (connected)
                {
                    StartStatistics();
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

        private void buttonRecordingSettings_Click(object sender, EventArgs e)
        {
            if (_recording)
            {
                return;
            }

            RecordingSettingsForm settingsDialog = new RecordingSettingsForm();
            DialogResult dialogResult = settingsDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                // TODO: implement
            }

            settingsDialog.Dispose();
        }

        private void buttonStartStatistics_Click(object sender, EventArgs e)
        {
            StartStatistics();
        }

        private void buttonStopStatistics_Click(object sender, EventArgs e)
        {
            StopStatistics();
        }

        private void buttonResetStatistics_Click(object sender, EventArgs e)
        {
            StopStatistics();
            StartStatistics();
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
            UpdateStatisticsDisplay();
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

        private void UpdateStatisticsDisplay()
        {
            ulong numberOfSamples = 0;
            decimal duration_s = 0.0M;
            decimal average_mm = 0.0M;
            decimal maximum_mm = 0.0M;
            decimal minimum_mm = 0.0M;
            decimal peak_to_peak_mm = 0.0M;

            lock (_controllerLock)
            {
                if (_controller != null)
                {
                    (numberOfSamples, duration_s, average_mm, maximum_mm, minimum_mm) = _controller.GetStatistics();
                }
                else
                {
                    return;
                }
            }

            peak_to_peak_mm = maximum_mm - minimum_mm;

            textBoxNumberOfSamples.Text = numberOfSamples.ToString();
            textBoxDuration.Text = duration_s.ToString("F3");
            textBoxAverage.Text = average_mm.ToString("F6");
            textBoxMaximum.Text = maximum_mm.ToString("F6");
            textBoxMinimum.Text = minimum_mm.ToString("F6");
            textBoxPeakToPeak.Text = peak_to_peak_mm.ToString("F6");
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
            SetRecordingButtonsState();
            SetStatisticsButtonsState();

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

                if (_takingStatistics)
                {
                    StopStatistics();
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
            SetRecordingButtonsState();
            SetStatisticsButtonsState();
        }

        private void StartRecording(String fileName)
        {
            bool failed = false;
            string failureMessage = "";

            buttonStartRecording.Enabled = false;
            buttonRecordingSettings.Enabled = false;

            lock (_controllerLock)
            {

                if (_controller == null)
                {
                    AppendOneLineLogMessage("Not connected. Cannot start recording.");
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
                _recording = false;
                SetRecordingButtonsState();
                AppendOneLineLogMessage("Failed to start recording to " + fileName);
                AppendOneLineLogMessage(failureMessage);
                return;
            }

            AppendOneLineLogMessage("Started recording to " + fileName);

            SetRecordingButtonsState();
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

            SetRecordingButtonsState();
        }

        private void StartStatistics()
        {
            bool actuallyStarted = false;

            lock (_controllerLock)
            {

                if (_controller == null)
                {
                    AppendOneLineLogMessage("Not connected. Cannot start statistics.");
                    return;
                }

                if (!_takingStatistics) {
                    _controller.StartStatistics();
                    _takingStatistics = true;
                    actuallyStarted = true;
                }
                else
                {
                    return;
                }
            }

            if (actuallyStarted)
            {
                AppendOneLineLogMessage("Started statistics.");
            }

            SetStatisticsButtonsState();
        }

        private void StopStatistics()
        {
            bool actuallyStopped = false;

            lock (_controllerLock)
            {
                if (_takingStatistics)
                {
                    _controller.StopStatistics();
                    _takingStatistics = false;
                    actuallyStopped = true;
                }
                else
                {
                    return;
                }
            }

            if (actuallyStopped)
            {
                AppendOneLineLogMessage("Stopped statistics.");
            }

            SetStatisticsButtonsState();
        }

        private void AppendOneLineLogMessage(String message)
        {
            textBoxStatus.AppendText(message + Environment.NewLine);
        }

        private void SetRecordingButtonsState()
        {
            if (!_connected)
            {
                buttonStartRecording.Enabled = false;
                buttonStopRecording.Enabled = false;
                buttonRecordingSettings.Enabled = true;
            }
            else if (!_recording)
            {
                buttonStartRecording.Enabled = true;
                buttonStopRecording.Enabled = false;
                buttonRecordingSettings.Enabled = true;
            }
            else
            {
                buttonStartRecording.Enabled = false;
                buttonStopRecording.Enabled = true;
                buttonRecordingSettings.Enabled = false;
            }
        }

        private void SetStatisticsButtonsState()
        {
            if (!_connected)
            {
                buttonStartStatistics.Enabled = false;
                buttonStopStatistics.Enabled = false;
                buttonResetStatistics.Enabled = false;
           }
            else if (_takingStatistics)
            {
                buttonStartStatistics.Enabled = false;
                buttonStopStatistics.Enabled = true;
                buttonResetStatistics.Enabled = true;
            }
            else
            {
                buttonStartStatistics.Enabled = true;
                buttonStopStatistics.Enabled = false;
                buttonResetStatistics.Enabled = false;
            }
        }
    }
}
