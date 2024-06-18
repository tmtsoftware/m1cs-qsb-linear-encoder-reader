using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace QSBLinearEncoderReader
{
    public partial class MainForm : Form, IConnectionStateListener, IStatisticsStateListener
    {
        private DeviceController _controller = null;
        private ConnectionState _connectionState = ConnectionState.Disconnected;
        private StatisticsState _statisticsState = StatisticsState.Stopped;

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

            _controller = new DeviceController(this, this);
            _connectionState = ConnectionState.Disconnected;
            _statisticsState = StatisticsState.Stopped;
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
            StartStatistics();
        }

        private void buttonStopStatistics_Click(object sender, EventArgs e)
        {
            StopStatistics();
        }

        private void buttonResetStatistics_Click(object sender, EventArgs e)
        {
            ResetStatistics();
        }

        private void checkBoxAutoStopStatistics_CheckedChanged(object sender, EventArgs e)
        {
            SetButtonsState();
        }
        private void timerDisplayUpdateLoop_Tick(object sender, EventArgs e)
        {
            UpdateEncoderReadingDisplay();
            UpdateStatisticsDisplay();
        }

        private void AppendOneLineLogMessage(String message)
        {
            textBoxStatus.AppendText(message + Environment.NewLine);
        }

        public void ConnectionStateChanged(ConnectionState newState)
        {
            if (this.InvokeRequired)
            {
                Action action = delegate { _ConnectionStateChanged(newState); };
                this.Invoke(action);
            }
            else
            {
                _ConnectionStateChanged(newState);
            }
        }

        private void _ConnectionStateChanged(ConnectionState newState)
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
                    buttonStartStatistics.Enabled = false;
                    buttonStopStatistics.Enabled = false;
                    buttonResetStatistics.Enabled = false;
                    break;
                case ConnectionState.Connected:
                    buttonConnect.Enabled = false;
                    buttonDisconnect.Enabled = true;
                    buttonSetZero.Enabled = true;
                    switch (_statisticsState)
                    {
                        case StatisticsState.Ongoing:
                            buttonStartStatistics.Enabled = false;
                            buttonStopStatistics.Enabled = true;
                            buttonResetStatistics.Enabled = true;
                            checkBoxAutoStopStatistics.Enabled = false;
                            numericUpDownAutoStopStatisticsCount.Enabled = false;
                            break;
                        case StatisticsState.Stopped:
                            buttonStartStatistics.Enabled = true;
                            buttonStopStatistics.Enabled = false;
                            buttonResetStatistics.Enabled = false;
                            checkBoxAutoStopStatistics.Enabled = true;
                            numericUpDownAutoStopStatisticsCount.Enabled = checkBoxAutoStopStatistics.Checked;
                            break;
                    }
                    break;
                case ConnectionState.Disconnecting:
                    buttonConnect.Enabled = false;
                    buttonDisconnect.Enabled = false;
                    buttonSetZero.Enabled = false;
                    buttonStartStatistics.Enabled = false;
                    buttonStopStatistics.Enabled = false;
                    buttonResetStatistics.Enabled = false;
                    break;
                case ConnectionState.Disconnected:
                    buttonConnect.Enabled = true;
                    buttonDisconnect.Enabled = false;
                    buttonSetZero.Enabled = false;
                    buttonStartStatistics.Enabled = false;
                    buttonStopStatistics.Enabled = false;
                    buttonResetStatistics.Enabled = false;
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
                ulong numberOfSamplesToStopStatistics = EncoderCountStatistics.Indefinite;
                if (checkBoxAutoStopStatistics.Checked)
                {
                    numberOfSamplesToStopStatistics = (ulong)numericUpDownAutoStopStatisticsCount.Value;
                }

                _controller.Connect(
                    portName,
                    baudRate,
                    quadratureMode,
                    encoderDirection,
                    zeroPositionCount,
                    resolution_nm,
                    numberOfSamplesToStopStatistics);
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
            UpdateStatisticsDisplay();
        }

        public void StartStatistics()
        {
            ulong numberOfSamplesToStopStatistics = EncoderCountStatistics.Indefinite;
            if (checkBoxAutoStopStatistics.Checked)
            {
                numberOfSamplesToStopStatistics = (ulong)numericUpDownAutoStopStatisticsCount.Value;
            }

            _controller.StartStatistics(numberOfSamplesToStopStatistics);
        }

        public void StopStatistics()
        {
            _controller.StopStatistics();
        }

        public void ResetStatistics()
        {
            _controller.ResetStatistics();
        }

        private void UpdateEncoderReadingDisplay()
        {
            labelEncoderReading.Text = _controller.CurrentPositionInMillimeters.ToString("0.000000");
        }

        private void UpdateStatisticsDisplay()
        {
            ulong numberOfSamples = 0;
            decimal duration_s = 0.0M;
            decimal average_mm = 0.0M;
            decimal stdev_mm = 0.0M;
            decimal maximum_mm = 0.0M;
            decimal minimum_mm = 0.0M;
            decimal p2p_mm = 0.0M;

            _controller.GetCurrentStatistics(
                out numberOfSamples,
                out duration_s,
                out average_mm,
                out stdev_mm,
                out maximum_mm,
                out minimum_mm,
                out p2p_mm);

            textBoxNumberOfSamples.Text = numberOfSamples.ToString();
            textBoxDuration.Text = duration_s.ToString("F3");
            textBoxAverage.Text = average_mm.ToString("F6");
            textBoxStdev.Text = stdev_mm.ToString("F6");
            textBoxMaximum.Text = maximum_mm.ToString("F6");
            textBoxMinimum.Text = minimum_mm.ToString("F6");
            textBoxPeakToPeak.Text = p2p_mm.ToString("F6");
        }

        public void StatisticsStateChanged(StatisticsState newState)
        {
            if (this.InvokeRequired)
            {
                Action action = delegate { _StatisticsStateChanged(newState); };
                this.Invoke(action);
            }
            else
            {
                _StatisticsStateChanged(newState);
            }
        }

        private void _StatisticsStateChanged(StatisticsState newState)
        {
            _statisticsState = newState;
            UpdateStatisticsDisplay();
            SetButtonsState();
        }
    }
}
