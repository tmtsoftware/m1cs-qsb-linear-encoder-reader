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
    public partial class RecordingSettingsForm : Form
    {
        public RecordingSettingsForm()
        {
            InitializeComponent();
        }

        private void RecordingSettingsForm_Load(object sender, EventArgs e)
        {
            loadPreviousSettings();
        }

        private void loadPreviousSettings()
        {
            textBoxOutputDirectory.Text = Properties.Settings.Default.OutputDirectory;
            textBoxCSVFilename.Text = Properties.Settings.Default.CSVFilename;
            numericUpDownInterval.Value = Properties.Settings.Default.RecordingInterval;
            numericUpDownMaxRecords.Value = Properties.Settings.Default.MaxRecordsPerFile;
            checkBoxRecordAbsoluteTime.Checked = Properties.Settings.Default.RecordAbsoluteTime;
        }
    }
}

