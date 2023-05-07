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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.labelEncoderReadingUnit = new System.Windows.Forms.Label();
            this.labelEncoderReading = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonSetZero = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.groupBoxRecording = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelRecording = new System.Windows.Forms.TableLayoutPanel();
            this.labelCSVOutputPath = new System.Windows.Forms.Label();
            this.textBoxCSVOutputPath = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelRecordingButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSetCSVOutputPath = new System.Windows.Forms.Button();
            this.buttonStartRecording = new System.Windows.Forms.Button();
            this.buttonStopRecording = new System.Windows.Forms.Button();
            this.timerDisplayUpdateLoop = new System.Windows.Forms.Timer(this.components);
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanelStatisticsButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.labelNumberOfSamples = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelAverage = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonStartStatistics = new System.Windows.Forms.Button();
            this.buttonStopStatistics = new System.Windows.Forms.Button();
            this.textBoxNumberOfSamples = new System.Windows.Forms.TextBox();
            this.labelDurationUnit = new System.Windows.Forms.Label();
            this.textBoxDuration = new System.Windows.Forms.TextBox();
            this.textBoxAverage = new System.Windows.Forms.TextBox();
            this.labelAverageUnit = new System.Windows.Forms.Label();
            this.labelMaximum = new System.Windows.Forms.Label();
            this.labelMinimum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMaximum = new System.Windows.Forms.TextBox();
            this.textBoxMinimum = new System.Windows.Forms.TextBox();
            this.textBoxPeakToPeak = new System.Windows.Forms.TextBox();
            this.labelMaximumUnit = new System.Windows.Forms.Label();
            this.labelMinimumUnit = new System.Windows.Forms.Label();
            this.labelPeakToPeakUnit = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain.SuspendLayout();
            this.groupBoxRecording.SuspendLayout();
            this.tableLayoutPanelRecording.SuspendLayout();
            this.flowLayoutPanelRecordingButtons.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanelStatisticsButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.Controls.Add(this.labelEncoderReadingUnit, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelEncoderReading, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.buttonConnect, 2, 0);
            this.tableLayoutPanelMain.Controls.Add(this.buttonSetZero, 2, 2);
            this.tableLayoutPanelMain.Controls.Add(this.buttonQuit, 2, 3);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxStatus, 0, 7);
            this.tableLayoutPanelMain.Controls.Add(this.labelStatus, 0, 6);
            this.tableLayoutPanelMain.Controls.Add(this.buttonDisconnect, 2, 1);
            this.tableLayoutPanelMain.Controls.Add(this.groupBoxRecording, 0, 4);
            this.tableLayoutPanelMain.Controls.Add(this.groupBox1, 0, 5);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 8;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(634, 468);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // labelEncoderReadingUnit
            // 
            this.labelEncoderReadingUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelEncoderReadingUnit.AutoSize = true;
            this.labelEncoderReadingUnit.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelEncoderReadingUnit.Location = new System.Drawing.Point(320, 0);
            this.labelEncoderReadingUnit.Name = "labelEncoderReadingUnit";
            this.labelEncoderReadingUnit.Padding = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this.tableLayoutPanelMain.SetRowSpan(this.labelEncoderReadingUnit, 4);
            this.labelEncoderReadingUnit.Size = new System.Drawing.Size(100, 112);
            this.labelEncoderReadingUnit.TabIndex = 0;
            this.labelEncoderReadingUnit.Text = "mm";
            this.labelEncoderReadingUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelEncoderReading
            // 
            this.labelEncoderReading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEncoderReading.AutoSize = true;
            this.labelEncoderReading.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelEncoderReading.Location = new System.Drawing.Point(82, 0);
            this.labelEncoderReading.Name = "labelEncoderReading";
            this.labelEncoderReading.Padding = new System.Windows.Forms.Padding(10, 10, 0, 10);
            this.tableLayoutPanelMain.SetRowSpan(this.labelEncoderReading, 4);
            this.labelEncoderReading.Size = new System.Drawing.Size(232, 112);
            this.labelEncoderReading.TabIndex = 0;
            this.labelEncoderReading.Text = "-0.000000";
            this.labelEncoderReading.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConnect.AutoSize = true;
            this.buttonConnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonConnect.Location = new System.Drawing.Point(426, 3);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(205, 22);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Connect to QSB Encoder Reader...";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonSetZero
            // 
            this.buttonSetZero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetZero.AutoSize = true;
            this.buttonSetZero.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSetZero.Enabled = false;
            this.buttonSetZero.Location = new System.Drawing.Point(426, 59);
            this.buttonSetZero.Name = "buttonSetZero";
            this.buttonSetZero.Size = new System.Drawing.Size(205, 22);
            this.buttonSetZero.TabIndex = 2;
            this.buttonSetZero.Text = "Zero Encoder Count";
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
            this.buttonQuit.Location = new System.Drawing.Point(426, 87);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(205, 22);
            this.buttonQuit.TabIndex = 5;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(3, 334);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(40, 12);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "Status:";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDisconnect.AutoSize = true;
            this.buttonDisconnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDisconnect.Enabled = false;
            this.buttonDisconnect.Location = new System.Drawing.Point(426, 31);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(205, 22);
            this.buttonDisconnect.TabIndex = 1;
            this.buttonDisconnect.Text = "Disconnect from QSB Enoder Reader";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // groupBoxRecording
            // 
            this.groupBoxRecording.AutoSize = true;
            this.groupBoxRecording.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.SetColumnSpan(this.groupBoxRecording, 3);
            this.groupBoxRecording.Controls.Add(this.tableLayoutPanelRecording);
            this.groupBoxRecording.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxRecording.Location = new System.Drawing.Point(3, 115);
            this.groupBoxRecording.Name = "groupBoxRecording";
            this.groupBoxRecording.Size = new System.Drawing.Size(628, 77);
            this.groupBoxRecording.TabIndex = 8;
            this.groupBoxRecording.TabStop = false;
            this.groupBoxRecording.Text = "Recording";
            // 
            // tableLayoutPanelRecording
            // 
            this.tableLayoutPanelRecording.AutoSize = true;
            this.tableLayoutPanelRecording.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelRecording.ColumnCount = 2;
            this.tableLayoutPanelRecording.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelRecording.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRecording.Controls.Add(this.labelCSVOutputPath, 0, 0);
            this.tableLayoutPanelRecording.Controls.Add(this.textBoxCSVOutputPath, 1, 0);
            this.tableLayoutPanelRecording.Controls.Add(this.flowLayoutPanelRecordingButtons, 0, 1);
            this.tableLayoutPanelRecording.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRecording.Location = new System.Drawing.Point(3, 15);
            this.tableLayoutPanelRecording.Name = "tableLayoutPanelRecording";
            this.tableLayoutPanelRecording.RowCount = 2;
            this.tableLayoutPanelRecording.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRecording.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRecording.Size = new System.Drawing.Size(622, 59);
            this.tableLayoutPanelRecording.TabIndex = 0;
            // 
            // labelCSVOutputPath
            // 
            this.labelCSVOutputPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCSVOutputPath.AutoSize = true;
            this.labelCSVOutputPath.Location = new System.Drawing.Point(3, 6);
            this.labelCSVOutputPath.Name = "labelCSVOutputPath";
            this.labelCSVOutputPath.Size = new System.Drawing.Size(95, 12);
            this.labelCSVOutputPath.TabIndex = 0;
            this.labelCSVOutputPath.Text = "CSV Output Path:";
            this.labelCSVOutputPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxCSVOutputPath
            // 
            this.textBoxCSVOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCSVOutputPath.Location = new System.Drawing.Point(104, 3);
            this.textBoxCSVOutputPath.Name = "textBoxCSVOutputPath";
            this.textBoxCSVOutputPath.ReadOnly = true;
            this.textBoxCSVOutputPath.Size = new System.Drawing.Size(515, 19);
            this.textBoxCSVOutputPath.TabIndex = 1;
            // 
            // flowLayoutPanelRecordingButtons
            // 
            this.flowLayoutPanelRecordingButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelRecordingButtons.AutoSize = true;
            this.flowLayoutPanelRecordingButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelRecording.SetColumnSpan(this.flowLayoutPanelRecordingButtons, 2);
            this.flowLayoutPanelRecordingButtons.Controls.Add(this.buttonSetCSVOutputPath);
            this.flowLayoutPanelRecordingButtons.Controls.Add(this.buttonStartRecording);
            this.flowLayoutPanelRecordingButtons.Controls.Add(this.buttonStopRecording);
            this.flowLayoutPanelRecordingButtons.Location = new System.Drawing.Point(3, 28);
            this.flowLayoutPanelRecordingButtons.Name = "flowLayoutPanelRecordingButtons";
            this.flowLayoutPanelRecordingButtons.Size = new System.Drawing.Size(616, 28);
            this.flowLayoutPanelRecordingButtons.TabIndex = 2;
            // 
            // buttonSetCSVOutputPath
            // 
            this.buttonSetCSVOutputPath.AutoSize = true;
            this.buttonSetCSVOutputPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSetCSVOutputPath.Location = new System.Drawing.Point(3, 3);
            this.buttonSetCSVOutputPath.Name = "buttonSetCSVOutputPath";
            this.buttonSetCSVOutputPath.Size = new System.Drawing.Size(130, 22);
            this.buttonSetCSVOutputPath.TabIndex = 0;
            this.buttonSetCSVOutputPath.Text = "Set CSV Output Path...";
            this.buttonSetCSVOutputPath.UseVisualStyleBackColor = true;
            this.buttonSetCSVOutputPath.Click += new System.EventHandler(this.buttonSetCSVOutputPath_Click);
            // 
            // buttonStartRecording
            // 
            this.buttonStartRecording.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartRecording.AutoSize = true;
            this.buttonStartRecording.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonStartRecording.Enabled = false;
            this.buttonStartRecording.Location = new System.Drawing.Point(139, 3);
            this.buttonStartRecording.Name = "buttonStartRecording";
            this.buttonStartRecording.Size = new System.Drawing.Size(95, 22);
            this.buttonStartRecording.TabIndex = 3;
            this.buttonStartRecording.Text = "Start Recording";
            this.buttonStartRecording.UseVisualStyleBackColor = true;
            this.buttonStartRecording.Click += new System.EventHandler(this.buttonStartRecording_Click);
            // 
            // buttonStopRecording
            // 
            this.buttonStopRecording.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStopRecording.AutoSize = true;
            this.buttonStopRecording.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonStopRecording.Enabled = false;
            this.buttonStopRecording.Location = new System.Drawing.Point(240, 3);
            this.buttonStopRecording.Name = "buttonStopRecording";
            this.buttonStopRecording.Size = new System.Drawing.Size(93, 22);
            this.buttonStopRecording.TabIndex = 4;
            this.buttonStopRecording.Text = "Stop Recording";
            this.buttonStopRecording.UseVisualStyleBackColor = true;
            this.buttonStopRecording.Click += new System.EventHandler(this.buttonStopRecording_Click);
            // 
            // timerDisplayUpdateLoop
            // 
            this.timerDisplayUpdateLoop.Enabled = true;
            this.timerDisplayUpdateLoop.Tick += new System.EventHandler(this.timerDisplayUpdateLoop_Tick);
            // 
            // textBoxStatus
            // 
            this.tableLayoutPanelMain.SetColumnSpan(this.textBoxStatus, 3);
            this.textBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxStatus.Location = new System.Drawing.Point(3, 349);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStatus.Size = new System.Drawing.Size(628, 116);
            this.textBoxStatus.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.SetColumnSpan(this.groupBox1, 3);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 198);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(628, 133);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistics";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelStatisticsButtons, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelNumberOfSamples, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelAverage, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxNumberOfSamples, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelDurationUnit, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxDuration, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxAverage, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelAverageUnit, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelMaximum, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelMinimum, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxMaximum, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxMinimum, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxPeakToPeak, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelMaximumUnit, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelMinimumUnit, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelPeakToPeakUnit, 5, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(622, 115);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanelStatisticsButtons
            // 
            this.flowLayoutPanelStatisticsButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelStatisticsButtons.AutoSize = true;
            this.flowLayoutPanelStatisticsButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanelStatisticsButtons, 6);
            this.flowLayoutPanelStatisticsButtons.Controls.Add(this.buttonStartStatistics);
            this.flowLayoutPanelStatisticsButtons.Controls.Add(this.buttonStopStatistics);
            this.flowLayoutPanelStatisticsButtons.Controls.Add(this.textBox1);
            this.flowLayoutPanelStatisticsButtons.Location = new System.Drawing.Point(3, 78);
            this.flowLayoutPanelStatisticsButtons.Name = "flowLayoutPanelStatisticsButtons";
            this.flowLayoutPanelStatisticsButtons.Size = new System.Drawing.Size(616, 34);
            this.flowLayoutPanelStatisticsButtons.TabIndex = 0;
            // 
            // labelNumberOfSamples
            // 
            this.labelNumberOfSamples.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelNumberOfSamples.AutoSize = true;
            this.labelNumberOfSamples.Location = new System.Drawing.Point(3, 6);
            this.labelNumberOfSamples.Name = "labelNumberOfSamples";
            this.labelNumberOfSamples.Size = new System.Drawing.Size(105, 12);
            this.labelNumberOfSamples.TabIndex = 1;
            this.labelNumberOfSamples.Text = "Number of Samples";
            this.labelNumberOfSamples.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Duration";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelAverage
            // 
            this.labelAverage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelAverage.AutoSize = true;
            this.labelAverage.Location = new System.Drawing.Point(61, 56);
            this.labelAverage.Name = "labelAverage";
            this.labelAverage.Size = new System.Drawing.Size(47, 12);
            this.labelAverage.TabIndex = 3;
            this.labelAverage.Text = "Average";
            this.labelAverage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 31);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(628, 0);
            this.textBox1.TabIndex = 7;
            // 
            // buttonStartStatistics
            // 
            this.buttonStartStatistics.AutoSize = true;
            this.buttonStartStatistics.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonStartStatistics.Location = new System.Drawing.Point(3, 3);
            this.buttonStartStatistics.Name = "buttonStartStatistics";
            this.buttonStartStatistics.Size = new System.Drawing.Size(93, 22);
            this.buttonStartStatistics.TabIndex = 8;
            this.buttonStartStatistics.Text = "Start Statistics";
            this.buttonStartStatistics.UseVisualStyleBackColor = true;
            // 
            // buttonStopStatistics
            // 
            this.buttonStopStatistics.AutoSize = true;
            this.buttonStopStatistics.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonStopStatistics.Location = new System.Drawing.Point(102, 3);
            this.buttonStopStatistics.Name = "buttonStopStatistics";
            this.buttonStopStatistics.Size = new System.Drawing.Size(91, 22);
            this.buttonStopStatistics.TabIndex = 9;
            this.buttonStopStatistics.Text = "Stop Statistics";
            this.buttonStopStatistics.UseVisualStyleBackColor = true;
            // 
            // textBoxNumberOfSamples
            // 
            this.textBoxNumberOfSamples.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNumberOfSamples.Location = new System.Drawing.Point(114, 3);
            this.textBoxNumberOfSamples.Name = "textBoxNumberOfSamples";
            this.textBoxNumberOfSamples.ReadOnly = true;
            this.textBoxNumberOfSamples.Size = new System.Drawing.Size(101, 19);
            this.textBoxNumberOfSamples.TabIndex = 4;
            this.textBoxNumberOfSamples.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNumberOfSamples.WordWrap = false;
            // 
            // labelDurationUnit
            // 
            this.labelDurationUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelDurationUnit.AutoSize = true;
            this.labelDurationUnit.Location = new System.Drawing.Point(221, 31);
            this.labelDurationUnit.Name = "labelDurationUnit";
            this.labelDurationUnit.Size = new System.Drawing.Size(11, 12);
            this.labelDurationUnit.TabIndex = 5;
            this.labelDurationUnit.Text = "s";
            this.labelDurationUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxDuration
            // 
            this.textBoxDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDuration.Location = new System.Drawing.Point(114, 28);
            this.textBoxDuration.Name = "textBoxDuration";
            this.textBoxDuration.ReadOnly = true;
            this.textBoxDuration.Size = new System.Drawing.Size(101, 19);
            this.textBoxDuration.TabIndex = 6;
            this.textBoxDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxDuration.WordWrap = false;
            // 
            // textBoxAverage
            // 
            this.textBoxAverage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAverage.Location = new System.Drawing.Point(114, 53);
            this.textBoxAverage.Name = "textBoxAverage";
            this.textBoxAverage.ReadOnly = true;
            this.textBoxAverage.Size = new System.Drawing.Size(101, 19);
            this.textBoxAverage.TabIndex = 7;
            this.textBoxAverage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxAverage.WordWrap = false;
            // 
            // labelAverageUnit
            // 
            this.labelAverageUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelAverageUnit.AutoSize = true;
            this.labelAverageUnit.Location = new System.Drawing.Point(221, 56);
            this.labelAverageUnit.Name = "labelAverageUnit";
            this.labelAverageUnit.Size = new System.Drawing.Size(23, 12);
            this.labelAverageUnit.TabIndex = 8;
            this.labelAverageUnit.Text = "mm";
            this.labelAverageUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMaximum
            // 
            this.labelMaximum.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelMaximum.AutoSize = true;
            this.labelMaximum.Location = new System.Drawing.Point(352, 6);
            this.labelMaximum.Name = "labelMaximum";
            this.labelMaximum.Size = new System.Drawing.Size(53, 12);
            this.labelMaximum.TabIndex = 9;
            this.labelMaximum.Text = "Maximum";
            this.labelMaximum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMinimum
            // 
            this.labelMinimum.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelMinimum.AutoSize = true;
            this.labelMinimum.Location = new System.Drawing.Point(355, 31);
            this.labelMinimum.Name = "labelMinimum";
            this.labelMinimum.Size = new System.Drawing.Size(50, 12);
            this.labelMinimum.TabIndex = 10;
            this.labelMinimum.Text = "Minimum";
            this.labelMinimum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "Peak-to-Peak";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxMaximum
            // 
            this.textBoxMaximum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMaximum.Location = new System.Drawing.Point(411, 3);
            this.textBoxMaximum.Name = "textBoxMaximum";
            this.textBoxMaximum.ReadOnly = true;
            this.textBoxMaximum.Size = new System.Drawing.Size(101, 19);
            this.textBoxMaximum.TabIndex = 12;
            this.textBoxMaximum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMaximum.WordWrap = false;
            // 
            // textBoxMinimum
            // 
            this.textBoxMinimum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMinimum.Location = new System.Drawing.Point(411, 28);
            this.textBoxMinimum.Name = "textBoxMinimum";
            this.textBoxMinimum.ReadOnly = true;
            this.textBoxMinimum.Size = new System.Drawing.Size(101, 19);
            this.textBoxMinimum.TabIndex = 13;
            this.textBoxMinimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMinimum.WordWrap = false;
            // 
            // textBoxPeakToPeak
            // 
            this.textBoxPeakToPeak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPeakToPeak.Location = new System.Drawing.Point(411, 53);
            this.textBoxPeakToPeak.Name = "textBoxPeakToPeak";
            this.textBoxPeakToPeak.ReadOnly = true;
            this.textBoxPeakToPeak.Size = new System.Drawing.Size(101, 19);
            this.textBoxPeakToPeak.TabIndex = 14;
            this.textBoxPeakToPeak.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPeakToPeak.WordWrap = false;
            // 
            // labelMaximumUnit
            // 
            this.labelMaximumUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelMaximumUnit.AutoSize = true;
            this.labelMaximumUnit.Location = new System.Drawing.Point(518, 6);
            this.labelMaximumUnit.Name = "labelMaximumUnit";
            this.labelMaximumUnit.Size = new System.Drawing.Size(23, 12);
            this.labelMaximumUnit.TabIndex = 15;
            this.labelMaximumUnit.Text = "mm";
            this.labelMaximumUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMinimumUnit
            // 
            this.labelMinimumUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelMinimumUnit.AutoSize = true;
            this.labelMinimumUnit.Location = new System.Drawing.Point(518, 31);
            this.labelMinimumUnit.Name = "labelMinimumUnit";
            this.labelMinimumUnit.Size = new System.Drawing.Size(23, 12);
            this.labelMinimumUnit.TabIndex = 16;
            this.labelMinimumUnit.Text = "mm";
            this.labelMinimumUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPeakToPeakUnit
            // 
            this.labelPeakToPeakUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelPeakToPeakUnit.AutoSize = true;
            this.labelPeakToPeakUnit.Location = new System.Drawing.Point(518, 56);
            this.labelPeakToPeakUnit.Name = "labelPeakToPeakUnit";
            this.labelPeakToPeakUnit.Size = new System.Drawing.Size(23, 12);
            this.labelPeakToPeakUnit.TabIndex = 17;
            this.labelPeakToPeakUnit.Text = "mm";
            this.labelPeakToPeakUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AcceptButton = this.buttonConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonQuit;
            this.ClientSize = new System.Drawing.Size(634, 468);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanelStatisticsButtons.ResumeLayout(false);
            this.flowLayoutPanelStatisticsButtons.PerformLayout();
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
        private System.Windows.Forms.Timer timerDisplayUpdateLoop;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.GroupBox groupBoxRecording;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRecording;
        private System.Windows.Forms.Label labelCSVOutputPath;
        private System.Windows.Forms.TextBox textBoxCSVOutputPath;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRecordingButtons;
        private System.Windows.Forms.Button buttonSetCSVOutputPath;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelStatisticsButtons;
        private System.Windows.Forms.Button buttonStartStatistics;
        private System.Windows.Forms.Button buttonStopStatistics;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelNumberOfSamples;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelAverage;
        private System.Windows.Forms.TextBox textBoxNumberOfSamples;
        private System.Windows.Forms.Label labelDurationUnit;
        private System.Windows.Forms.TextBox textBoxDuration;
        private System.Windows.Forms.TextBox textBoxAverage;
        private System.Windows.Forms.Label labelAverageUnit;
        private System.Windows.Forms.Label labelMaximum;
        private System.Windows.Forms.Label labelMinimum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMaximum;
        private System.Windows.Forms.TextBox textBoxMinimum;
        private System.Windows.Forms.TextBox textBoxPeakToPeak;
        private System.Windows.Forms.Label labelMaximumUnit;
        private System.Windows.Forms.Label labelMinimumUnit;
        private System.Windows.Forms.Label labelPeakToPeakUnit;
    }
}

