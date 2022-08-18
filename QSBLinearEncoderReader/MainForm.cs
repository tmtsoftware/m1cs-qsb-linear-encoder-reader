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
        private bool _connected;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (_qsb == null)
            {
                _qsb = new QSB_D();
            }

            // TODO: remove the hard-coded COM port name.
            connect("COM6");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_connected)
            {
                disconnect();
            }
        }

        private void timerEncoderReaderLoop_Tick(object sender, EventArgs e)
        {
            if (_connected)
            {
                try
                {
                    int count = (int)_qsb.GetCount();
                    double displacement = (count - _zeroCount) * _resolution_mm;
                    labelEncoderReading.Text = displacement.ToString("000.000000");
                }
                catch (Exception ex)
                {
                    disconnect();
                }
            }
        }

        private void connect(String portName)
        {
            textBoxStatus.AppendText("Connecting to an US Digital QSB-D Encoder Reader via " + portName + " ... ");
            _qsb.Open(portName);
            textBoxStatus.AppendText("OK" + Environment.NewLine);
            _connected = true;
            timerEncoderReaderLoop.Enabled = true;
        }

        private void disconnect()
        {
            timerEncoderReaderLoop.Enabled = false;
            _connected = false;
            _qsb.Close();
            textBoxStatus.AppendText("Disconnected from the US Digital QSB-D Encoder Reader." + Environment.NewLine);
        }

    }
}
