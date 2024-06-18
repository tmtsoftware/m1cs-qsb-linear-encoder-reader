using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QSBLinearEncoderReader
{
    public partial class MainForm : Form, IConnectionStatusListener, IEncoderCountListener
    {
        private DeviceController _controller = null;
        private ConnectionStatus _connectionStatus = new ConnectionStatus();
        private EncoderCount _encoderCount = new EncoderCount();
        private int _previousTextBoxStatusHeight = 125;

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
            SetConnectionStatus(new ConnectionStatus());
            SetEncoderCount(new EncoderCount());
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
                    connectDialog.Direction,
                    connectDialog.DisplayUpdateInterval);

                // Save the successful configuration values as the default settings.
                if (connected)
                {
                    Properties.Settings.Default.PortName = connectDialog.PortName;
                    Properties.Settings.Default.BaudRate = connectDialog.BaudRate;
                    Properties.Settings.Default.QuadratureMode = connectDialog.QuadratureMode;
                    Properties.Settings.Default.Resolution_nm = connectDialog.Resolution_nm;
                    Properties.Settings.Default.ZeroPositionCount = connectDialog.ZeroPositionCount;
                    Properties.Settings.Default.Direction = connectDialog.Direction;
                    Properties.Settings.Default.DisplayUpdateInterval = connectDialog.DisplayUpdateInterval;
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

        private void pictureBoxExpandConnectionStatus_Click(object sender, EventArgs e)
        {
            if (groupBoxConnectionStatus.Visible)
            {
                groupBoxConnectionStatus.Visible = false;
                this.MinimumSize = new Size(this.MinimumSize.Width, this.MinimumSize.Height - groupBoxConnectionStatus.Size.Height);
                this.Size = new Size(this.Size.Width, this.Size.Height - groupBoxConnectionStatus.Size.Height);
            }
            else
            {
                groupBoxConnectionStatus.Visible = true;
                this.Size = new Size(this.Size.Width, this.Size.Height + groupBoxConnectionStatus.Size.Height);
                this.MinimumSize = new Size(this.MinimumSize.Width, this.MinimumSize.Height + groupBoxConnectionStatus.Size.Height);
            }

            SetButtonsState();
        }

        private void pictureBoxExpandRecording_Click(object sender, EventArgs e)
        {
            if (groupBoxRecording.Visible)
            {
                groupBoxRecording.Visible = false;
                this.MinimumSize = new Size(this.MinimumSize.Width, this.MinimumSize.Height - groupBoxRecording.Size.Height);
                this.Size = new Size(this.Size.Width, this.Size.Height - groupBoxRecording.Size.Height);
            }
            else
            {
                groupBoxRecording.Visible = true;
                this.Size = new Size(this.Size.Width, this.Size.Height + groupBoxRecording.Size.Height);
                this.MinimumSize = new Size(this.MinimumSize.Width, this.MinimumSize.Height + groupBoxRecording.Size.Height);
            }

            SetButtonsState();
        }

        private void pictureBoxExpandStatistics_Click(object sender, EventArgs e)
        {
            if (groupBoxStatistics.Visible)
            {
                groupBoxStatistics.Visible = false;
                this.MinimumSize = new Size(this.MinimumSize.Width, this.MinimumSize.Height - groupBoxStatistics.Size.Height);
                this.Size = new Size(this.Size.Width, this.Size.Height - groupBoxStatistics.Size.Height);
            }
            else
            {
                groupBoxStatistics.Visible = true;
                this.Size = new Size(this.Size.Width, this.Size.Height + groupBoxStatistics.Size.Height);
                this.MinimumSize = new Size(this.MinimumSize.Width, this.MinimumSize.Height + groupBoxStatistics.Size.Height);
            }

            SetButtonsState();
        }

        private void pictureBoxExpandStatus_Click(object sender, EventArgs e)
        {
            if (textBoxStatus.Visible)
            {
                _previousTextBoxStatusHeight = textBoxStatus.Size.Height;
                textBoxStatus.Visible = false;
                this.MinimumSize = new Size(this.MinimumSize.Width, this.MinimumSize.Height - _previousTextBoxStatusHeight);
                this.Size = new Size(this.Size.Width, this.Size.Height - _previousTextBoxStatusHeight);
            }
            else
            {
                textBoxStatus.Visible = true;
                this.Size = new Size(this.Size.Width, this.Size.Height + _previousTextBoxStatusHeight);
                this.MinimumSize = new Size(this.MinimumSize.Width, this.MinimumSize.Height + _previousTextBoxStatusHeight);
            }

            SetButtonsState();
        }

        private void AppendOneLineLogMessage(String message)
        {
            textBoxStatus.AppendText(message + Environment.NewLine);
        }

        public void ConnectionStatusChanged(ConnectionStatus newStatus)
        {
            if (this.InvokeRequired)
            {
                Action action = delegate { SetConnectionStatus(newStatus); };
                this.Invoke(action);
            }
            else
            {
                SetConnectionStatus(newStatus);
            }
        }

        public void SetConnectionStatus(ConnectionStatus status)
        {
            AppendOneLineLogMessage("Connection state: " + status.ConnectionState);

            textBoxConnectionState.Text = status.ConnectionState.ToString();

            if (status.ConnectionState == ConnectionState.Connected)
            {
                pictureBoxConnectionState.Image = Properties.Resources.check_circle_solid;

                textBoxProductType.Text = status.ProductType;
                textBoxSerialNumber.Text = status.SerialNumber.ToString();
                textBoxFirmwareVersion.Text = status.FirmwareVersion.ToString();
                textBoxCOMPort.Text = status.PortName;
                textBoxBaudRate.Text = status.BaudRate.ToString();
                textBoxQuadratureMode.Text = status.QuadratureMode.ToString();
                textBoxDirection.Text = status.EncoderDirection.ToString();

                AppendOneLineLogMessage(String.Format("Product Type: {0}", status.ProductType));
                if (status.ProductType != "QSB-D")
                {
                    AppendOneLineLogMessage(String.Format("Warning: this application was not tested with '{0}'.", status.ProductType));
                }

                AppendOneLineLogMessage(String.Format("Serial Number: {0}", status.SerialNumber));
                AppendOneLineLogMessage(String.Format("Firmware Version: {0}", status.FirmwareVersion));
                AppendOneLineLogMessage(String.Format("Quadrature Mode: {0}", status.QuadratureMode));
                AppendOneLineLogMessage(String.Format("Encoder Direction: {0}", status.EncoderDirection));
            }
            else
            {
                if (status.ConnectionState == ConnectionState.Connecting
                    || status.ConnectionState == ConnectionState.Disconnecting)
                {
                    pictureBoxConnectionState.Image = Properties.Resources.refresh_circle_solid;
                }
                else
                {
                    pictureBoxConnectionState.Image = Properties.Resources.minus_circle_solid;
                }

                textBoxProductType.Text = "";
                textBoxSerialNumber.Text = "";
                textBoxFirmwareVersion.Text = "";
                textBoxCOMPort.Text = "";
                textBoxBaudRate.Text = "";
                textBoxQuadratureMode.Text = "";
                textBoxDirection.Text = "";
            }

            _connectionStatus = status;
            SetButtonsState();
        }

        public void EncoderCountChanged(EncoderCount newCount)
        {
            if (this.InvokeRequired)
            {
                Action action = delegate { SetEncoderCount(newCount); };
                this.Invoke(action);
            }
            else
            {
                SetEncoderCount(newCount);
            }
        }

        public void SetEncoderCount(EncoderCount newCount)
        {
            labelEncoderReading.Text = newCount.PositionInMillimeters.ToString("F6");
            textBoxResolution.Text = newCount.ResolutionInNanometers + " nm/count";
            textBoxZeroPositionCount.Text = newCount.ZeroPositionCount.ToString();

            EncoderCountStatistics stats = newCount.Statistics;
            textBoxNumberOfSamples.Text = stats.NumberOfSamples.ToString();
            textBoxDuration.Text = stats.DurationInSeconds.ToString("F3");
            textBoxAverage.Text = stats.AverageInMillimeters.ToString("F6");
            textBoxStdev.Text = stats.StdevInMillimeters.ToString("F6");
            textBoxMaximum.Text = stats.MaximumInMillimeters.ToString("F6");
            textBoxMinimum.Text = stats.MinimumInMillimeters.ToString("F6");

            decimal p2p_mm = stats.MaximumInMillimeters - stats.MinimumInMillimeters;
            textBoxPeakToPeak.Text = p2p_mm.ToString("F6");

            if (_encoderCount.Statistics.State != newCount.Statistics.State)
            {
                if (newCount.Statistics.State == StatisticsState.Ongoing)
                {
                    AppendOneLineLogMessage("Started statistics");
                }
                else if (newCount.Statistics.State == StatisticsState.Stopped)
                {
                    AppendOneLineLogMessage("Stopped statistics");
                }
            }

            _encoderCount = newCount;
            SetButtonsState();
        }

        private void SetButtonsState()
        {
            switch (_connectionStatus.ConnectionState)
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
                    switch (_encoderCount.Statistics.State)
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

            pictureBoxExpandConnectionStatus.Image = groupBoxConnectionStatus.Visible ? Properties.Resources.nav_arrow_down : Properties.Resources.nav_arrow_right;
            pictureBoxExpandRecording.Image = groupBoxRecording.Visible ? Properties.Resources.nav_arrow_down : Properties.Resources.nav_arrow_right;
            pictureBoxExpandStatistics.Image = groupBoxStatistics.Visible ? Properties.Resources.nav_arrow_down : Properties.Resources.nav_arrow_right;
            pictureBoxExpandStatus.Image = textBoxStatus.Visible ? Properties.Resources.nav_arrow_down : Properties.Resources.nav_arrow_right;
        }

        private bool Connect(
            String portName,
            int baudRate,
            QuadratureMode quadratureMode,
            decimal resolution_nm,
            int zeroPositionCount,
            EncoderDirection encoderDirection,
            ulong displayUpdateInterval)
        {
            AppendOneLineLogMessage(String.Format("Connecting to an US Digital QSB Encoder Reader via '{0}' (baud rate: {1}).", portName, baudRate));

            try
            {
                ulong numberOfSamplesToStopStatistics = EncoderCountProcessor.Indefinite;
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
                    numberOfSamplesToStopStatistics,
                    displayUpdateInterval);
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
        }

        public void StartStatistics()
        {
            ulong numberOfSamplesToStopStatistics = EncoderCountProcessor.Indefinite;
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
            AppendOneLineLogMessage("Reset statistics");
        }
    }
}
