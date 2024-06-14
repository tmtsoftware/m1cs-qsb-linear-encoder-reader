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
            List<string> errMsgs = new List<string>();

            // Validate the output directory path.
            string outputDir = textBoxOutputDirectory.Text;
            try
            {
                string outputDirFull = Path.GetFullPath(outputDir);
                if (!outputDir.Equals(outputDirFull))
                {
                    errMsgs.Add("Output directory \"" + outputDir + "\" is not a full path.");
                }
                else if (File.Exists(outputDir))
                {
                    errMsgs.Add("\"" + outputDir + "\" is a file, not a directory.");
                }
            }
            catch (Exception ex)
            {
                errMsgs.Add("Output directory \"" + outputDir + "\" is invalid. " + ex.Message);
            }

            if (errMsgs.Count > 0)
            {
                string fullErrMsg = String.Join(Environment.NewLine, errMsgs.ToArray());
                MessageBox.Show(fullErrMsg, "Invalid settings", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Prevent the dialog from being closed.
                this.DialogResult = DialogResult.None;
            }
        }

        private void buttonSelectDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Select the folder to which you want to save CSV files";
            dialog.ShowNewFolderButton = true;
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxOutputDirectory.Text = dialog.SelectedPath;
            }
        }
    }
}

