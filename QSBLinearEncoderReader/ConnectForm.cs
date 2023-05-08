using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;

namespace QSBLinearEncoderReader
{
    public partial class ConnectForm : Form
    {
        private BaudRateOption[] _baudRateOptions = new BaudRateOption[]
        {
            new BaudRateOption(9600),
            new BaudRateOption(19200),
            new BaudRateOption(38400),
            new BaudRateOption(56000),
            new BaudRateOption(115200),
            new BaudRateOption(128000),
            new BaudRateOption(230400, "230400 (factory default)"),
            new BaudRateOption(256000),
        };

        private QuadratureModeOption[] _quadratureModeOptions = new QuadratureModeOption[]
        {
                new QuadratureModeOption(QuadratureMode.X1, "x1 (one count per quadrature cycle)"),
                new QuadratureModeOption(QuadratureMode.X2, "x2 (two counts per quadrature cycle)"),
                new QuadratureModeOption(QuadratureMode.X4, "x4 (four counts per quadrature cycle)"),
        };

        private EncoderDirectionOption[] _encoderDirectionOptions = new EncoderDirectionOption[]
        {
                new EncoderDirectionOption(EncoderDirection.CountUp, "Count Up (Positive)"),
                new EncoderDirectionOption(EncoderDirection.CountDown, "Count Down (Negative)"),
        };

        public ConnectForm()
        {
            InitializeComponent();
        }

        private void ConnectForm_Load(object sender, EventArgs e)
        {
            populateCOMPortComboBox();
            populateBaudRateComboBox();
            populateQuadratureModeComboBox();
            populateDirectionComboBox();

            loadPreviousSettings();
        }

        private void populateCOMPortComboBox()
        {
            List<string> availablePortNames = new List<string>();
            foreach (string s in SerialPort.GetPortNames())
            {
                availablePortNames.Add(s);
            }
            availablePortNames.Add("Simulated Device");
            comboBoxCOMPort.DataSource = availablePortNames;
            comboBoxCOMPort.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void populateBaudRateComboBox()
        {
            comboBoxBaudRate.DataSource = _baudRateOptions;
            comboBoxBaudRate.DisplayMember = "DisplayString";
            comboBoxBaudRate.ValueMember = "BaudRate";
            comboBoxBaudRate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBaudRate.SelectedValue = 230400;
        }

        private void populateQuadratureModeComboBox()
        {
            comboBoxQuadratureMode.DataSource = _quadratureModeOptions;
            comboBoxQuadratureMode.DisplayMember = "DisplayString";
            comboBoxQuadratureMode.ValueMember = "Mode";
            comboBoxQuadratureMode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxQuadratureMode.SelectedValue = QuadratureMode.X4;
        }

        private void populateDirectionComboBox()
        {
            comboBoxDirection.DataSource = _encoderDirectionOptions;
            comboBoxDirection.DisplayMember = "DisplayString";
            comboBoxDirection.ValueMember = "Direction";
            comboBoxDirection.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDirection.SelectedValue = EncoderDirection.CountUp;
        }

        private void loadPreviousSettings()
        {
            // Port name setting
            foreach (string availablePortName in comboBoxCOMPort.Items)
            {
                if (availablePortName == Properties.Settings.Default.PortName)
                {
                    comboBoxCOMPort.SelectedItem = Properties.Settings.Default.PortName;
                    break;
                }
            }

            // Other settings
            comboBoxBaudRate.SelectedValue = Properties.Settings.Default.BaudRate;
            comboBoxQuadratureMode.SelectedValue = Properties.Settings.Default.QuadratureMode;
            numericUpDownResolution.Value = Properties.Settings.Default.Resolution_nm;
            numericUpDownZeroPositionCount.Value = Properties.Settings.Default.ZeroPositionCount;
            comboBoxDirection.SelectedValue = Properties.Settings.Default.Direction;
        }

        public string PortName
        {
            get { return comboBoxCOMPort.Text; }
        }

        public int BaudRate
        {
            get { return (int)comboBoxBaudRate.SelectedValue; }
        }

        public QuadratureMode QuadratureMode
        {
            get { return (QuadratureMode)comboBoxQuadratureMode.SelectedValue; }
        }

        public decimal Resolution_nm
        {
            get { return numericUpDownResolution.Value; }
        }

        public int ZeroPositionCount
        {
            get { return (int)numericUpDownZeroPositionCount.Value; }
        }

        public EncoderDirection Direction
        {
            get { return (EncoderDirection)comboBoxDirection.SelectedValue; }
        }
    }
    public class BaudRateOption
    {
        private int _baudRate;
        private string _displayString;

        public BaudRateOption(int baudRate)
        {
            _baudRate = baudRate;
            _displayString = baudRate.ToString();
        }

        public BaudRateOption(int baudRate, string displayString)
        {
            _baudRate = baudRate;
            _displayString = displayString;
        }

        public int BaudRate
        {
            get { return _baudRate; }
        }

        public string DisplayString
        {
            get { return _displayString; }
        }
    }

    public class QuadratureModeOption
    {
        private QuadratureMode _mode;
        private string _displayString;

        public QuadratureModeOption(QuadratureMode mode, string displayString)
        {
            _mode = mode;
            _displayString = displayString;
        }

        public QuadratureMode Mode
        {
            get { return _mode; }
        }

        public string DisplayString
        {
            get { return _displayString; }
        }
    }

    public class EncoderDirectionOption
    {
        private EncoderDirection _direction;
        private string _displayString;

        public EncoderDirectionOption(EncoderDirection direction, string displayString)
        {
            _direction = direction;
            _displayString = displayString;
        }

        public EncoderDirection Direction
        {
            get { return _direction; }
        }

        public string DisplayString
        {
            get { return _displayString; }
        }
    }
}
