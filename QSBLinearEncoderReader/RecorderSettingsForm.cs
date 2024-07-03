using QSBLinearEncoderReader.Properties;
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
    public partial class RecorderSettingsForm : Form
    {
        DateTime _dialogOpenDateTime;

        public RecorderSettingsForm()
        {
            InitializeComponent();
            _dialogOpenDateTime = DateTime.Now;
        }

        private void RecordingSettingsForm_Load(object sender, EventArgs e)
        {
            LoadPreviousSettings();
            CalculateRecordingRate();
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

        private void textBoxOutputDirectory_Validating(object sender, CancelEventArgs e)
        {
            validate();
        }

        private void textBoxOutputDirectory_TextChanged(object sender, EventArgs e)
        {
            validate();
        }

        private void textBoxCSVFilename_Validating(object sender, EventArgs e)
        {
            validate();
        }

        private void textBoxCSVFilename_TextChanged(object sender, EventArgs e)
        {
            validate();
        }

        private void buttonCSVFilenameHelp_Click(object sender, EventArgs e)
        {
            string[] lines =
            {
                "Special character sequences in the filename like \"%Y\" are replaced as shown in the list below:",
                "",
                "  %N: serial number",
                "  %Y: year",
                "  %m: month",
                "  %d: day",
                "  %H: hour",
                "  %M: minute",
                "  %S: second",
                "",
                "It is highly recommended to include the date and time in the file name because the recording stops if the file with the same name already exists."
            };

            MessageBox.Show(
                String.Join(Environment.NewLine, lines),
                "CSV Filename",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void numericUpDownRecordingInterval_ValueChanged(object sender, EventArgs e)
        {
            CalculateRecordingRate();
        }

        private void numericUpDownRecordingInterval_KeyDown(object sender, KeyEventArgs e)
        {
            CalculateRecordingRate();
        }

        private void numericUpDownRecordingInterval_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateRecordingRate();
        }

        private void LoadPreviousSettings()
        {
            textBoxOutputDirectory.Text = Environment.ExpandEnvironmentVariables(Properties.Settings.Default.OutputDirectory);
            textBoxCSVFilename.Text = Properties.Settings.Default.CSVFilename;
            numericUpDownRecordingInterval.Value = Properties.Settings.Default.RecordingInterval;
            numericUpDownMaxRecordsPerFile.Value = Properties.Settings.Default.MaxRecordsPerFile;
            numericUpDownFlushInterval.Value = Properties.Settings.Default.FlushInterval_s;
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.OutputDirectory = textBoxOutputDirectory.Text;
            Properties.Settings.Default.CSVFilename = textBoxCSVFilename.Text;
            Properties.Settings.Default.RecordingInterval = Convert.ToUInt32(numericUpDownRecordingInterval.Value);
            Properties.Settings.Default.MaxRecordsPerFile = Convert.ToUInt32(numericUpDownMaxRecordsPerFile.Value);
            Properties.Settings.Default.FlushInterval_s = Convert.ToUInt32(numericUpDownFlushInterval.Value);
            Properties.Settings.Default.Save();
        }

        private void validate()
        {
            bool valid = ValidateOutputDirectory() && ValidateCSVFilename();
            buttonOK.Enabled = valid;
        }

        private bool ValidateOutputDirectory()
        {
            string outputDir = textBoxOutputDirectory.Text;
            try
            {
                string outputDirFull = Path.GetFullPath(outputDir);
                if (!outputDir.Equals(outputDirFull))
                {
                    errorProviderOutputDirectory.SetError(textBoxOutputDirectory, "Output directory \"" + outputDir + "\" is not a full path.");
                    errorProviderOutputDirectory.Icon = Util.IconError;
                    return false;
                }
                else if (File.Exists(outputDir))
                {
                    errorProviderOutputDirectory.SetError(textBoxOutputDirectory, "\"" + outputDir + "\" is a file, not a directory.");
                    errorProviderOutputDirectory.Icon = Util.IconError;
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorProviderOutputDirectory.SetError(textBoxOutputDirectory, "Output directory \"" + outputDir + "\" is invalid. " + ex.Message);
                errorProviderOutputDirectory.Icon = Util.IconError;
                return false;
            }

            errorProviderOutputDirectory.SetError(textBoxOutputDirectory, String.Empty);
            return true;
        }

        private bool ValidateCSVFilename()
        {
            string filenameBase = textBoxCSVFilename.Text;
            if (filenameBase.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                errorProviderCSVFilename.SetError(textBoxCSVFilename, "CSV file name \"" + filenameBase + "\" includes an invalid character.");
                errorProviderCSVFilename.Icon = Util.IconError;
                textBoxCSVFilenameExample.Text = String.Empty;
                return false;
            }

            if (filenameBase.IndexOf("%Y") < 0 ||
                filenameBase.IndexOf("%m") < 0 ||
                filenameBase.IndexOf("%d") < 0 ||
                filenameBase.IndexOf("%H") < 0 ||
                filenameBase.IndexOf("%M") < 0 ||
                filenameBase.IndexOf("%S") < 0)
            {
                errorProviderCSVFilename.SetError(textBoxCSVFilename, "Please consider including date and time (%Y, %m, %d, %H, %M, %S) because recording stops if the same file name exists.");
                errorProviderCSVFilename.Icon = Util.IconWarning;
            }
            else
            {
                errorProviderCSVFilename.SetError(textBoxCSVFilename, "");
            }

            textBoxCSVFilenameExample.Text = Util.FormatFilename(filenameBase, _dialogOpenDateTime).Replace("%N", "123456");
            return true;
        }

        private void CalculateRecordingRate()
        {
            decimal recordingRate_Hz = Decimal.Divide(512.0m, numericUpDownRecordingInterval.Value);
            labelRecordingRate.Text = String.Format("({0:0.###} Hz)", recordingRate_Hz);
        }
    }
}

