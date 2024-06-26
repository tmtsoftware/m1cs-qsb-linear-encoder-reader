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
            this.labelCOMPort = new System.Windows.Forms.Label();
            this.labelQuadratureMode = new System.Windows.Forms.Label();
            this.labelResolution = new System.Windows.Forms.Label();
            this.labelZeroPositionCount = new System.Windows.Forms.Label();
            this.labelDirection = new System.Windows.Forms.Label();
            this.comboBoxCOMPort = new System.Windows.Forms.ComboBox();
            this.comboBoxQuadratureMode = new System.Windows.Forms.ComboBox();
            this.numericUpDownResolution = new System.Windows.Forms.NumericUpDown();
            this.labelResolutionUnit = new System.Windows.Forms.Label();
            this.numericUpDownZeroPositionCount = new System.Windows.Forms.NumericUpDown();
            this.labelZeroPositionCountUnit = new System.Windows.Forms.Label();
            this.comboBoxDirection = new System.Windows.Forms.ComboBox();
            this.labelBaudRate = new System.Windows.Forms.Label();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.labelDisplayUpdateRate = new System.Windows.Forms.Label();
            this.comboBoxDisplayUpdateRate = new System.Windows.Forms.ComboBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelIgnoreInvalidMessage = new System.Windows.Forms.Label();
            this.labelIgnoreInvalidMessageUnit = new System.Windows.Forms.Label();
            this.numericUpDownAcceptableInvalidMessagesInARow = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownResolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZeroPositionCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAcceptableInvalidMessagesInARow)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.labelCOMPort, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelQuadratureMode, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelResolution, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelZeroPositionCount, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelDirection, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxCOMPort, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxQuadratureMode, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownResolution, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelResolutionUnit, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownZeroPositionCount, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelZeroPositionCountUnit, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxDirection, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelBaudRate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxBaudRate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelDisplayUpdateRate, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxDisplayUpdateRate, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelIgnoreInvalidMessage, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelIgnoreInvalidMessageUnit, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownAcceptableInvalidMessagesInARow, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 8);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 283);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelCOMPort
            // 
            this.labelCOMPort.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelCOMPort.AutoSize = true;
            this.labelCOMPort.Location = new System.Drawing.Point(55, 9);
            this.labelCOMPort.Name = "labelCOMPort";
            this.labelCOMPort.Size = new System.Drawing.Size(56, 13);
            this.labelCOMPort.TabIndex = 99;
            this.labelCOMPort.Text = "COM Port:";
            this.labelCOMPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelQuadratureMode
            // 
            this.labelQuadratureMode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelQuadratureMode.AutoSize = true;
            this.labelQuadratureMode.Location = new System.Drawing.Point(18, 71);
            this.labelQuadratureMode.Name = "labelQuadratureMode";
            this.labelQuadratureMode.Size = new System.Drawing.Size(93, 13);
            this.labelQuadratureMode.TabIndex = 99;
            this.labelQuadratureMode.Text = "Quadrature Mode:";
            this.labelQuadratureMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelResolution
            // 
            this.labelResolution.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelResolution.AutoSize = true;
            this.labelResolution.Location = new System.Drawing.Point(51, 102);
            this.labelResolution.Name = "labelResolution";
            this.labelResolution.Size = new System.Drawing.Size(60, 13);
            this.labelResolution.TabIndex = 99;
            this.labelResolution.Text = "Resolution:";
            this.labelResolution.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelZeroPositionCount
            // 
            this.labelZeroPositionCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelZeroPositionCount.AutoSize = true;
            this.labelZeroPositionCount.Location = new System.Drawing.Point(8, 133);
            this.labelZeroPositionCount.Name = "labelZeroPositionCount";
            this.labelZeroPositionCount.Size = new System.Drawing.Size(103, 13);
            this.labelZeroPositionCount.TabIndex = 99;
            this.labelZeroPositionCount.Text = "Zero Position Count:";
            this.labelZeroPositionCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDirection
            // 
            this.labelDirection.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelDirection.AutoSize = true;
            this.labelDirection.Location = new System.Drawing.Point(59, 164);
            this.labelDirection.Name = "labelDirection";
            this.labelDirection.Size = new System.Drawing.Size(52, 13);
            this.labelDirection.TabIndex = 99;
            this.labelDirection.Text = "Direction:";
            this.labelDirection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxCOMPort
            // 
            this.comboBoxCOMPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCOMPort.FormattingEnabled = true;
            this.comboBoxCOMPort.Location = new System.Drawing.Point(117, 5);
            this.comboBoxCOMPort.Name = "comboBoxCOMPort";
            this.comboBoxCOMPort.Size = new System.Drawing.Size(131, 21);
            this.comboBoxCOMPort.TabIndex = 2;
            // 
            // comboBoxQuadratureMode
            // 
            this.comboBoxQuadratureMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxQuadratureMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQuadratureMode.FormattingEnabled = true;
            this.comboBoxQuadratureMode.Location = new System.Drawing.Point(117, 67);
            this.comboBoxQuadratureMode.Name = "comboBoxQuadratureMode";
            this.comboBoxQuadratureMode.Size = new System.Drawing.Size(131, 21);
            this.comboBoxQuadratureMode.TabIndex = 4;
            // 
            // numericUpDownResolution
            // 
            this.numericUpDownResolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownResolution.DecimalPlaces = 2;
            this.numericUpDownResolution.Location = new System.Drawing.Point(117, 98);
            this.numericUpDownResolution.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownResolution.Name = "numericUpDownResolution";
            this.numericUpDownResolution.Size = new System.Drawing.Size(131, 20);
            this.numericUpDownResolution.TabIndex = 5;
            this.numericUpDownResolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownResolution.Value = new decimal(new int[] {
            125,
            0,
            0,
            131072});
            // 
            // labelResolutionUnit
            // 
            this.labelResolutionUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelResolutionUnit.AutoSize = true;
            this.labelResolutionUnit.Location = new System.Drawing.Point(254, 102);
            this.labelResolutionUnit.Name = "labelResolutionUnit";
            this.labelResolutionUnit.Size = new System.Drawing.Size(53, 13);
            this.labelResolutionUnit.TabIndex = 99;
            this.labelResolutionUnit.Text = "nm/count";
            this.labelResolutionUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownZeroPositionCount
            // 
            this.numericUpDownZeroPositionCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownZeroPositionCount.Location = new System.Drawing.Point(117, 129);
            this.numericUpDownZeroPositionCount.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDownZeroPositionCount.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.numericUpDownZeroPositionCount.Name = "numericUpDownZeroPositionCount";
            this.numericUpDownZeroPositionCount.Size = new System.Drawing.Size(131, 20);
            this.numericUpDownZeroPositionCount.TabIndex = 6;
            this.numericUpDownZeroPositionCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelZeroPositionCountUnit
            // 
            this.labelZeroPositionCountUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelZeroPositionCountUnit.AutoSize = true;
            this.labelZeroPositionCountUnit.Location = new System.Drawing.Point(254, 133);
            this.labelZeroPositionCountUnit.Name = "labelZeroPositionCountUnit";
            this.labelZeroPositionCountUnit.Size = new System.Drawing.Size(34, 13);
            this.labelZeroPositionCountUnit.TabIndex = 99;
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
            this.comboBoxDirection.Location = new System.Drawing.Point(117, 160);
            this.comboBoxDirection.Name = "comboBoxDirection";
            this.comboBoxDirection.Size = new System.Drawing.Size(131, 21);
            this.comboBoxDirection.TabIndex = 7;
            // 
            // labelBaudRate
            // 
            this.labelBaudRate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelBaudRate.AutoSize = true;
            this.labelBaudRate.Location = new System.Drawing.Point(50, 40);
            this.labelBaudRate.Name = "labelBaudRate";
            this.labelBaudRate.Size = new System.Drawing.Size(61, 13);
            this.labelBaudRate.TabIndex = 99;
            this.labelBaudRate.Text = "Baud Rate:";
            this.labelBaudRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Location = new System.Drawing.Point(117, 36);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(131, 21);
            this.comboBoxBaudRate.TabIndex = 3;
            // 
            // labelDisplayUpdateRate
            // 
            this.labelDisplayUpdateRate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelDisplayUpdateRate.AutoSize = true;
            this.labelDisplayUpdateRate.Location = new System.Drawing.Point(3, 195);
            this.labelDisplayUpdateRate.Name = "labelDisplayUpdateRate";
            this.labelDisplayUpdateRate.Size = new System.Drawing.Size(108, 13);
            this.labelDisplayUpdateRate.TabIndex = 99;
            this.labelDisplayUpdateRate.Text = "Display Update Rate:";
            this.labelDisplayUpdateRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxDisplayUpdateRate
            // 
            this.comboBoxDisplayUpdateRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDisplayUpdateRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDisplayUpdateRate.FormattingEnabled = true;
            this.comboBoxDisplayUpdateRate.Items.AddRange(new object[] {
            "Positive",
            "Negative"});
            this.comboBoxDisplayUpdateRate.Location = new System.Drawing.Point(117, 191);
            this.comboBoxDisplayUpdateRate.Name = "comboBoxDisplayUpdateRate";
            this.comboBoxDisplayUpdateRate.Size = new System.Drawing.Size(131, 21);
            this.comboBoxDisplayUpdateRate.TabIndex = 8;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonConnect.AutoSize = true;
            this.buttonConnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonConnect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonConnect.Location = new System.Drawing.Point(262, 3);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(57, 23);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(325, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(50, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelIgnoreInvalidMessage
            // 
            this.labelIgnoreInvalidMessage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelIgnoreInvalidMessage.AutoSize = true;
            this.labelIgnoreInvalidMessage.Location = new System.Drawing.Point(47, 226);
            this.labelIgnoreInvalidMessage.Name = "labelIgnoreInvalidMessage";
            this.labelIgnoreInvalidMessage.Size = new System.Drawing.Size(64, 13);
            this.labelIgnoreInvalidMessage.TabIndex = 99;
            this.labelIgnoreInvalidMessage.Text = "Ignore up to";
            this.labelIgnoreInvalidMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelIgnoreInvalidMessageUnit
            // 
            this.labelIgnoreInvalidMessageUnit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelIgnoreInvalidMessageUnit.AutoSize = true;
            this.labelIgnoreInvalidMessageUnit.Location = new System.Drawing.Point(254, 226);
            this.labelIgnoreInvalidMessageUnit.Name = "labelIgnoreInvalidMessageUnit";
            this.labelIgnoreInvalidMessageUnit.Size = new System.Drawing.Size(127, 13);
            this.labelIgnoreInvalidMessageUnit.TabIndex = 99;
            this.labelIgnoreInvalidMessageUnit.Text = "invalid messages in a row";
            this.labelIgnoreInvalidMessageUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownAcceptableInvalidMessagesInARow
            // 
            this.numericUpDownAcceptableInvalidMessagesInARow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownAcceptableInvalidMessagesInARow.Location = new System.Drawing.Point(117, 222);
            this.numericUpDownAcceptableInvalidMessagesInARow.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownAcceptableInvalidMessagesInARow.Name = "numericUpDownAcceptableInvalidMessagesInARow";
            this.numericUpDownAcceptableInvalidMessagesInARow.Size = new System.Drawing.Size(131, 20);
            this.numericUpDownAcceptableInvalidMessagesInARow.TabIndex = 9;
            this.numericUpDownAcceptableInvalidMessagesInARow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 3);
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Controls.Add(this.buttonConnect);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 251);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(378, 29);
            this.flowLayoutPanel1.TabIndex = 100;
            // 
            // ConnectForm
            // 
            this.AcceptButton = this.buttonConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(384, 283);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 322);
            this.Name = "ConnectForm";
            this.Text = "Connect to QSB Encoder Reader";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ConnectForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownResolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZeroPositionCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAcceptableInvalidMessagesInARow)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelCOMPort;
        private System.Windows.Forms.Label labelQuadratureMode;
        private System.Windows.Forms.Label labelResolution;
        private System.Windows.Forms.Label labelZeroPositionCount;
        private System.Windows.Forms.Label labelDirection;
        private System.Windows.Forms.ComboBox comboBoxCOMPort;
        private System.Windows.Forms.ComboBox comboBoxQuadratureMode;
        private System.Windows.Forms.NumericUpDown numericUpDownResolution;
        private System.Windows.Forms.Label labelResolutionUnit;
        private System.Windows.Forms.NumericUpDown numericUpDownZeroPositionCount;
        private System.Windows.Forms.Label labelZeroPositionCountUnit;
        private System.Windows.Forms.ComboBox comboBoxDirection;
        private System.Windows.Forms.Label labelBaudRate;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.Label labelDisplayUpdateRate;
        private System.Windows.Forms.ComboBox comboBoxDisplayUpdateRate;
        private System.Windows.Forms.Label labelIgnoreInvalidMessage;
        private System.Windows.Forms.Label labelIgnoreInvalidMessageUnit;
        private System.Windows.Forms.NumericUpDown numericUpDownAcceptableInvalidMessagesInARow;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}