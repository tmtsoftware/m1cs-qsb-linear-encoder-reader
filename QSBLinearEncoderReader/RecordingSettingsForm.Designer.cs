namespace QSBLinearEncoderReader
{
    partial class RecordingSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordingSettingsForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelOutputDirectory = new System.Windows.Forms.Label();
            this.labelMaxRecords = new System.Windows.Forms.Label();
            this.labelRecordingInterval = new System.Windows.Forms.Label();
            this.labelRecordAbsoluteTime = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxOutputDirectory = new System.Windows.Forms.TextBox();
            this.buttonSelectDirectory = new System.Windows.Forms.Button();
            this.labelCSVFilename = new System.Windows.Forms.Label();
            this.textBoxCSVFilename = new System.Windows.Forms.TextBox();
            this.labelCSVFilenameExample = new System.Windows.Forms.Label();
            this.textBoxCSVFilenameExample = new System.Windows.Forms.TextBox();
            this.buttonCSVFilenameHelp = new System.Windows.Forms.Button();
            this.checkBoxRecordAbsoluteTime = new System.Windows.Forms.CheckBox();
            this.numericUpDownMaxRecords = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.labelRecordingRate = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.labelOutputDirectory, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxOutputDirectory, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelCSVFilename, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCSVFilename, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelRecordAbsoluteTime, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelRecordingInterval, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelMaxRecords, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelCSVFilenameExample, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCSVFilenameExample, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxRecordAbsoluteTime, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownMaxRecords, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonCSVFilenameHelp, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonSelectDirectory, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownInterval, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelRecordingRate, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonOK, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 3, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(604, 201);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelOutputDirectory
            // 
            this.labelOutputDirectory.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelOutputDirectory.AutoSize = true;
            this.labelOutputDirectory.Location = new System.Drawing.Point(87, 7);
            this.labelOutputDirectory.Name = "labelOutputDirectory";
            this.labelOutputDirectory.Size = new System.Drawing.Size(87, 13);
            this.labelOutputDirectory.TabIndex = 99;
            this.labelOutputDirectory.Text = "Output Directory:";
            this.labelOutputDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMaxRecords
            // 
            this.labelMaxRecords.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelMaxRecords.AutoSize = true;
            this.labelMaxRecords.Location = new System.Drawing.Point(3, 91);
            this.labelMaxRecords.Name = "labelMaxRecords";
            this.labelMaxRecords.Size = new System.Drawing.Size(171, 13);
            this.labelMaxRecords.TabIndex = 99;
            this.labelMaxRecords.Text = "Maximum records per one CSV file:";
            this.labelMaxRecords.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRecordingInterval
            // 
            this.labelRecordingInterval.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelRecordingInterval.AutoSize = true;
            this.labelRecordingInterval.Location = new System.Drawing.Point(77, 119);
            this.labelRecordingInterval.Name = "labelRecordingInterval";
            this.labelRecordingInterval.Size = new System.Drawing.Size(97, 13);
            this.labelRecordingInterval.TabIndex = 99;
            this.labelRecordingInterval.Text = "Recording Interval:";
            this.labelRecordingInterval.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRecordAbsoluteTime
            // 
            this.labelRecordAbsoluteTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelRecordAbsoluteTime.AutoSize = true;
            this.labelRecordAbsoluteTime.Location = new System.Drawing.Point(59, 147);
            this.labelRecordAbsoluteTime.Name = "labelRecordAbsoluteTime";
            this.labelRecordAbsoluteTime.Size = new System.Drawing.Size(115, 13);
            this.labelRecordAbsoluteTime.TabIndex = 99;
            this.labelRecordAbsoluteTime.Text = "Record Absolute Time:";
            this.labelRecordAbsoluteTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(445, 173);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // textBoxOutputDirectory
            // 
            this.textBoxOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxOutputDirectory, 2);
            this.textBoxOutputDirectory.Location = new System.Drawing.Point(180, 4);
            this.textBoxOutputDirectory.Name = "textBoxOutputDirectory";
            this.textBoxOutputDirectory.Size = new System.Drawing.Size(340, 20);
            this.textBoxOutputDirectory.TabIndex = 2;
            this.textBoxOutputDirectory.WordWrap = false;
            // 
            // buttonSelectDirectory
            // 
            this.buttonSelectDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectDirectory.Location = new System.Drawing.Point(526, 3);
            this.buttonSelectDirectory.Name = "buttonSelectDirectory";
            this.buttonSelectDirectory.Size = new System.Drawing.Size(75, 22);
            this.buttonSelectDirectory.TabIndex = 3;
            this.buttonSelectDirectory.Text = "Select...";
            this.buttonSelectDirectory.UseVisualStyleBackColor = true;
            // 
            // labelCSVFilename
            // 
            this.labelCSVFilename.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelCSVFilename.AutoSize = true;
            this.labelCSVFilename.Location = new System.Drawing.Point(98, 35);
            this.labelCSVFilename.Name = "labelCSVFilename";
            this.labelCSVFilename.Size = new System.Drawing.Size(76, 13);
            this.labelCSVFilename.TabIndex = 99;
            this.labelCSVFilename.Text = "CSV Filename:";
            this.labelCSVFilename.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxCSVFilename
            // 
            this.textBoxCSVFilename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxCSVFilename, 2);
            this.textBoxCSVFilename.Location = new System.Drawing.Point(180, 32);
            this.textBoxCSVFilename.Name = "textBoxCSVFilename";
            this.textBoxCSVFilename.Size = new System.Drawing.Size(340, 20);
            this.textBoxCSVFilename.TabIndex = 4;
            this.textBoxCSVFilename.WordWrap = false;
            // 
            // labelCSVFilenameExample
            // 
            this.labelCSVFilenameExample.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelCSVFilenameExample.AutoSize = true;
            this.labelCSVFilenameExample.Location = new System.Drawing.Point(55, 63);
            this.labelCSVFilenameExample.Name = "labelCSVFilenameExample";
            this.labelCSVFilenameExample.Size = new System.Drawing.Size(119, 13);
            this.labelCSVFilenameExample.TabIndex = 99;
            this.labelCSVFilenameExample.Text = "CSV Filename Example:";
            this.labelCSVFilenameExample.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxCSVFilenameExample
            // 
            this.textBoxCSVFilenameExample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxCSVFilenameExample, 2);
            this.textBoxCSVFilenameExample.Location = new System.Drawing.Point(180, 60);
            this.textBoxCSVFilenameExample.Name = "textBoxCSVFilenameExample";
            this.textBoxCSVFilenameExample.ReadOnly = true;
            this.textBoxCSVFilenameExample.Size = new System.Drawing.Size(340, 20);
            this.textBoxCSVFilenameExample.TabIndex = 99;
            this.textBoxCSVFilenameExample.TabStop = false;
            this.textBoxCSVFilenameExample.WordWrap = false;
            // 
            // buttonCSVFilenameHelp
            // 
            this.buttonCSVFilenameHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCSVFilenameHelp.Location = new System.Drawing.Point(526, 31);
            this.buttonCSVFilenameHelp.Name = "buttonCSVFilenameHelp";
            this.buttonCSVFilenameHelp.Size = new System.Drawing.Size(75, 22);
            this.buttonCSVFilenameHelp.TabIndex = 5;
            this.buttonCSVFilenameHelp.Text = "Help...";
            this.buttonCSVFilenameHelp.UseVisualStyleBackColor = true;
            // 
            // checkBoxRecordAbsoluteTime
            // 
            this.checkBoxRecordAbsoluteTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxRecordAbsoluteTime.AutoSize = true;
            this.checkBoxRecordAbsoluteTime.Location = new System.Drawing.Point(180, 147);
            this.checkBoxRecordAbsoluteTime.Name = "checkBoxRecordAbsoluteTime";
            this.checkBoxRecordAbsoluteTime.Size = new System.Drawing.Size(15, 14);
            this.checkBoxRecordAbsoluteTime.TabIndex = 8;
            this.checkBoxRecordAbsoluteTime.UseVisualStyleBackColor = true;
            // 
            // numericUpDownMaxRecords
            // 
            this.numericUpDownMaxRecords.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownMaxRecords.Location = new System.Drawing.Point(180, 88);
            this.numericUpDownMaxRecords.Maximum = new decimal(new int[] {
            1048574,
            0,
            0,
            0});
            this.numericUpDownMaxRecords.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownMaxRecords.Name = "numericUpDownMaxRecords";
            this.numericUpDownMaxRecords.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMaxRecords.TabIndex = 6;
            this.numericUpDownMaxRecords.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownMaxRecords.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // numericUpDownInterval
            // 
            this.numericUpDownInterval.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownInterval.Location = new System.Drawing.Point(180, 116);
            this.numericUpDownInterval.Maximum = new decimal(new int[] {
            30720,
            0,
            0,
            0});
            this.numericUpDownInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.numericUpDownInterval.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownInterval.TabIndex = 7;
            this.numericUpDownInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelRecordingRate
            // 
            this.labelRecordingRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelRecordingRate.AutoSize = true;
            this.labelRecordingRate.Location = new System.Drawing.Point(306, 119);
            this.labelRecordingRate.Name = "labelRecordingRate";
            this.labelRecordingRate.Size = new System.Drawing.Size(29, 13);
            this.labelRecordingRate.TabIndex = 99;
            this.labelRecordingRate.Text = "( Hz)";
            this.labelRecordingRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(526, 173);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // RecordingSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 201);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RecordingSettingsForm";
            this.Text = "Recording Settings";
            this.Load += new System.EventHandler(this.RecordingSettingsForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelOutputDirectory;
        private System.Windows.Forms.Label labelMaxRecords;
        private System.Windows.Forms.Label labelRecordingInterval;
        private System.Windows.Forms.Label labelRecordAbsoluteTime;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBoxOutputDirectory;
        private System.Windows.Forms.Button buttonSelectDirectory;
        private System.Windows.Forms.Label labelCSVFilename;
        private System.Windows.Forms.TextBox textBoxCSVFilename;
        private System.Windows.Forms.Label labelCSVFilenameExample;
        private System.Windows.Forms.TextBox textBoxCSVFilenameExample;
        private System.Windows.Forms.Button buttonCSVFilenameHelp;
        private System.Windows.Forms.CheckBox checkBoxRecordAbsoluteTime;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxRecords;
        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
        private System.Windows.Forms.Label labelRecordingRate;
        private System.Windows.Forms.Button buttonCancel;
    }
}