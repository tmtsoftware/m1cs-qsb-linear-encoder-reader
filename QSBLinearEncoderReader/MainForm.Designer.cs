namespace QSBLinearEncoderReader
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.groupBoxRecording = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelRecording = new System.Windows.Forms.TableLayoutPanel();
            this.labelCSVOutputPath = new System.Windows.Forms.Label();
            this.textBoxCSVOutputPath = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelRecordingButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonStartRecording = new System.Windows.Forms.Button();
            this.buttonStopRecording = new System.Windows.Forms.Button();
            this.buttonRecordingSettings = new System.Windows.Forms.Button();
            this.groupBoxStatistics = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelStatistics = new System.Windows.Forms.TableLayoutPanel();
            this.labelNumberOfSamples = new System.Windows.Forms.Label();
            this.labelDuration = new System.Windows.Forms.Label();
            this.labelAverage = new System.Windows.Forms.Label();
            this.checkBoxAutoStopStatistics = new System.Windows.Forms.CheckBox();
            this.textBoxNumberOfSamples = new System.Windows.Forms.TextBox();
            this.labelAutoStopStatistics1 = new System.Windows.Forms.Label();
            this.labelDurationUnit = new System.Windows.Forms.Label();
            this.numericUpDownAutoStopStatisticsCount = new System.Windows.Forms.NumericUpDown();
            this.textBoxDuration = new System.Windows.Forms.TextBox();
            this.labelAutoStopStatistics2 = new System.Windows.Forms.Label();
            this.textBoxAverage = new System.Windows.Forms.TextBox();
            this.labelAverageUnit = new System.Windows.Forms.Label();
            this.flowLayoutPanelStatisticsButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonStartStatistics = new System.Windows.Forms.Button();
            this.buttonStopStatistics = new System.Windows.Forms.Button();
            this.buttonResetStatistics = new System.Windows.Forms.Button();
            this.labelStdev = new System.Windows.Forms.Label();
            this.textBoxStdev = new System.Windows.Forms.TextBox();
            this.labelStdevUnit = new System.Windows.Forms.Label();
            this.labelPeakToPeakUnit = new System.Windows.Forms.Label();
            this.labelMinimumUnit = new System.Windows.Forms.Label();
            this.labelMaximumUnit = new System.Windows.Forms.Label();
            this.textBoxMaximum = new System.Windows.Forms.TextBox();
            this.textBoxMinimum = new System.Windows.Forms.TextBox();
            this.textBoxPeakToPeak = new System.Windows.Forms.TextBox();
            this.labelPeakToPeak = new System.Windows.Forms.Label();
            this.labelMinimum = new System.Windows.Forms.Label();
            this.labelMaximum = new System.Windows.Forms.Label();
            this.groupBoxConnectionStatus = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelConnectionStatus = new System.Windows.Forms.TableLayoutPanel();
            this.labelConnectionState = new System.Windows.Forms.Label();
            this.textBoxConnectionState = new System.Windows.Forms.TextBox();
            this.labelDirection = new System.Windows.Forms.Label();
            this.textBoxDirection = new System.Windows.Forms.TextBox();
            this.labelQuadratureMode = new System.Windows.Forms.Label();
            this.textBoxQuadratureMode = new System.Windows.Forms.TextBox();
            this.labelCOMPort = new System.Windows.Forms.Label();
            this.textBoxCOMPort = new System.Windows.Forms.TextBox();
            this.labelSerialNumber = new System.Windows.Forms.Label();
            this.textBoxSerialNumber = new System.Windows.Forms.TextBox();
            this.textBoxProductType = new System.Windows.Forms.TextBox();
            this.textBoxFirmwareVersion = new System.Windows.Forms.TextBox();
            this.textBoxBaudRate = new System.Windows.Forms.TextBox();
            this.textBoxResolution = new System.Windows.Forms.TextBox();
            this.textBoxZeroPositionCount = new System.Windows.Forms.TextBox();
            this.labelZeroPositionCount = new System.Windows.Forms.Label();
            this.labelResolution = new System.Windows.Forms.Label();
            this.labelBaudRate = new System.Windows.Forms.Label();
            this.labelFirmwareVersion = new System.Windows.Forms.Label();
            this.labelProductType = new System.Windows.Forms.Label();
            this.pictureBoxConnectionState = new System.Windows.Forms.PictureBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.buttonSetZero = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.labelEncoderReadingUnit = new System.Windows.Forms.Label();
            this.labelEncoderReading = new System.Windows.Forms.Label();
            this.pictureBoxExpandConnectionStatus = new System.Windows.Forms.PictureBox();
            this.labelConnectionStatus = new System.Windows.Forms.Label();
            this.pictureBoxExpandRecording = new System.Windows.Forms.PictureBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelRecording = new System.Windows.Forms.Label();
            this.labelStatistics = new System.Windows.Forms.Label();
            this.pictureBoxExpandStatus = new System.Windows.Forms.PictureBox();
            this.pictureBoxExpandStatistics = new System.Windows.Forms.PictureBox();
            this.labelRecordingStatus = new System.Windows.Forms.Label();
            this.textBoxRecordingStatus = new System.Windows.Forms.TextBox();
            this.pictureBoxRecordingStatus = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanelMain.SuspendLayout();
            this.groupBoxRecording.SuspendLayout();
            this.tableLayoutPanelRecording.SuspendLayout();
            this.flowLayoutPanelRecordingButtons.SuspendLayout();
            this.groupBoxStatistics.SuspendLayout();
            this.tableLayoutPanelStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAutoStopStatisticsCount)).BeginInit();
            this.flowLayoutPanelStatisticsButtons.SuspendLayout();
            this.groupBoxConnectionStatus.SuspendLayout();
            this.tableLayoutPanelConnectionStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConnectionState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExpandConnectionStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExpandRecording)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExpandStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExpandStatistics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRecordingStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.ColumnCount = 4;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.Controls.Add(this.textBoxStatus, 0, 11);
            this.tableLayoutPanelMain.Controls.Add(this.groupBoxRecording, 0, 7);
            this.tableLayoutPanelMain.Controls.Add(this.groupBoxStatistics, 0, 9);
            this.tableLayoutPanelMain.Controls.Add(this.groupBoxConnectionStatus, 0, 5);
            this.tableLayoutPanelMain.Controls.Add(this.buttonConnect, 3, 0);
            this.tableLayoutPanelMain.Controls.Add(this.buttonDisconnect, 3, 1);
            this.tableLayoutPanelMain.Controls.Add(this.buttonSetZero, 3, 2);
            this.tableLayoutPanelMain.Controls.Add(this.buttonQuit, 3, 3);
            this.tableLayoutPanelMain.Controls.Add(this.labelEncoderReadingUnit, 2, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelEncoderReading, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.pictureBoxExpandConnectionStatus, 0, 4);
            this.tableLayoutPanelMain.Controls.Add(this.labelConnectionStatus, 1, 4);
            this.tableLayoutPanelMain.Controls.Add(this.pictureBoxExpandRecording, 0, 6);
            this.tableLayoutPanelMain.Controls.Add(this.labelStatus, 1, 10);
            this.tableLayoutPanelMain.Controls.Add(this.labelRecording, 1, 6);
            this.tableLayoutPanelMain.Controls.Add(this.labelStatistics, 1, 8);
            this.tableLayoutPanelMain.Controls.Add(this.pictureBoxExpandStatus, 0, 10);
            this.tableLayoutPanelMain.Controls.Add(this.pictureBoxExpandStatistics, 0, 8);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 12;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(584, 711);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // textBoxStatus
            // 
            this.tableLayoutPanelMain.SetColumnSpan(this.textBoxStatus, 4);
            this.textBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxStatus.Location = new System.Drawing.Point(3, 609);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStatus.Size = new System.Drawing.Size(578, 99);
            this.textBoxStatus.TabIndex = 999;
            this.textBoxStatus.TabStop = false;
            this.textBoxStatus.Resize += new System.EventHandler(this.textBoxStatus_Resize);
            // 
            // groupBoxRecording
            // 
            this.groupBoxRecording.AutoSize = true;
            this.groupBoxRecording.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.SetColumnSpan(this.groupBoxRecording, 4);
            this.groupBoxRecording.Controls.Add(this.tableLayoutPanelRecording);
            this.groupBoxRecording.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxRecording.Location = new System.Drawing.Point(6, 302);
            this.groupBoxRecording.Margin = new System.Windows.Forms.Padding(6, 0, 6, 3);
            this.groupBoxRecording.Name = "groupBoxRecording";
            this.groupBoxRecording.Size = new System.Drawing.Size(572, 106);
            this.groupBoxRecording.TabIndex = 200;
            this.groupBoxRecording.TabStop = false;
            // 
            // tableLayoutPanelRecording
            // 
            this.tableLayoutPanelRecording.AutoSize = true;
            this.tableLayoutPanelRecording.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelRecording.ColumnCount = 3;
            this.tableLayoutPanelRecording.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRecording.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelRecording.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRecording.Controls.Add(this.labelCSVOutputPath, 0, 0);
            this.tableLayoutPanelRecording.Controls.Add(this.textBoxCSVOutputPath, 1, 0);
            this.tableLayoutPanelRecording.Controls.Add(this.flowLayoutPanelRecordingButtons, 0, 2);
            this.tableLayoutPanelRecording.Controls.Add(this.labelRecordingStatus, 0, 1);
            this.tableLayoutPanelRecording.Controls.Add(this.textBoxRecordingStatus, 2, 1);
            this.tableLayoutPanelRecording.Controls.Add(this.pictureBoxRecordingStatus, 1, 1);
            this.tableLayoutPanelRecording.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRecording.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelRecording.Name = "tableLayoutPanelRecording";
            this.tableLayoutPanelRecording.RowCount = 3;
            this.tableLayoutPanelRecording.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRecording.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRecording.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRecording.Size = new System.Drawing.Size(566, 87);
            this.tableLayoutPanelRecording.TabIndex = 0;
            // 
            // labelCSVOutputPath
            // 
            this.labelCSVOutputPath.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelCSVOutputPath.AutoSize = true;
            this.labelCSVOutputPath.Location = new System.Drawing.Point(3, 6);
            this.labelCSVOutputPath.Name = "labelCSVOutputPath";
            this.labelCSVOutputPath.Size = new System.Drawing.Size(128, 13);
            this.labelCSVOutputPath.TabIndex = 999;
            this.labelCSVOutputPath.Text = "Current CSV Output Path:";
            this.labelCSVOutputPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxCSVOutputPath
            // 
            this.textBoxCSVOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelRecording.SetColumnSpan(this.textBoxCSVOutputPath, 2);
            this.textBoxCSVOutputPath.Location = new System.Drawing.Point(137, 3);
            this.textBoxCSVOutputPath.Name = "textBoxCSVOutputPath";
            this.textBoxCSVOutputPath.ReadOnly = true;
            this.textBoxCSVOutputPath.Size = new System.Drawing.Size(426, 20);
            this.textBoxCSVOutputPath.TabIndex = 201;
            // 
            // flowLayoutPanelRecordingButtons
            // 
            this.flowLayoutPanelRecordingButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelRecordingButtons.AutoSize = true;
            this.flowLayoutPanelRecordingButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelRecording.SetColumnSpan(this.flowLayoutPanelRecordingButtons, 3);
            this.flowLayoutPanelRecordingButtons.Controls.Add(this.buttonStartRecording);
            this.flowLayoutPanelRecordingButtons.Controls.Add(this.buttonStopRecording);
            this.flowLayoutPanelRecordingButtons.Controls.Add(this.buttonRecordingSettings);
            this.flowLayoutPanelRecordingButtons.Location = new System.Drawing.Point(3, 55);
            this.flowLayoutPanelRecordingButtons.Name = "flowLayoutPanelRecordingButtons";
            this.flowLayoutPanelRecordingButtons.Size = new System.Drawing.Size(560, 29);
            this.flowLayoutPanelRecordingButtons.TabIndex = 210;
            // 
            // buttonStartRecording
            // 
            this.buttonStartRecording.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartRecording.AutoSize = true;
            this.buttonStartRecording.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonStartRecording.Enabled = false;
            this.buttonStartRecording.Location = new System.Drawing.Point(3, 3);
            this.buttonStartRecording.Name = "buttonStartRecording";
            this.buttonStartRecording.Size = new System.Drawing.Size(91, 23);
            this.buttonStartRecording.TabIndex = 211;
            this.buttonStartRecording.Text = "S&tart Recording";
            this.buttonStartRecording.UseVisualStyleBackColor = true;
            this.buttonStartRecording.Click += new System.EventHandler(this.buttonStartRecording_Click);
            // 
            // buttonStopRecording
            // 
            this.buttonStopRecording.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStopRecording.AutoSize = true;
            this.buttonStopRecording.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonStopRecording.Enabled = false;
            this.buttonStopRecording.Location = new System.Drawing.Point(100, 3);
            this.buttonStopRecording.Name = "buttonStopRecording";
            this.buttonStopRecording.Size = new System.Drawing.Size(91, 23);
            this.buttonStopRecording.TabIndex = 212;
            this.buttonStopRecording.Text = "Stop R&ecording";
            this.buttonStopRecording.UseVisualStyleBackColor = true;
            this.buttonStopRecording.Click += new System.EventHandler(this.buttonStopRecording_Click);
            // 
            // buttonRecordingSettings
            // 
            this.buttonRecordingSettings.Location = new System.Drawing.Point(197, 3);
            this.buttonRecordingSettings.Name = "buttonRecordingSettings";
            this.buttonRecordingSettings.Size = new System.Drawing.Size(75, 23);
            this.buttonRecordingSettings.TabIndex = 213;
            this.buttonRecordingSettings.Text = "Settings...";
            this.buttonRecordingSettings.UseVisualStyleBackColor = true;
            this.buttonRecordingSettings.Click += new System.EventHandler(this.buttonRecordingSettings_Click);
            // 
            // groupBoxStatistics
            // 
            this.groupBoxStatistics.AutoSize = true;
            this.groupBoxStatistics.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.SetColumnSpan(this.groupBoxStatistics, 4);
            this.groupBoxStatistics.Controls.Add(this.tableLayoutPanelStatistics);
            this.groupBoxStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStatistics.Location = new System.Drawing.Point(6, 428);
            this.groupBoxStatistics.Margin = new System.Windows.Forms.Padding(6, 0, 6, 3);
            this.groupBoxStatistics.Name = "groupBoxStatistics";
            this.groupBoxStatistics.Size = new System.Drawing.Size(572, 158);
            this.groupBoxStatistics.TabIndex = 300;
            this.groupBoxStatistics.TabStop = false;
            // 
            // tableLayoutPanelStatistics
            // 
            this.tableLayoutPanelStatistics.AutoSize = true;
            this.tableLayoutPanelStatistics.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelStatistics.ColumnCount = 7;
            this.tableLayoutPanelStatistics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStatistics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelStatistics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelStatistics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStatistics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelStatistics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelStatistics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelStatistics.Controls.Add(this.labelNumberOfSamples, 0, 0);
            this.tableLayoutPanelStatistics.Controls.Add(this.labelDuration, 0, 1);
            this.tableLayoutPanelStatistics.Controls.Add(this.labelAverage, 0, 2);
            this.tableLayoutPanelStatistics.Controls.Add(this.checkBoxAutoStopStatistics, 3, 3);
            this.tableLayoutPanelStatistics.Controls.Add(this.textBoxNumberOfSamples, 1, 0);
            this.tableLayoutPanelStatistics.Controls.Add(this.labelAutoStopStatistics1, 4, 3);
            this.tableLayoutPanelStatistics.Controls.Add(this.labelDurationUnit, 2, 1);
            this.tableLayoutPanelStatistics.Controls.Add(this.numericUpDownAutoStopStatisticsCount, 5, 3);
            this.tableLayoutPanelStatistics.Controls.Add(this.textBoxDuration, 1, 1);
            this.tableLayoutPanelStatistics.Controls.Add(this.labelAutoStopStatistics2, 6, 3);
            this.tableLayoutPanelStatistics.Controls.Add(this.textBoxAverage, 1, 2);
            this.tableLayoutPanelStatistics.Controls.Add(this.labelAverageUnit, 2, 2);
            this.tableLayoutPanelStatistics.Controls.Add(this.flowLayoutPanelStatisticsButtons, 0, 4);
            this.tableLayoutPanelStatistics.Controls.Add(this.labelStdev, 0, 3);
            this.tableLayoutPanelStatistics.Controls.Add(this.textBoxStdev, 1, 3);
            this.tableLayoutPanelStatistics.Controls.Add(this.labelStdevUnit, 2, 3);
            this.tableLayoutPanelStatistics.Controls.Add(this.labelPeakToPeakUnit, 6, 2);
            this.tableLayoutPanelStatistics.Controls.Add(this.labelMinimumUnit, 6, 1);
            this.tableLayoutPanelStatistics.Controls.Add(this.labelMaximumUnit, 6, 0);
            this.tableLayoutPanelStatistics.Controls.Add(this.textBoxMaximum, 5, 0);
            this.tableLayoutPanelStatistics.Controls.Add(this.textBoxMinimum, 5, 1);
            this.tableLayoutPanelStatistics.Controls.Add(this.textBoxPeakToPeak, 5, 2);
            this.tableLayoutPanelStatistics.Controls.Add(this.labelPeakToPeak, 4, 2);
            this.tableLayoutPanelStatistics.Controls.Add(this.labelMinimum, 4, 1);
            this.tableLayoutPanelStatistics.Controls.Add(this.labelMaximum, 4, 0);
            this.tableLayoutPanelStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelStatistics.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelStatistics.Name = "tableLayoutPanelStatistics";
            this.tableLayoutPanelStatistics.RowCount = 5;
            this.tableLayoutPanelStatistics.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStatistics.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStatistics.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStatistics.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStatistics.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelStatistics.Size = new System.Drawing.Size(566, 139);
            this.tableLayoutPanelStatistics.TabIndex = 0;
            // 
            // labelNumberOfSamples
            // 
            this.labelNumberOfSamples.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelNumberOfSamples.AutoSize = true;
            this.labelNumberOfSamples.Location = new System.Drawing.Point(3, 6);
            this.labelNumberOfSamples.Name = "labelNumberOfSamples";
            this.labelNumberOfSamples.Size = new System.Drawing.Size(99, 13);
            this.labelNumberOfSamples.TabIndex = 999;
            this.labelNumberOfSamples.Text = "Number of Samples";
            this.labelNumberOfSamples.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDuration
            // 
            this.labelDuration.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelDuration.AutoSize = true;
            this.labelDuration.Location = new System.Drawing.Point(55, 32);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(47, 13);
            this.labelDuration.TabIndex = 999;
            this.labelDuration.Text = "Duration";
            this.labelDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelAverage
            // 
            this.labelAverage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelAverage.AutoSize = true;
            this.labelAverage.Location = new System.Drawing.Point(55, 58);
            this.labelAverage.Name = "labelAverage";
            this.labelAverage.Size = new System.Drawing.Size(47, 13);
            this.labelAverage.TabIndex = 999;
            this.labelAverage.Text = "Average";
            this.labelAverage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxAutoStopStatistics
            // 
            this.checkBoxAutoStopStatistics.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxAutoStopStatistics.AutoSize = true;
            this.checkBoxAutoStopStatistics.Location = new System.Drawing.Point(278, 84);
            this.checkBoxAutoStopStatistics.Name = "checkBoxAutoStopStatistics";
            this.checkBoxAutoStopStatistics.Size = new System.Drawing.Size(15, 14);
            this.checkBoxAutoStopStatistics.TabIndex = 308;
            this.checkBoxAutoStopStatistics.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxAutoStopStatistics.UseVisualStyleBackColor = true;
            this.checkBoxAutoStopStatistics.CheckedChanged += new System.EventHandler(this.checkBoxAutoStopStatistics_CheckedChanged);
            // 
            // textBoxNumberOfSamples
            // 
            this.textBoxNumberOfSamples.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNumberOfSamples.Location = new System.Drawing.Point(108, 3);
            this.textBoxNumberOfSamples.Name = "textBoxNumberOfSamples";
            this.textBoxNumberOfSamples.ReadOnly = true;
            this.textBoxNumberOfSamples.Size = new System.Drawing.Size(96, 20);
            this.textBoxNumberOfSamples.TabIndex = 301;
            this.textBoxNumberOfSamples.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNumberOfSamples.WordWrap = false;
            // 
            // labelAutoStopStatistics1
            // 
            this.labelAutoStopStatistics1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelAutoStopStatistics1.AutoSize = true;
            this.labelAutoStopStatistics1.Location = new System.Drawing.Point(299, 84);
            this.labelAutoStopStatistics1.Name = "labelAutoStopStatistics1";
            this.labelAutoStopStatistics1.Size = new System.Drawing.Size(91, 13);
            this.labelAutoStopStatistics1.TabIndex = 999;
            this.labelAutoStopStatistics1.Text = "Stop recording at ";
            this.labelAutoStopStatistics1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDurationUnit
            // 
            this.labelDurationUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelDurationUnit.AutoSize = true;
            this.labelDurationUnit.Location = new System.Drawing.Point(210, 32);
            this.labelDurationUnit.Name = "labelDurationUnit";
            this.labelDurationUnit.Size = new System.Drawing.Size(12, 13);
            this.labelDurationUnit.TabIndex = 999;
            this.labelDurationUnit.Text = "s";
            this.labelDurationUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownAutoStopStatisticsCount
            // 
            this.numericUpDownAutoStopStatisticsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownAutoStopStatisticsCount.Location = new System.Drawing.Point(396, 81);
            this.numericUpDownAutoStopStatisticsCount.Maximum = new decimal(new int[] {
            44236800,
            0,
            0,
            0});
            this.numericUpDownAutoStopStatisticsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownAutoStopStatisticsCount.Name = "numericUpDownAutoStopStatisticsCount";
            this.numericUpDownAutoStopStatisticsCount.Size = new System.Drawing.Size(96, 20);
            this.numericUpDownAutoStopStatisticsCount.TabIndex = 309;
            this.numericUpDownAutoStopStatisticsCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownAutoStopStatisticsCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // textBoxDuration
            // 
            this.textBoxDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDuration.Location = new System.Drawing.Point(108, 29);
            this.textBoxDuration.Name = "textBoxDuration";
            this.textBoxDuration.ReadOnly = true;
            this.textBoxDuration.Size = new System.Drawing.Size(96, 20);
            this.textBoxDuration.TabIndex = 302;
            this.textBoxDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxDuration.WordWrap = false;
            // 
            // labelAutoStopStatistics2
            // 
            this.labelAutoStopStatistics2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelAutoStopStatistics2.AutoSize = true;
            this.labelAutoStopStatistics2.Location = new System.Drawing.Point(498, 84);
            this.labelAutoStopStatistics2.Name = "labelAutoStopStatistics2";
            this.labelAutoStopStatistics2.Size = new System.Drawing.Size(58, 13);
            this.labelAutoStopStatistics2.TabIndex = 999;
            this.labelAutoStopStatistics2.Text = "-th sample.";
            this.labelAutoStopStatistics2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxAverage
            // 
            this.textBoxAverage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAverage.Location = new System.Drawing.Point(108, 55);
            this.textBoxAverage.Name = "textBoxAverage";
            this.textBoxAverage.ReadOnly = true;
            this.textBoxAverage.Size = new System.Drawing.Size(96, 20);
            this.textBoxAverage.TabIndex = 303;
            this.textBoxAverage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxAverage.WordWrap = false;
            // 
            // labelAverageUnit
            // 
            this.labelAverageUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelAverageUnit.AutoSize = true;
            this.labelAverageUnit.Location = new System.Drawing.Point(210, 58);
            this.labelAverageUnit.Name = "labelAverageUnit";
            this.labelAverageUnit.Size = new System.Drawing.Size(23, 13);
            this.labelAverageUnit.TabIndex = 999;
            this.labelAverageUnit.Text = "mm";
            this.labelAverageUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanelStatisticsButtons
            // 
            this.flowLayoutPanelStatisticsButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelStatisticsButtons.AutoSize = true;
            this.flowLayoutPanelStatisticsButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelStatistics.SetColumnSpan(this.flowLayoutPanelStatisticsButtons, 6);
            this.flowLayoutPanelStatisticsButtons.Controls.Add(this.buttonStartStatistics);
            this.flowLayoutPanelStatisticsButtons.Controls.Add(this.buttonStopStatistics);
            this.flowLayoutPanelStatisticsButtons.Controls.Add(this.buttonResetStatistics);
            this.flowLayoutPanelStatisticsButtons.Location = new System.Drawing.Point(3, 107);
            this.flowLayoutPanelStatisticsButtons.Name = "flowLayoutPanelStatisticsButtons";
            this.flowLayoutPanelStatisticsButtons.Size = new System.Drawing.Size(489, 29);
            this.flowLayoutPanelStatisticsButtons.TabIndex = 310;
            // 
            // buttonStartStatistics
            // 
            this.buttonStartStatistics.AutoSize = true;
            this.buttonStartStatistics.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonStartStatistics.Location = new System.Drawing.Point(3, 3);
            this.buttonStartStatistics.Name = "buttonStartStatistics";
            this.buttonStartStatistics.Size = new System.Drawing.Size(39, 23);
            this.buttonStartStatistics.TabIndex = 311;
            this.buttonStartStatistics.Text = "St&art";
            this.buttonStartStatistics.UseVisualStyleBackColor = true;
            this.buttonStartStatistics.Click += new System.EventHandler(this.buttonStartStatistics_Click);
            // 
            // buttonStopStatistics
            // 
            this.buttonStopStatistics.AutoSize = true;
            this.buttonStopStatistics.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonStopStatistics.Location = new System.Drawing.Point(48, 3);
            this.buttonStopStatistics.Name = "buttonStopStatistics";
            this.buttonStopStatistics.Size = new System.Drawing.Size(39, 23);
            this.buttonStopStatistics.TabIndex = 312;
            this.buttonStopStatistics.Text = "Sto&p";
            this.buttonStopStatistics.UseVisualStyleBackColor = true;
            this.buttonStopStatistics.Click += new System.EventHandler(this.buttonStopStatistics_Click);
            // 
            // buttonResetStatistics
            // 
            this.buttonResetStatistics.AutoSize = true;
            this.buttonResetStatistics.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonResetStatistics.Location = new System.Drawing.Point(93, 3);
            this.buttonResetStatistics.Name = "buttonResetStatistics";
            this.buttonResetStatistics.Size = new System.Drawing.Size(45, 23);
            this.buttonResetStatistics.TabIndex = 333;
            this.buttonResetStatistics.Text = "&Reset";
            this.buttonResetStatistics.UseVisualStyleBackColor = true;
            this.buttonResetStatistics.Click += new System.EventHandler(this.buttonResetStatistics_Click);
            // 
            // labelStdev
            // 
            this.labelStdev.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelStdev.AutoSize = true;
            this.labelStdev.Location = new System.Drawing.Point(4, 84);
            this.labelStdev.Name = "labelStdev";
            this.labelStdev.Size = new System.Drawing.Size(98, 13);
            this.labelStdev.TabIndex = 999;
            this.labelStdev.Text = "Standard Deviation";
            this.labelStdev.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxStdev
            // 
            this.textBoxStdev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStdev.Location = new System.Drawing.Point(108, 81);
            this.textBoxStdev.Name = "textBoxStdev";
            this.textBoxStdev.ReadOnly = true;
            this.textBoxStdev.Size = new System.Drawing.Size(96, 20);
            this.textBoxStdev.TabIndex = 304;
            this.textBoxStdev.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxStdev.WordWrap = false;
            // 
            // labelStdevUnit
            // 
            this.labelStdevUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelStdevUnit.AutoSize = true;
            this.labelStdevUnit.Location = new System.Drawing.Point(210, 84);
            this.labelStdevUnit.Name = "labelStdevUnit";
            this.labelStdevUnit.Size = new System.Drawing.Size(23, 13);
            this.labelStdevUnit.TabIndex = 999;
            this.labelStdevUnit.Text = "mm";
            this.labelStdevUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPeakToPeakUnit
            // 
            this.labelPeakToPeakUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelPeakToPeakUnit.AutoSize = true;
            this.labelPeakToPeakUnit.Location = new System.Drawing.Point(498, 58);
            this.labelPeakToPeakUnit.Name = "labelPeakToPeakUnit";
            this.labelPeakToPeakUnit.Size = new System.Drawing.Size(23, 13);
            this.labelPeakToPeakUnit.TabIndex = 999;
            this.labelPeakToPeakUnit.Text = "mm";
            this.labelPeakToPeakUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMinimumUnit
            // 
            this.labelMinimumUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelMinimumUnit.AutoSize = true;
            this.labelMinimumUnit.Location = new System.Drawing.Point(498, 32);
            this.labelMinimumUnit.Name = "labelMinimumUnit";
            this.labelMinimumUnit.Size = new System.Drawing.Size(23, 13);
            this.labelMinimumUnit.TabIndex = 999;
            this.labelMinimumUnit.Text = "mm";
            this.labelMinimumUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMaximumUnit
            // 
            this.labelMaximumUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelMaximumUnit.AutoSize = true;
            this.labelMaximumUnit.Location = new System.Drawing.Point(498, 6);
            this.labelMaximumUnit.Name = "labelMaximumUnit";
            this.labelMaximumUnit.Size = new System.Drawing.Size(23, 13);
            this.labelMaximumUnit.TabIndex = 999;
            this.labelMaximumUnit.Text = "mm";
            this.labelMaximumUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxMaximum
            // 
            this.textBoxMaximum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMaximum.Location = new System.Drawing.Point(396, 3);
            this.textBoxMaximum.Name = "textBoxMaximum";
            this.textBoxMaximum.ReadOnly = true;
            this.textBoxMaximum.Size = new System.Drawing.Size(96, 20);
            this.textBoxMaximum.TabIndex = 305;
            this.textBoxMaximum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMaximum.WordWrap = false;
            // 
            // textBoxMinimum
            // 
            this.textBoxMinimum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMinimum.Location = new System.Drawing.Point(396, 29);
            this.textBoxMinimum.Name = "textBoxMinimum";
            this.textBoxMinimum.ReadOnly = true;
            this.textBoxMinimum.Size = new System.Drawing.Size(96, 20);
            this.textBoxMinimum.TabIndex = 306;
            this.textBoxMinimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMinimum.WordWrap = false;
            // 
            // textBoxPeakToPeak
            // 
            this.textBoxPeakToPeak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPeakToPeak.Location = new System.Drawing.Point(396, 55);
            this.textBoxPeakToPeak.Name = "textBoxPeakToPeak";
            this.textBoxPeakToPeak.ReadOnly = true;
            this.textBoxPeakToPeak.Size = new System.Drawing.Size(96, 20);
            this.textBoxPeakToPeak.TabIndex = 307;
            this.textBoxPeakToPeak.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPeakToPeak.WordWrap = false;
            // 
            // labelPeakToPeak
            // 
            this.labelPeakToPeak.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelPeakToPeak.AutoSize = true;
            this.labelPeakToPeak.Location = new System.Drawing.Point(318, 58);
            this.labelPeakToPeak.Name = "labelPeakToPeak";
            this.labelPeakToPeak.Size = new System.Drawing.Size(72, 13);
            this.labelPeakToPeak.TabIndex = 999;
            this.labelPeakToPeak.Text = "Peak-to-Peak";
            this.labelPeakToPeak.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMinimum
            // 
            this.labelMinimum.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelMinimum.AutoSize = true;
            this.labelMinimum.Location = new System.Drawing.Point(342, 32);
            this.labelMinimum.Name = "labelMinimum";
            this.labelMinimum.Size = new System.Drawing.Size(48, 13);
            this.labelMinimum.TabIndex = 999;
            this.labelMinimum.Text = "Minimum";
            this.labelMinimum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMaximum
            // 
            this.labelMaximum.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelMaximum.AutoSize = true;
            this.labelMaximum.Location = new System.Drawing.Point(339, 6);
            this.labelMaximum.Name = "labelMaximum";
            this.labelMaximum.Size = new System.Drawing.Size(51, 13);
            this.labelMaximum.TabIndex = 999;
            this.labelMaximum.Text = "Maximum";
            this.labelMaximum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxConnectionStatus
            // 
            this.groupBoxConnectionStatus.AutoSize = true;
            this.groupBoxConnectionStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.SetColumnSpan(this.groupBoxConnectionStatus, 4);
            this.groupBoxConnectionStatus.Controls.Add(this.tableLayoutPanelConnectionStatus);
            this.groupBoxConnectionStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxConnectionStatus.Location = new System.Drawing.Point(6, 133);
            this.groupBoxConnectionStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 3);
            this.groupBoxConnectionStatus.Name = "groupBoxConnectionStatus";
            this.groupBoxConnectionStatus.Size = new System.Drawing.Size(572, 149);
            this.groupBoxConnectionStatus.TabIndex = 100;
            this.groupBoxConnectionStatus.TabStop = false;
            // 
            // tableLayoutPanelConnectionStatus
            // 
            this.tableLayoutPanelConnectionStatus.AutoSize = true;
            this.tableLayoutPanelConnectionStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelConnectionStatus.ColumnCount = 5;
            this.tableLayoutPanelConnectionStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelConnectionStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelConnectionStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanelConnectionStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelConnectionStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelConnectionStatus.Controls.Add(this.labelConnectionState, 0, 0);
            this.tableLayoutPanelConnectionStatus.Controls.Add(this.textBoxConnectionState, 1, 0);
            this.tableLayoutPanelConnectionStatus.Controls.Add(this.labelDirection, 0, 4);
            this.tableLayoutPanelConnectionStatus.Controls.Add(this.textBoxDirection, 1, 4);
            this.tableLayoutPanelConnectionStatus.Controls.Add(this.labelQuadratureMode, 0, 3);
            this.tableLayoutPanelConnectionStatus.Controls.Add(this.textBoxQuadratureMode, 1, 3);
            this.tableLayoutPanelConnectionStatus.Controls.Add(this.labelCOMPort, 0, 2);
            this.tableLayoutPanelConnectionStatus.Controls.Add(this.textBoxCOMPort, 1, 2);
            this.tableLayoutPanelConnectionStatus.Controls.Add(this.labelSerialNumber, 0, 1);
            this.tableLayoutPanelConnectionStatus.Controls.Add(this.textBoxSerialNumber, 1, 1);
            this.tableLayoutPanelConnectionStatus.Controls.Add(this.textBoxProductType, 4, 0);
            this.tableLayoutPanelConnectionStatus.Controls.Add(this.textBoxFirmwareVersion, 4, 1);
            this.tableLayoutPanelConnectionStatus.Controls.Add(this.textBoxBaudRate, 4, 2);
            this.tableLayoutPanelConnectionStatus.Controls.Add(this.textBoxResolution, 4, 3);
            this.tableLayoutPanelConnectionStatus.Controls.Add(this.textBoxZeroPositionCount, 4, 4);
            this.tableLayoutPanelConnectionStatus.Controls.Add(this.labelZeroPositionCount, 3, 4);
            this.tableLayoutPanelConnectionStatus.Controls.Add(this.labelResolution, 3, 3);
            this.tableLayoutPanelConnectionStatus.Controls.Add(this.labelBaudRate, 3, 2);
            this.tableLayoutPanelConnectionStatus.Controls.Add(this.labelFirmwareVersion, 3, 1);
            this.tableLayoutPanelConnectionStatus.Controls.Add(this.labelProductType, 3, 0);
            this.tableLayoutPanelConnectionStatus.Controls.Add(this.pictureBoxConnectionState, 2, 0);
            this.tableLayoutPanelConnectionStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelConnectionStatus.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelConnectionStatus.Name = "tableLayoutPanelConnectionStatus";
            this.tableLayoutPanelConnectionStatus.RowCount = 5;
            this.tableLayoutPanelConnectionStatus.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelConnectionStatus.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelConnectionStatus.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelConnectionStatus.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelConnectionStatus.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelConnectionStatus.Size = new System.Drawing.Size(566, 130);
            this.tableLayoutPanelConnectionStatus.TabIndex = 0;
            // 
            // labelConnectionState
            // 
            this.labelConnectionState.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelConnectionState.AutoSize = true;
            this.labelConnectionState.Location = new System.Drawing.Point(44, 6);
            this.labelConnectionState.Name = "labelConnectionState";
            this.labelConnectionState.Size = new System.Drawing.Size(89, 13);
            this.labelConnectionState.TabIndex = 999;
            this.labelConnectionState.Text = "Connection State";
            this.labelConnectionState.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxConnectionState
            // 
            this.textBoxConnectionState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxConnectionState.Location = new System.Drawing.Point(139, 3);
            this.textBoxConnectionState.Name = "textBoxConnectionState";
            this.textBoxConnectionState.ReadOnly = true;
            this.textBoxConnectionState.Size = new System.Drawing.Size(130, 20);
            this.textBoxConnectionState.TabIndex = 101;
            this.textBoxConnectionState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxConnectionState.WordWrap = false;
            // 
            // labelDirection
            // 
            this.labelDirection.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelDirection.AutoSize = true;
            this.labelDirection.Location = new System.Drawing.Point(84, 110);
            this.labelDirection.Name = "labelDirection";
            this.labelDirection.Size = new System.Drawing.Size(49, 13);
            this.labelDirection.TabIndex = 999;
            this.labelDirection.Text = "Direction";
            this.labelDirection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxDirection
            // 
            this.textBoxDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDirection.Location = new System.Drawing.Point(139, 107);
            this.textBoxDirection.Name = "textBoxDirection";
            this.textBoxDirection.ReadOnly = true;
            this.textBoxDirection.Size = new System.Drawing.Size(130, 20);
            this.textBoxDirection.TabIndex = 105;
            this.textBoxDirection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxDirection.WordWrap = false;
            // 
            // labelQuadratureMode
            // 
            this.labelQuadratureMode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelQuadratureMode.AutoSize = true;
            this.labelQuadratureMode.Location = new System.Drawing.Point(43, 84);
            this.labelQuadratureMode.Name = "labelQuadratureMode";
            this.labelQuadratureMode.Size = new System.Drawing.Size(90, 13);
            this.labelQuadratureMode.TabIndex = 999;
            this.labelQuadratureMode.Text = "Quadrature Mode";
            this.labelQuadratureMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxQuadratureMode
            // 
            this.textBoxQuadratureMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxQuadratureMode.Location = new System.Drawing.Point(139, 81);
            this.textBoxQuadratureMode.Name = "textBoxQuadratureMode";
            this.textBoxQuadratureMode.ReadOnly = true;
            this.textBoxQuadratureMode.Size = new System.Drawing.Size(130, 20);
            this.textBoxQuadratureMode.TabIndex = 104;
            this.textBoxQuadratureMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxQuadratureMode.WordWrap = false;
            // 
            // labelCOMPort
            // 
            this.labelCOMPort.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelCOMPort.AutoSize = true;
            this.labelCOMPort.Location = new System.Drawing.Point(80, 58);
            this.labelCOMPort.Name = "labelCOMPort";
            this.labelCOMPort.Size = new System.Drawing.Size(53, 13);
            this.labelCOMPort.TabIndex = 999;
            this.labelCOMPort.Text = "COM Port";
            this.labelCOMPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxCOMPort
            // 
            this.textBoxCOMPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCOMPort.Location = new System.Drawing.Point(139, 55);
            this.textBoxCOMPort.Name = "textBoxCOMPort";
            this.textBoxCOMPort.ReadOnly = true;
            this.textBoxCOMPort.Size = new System.Drawing.Size(130, 20);
            this.textBoxCOMPort.TabIndex = 103;
            this.textBoxCOMPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxCOMPort.WordWrap = false;
            // 
            // labelSerialNumber
            // 
            this.labelSerialNumber.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelSerialNumber.AutoSize = true;
            this.labelSerialNumber.Location = new System.Drawing.Point(60, 32);
            this.labelSerialNumber.Name = "labelSerialNumber";
            this.labelSerialNumber.Size = new System.Drawing.Size(73, 13);
            this.labelSerialNumber.TabIndex = 999;
            this.labelSerialNumber.Text = "Serial Number";
            this.labelSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxSerialNumber
            // 
            this.textBoxSerialNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSerialNumber.Location = new System.Drawing.Point(139, 29);
            this.textBoxSerialNumber.Name = "textBoxSerialNumber";
            this.textBoxSerialNumber.ReadOnly = true;
            this.textBoxSerialNumber.Size = new System.Drawing.Size(130, 20);
            this.textBoxSerialNumber.TabIndex = 102;
            this.textBoxSerialNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxSerialNumber.WordWrap = false;
            // 
            // textBoxProductType
            // 
            this.textBoxProductType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProductType.Location = new System.Drawing.Point(433, 3);
            this.textBoxProductType.Name = "textBoxProductType";
            this.textBoxProductType.ReadOnly = true;
            this.textBoxProductType.Size = new System.Drawing.Size(130, 20);
            this.textBoxProductType.TabIndex = 106;
            this.textBoxProductType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxProductType.WordWrap = false;
            // 
            // textBoxFirmwareVersion
            // 
            this.textBoxFirmwareVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFirmwareVersion.Location = new System.Drawing.Point(433, 29);
            this.textBoxFirmwareVersion.Name = "textBoxFirmwareVersion";
            this.textBoxFirmwareVersion.ReadOnly = true;
            this.textBoxFirmwareVersion.Size = new System.Drawing.Size(130, 20);
            this.textBoxFirmwareVersion.TabIndex = 107;
            this.textBoxFirmwareVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxFirmwareVersion.WordWrap = false;
            // 
            // textBoxBaudRate
            // 
            this.textBoxBaudRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBaudRate.Location = new System.Drawing.Point(433, 55);
            this.textBoxBaudRate.Name = "textBoxBaudRate";
            this.textBoxBaudRate.ReadOnly = true;
            this.textBoxBaudRate.Size = new System.Drawing.Size(130, 20);
            this.textBoxBaudRate.TabIndex = 108;
            this.textBoxBaudRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxBaudRate.WordWrap = false;
            // 
            // textBoxResolution
            // 
            this.textBoxResolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxResolution.Location = new System.Drawing.Point(433, 81);
            this.textBoxResolution.Name = "textBoxResolution";
            this.textBoxResolution.ReadOnly = true;
            this.textBoxResolution.Size = new System.Drawing.Size(130, 20);
            this.textBoxResolution.TabIndex = 109;
            this.textBoxResolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxResolution.WordWrap = false;
            // 
            // textBoxZeroPositionCount
            // 
            this.textBoxZeroPositionCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxZeroPositionCount.Location = new System.Drawing.Point(433, 107);
            this.textBoxZeroPositionCount.Name = "textBoxZeroPositionCount";
            this.textBoxZeroPositionCount.ReadOnly = true;
            this.textBoxZeroPositionCount.Size = new System.Drawing.Size(130, 20);
            this.textBoxZeroPositionCount.TabIndex = 110;
            this.textBoxZeroPositionCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxZeroPositionCount.WordWrap = false;
            // 
            // labelZeroPositionCount
            // 
            this.labelZeroPositionCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelZeroPositionCount.AutoSize = true;
            this.labelZeroPositionCount.Location = new System.Drawing.Point(327, 110);
            this.labelZeroPositionCount.Name = "labelZeroPositionCount";
            this.labelZeroPositionCount.Size = new System.Drawing.Size(100, 13);
            this.labelZeroPositionCount.TabIndex = 999;
            this.labelZeroPositionCount.Text = "Zero Position Count";
            this.labelZeroPositionCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelResolution
            // 
            this.labelResolution.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelResolution.AutoSize = true;
            this.labelResolution.Location = new System.Drawing.Point(370, 84);
            this.labelResolution.Name = "labelResolution";
            this.labelResolution.Size = new System.Drawing.Size(57, 13);
            this.labelResolution.TabIndex = 999;
            this.labelResolution.Text = "Resolution";
            this.labelResolution.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelBaudRate
            // 
            this.labelBaudRate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelBaudRate.AutoSize = true;
            this.labelBaudRate.Location = new System.Drawing.Point(369, 58);
            this.labelBaudRate.Name = "labelBaudRate";
            this.labelBaudRate.Size = new System.Drawing.Size(58, 13);
            this.labelBaudRate.TabIndex = 999;
            this.labelBaudRate.Text = "Baud Rate";
            this.labelBaudRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelFirmwareVersion
            // 
            this.labelFirmwareVersion.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelFirmwareVersion.AutoSize = true;
            this.labelFirmwareVersion.Location = new System.Drawing.Point(343, 32);
            this.labelFirmwareVersion.Name = "labelFirmwareVersion";
            this.labelFirmwareVersion.Size = new System.Drawing.Size(84, 13);
            this.labelFirmwareVersion.TabIndex = 999;
            this.labelFirmwareVersion.Text = "FirmwareVersion";
            this.labelFirmwareVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelProductType
            // 
            this.labelProductType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelProductType.AutoSize = true;
            this.labelProductType.Location = new System.Drawing.Point(359, 6);
            this.labelProductType.Name = "labelProductType";
            this.labelProductType.Size = new System.Drawing.Size(68, 13);
            this.labelProductType.TabIndex = 999;
            this.labelProductType.Text = "ProductType";
            this.labelProductType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBoxConnectionState
            // 
            this.pictureBoxConnectionState.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxConnectionState.Location = new System.Drawing.Point(275, 4);
            this.pictureBoxConnectionState.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxConnectionState.MinimumSize = new System.Drawing.Size(16, 16);
            this.pictureBoxConnectionState.Name = "pictureBoxConnectionState";
            this.pictureBoxConnectionState.Size = new System.Drawing.Size(16, 17);
            this.pictureBoxConnectionState.TabIndex = 5;
            this.pictureBoxConnectionState.TabStop = false;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConnect.AutoSize = true;
            this.buttonConnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonConnect.Location = new System.Drawing.Point(387, 3);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(194, 23);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "&Connect to QSB Encoder Reader...";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDisconnect.AutoSize = true;
            this.buttonDisconnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDisconnect.Enabled = false;
            this.buttonDisconnect.Location = new System.Drawing.Point(387, 32);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(194, 23);
            this.buttonDisconnect.TabIndex = 1;
            this.buttonDisconnect.Text = "&Disconnect from QSB Enoder Reader";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // buttonSetZero
            // 
            this.buttonSetZero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetZero.AutoSize = true;
            this.buttonSetZero.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSetZero.Enabled = false;
            this.buttonSetZero.Location = new System.Drawing.Point(387, 61);
            this.buttonSetZero.Name = "buttonSetZero";
            this.buttonSetZero.Size = new System.Drawing.Size(194, 23);
            this.buttonSetZero.TabIndex = 2;
            this.buttonSetZero.Text = "&Zero Encoder Count";
            this.buttonSetZero.UseVisualStyleBackColor = true;
            this.buttonSetZero.Click += new System.EventHandler(this.buttonSetZero_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQuit.AutoSize = true;
            this.buttonQuit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonQuit.Location = new System.Drawing.Point(387, 90);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(194, 23);
            this.buttonQuit.TabIndex = 3;
            this.buttonQuit.Text = "&Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // labelEncoderReadingUnit
            // 
            this.labelEncoderReadingUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelEncoderReadingUnit.AutoSize = true;
            this.labelEncoderReadingUnit.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelEncoderReadingUnit.Location = new System.Drawing.Point(281, 0);
            this.labelEncoderReadingUnit.Name = "labelEncoderReadingUnit";
            this.labelEncoderReadingUnit.Padding = new System.Windows.Forms.Padding(0, 11, 10, 11);
            this.tableLayoutPanelMain.SetRowSpan(this.labelEncoderReadingUnit, 4);
            this.labelEncoderReadingUnit.Size = new System.Drawing.Size(100, 116);
            this.labelEncoderReadingUnit.TabIndex = 999;
            this.labelEncoderReadingUnit.Text = "mm";
            this.labelEncoderReadingUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelEncoderReading
            // 
            this.labelEncoderReading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEncoderReading.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelEncoderReading, 2);
            this.labelEncoderReading.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelEncoderReading.Location = new System.Drawing.Point(43, 0);
            this.labelEncoderReading.Name = "labelEncoderReading";
            this.labelEncoderReading.Padding = new System.Windows.Forms.Padding(10, 11, 0, 11);
            this.tableLayoutPanelMain.SetRowSpan(this.labelEncoderReading, 4);
            this.labelEncoderReading.Size = new System.Drawing.Size(232, 116);
            this.labelEncoderReading.TabIndex = 999;
            this.labelEncoderReading.Text = "-0.000000";
            this.labelEncoderReading.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBoxExpandConnectionStatus
            // 
            this.pictureBoxExpandConnectionStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBoxExpandConnectionStatus.Location = new System.Drawing.Point(0, 116);
            this.pictureBoxExpandConnectionStatus.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxExpandConnectionStatus.MinimumSize = new System.Drawing.Size(16, 17);
            this.pictureBoxExpandConnectionStatus.Name = "pictureBoxExpandConnectionStatus";
            this.pictureBoxExpandConnectionStatus.Size = new System.Drawing.Size(16, 17);
            this.pictureBoxExpandConnectionStatus.TabIndex = 5;
            this.pictureBoxExpandConnectionStatus.TabStop = false;
            this.pictureBoxExpandConnectionStatus.Click += new System.EventHandler(this.pictureBoxExpandConnectionStatus_Click);
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelConnectionStatus.AutoSize = true;
            this.labelConnectionStatus.Location = new System.Drawing.Point(19, 116);
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(97, 17);
            this.labelConnectionStatus.TabIndex = 999;
            this.labelConnectionStatus.Text = "Connection Status:";
            this.labelConnectionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxExpandRecording
            // 
            this.pictureBoxExpandRecording.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBoxExpandRecording.Location = new System.Drawing.Point(0, 285);
            this.pictureBoxExpandRecording.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxExpandRecording.MinimumSize = new System.Drawing.Size(16, 17);
            this.pictureBoxExpandRecording.Name = "pictureBoxExpandRecording";
            this.pictureBoxExpandRecording.Size = new System.Drawing.Size(16, 17);
            this.pictureBoxExpandRecording.TabIndex = 5;
            this.pictureBoxExpandRecording.TabStop = false;
            this.pictureBoxExpandRecording.Click += new System.EventHandler(this.pictureBoxExpandRecording_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(19, 593);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(40, 13);
            this.labelStatus.TabIndex = 999;
            this.labelStatus.Text = "Status:";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRecording
            // 
            this.labelRecording.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelRecording.AutoSize = true;
            this.labelRecording.Location = new System.Drawing.Point(19, 285);
            this.labelRecording.Name = "labelRecording";
            this.labelRecording.Size = new System.Drawing.Size(59, 17);
            this.labelRecording.TabIndex = 999;
            this.labelRecording.Text = "Recording:";
            this.labelRecording.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelStatistics
            // 
            this.labelStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStatistics.AutoSize = true;
            this.labelStatistics.Location = new System.Drawing.Point(19, 411);
            this.labelStatistics.Name = "labelStatistics";
            this.labelStatistics.Size = new System.Drawing.Size(52, 17);
            this.labelStatistics.TabIndex = 999;
            this.labelStatistics.Text = "Statistics:";
            this.labelStatistics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxExpandStatus
            // 
            this.pictureBoxExpandStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBoxExpandStatus.Location = new System.Drawing.Point(0, 589);
            this.pictureBoxExpandStatus.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxExpandStatus.MinimumSize = new System.Drawing.Size(16, 17);
            this.pictureBoxExpandStatus.Name = "pictureBoxExpandStatus";
            this.pictureBoxExpandStatus.Size = new System.Drawing.Size(16, 17);
            this.pictureBoxExpandStatus.TabIndex = 5;
            this.pictureBoxExpandStatus.TabStop = false;
            this.pictureBoxExpandStatus.Click += new System.EventHandler(this.pictureBoxExpandStatus_Click);
            // 
            // pictureBoxExpandStatistics
            // 
            this.pictureBoxExpandStatistics.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBoxExpandStatistics.Location = new System.Drawing.Point(0, 411);
            this.pictureBoxExpandStatistics.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxExpandStatistics.MinimumSize = new System.Drawing.Size(16, 17);
            this.pictureBoxExpandStatistics.Name = "pictureBoxExpandStatistics";
            this.pictureBoxExpandStatistics.Size = new System.Drawing.Size(16, 17);
            this.pictureBoxExpandStatistics.TabIndex = 5;
            this.pictureBoxExpandStatistics.TabStop = false;
            this.pictureBoxExpandStatistics.Click += new System.EventHandler(this.pictureBoxExpandStatistics_Click);
            // 
            // labelRecordingStatus
            // 
            this.labelRecordingStatus.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelRecordingStatus.AutoSize = true;
            this.labelRecordingStatus.Location = new System.Drawing.Point(91, 32);
            this.labelRecordingStatus.Name = "labelRecordingStatus";
            this.labelRecordingStatus.Size = new System.Drawing.Size(40, 13);
            this.labelRecordingStatus.TabIndex = 999;
            this.labelRecordingStatus.Text = "Status:";
            this.labelRecordingStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxRecordingStatus
            // 
            this.textBoxRecordingStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRecordingStatus.Location = new System.Drawing.Point(153, 29);
            this.textBoxRecordingStatus.Name = "textBoxRecordingStatus";
            this.textBoxRecordingStatus.ReadOnly = true;
            this.textBoxRecordingStatus.Size = new System.Drawing.Size(410, 20);
            this.textBoxRecordingStatus.TabIndex = 201;
            this.textBoxRecordingStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBoxRecordingStatus
            // 
            this.pictureBoxRecordingStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxRecordingStatus.Location = new System.Drawing.Point(134, 30);
            this.pictureBoxRecordingStatus.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxRecordingStatus.MinimumSize = new System.Drawing.Size(16, 16);
            this.pictureBoxRecordingStatus.Name = "pictureBoxRecordingStatus";
            this.pictureBoxRecordingStatus.Size = new System.Drawing.Size(16, 17);
            this.pictureBoxRecordingStatus.TabIndex = 5;
            this.pictureBoxRecordingStatus.TabStop = false;
            // 
            // MainForm
            // 
            this.AcceptButton = this.buttonConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 711);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 750);
            this.Name = "MainForm";
            this.Text = "QSB Linear Encoder Reader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.groupBoxRecording.ResumeLayout(false);
            this.groupBoxRecording.PerformLayout();
            this.tableLayoutPanelRecording.ResumeLayout(false);
            this.tableLayoutPanelRecording.PerformLayout();
            this.flowLayoutPanelRecordingButtons.ResumeLayout(false);
            this.flowLayoutPanelRecordingButtons.PerformLayout();
            this.groupBoxStatistics.ResumeLayout(false);
            this.groupBoxStatistics.PerformLayout();
            this.tableLayoutPanelStatistics.ResumeLayout(false);
            this.tableLayoutPanelStatistics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAutoStopStatisticsCount)).EndInit();
            this.flowLayoutPanelStatisticsButtons.ResumeLayout(false);
            this.flowLayoutPanelStatisticsButtons.PerformLayout();
            this.groupBoxConnectionStatus.ResumeLayout(false);
            this.groupBoxConnectionStatus.PerformLayout();
            this.tableLayoutPanelConnectionStatus.ResumeLayout(false);
            this.tableLayoutPanelConnectionStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConnectionState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExpandConnectionStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExpandRecording)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExpandStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExpandStatistics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRecordingStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Label labelEncoderReadingUnit;
        private System.Windows.Forms.Label labelEncoderReading;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonSetZero;
        private System.Windows.Forms.Button buttonStartRecording;
        private System.Windows.Forms.Button buttonStopRecording;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.GroupBox groupBoxRecording;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRecording;
        private System.Windows.Forms.Label labelCSVOutputPath;
        private System.Windows.Forms.TextBox textBoxCSVOutputPath;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRecordingButtons;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.GroupBox groupBoxStatistics;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelStatistics;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelStatisticsButtons;
        private System.Windows.Forms.Button buttonStartStatistics;
        private System.Windows.Forms.Button buttonStopStatistics;
        private System.Windows.Forms.Label labelNumberOfSamples;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.Label labelAverage;
        private System.Windows.Forms.TextBox textBoxNumberOfSamples;
        private System.Windows.Forms.Label labelDurationUnit;
        private System.Windows.Forms.TextBox textBoxDuration;
        private System.Windows.Forms.TextBox textBoxAverage;
        private System.Windows.Forms.Label labelAverageUnit;
        private System.Windows.Forms.Label labelMaximum;
        private System.Windows.Forms.Label labelMinimum;
        private System.Windows.Forms.Label labelPeakToPeak;
        private System.Windows.Forms.TextBox textBoxMaximum;
        private System.Windows.Forms.TextBox textBoxMinimum;
        private System.Windows.Forms.TextBox textBoxPeakToPeak;
        private System.Windows.Forms.Label labelMaximumUnit;
        private System.Windows.Forms.Label labelMinimumUnit;
        private System.Windows.Forms.Label labelPeakToPeakUnit;
        private System.Windows.Forms.Button buttonResetStatistics;
        private System.Windows.Forms.Button buttonRecordingSettings;
        private System.Windows.Forms.Label labelStdev;
        private System.Windows.Forms.TextBox textBoxStdev;
        private System.Windows.Forms.Label labelStdevUnit;
        private System.Windows.Forms.CheckBox checkBoxAutoStopStatistics;
        private System.Windows.Forms.Label labelAutoStopStatistics1;
        private System.Windows.Forms.NumericUpDown numericUpDownAutoStopStatisticsCount;
        private System.Windows.Forms.Label labelAutoStopStatistics2;
        private System.Windows.Forms.GroupBox groupBoxConnectionStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelConnectionStatus;
        private System.Windows.Forms.Label labelConnectionState;
        private System.Windows.Forms.Label labelCOMPort;
        private System.Windows.Forms.Label labelQuadratureMode;
        private System.Windows.Forms.Label labelDirection;
        private System.Windows.Forms.Label labelBaudRate;
        private System.Windows.Forms.Label labelResolution;
        private System.Windows.Forms.Label labelZeroPositionCount;
        private System.Windows.Forms.TextBox textBoxConnectionState;
        private System.Windows.Forms.TextBox textBoxCOMPort;
        private System.Windows.Forms.TextBox textBoxQuadratureMode;
        private System.Windows.Forms.TextBox textBoxDirection;
        private System.Windows.Forms.TextBox textBoxBaudRate;
        private System.Windows.Forms.TextBox textBoxResolution;
        private System.Windows.Forms.TextBox textBoxZeroPositionCount;
        private System.Windows.Forms.Label labelSerialNumber;
        private System.Windows.Forms.TextBox textBoxSerialNumber;
        private System.Windows.Forms.Label labelProductType;
        private System.Windows.Forms.TextBox textBoxProductType;
        private System.Windows.Forms.Label labelFirmwareVersion;
        private System.Windows.Forms.TextBox textBoxFirmwareVersion;
        private System.Windows.Forms.PictureBox pictureBoxConnectionState;
        private System.Windows.Forms.PictureBox pictureBoxExpandConnectionStatus;
        private System.Windows.Forms.PictureBox pictureBoxExpandRecording;
        private System.Windows.Forms.PictureBox pictureBoxExpandStatistics;
        private System.Windows.Forms.PictureBox pictureBoxExpandStatus;
        private System.Windows.Forms.Label labelConnectionStatus;
        private System.Windows.Forms.Label labelRecording;
        private System.Windows.Forms.Label labelStatistics;
        private System.Windows.Forms.Label labelRecordingStatus;
        private System.Windows.Forms.TextBox textBoxRecordingStatus;
        private System.Windows.Forms.PictureBox pictureBoxRecordingStatus;
    }
}

