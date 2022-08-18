using System;
using System.Windows.Forms;
using USDigital;

namespace QSBLinearEncoderReader
{
    public partial class MainForm : Form
    {
        private QSB_D _qsb;
        private double _resolution_mm = 0.000005;
        private int _zeroCount = 0;
        private int _latestCount = 0;
        private bool _connected = false;

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

        private void timerEncoderReaderLoop_Tick(object sender, EventArgs e)
        {
            updateEncoderReadingDisplay();
        }

        private void updateEncoderReadingDisplay()
        {
            try
            {
                _latestCount = (int)_qsb.GetCount();
                double displacement = (_latestCount - _zeroCount) * _resolution_mm;
                labelEncoderReading.Text = displacement.ToString("000.000000");
            }
            catch (Exception ex)
            {
                disconnect();
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

            _resolution_mm = 0.000005;
            appendOneLineLogMessage("Encoder resolution: " + _resolution_mm.ToString("0.000000") + " mm/count");

            _zeroCount = 0;
            appendOneLineLogMessage("Encoder count for zero position: " + _zeroCount);

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

        private void appendOneLineLogMessage(String message)
        {
            textBoxStatus.AppendText(message + Environment.NewLine);
        }

    }
}
