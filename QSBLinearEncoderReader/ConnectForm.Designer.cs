﻿namespace QSBLinearEncoderReader
{
    partial class ConnectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.labelCOMPort = new System.Windows.Forms.Label();
            this.labelBaudRate = new System.Windows.Forms.Label();
            this.labelQuadratureMode = new System.Windows.Forms.Label();
            this.labelResolution = new System.Windows.Forms.Label();
            this.labelZeroPositionCount = new System.Windows.Forms.Label();
            this.labelDirection = new System.Windows.Forms.Label();
            this.comboBoxCOMPort = new System.Windows.Forms.ComboBox();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.labelBaudRateUnit = new System.Windows.Forms.Label();
            this.comboBoxQuadratureMode = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelResolutionUnit = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.labelZeroPositionCountUnit = new System.Windows.Forms.Label();
            this.comboBoxDirection = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonConnect, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelCOMPort, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelBaudRate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelQuadratureMode, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelResolution, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelZeroPositionCount, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelDirection, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxCOMPort, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxBaudRate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelBaudRateUnit, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxQuadratureMode, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelResolutionUnit, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelZeroPositionCountUnit, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxDirection, 1, 5);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 261);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(328, 230);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(53, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonConnect.AutoSize = true;
            this.buttonConnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonConnect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonConnect.Location = new System.Drawing.Point(265, 230);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(57, 23);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            // 
            // labelCOMPort
            // 
            this.labelCOMPort.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelCOMPort.AutoSize = true;
            this.labelCOMPort.Location = new System.Drawing.Point(50, 12);
            this.labelCOMPort.Name = "labelCOMPort";
            this.labelCOMPort.Size = new System.Drawing.Size(56, 13);
            this.labelCOMPort.TabIndex = 2;
            this.labelCOMPort.Text = "COM Port:";
            this.labelCOMPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelBaudRate
            // 
            this.labelBaudRate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelBaudRate.AutoSize = true;
            this.labelBaudRate.Location = new System.Drawing.Point(45, 49);
            this.labelBaudRate.Name = "labelBaudRate";
            this.labelBaudRate.Size = new System.Drawing.Size(61, 13);
            this.labelBaudRate.TabIndex = 3;
            this.labelBaudRate.Text = "Baud Rate:";
            this.labelBaudRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelQuadratureMode
            // 
            this.labelQuadratureMode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelQuadratureMode.AutoSize = true;
            this.labelQuadratureMode.Location = new System.Drawing.Point(13, 86);
            this.labelQuadratureMode.Name = "labelQuadratureMode";
            this.labelQuadratureMode.Size = new System.Drawing.Size(93, 13);
            this.labelQuadratureMode.TabIndex = 4;
            this.labelQuadratureMode.Text = "Quadrature Mode:";
            this.labelQuadratureMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelResolution
            // 
            this.labelResolution.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelResolution.AutoSize = true;
            this.labelResolution.Location = new System.Drawing.Point(46, 123);
            this.labelResolution.Name = "labelResolution";
            this.labelResolution.Size = new System.Drawing.Size(60, 13);
            this.labelResolution.TabIndex = 5;
            this.labelResolution.Text = "Resolution:";
            this.labelResolution.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelZeroPositionCount
            // 
            this.labelZeroPositionCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelZeroPositionCount.AutoSize = true;
            this.labelZeroPositionCount.Location = new System.Drawing.Point(3, 160);
            this.labelZeroPositionCount.Name = "labelZeroPositionCount";
            this.labelZeroPositionCount.Size = new System.Drawing.Size(103, 13);
            this.labelZeroPositionCount.TabIndex = 6;
            this.labelZeroPositionCount.Text = "Zero Position Count:";
            this.labelZeroPositionCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDirection
            // 
            this.labelDirection.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelDirection.AutoSize = true;
            this.labelDirection.Location = new System.Drawing.Point(57, 197);
            this.labelDirection.Name = "labelDirection";
            this.labelDirection.Size = new System.Drawing.Size(49, 13);
            this.labelDirection.TabIndex = 7;
            this.labelDirection.Text = "Direction";
            this.labelDirection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxCOMPort
            // 
            this.comboBoxCOMPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCOMPort.FormattingEnabled = true;
            this.comboBoxCOMPort.Location = new System.Drawing.Point(112, 8);
            this.comboBoxCOMPort.Name = "comboBoxCOMPort";
            this.comboBoxCOMPort.Size = new System.Drawing.Size(210, 21);
            this.comboBoxCOMPort.TabIndex = 8;
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "56000",
            "115200",
            "128000",
            "230400",
            "256000"});
            this.comboBoxBaudRate.Location = new System.Drawing.Point(112, 45);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(210, 21);
            this.comboBoxBaudRate.TabIndex = 9;
            // 
            // labelBaudRateUnit
            // 
            this.labelBaudRateUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelBaudRateUnit.AutoSize = true;
            this.labelBaudRateUnit.Location = new System.Drawing.Point(328, 49);
            this.labelBaudRateUnit.Name = "labelBaudRateUnit";
            this.labelBaudRateUnit.Size = new System.Drawing.Size(33, 13);
            this.labelBaudRateUnit.TabIndex = 10;
            this.labelBaudRateUnit.Text = "bits/s";
            this.labelBaudRateUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxQuadratureMode
            // 
            this.comboBoxQuadratureMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxQuadratureMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQuadratureMode.FormattingEnabled = true;
            this.comboBoxQuadratureMode.Items.AddRange(new object[] {
            "X1 (one count per quadrature cycle)",
            "X2 (two counts per quadrature cycle)",
            "X4 (four counts per quadrature cycle)"});
            this.comboBoxQuadratureMode.Location = new System.Drawing.Point(112, 82);
            this.comboBoxQuadratureMode.Name = "comboBoxQuadratureMode";
            this.comboBoxQuadratureMode.Size = new System.Drawing.Size(210, 21);
            this.comboBoxQuadratureMode.TabIndex = 11;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown1.Location = new System.Drawing.Point(112, 119);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(210, 20);
            this.numericUpDown1.TabIndex = 12;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelResolutionUnit
            // 
            this.labelResolutionUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelResolutionUnit.AutoSize = true;
            this.labelResolutionUnit.Location = new System.Drawing.Point(328, 123);
            this.labelResolutionUnit.Name = "labelResolutionUnit";
            this.labelResolutionUnit.Size = new System.Drawing.Size(53, 13);
            this.labelResolutionUnit.TabIndex = 13;
            this.labelResolutionUnit.Text = "nm/count";
            this.labelResolutionUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown2.Location = new System.Drawing.Point(112, 156);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(210, 20);
            this.numericUpDown2.TabIndex = 14;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelZeroPositionCountUnit
            // 
            this.labelZeroPositionCountUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelZeroPositionCountUnit.AutoSize = true;
            this.labelZeroPositionCountUnit.Location = new System.Drawing.Point(328, 160);
            this.labelZeroPositionCountUnit.Name = "labelZeroPositionCountUnit";
            this.labelZeroPositionCountUnit.Size = new System.Drawing.Size(34, 13);
            this.labelZeroPositionCountUnit.TabIndex = 15;
            this.labelZeroPositionCountUnit.Text = "count";
            this.labelZeroPositionCountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxDirection
            // 
            this.comboBoxDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDirection.FormattingEnabled = true;
            this.comboBoxDirection.Items.AddRange(new object[] {
            "Positive",
            "Negative"});
            this.comboBoxDirection.Location = new System.Drawing.Point(112, 193);
            this.comboBoxDirection.Name = "comboBoxDirection";
            this.comboBoxDirection.Size = new System.Drawing.Size(210, 21);
            this.comboBoxDirection.TabIndex = 16;
            // 
            // ConnectForm
            // 
            this.AcceptButton = this.buttonConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "ConnectForm";
            this.Text = "Connect to QSB Encoder Reader";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ConnectForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelCOMPort;
        private System.Windows.Forms.Label labelBaudRate;
        private System.Windows.Forms.Label labelQuadratureMode;
        private System.Windows.Forms.Label labelResolution;
        private System.Windows.Forms.Label labelZeroPositionCount;
        private System.Windows.Forms.Label labelDirection;
        private System.Windows.Forms.ComboBox comboBoxCOMPort;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.Label labelBaudRateUnit;
        private System.Windows.Forms.ComboBox comboBoxQuadratureMode;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label labelResolutionUnit;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label labelZeroPositionCountUnit;
        private System.Windows.Forms.ComboBox comboBoxDirection;
    }
}