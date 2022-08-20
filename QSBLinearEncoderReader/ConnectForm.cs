using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QSBLinearEncoderReader
{
    public partial class ConnectForm : Form
    {
        public ConnectForm()
        {
            InitializeComponent();
        }

        private void ConnectForm_Load(object sender, EventArgs e)
        {
            comboBoxBaudRate.SelectedIndex = 6;
            comboBoxQuadratureMode.SelectedIndex = 2;
            comboBoxDirection.SelectedIndex = 0;
        }
    }
}
