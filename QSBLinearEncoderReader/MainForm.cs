using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace QSBLinearEncoderReader
{
    public partial class MainForm : Form, IConnectionStateListener
    {
        private DeviceController _controller = null;
        private ConnectionState _connectionState = ConnectionState.Disconnected;

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

            _controller = new DeviceController(this);
            _connectionState = ConnectionState.Disconnected;
            SetButtonsState();
            SetConnectionStatus();
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

                // TODO: start statistics automatically
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
            // TODO: implement
            /*
            StartRecording();
            */
        }

        private void buttonStopRecording_Click(object sender, EventArgs e)
        {
            // TODO: implement
            /*
            StopRecording();
            */
        }

        private void buttonRecordingSettings_Click(object sender, EventArgs e)
        {
            // TODO: impelement
            /*
            lock (_controllerLock)
            {
                if (_controller != null && _controller.IsRecording)
                {
                    return;
                }
            }

            RecordingSettingsForm settingsDialog = new RecordingSettingsForm();
            DialogResult dialogResult = settingsDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                settingsDialog.SaveSettings();
            }

            settingsDialog.Dispose();
            */
        }

        private void buttonStartStatistics_Click(object sender, EventArgs e)
        {
            // TODO: implement
            /*
            StartStatistics();
            */
        }

        private void buttonStopStatistics_Click(object sender, EventArgs e)
        {
            // TODO: implement
            /*
            StopStatistics();
            */
        }

        private void buttonResetStatistics_Click(object sender, EventArgs e)
        {
            // TODO: implement
            /*
            StopStatistics();
            StartStatistics();
            */
        }

        private void checkBoxAutoStopStatistics_CheckedChanged(object sender, EventArgs e)
        {
            // TODO: implement
            /*
            SetButtonsState();
            */
        }
        private void timerDisplayUpdateLoop_Tick(object sender, EventArgs e)
        {
            UpdateEncoderReadingDisplay();
            UpdateStatisticsDisplay();
        }

        /*

        private void StartRecording()
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
                    _controller.StartRecording(
                        Environment.ExpandEnvironmentVariables(Properties.Settings.Default.OutputDirectory),
                        Properties.Settings.Default.CSVFilename,
                        Properties.Settings.Default.RecordingInterval,
                        Properties.Settings.Default.MaxRecordsPerFile);
                }
                catch (Exception ex)
                {
                    failed = true;
                    failureMessage = ex.Message;
                }
            }

            if (failed)
            {
                SetButtonsState();
                AppendOneLineLogMessage("Failed to start recording.");
                AppendOneLineLogMessage(failureMessage);
                return;
            }

            AppendOneLineLogMessage("Started recording.");

            SetButtonsState();
        }

        private void StopRecording()
        {
            lock (_controllerLock)
            {
                if (_controller.IsRecording)
                {
                    _controller.StopRecording();
                }
                else
                {
                    return;
                }
            }

            AppendOneLineLogMessage("Stopped recording.");

            SetButtonsState();
        }

        private void StartStatistics()
        {
            bool actuallyStarted = false;
            ulong stopCount = 0;
            if (checkBoxAutoStopStatistics.Checked)
            {
                stopCount = (ulong)numericUpDownAutoStopStatisticsCount.Value;
            }

            lock (_controllerLock)
            {

                if (_controller == null)
                {
                    AppendOneLineLogMessage("Not connected. Cannot start statistics.");
                    return;
                }

                if (!_controller.IsStatisticsOngoing) {
                    _controller.StartStatistics(stopCount);
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

            SetButtonsState();
        }

        private void StopStatistics()
        {
            bool actuallyStopped = false;

            lock (_controllerLock)
            {
                if (_controller != null && _controller.IsStatisticsOngoing)
                {
                    _controller.StopStatistics();
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

            SetButtonsState();
        }

        private void SetButtonsState()
        {
            SetRecordingButtonsState();
            SetStatisticsButtonsState();
        }

        private void SetRecordingButtonsState()
        {
            bool isRecording = false;
            lock (_controllerLock)
            {
                if (_controller != null)
                {
                    isRecording = _controller.IsRecording;
                }
            }

            if (!_connected)
            {
                buttonStartRecording.Enabled = false;
                buttonStopRecording.Enabled = false;
                buttonRecordingSettings.Enabled = true;
            }
            else if (!isRecording)
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
            bool isStatisticsOngoing = false;
            lock (_controllerLock)
            {
                if (_controller != null)
                {
                    isStatisticsOngoing = _controller.IsStatisticsOngoing;
                }
            }

            if (!_connected)
            {
                buttonStartStatistics.Enabled = false;
                buttonStopStatistics.Enabled = false;
                buttonResetStatistics.Enabled = false;
                checkBoxAutoStopStatistics.Enabled = true;
                numericUpDownAutoStopStatisticsCount.Enabled = checkBoxAutoStopStatistics.Checked;
            }
            else if (isStatisticsOngoing)
            {
                buttonStartStatistics.Enabled = false;
                buttonStopStatistics.Enabled = true;
                buttonResetStatistics.Enabled = true;
                checkBoxAutoStopStatistics.Enabled = false;
                numericUpDownAutoStopStatisticsCount.Enabled = false;
            }
            else
            {
                buttonStartStatistics.Enabled = true;
                buttonStopStatistics.Enabled = false;
                buttonResetStatistics.Enabled = false;
                checkBoxAutoStopStatistics.Enabled = true;
                numericUpDownAutoStopStatisticsCount.Enabled = checkBoxAutoStopStatistics.Checked;
            }
        }
        */
        private void AppendOneLineLogMessage(String message)
        {
            textBoxStatus.AppendText(message + Environment.NewLine);
        }

        public void ConnectionStateChanged(ConnectionState newState)
        {
            AppendOneLineLogMessage("Connection state: " + newState);
            _connectionState = newState;
            SetButtonsState();
            SetConnectionStatus();

            if (newState == ConnectionState.Connected)
            {
                // Show product type, serial number, firmware and configuration
                ConnectionInfo info = _controller.ConnectionInfo;

                string productType = info.ProductType;
                AppendOneLineLogMessage(String.Format("Product Type: {0}", productType));
                if (productType != "QSB-D")
                {
                    AppendOneLineLogMessage(String.Format("Warning: this application was not tested with '{0}'.", productType));
                }

                AppendOneLineLogMessage(String.Format("Serial Number: {0}", info.SerialNumber));
                AppendOneLineLogMessage(String.Format("Firmware Version: {0}", info.FirmwareVersion));
                AppendOneLineLogMessage(String.Format("Quadrature Mode: {0}", info.QuadratureMode));
                AppendOneLineLogMessage(String.Format("Encoder Direction: {0}", info.EncoderDirection));
                AppendOneLineLogMessage(String.Format("Encoder resolution: {0} nm/count", _controller.ResolutionInNanometers.ToString("0.00")));
                AppendOneLineLogMessage("Set the encoder zero position count: " + _controller.ZeroPositionCount);
            }
        }

        private void SetButtonsState()
        {
            switch (_connectionState)
            {
                case ConnectionState.Connecting:
                    buttonConnect.Enabled = false;
                    buttonDisconnect.Enabled = false;
                    buttonSetZero.Enabled = false;
                    break;
                case ConnectionState.Connected:
                    buttonConnect.Enabled = false;
                    buttonDisconnect.Enabled = true;
                    buttonSetZero.Enabled = true;
                    break;
                case ConnectionState.Disconnecting:
                    buttonConnect.Enabled = false;
                    buttonDisconnect.Enabled = false;
                    buttonSetZero.Enabled = false;
                    break;
                case ConnectionState.Disconnected:
                    buttonConnect.Enabled = true;
                    buttonDisconnect.Enabled = false;
                    buttonSetZero.Enabled = false;
                    break;
            }
        }

        public void SetConnectionStatus()
        {
            textBoxConnectionState.Text = _connectionState.ToString();

            if (_connectionState == ConnectionState.Connected)
            {
                pictureBoxConnectionState.Image = Util.ResizeIconForErrorProvider(SystemIcons.Information).ToBitmap();

                ConnectionInfo info = _controller.ConnectionInfo;
                textBoxProductType.Text = info.ProductType;
                textBoxSerialNumber.Text = info.SerialNumber.ToString();
                textBoxFirmwareVersion.Text = info.FirmwareVersion.ToString();
                textBoxCOMPort.Text = info.PortName;
                textBoxBaudRate.Text = info.BaudRate.ToString();
                textBoxQuadratureMode.Text = info.QuadratureMode.ToString();
                textBoxDirection.Text = info.EncoderDirection.ToString();
                textBoxResolution.Text = _controller.ResolutionInNanometers.ToString("0.00") + " nm/count";
                textBoxZeroPositionCount.Text = _controller.ZeroPositionCount.ToString();
            }
            else
            {
                if (_connectionState == ConnectionState.Connecting || _connectionState == ConnectionState.Disconnecting)
                {
                    pictureBoxConnectionState.Image = Util.ResizeIconForErrorProvider(SystemIcons.Warning).ToBitmap();
                }
                else
                {
                    pictureBoxConnectionState.Image = Util.ResizeIconForErrorProvider(SystemIcons.Error).ToBitmap();
                }

                textBoxProductType.Text = "";
                textBoxSerialNumber.Text = "";
                textBoxFirmwareVersion.Text = "";
                textBoxCOMPort.Text = "";
                textBoxBaudRate.Text = "";
                textBoxQuadratureMode.Text = "";
                textBoxDirection.Text = "";
                textBoxResolution.Text = "";
                textBoxZeroPositionCount.Text = "";
            }
        }

        private bool Connect(
            String portName,
            int baudRate,
            QuadratureMode quadratureMode,
            decimal resolution_nm,
            int zeroPositionCount,
            EncoderDirection encoderDirection)
        {
            AppendOneLineLogMessage(String.Format("Connecting to an US Digital QSB Encoder Reader via '{0}' (baud rate: {1}).", portName, baudRate));

            try
            {
                _controller.Connect(portName, baudRate, quadratureMode, encoderDirection, zeroPositionCount, resolution_nm);
            }
            catch (Exception e)
            {
                AppendOneLineLogMessage("FALIED TO CONNECT!!!");
                AppendOneLineLogMessage(e.Message);
                return false;
            }

            return true;
        }

        private void Disconnect()
        {
            try
            {
                _controller.Disconnect();
            }
            catch (Exception e)
            {
                AppendOneLineLogMessage("FALIED TO DISCONNECT!!!");
                AppendOneLineLogMessage(e.Message);
            }
        }

        private void Zero()
        {
            int newZeroPositionCount = _controller.Zero();

            AppendOneLineLogMessage("Set the encoder zero position count: " + newZeroPositionCount);
            textBoxZeroPositionCount.Text = newZeroPositionCount.ToString();
            UpdateEncoderReadingDisplay();
        }

        private void UpdateEncoderReadingDisplay()
        {
            labelEncoderReading.Text = _controller.CurrentPositionInMillimeters.ToString("0.000000");
        }

        private void UpdateStatisticsDisplay()
        {
            // TODO: implement
            /*
            ulong numberOfSamples = 0;
            decimal duration_s = 0.0M;
            decimal average_mm = 0.0M;
            decimal stdev_mm = 0.0M;
            decimal maximum_mm = 0.0M;
            decimal minimum_mm = 0.0M;
            decimal peak_to_peak_mm = 0.0M;

            lock (_controllerLock)
            {
                if (_controller != null)
                {
                    (numberOfSamples, duration_s, average_mm, stdev_mm, maximum_mm, minimum_mm) = _controller.GetStatistics();
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
            textBoxStdev.Text = stdev_mm.ToString("F6");
            textBoxMaximum.Text = maximum_mm.ToString("F6");
            textBoxMinimum.Text = minimum_mm.ToString("F6");
            textBoxPeakToPeak.Text = peak_to_peak_mm.ToString("F6");
            */
        }
    }
}
