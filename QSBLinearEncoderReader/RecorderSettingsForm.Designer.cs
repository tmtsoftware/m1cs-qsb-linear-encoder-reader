﻿namespace QSBLinearEncoderReader
{
    partial class RecorderSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecorderSettingsForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelOutputDirectory = new System.Windows.Forms.Label();
            this.textBoxOutputDirectory = new System.Windows.Forms.TextBox();
            this.labelCSVFilename = new System.Windows.Forms.Label();
            this.textBoxCSVFilename = new System.Windows.Forms.TextBox();
            this.labelRecordingInterval = new System.Windows.Forms.Label();
            this.labelMaxRecords = new System.Windows.Forms.Label();
            this.labelCSVFilenameExample = new System.Windows.Forms.Label();
            this.textBoxCSVFilenameExample = new System.Windows.Forms.TextBox();
            this.numericUpDownMaxRecordsPerFile = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRecordingInterval = new System.Windows.Forms.NumericUpDown();
            this.labelRecordingRate = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonCSVFilenameHelp = new System.Windows.Forms.Button();
            this.buttonSelectDirectory = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelFlushInterval = new System.Windows.Forms.Label();
            this.numericUpDownFlushInterval = new System.Windows.Forms.NumericUpDown();
            this.labelFlushIntervalUnit = new System.Windows.Forms.Label();
            this.errorProviderOutputDirectory = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderCSVFilename = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxRecordsPerFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRecordingInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFlushInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderOutputDirectory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCSVFilename)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.labelOutputDirectory, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxOutputDirectory, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelCSVFilename, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCSVFilename, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelRecordingInterval, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelMaxRecords, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelCSVFilenameExample, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCSVFilenameExample, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownMaxRecordsPerFile, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownRecordingInterval, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelRecordingRate, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonCSVFilenameHelp, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonSelectDirectory, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonOK, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelFlushInterval, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownFlushInterval, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelFlushIntervalUnit, 2, 5);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 221);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelOutputDirectory
            // 
            this.labelOutputDirectory.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelOutputDirectory.AutoSize = true;
            this.labelOutputDirectory.Location = new System.Drawing.Point(87, 9);
            this.labelOutputDirectory.Name = "labelOutputDirectory";
            this.labelOutputDirectory.Size = new System.Drawing.Size(87, 13);
            this.labelOutputDirectory.TabIndex = 99;
            this.labelOutputDirectory.Text = "Output Directory:";
            this.labelOutputDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxOutputDirectory
            // 
            this.textBoxOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxOutputDirectory, 2);
            this.textBoxOutputDirectory.Location = new System.Drawing.Point(180, 5);
            this.textBoxOutputDirectory.Name = "textBoxOutputDirectory";
            this.textBoxOutputDirectory.Size = new System.Drawing.Size(296, 20);
            this.textBoxOutputDirectory.TabIndex = 2;
            this.textBoxOutputDirectory.WordWrap = false;
            this.textBoxOutputDirectory.TextChanged += new System.EventHandler(this.textBoxOutputDirectory_TextChanged);
            this.textBoxOutputDirectory.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxOutputDirectory_Validating);
            // 
            // labelCSVFilename
            // 
            this.labelCSVFilename.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelCSVFilename.AutoSize = true;
            this.labelCSVFilename.Location = new System.Drawing.Point(98, 40);
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
            this.textBoxCSVFilename.Location = new System.Drawing.Point(180, 36);
            this.textBoxCSVFilename.Name = "textBoxCSVFilename";
            this.textBoxCSVFilename.Size = new System.Drawing.Size(296, 20);
            this.textBoxCSVFilename.TabIndex = 4;
            this.textBoxCSVFilename.WordWrap = false;
            this.textBoxCSVFilename.TextChanged += new System.EventHandler(this.textBoxCSVFilename_TextChanged);
            this.textBoxCSVFilename.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxCSVFilename_Validating);
            // 
            // labelRecordingInterval
            // 
            this.labelRecordingInterval.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelRecordingInterval.AutoSize = true;
            this.labelRecordingInterval.Location = new System.Drawing.Point(77, 133);
            this.labelRecordingInterval.Name = "labelRecordingInterval";
            this.labelRecordingInterval.Size = new System.Drawing.Size(97, 13);
            this.labelRecordingInterval.TabIndex = 99;
            this.labelRecordingInterval.Text = "Recording Interval:";
            this.labelRecordingInterval.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMaxRecords
            // 
            this.labelMaxRecords.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelMaxRecords.AutoSize = true;
            this.labelMaxRecords.Location = new System.Drawing.Point(3, 102);
            this.labelMaxRecords.Name = "labelMaxRecords";
            this.labelMaxRecords.Size = new System.Drawing.Size(171, 13);
            this.labelMaxRecords.TabIndex = 99;
            this.labelMaxRecords.Text = "Maximum records per one CSV file:";
            this.labelMaxRecords.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCSVFilenameExample
            // 
            this.labelCSVFilenameExample.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelCSVFilenameExample.AutoSize = true;
            this.labelCSVFilenameExample.Location = new System.Drawing.Point(55, 71);
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
            this.textBoxCSVFilenameExample.Location = new System.Drawing.Point(180, 67);
            this.textBoxCSVFilenameExample.Name = "textBoxCSVFilenameExample";
            this.textBoxCSVFilenameExample.ReadOnly = true;
            this.textBoxCSVFilenameExample.Size = new System.Drawing.Size(296, 20);
            this.textBoxCSVFilenameExample.TabIndex = 99;
            this.textBoxCSVFilenameExample.TabStop = false;
            this.textBoxCSVFilenameExample.WordWrap = false;
            // 
            // numericUpDownMaxRecordsPerFile
            // 
            this.numericUpDownMaxRecordsPerFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownMaxRecordsPerFile.AutoSize = true;
            this.numericUpDownMaxRecordsPerFile.Location = new System.Drawing.Point(180, 98);
            this.numericUpDownMaxRecordsPerFile.Maximum = new decimal(new int[] {
            1048574,
            0,
            0,
            0});
            this.numericUpDownMaxRecordsPerFile.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownMaxRecordsPerFile.Name = "numericUpDownMaxRecordsPerFile";
            this.numericUpDownMaxRecordsPerFile.Size = new System.Drawing.Size(71, 20);
            this.numericUpDownMaxRecordsPerFile.TabIndex = 6;
            this.numericUpDownMaxRecordsPerFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownMaxRecordsPerFile.ThousandsSeparator = true;
            this.numericUpDownMaxRecordsPerFile.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // numericUpDownRecordingInterval
            // 
            this.numericUpDownRecordingInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownRecordingInterval.AutoSize = true;
            this.numericUpDownRecordingInterval.Location = new System.Drawing.Point(180, 129);
            this.numericUpDownRecordingInterval.Maximum = new decimal(new int[] {
            30720,
            0,
            0,
            0});
            this.numericUpDownRecordingInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRecordingInterval.Name = "numericUpDownRecordingInterval";
            this.numericUpDownRecordingInterval.Size = new System.Drawing.Size(71, 20);
            this.numericUpDownRecordingInterval.TabIndex = 7;
            this.numericUpDownRecordingInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownRecordingInterval.ThousandsSeparator = true;
            this.numericUpDownRecordingInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRecordingInterval.ValueChanged += new System.EventHandler(this.numericUpDownRecordingInterval_ValueChanged);
            this.numericUpDownRecordingInterval.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDownRecordingInterval_KeyDown);
            this.numericUpDownRecordingInterval.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownRecordingInterval_KeyUp);
            // 
            // labelRecordingRate
            // 
            this.labelRecordingRate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelRecordingRate.AutoSize = true;
            this.labelRecordingRate.Location = new System.Drawing.Point(257, 133);
            this.labelRecordingRate.Name = "labelRecordingRate";
            this.labelRecordingRate.Size = new System.Drawing.Size(29, 13);
            this.labelRecordingRate.TabIndex = 99;
            this.labelRecordingRate.Text = "( Hz)";
            this.labelRecordingRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.buttonCancel, 2);
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(482, 192);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(99, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonCSVFilenameHelp
            // 
            this.buttonCSVFilenameHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCSVFilenameHelp.Location = new System.Drawing.Point(506, 35);
            this.buttonCSVFilenameHelp.Name = "buttonCSVFilenameHelp";
            this.buttonCSVFilenameHelp.Size = new System.Drawing.Size(75, 22);
            this.buttonCSVFilenameHelp.TabIndex = 5;
            this.buttonCSVFilenameHelp.Text = "&Help...";
            this.buttonCSVFilenameHelp.UseVisualStyleBackColor = true;
            this.buttonCSVFilenameHelp.Click += new System.EventHandler(this.buttonCSVFilenameHelp_Click);
            // 
            // buttonSelectDirectory
            // 
            this.buttonSelectDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectDirectory.Location = new System.Drawing.Point(506, 4);
            this.buttonSelectDirectory.Name = "buttonSelectDirectory";
            this.buttonSelectDirectory.Size = new System.Drawing.Size(75, 22);
            this.buttonSelectDirectory.TabIndex = 3;
            this.buttonSelectDirectory.Text = "&Select...";
            this.buttonSelectDirectory.UseVisualStyleBackColor = true;
            this.buttonSelectDirectory.Click += new System.EventHandler(this.buttonSelectDirectory_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(401, 192);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // labelFlushInterval
            // 
            this.labelFlushInterval.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelFlushInterval.AutoSize = true;
            this.labelFlushInterval.Location = new System.Drawing.Point(101, 164);
            this.labelFlushInterval.Name = "labelFlushInterval";
            this.labelFlushInterval.Size = new System.Drawing.Size(73, 13);
            this.labelFlushInterval.TabIndex = 99;
            this.labelFlushInterval.Text = "Flush Interval:";
            this.labelFlushInterval.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDownFlushInterval
            // 
            this.numericUpDownFlushInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownFlushInterval.AutoSize = true;
            this.numericUpDownFlushInterval.Location = new System.Drawing.Point(180, 160);
            this.numericUpDownFlushInterval.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownFlushInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFlushInterval.Name = "numericUpDownFlushInterval";
            this.numericUpDownFlushInterval.Size = new System.Drawing.Size(71, 20);
            this.numericUpDownFlushInterval.TabIndex = 8;
            this.numericUpDownFlushInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownFlushInterval.ThousandsSeparator = true;
            this.numericUpDownFlushInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownFlushInterval.ValueChanged += new System.EventHandler(this.numericUpDownRecordingInterval_ValueChanged);
            this.numericUpDownFlushInterval.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDownRecordingInterval_KeyDown);
            this.numericUpDownFlushInterval.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDownRecordingInterval_KeyUp);
            // 
            // labelFlushIntervalUnit
            // 
            this.labelFlushIntervalUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelFlushIntervalUnit.AutoSize = true;
            this.labelFlushIntervalUnit.Location = new System.Drawing.Point(257, 164);
            this.labelFlushIntervalUnit.Name = "labelFlushIntervalUnit";
            this.labelFlushIntervalUnit.Size = new System.Drawing.Size(12, 13);
            this.labelFlushIntervalUnit.TabIndex = 99;
            this.labelFlushIntervalUnit.Text = "s";
            this.labelFlushIntervalUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProviderOutputDirectory
            // 
            this.errorProviderOutputDirectory.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderOutputDirectory.ContainerControl = this;
            // 
            // errorProviderCSVFilename
            // 
            this.errorProviderCSVFilename.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderCSVFilename.ContainerControl = this;
            // 
            // RecorderSettingsForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(584, 221);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 246);
            this.Name = "RecorderSettingsForm";
            this.Text = "Recorder Settings";
            this.Load += new System.EventHandler(this.RecordingSettingsForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxRecordsPerFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRecordingInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFlushInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderOutputDirectory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderCSVFilename)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelOutputDirectory;
        private System.Windows.Forms.Label labelMaxRecords;
        private System.Windows.Forms.Label labelRecordingInterval;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBoxOutputDirectory;
        private System.Windows.Forms.Button buttonSelectDirectory;
        private System.Windows.Forms.Label labelCSVFilename;
        private System.Windows.Forms.TextBox textBoxCSVFilename;
        private System.Windows.Forms.Label labelCSVFilenameExample;
        private System.Windows.Forms.TextBox textBoxCSVFilenameExample;
        private System.Windows.Forms.Button buttonCSVFilenameHelp;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxRecordsPerFile;
        private System.Windows.Forms.NumericUpDown numericUpDownRecordingInterval;
        private System.Windows.Forms.Label labelRecordingRate;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ErrorProvider errorProviderOutputDirectory;
        private System.Windows.Forms.ErrorProvider errorProviderCSVFilename;
        private System.Windows.Forms.Label labelFlushInterval;
        private System.Windows.Forms.NumericUpDown numericUpDownFlushInterval;
        private System.Windows.Forms.Label labelFlushIntervalUnit;
    }
}