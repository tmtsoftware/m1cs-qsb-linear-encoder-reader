using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
using USDigital;

namespace QSBLinearEncoderReader
{
    public partial class ConnectForm : Form
    {
        private BaudRateOption[] _baudRateOptions = new BaudRateOption[]
        {
                new BaudRateOption(SerialPortGuard.BaudRateCode.Baud9600),
                new BaudRateOption(SerialPortGuard.BaudRateCode.Baud19200),
                new BaudRateOption(SerialPortGuard.BaudRateCode.Baud38400),
                new BaudRateOption(SerialPortGuard.BaudRateCode.Baud56000),
                new BaudRateOption(SerialPortGuard.BaudRateCode.Baud115200),
                new BaudRateOption(SerialPortGuard.BaudRateCode.Baud128000),
                new BaudRateOption(SerialPortGuard.BaudRateCode.Baud230400),
                new BaudRateOption(SerialPortGuard.BaudRateCode.Baud256000),
        };

        private QuadratureModeOption[] _quadratureModeOptions = new QuadratureModeOption[]
        {
                new QuadratureModeOption(QuadratureMode.X1, "x1 (one count per quadrature cycle)"),
                new QuadratureModeOption(QuadratureMode.X2, "x2 (two counts per quadrature cycle)"),
                new QuadratureModeOption(QuadratureMode.X4, "x4 (four counts per quadrature cycle)"),
        };

        private EncoderDirectionOption[] _encoderDirectionOptions = new EncoderDirectionOption[]
        {
                new EncoderDirectionOption(EncoderDirection.CountingUp, "Positive"),
                new EncoderDirectionOption(EncoderDirection.CountingDown, "Negative"),
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
            comboBoxCOMPort.DataSource = availablePortNames;
            comboBoxCOMPort.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void populateBaudRateComboBox()
        {
            comboBoxBaudRate.DataSource = _baudRateOptions;
            comboBoxBaudRate.DisplayMember = "BaudRate";
            comboBoxBaudRate.ValueMember = "BaudRateCode";
            comboBoxBaudRate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBaudRate.SelectedValue = SerialPortGuard.BaudRateCode.Baud230400;
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
            comboBoxDirection.SelectedValue = EncoderDirection.CountingUp;
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

            // Baud rate setting
            comboBoxBaudRate.SelectedItem = SerialPortGuard.BaudRateCode.Baud230400;
            foreach (BaudRateOption baudRateOption in _baudRateOptions)
            {
                if (baudRateOption.BaudRate == Properties.Settings.Default.BaudRate)
                {
                    comboBoxBaudRate.SelectedItem = baudRateOption;
                    break;
                }
            }

            // Other settings
            comboBoxQuadratureMode.SelectedValue = Properties.Settings.Default.QuadratureMode;
            numericUpDownResolution.Value = Properties.Settings.Default.Resolution_nm;
            numericUpDownZeroPositionCount.Value = Properties.Settings.Default.ZeroPositionCount;
            comboBoxDirection.SelectedValue = Properties.Settings.Default.Direction;
        }


        public string PortName
        {
            get { return comboBoxCOMPort.Text; }
        }

        public SerialPortGuard.BaudRateCode BaudRateCode
        {
            get { return (SerialPortGuard.BaudRateCode)comboBoxBaudRate.SelectedValue; }
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
        private SerialPortGuard.BaudRateCode _baudRateCode;

        public BaudRateOption(SerialPortGuard.BaudRateCode baudRateCode)
        {
            _baudRateCode = baudRateCode;
        }

        public SerialPortGuard.BaudRateCode BaudRateCode
        {
            get { return _baudRateCode; }
        }

        public int BaudRate
        {
            get { return SerialPortGuard.GetBaudRateFromCode(_baudRateCode); }
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
