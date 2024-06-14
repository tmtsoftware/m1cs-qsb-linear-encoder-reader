using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            textBoxOutputDirectory.Text = Environment.ExpandEnvironmentVariables(Properties.Settings.Default.OutputDirectory);
            textBoxCSVFilename.Text = Properties.Settings.Default.CSVFilename;
            numericUpDownRecordingInterval.Value = Properties.Settings.Default.RecordingInterval;
            numericUpDownMaxRecordsPerFile.Value = Properties.Settings.Default.MaxRecordsPerFile;
            checkBoxRecordAbsoluteTime.Checked = Properties.Settings.Default.RecordAbsoluteTime;
        }

        public void saveSettings()
        {
            Properties.Settings.Default.OutputDirectory = textBoxOutputDirectory.Text;
            Properties.Settings.Default.CSVFilename = textBoxCSVFilename.Text;
            Properties.Settings.Default.RecordingInterval = Convert.ToInt32(numericUpDownRecordingInterval.Value);
            Properties.Settings.Default.MaxRecordsPerFile = Convert.ToInt32(numericUpDownMaxRecordsPerFile.Value);
            Properties.Settings.Default.RecordAbsoluteTime = checkBoxRecordAbsoluteTime.Checked;
            Properties.Settings.Default.Save();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // TODO: Validate the output directory path.
            string outputDir = textBoxOutputDirectory.Text;
            this.DialogResult = DialogResult.None;
        }
    }
}

