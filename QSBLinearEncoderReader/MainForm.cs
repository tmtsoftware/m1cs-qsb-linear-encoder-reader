using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using USDigital;

namespace QSBLinearEncoderReader
{
    public partial class MainForm : Form
    {
        private object _controllerLock = new object();
        private DeviceController _controller = null;

        public MainForm()
        {
            InitializeComponent();
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
                connect(
                    connectDialog.PortName,
                    connectDialog.QuadratureMode,
                    connectDialog.Resolution_nm,
                    connectDialog.ZeroPositionCount,
                    connectDialog.Direction);

                // Save the successful configuration values as the default settings.
                if (IsConnected)
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
            disconnect();
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
        }

        private void updateEncoderReadingDisplay()
        {
            // TODO: implement
        }

        private void zero()
        {
            // TODO: implement
        }

        private void connect(
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
                if (IsConnected)
                {
                    return;
                }

                textBoxStatus.AppendText("Connecting to an US Digital QSB-D Encoder Reader via " + portName + " ... ");

                try
                {
                    // TODO: use resoultion_nm and zeroPositionCount

                    // TODO: make the baud rate configurable
                    _controller = new DeviceController(portName, 230400, quadratureMode, direction);
                    _controller.Connect();
                }
                catch (Exception e)
                {
                    // TODO: handle exception
                    _controller = null;
                    failed = true;
                    failureMessage = e.Message;
                }
            }

            if (failed)
            {
                appendOneLineLogMessage("FALIED!!!");
                appendOneLineLogMessage(failureMessage);
                return;
            }

            appendOneLineLogMessage("OK");

            // Enable buttons that can be clicked when connected.
            buttonSetZero.Enabled = true;
            buttonStartRecording.Enabled = true;
            buttonDisconnect.Enabled = true;

            // Disable the button that cannot be clicked when connected.
            buttonConnect.Enabled = false;
        }

        private bool IsConnected
        {
            get
            {
                lock (_controllerLock)
                {
                    return _controller != null;
                }
            }
        }

        private void disconnect()
        {
            lock (_controllerLock)
            {
                if (!IsConnected)
                {
                    return;
                }

                // TODO: stop recording if the recording is in progress

                _controller.Disconnect();
                _controller = null;
            }

            appendOneLineLogMessage("Disconnected from the US Digital QSB-D Encoder Reader.");

            // Disable buttons that cannot be clicked when disconnected.
            buttonSetZero.Enabled = false;
            buttonStartRecording.Enabled = false;
            buttonDisconnect.Enabled = false;

            // Disable the button that can be clicked when disconnected.
            buttonConnect.Enabled = true;
        }

        private void startRecording(String fileName)
        {
            // TODO: confirm that the device is not recording

            // TODO: start recording

            // TODO: add a log message

            buttonStartRecording.Enabled = false;
            buttonStopRecording.Enabled = true;
        }

        private void stopRecording()
        {
            // TODO: confirm that the device is recording

            // TODO: stop recording

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
