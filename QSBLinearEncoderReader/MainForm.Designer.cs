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
            this.labelEncoderReading = new System.Windows.Forms.Label();
            this.labelEncoderReadingUnit = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonSetZero = new System.Windows.Forms.Button();
            this.buttonStartRecording = new System.Windows.Forms.Button();
            this.buttonStopRecording = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelMain.SuspendLayout();
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
            this.tableLayoutPanelMain.Controls.Add(this.buttonSetZero, 2, 1);
            this.tableLayoutPanelMain.Controls.Add(this.buttonStartRecording, 2, 2);
            this.tableLayoutPanelMain.Controls.Add(this.buttonStopRecording, 2, 3);
            this.tableLayoutPanelMain.Controls.Add(this.buttonQuit, 2, 4);
            this.tableLayoutPanelMain.Controls.Add(this.textBox1, 0, 6);
            this.tableLayoutPanelMain.Controls.Add(this.labelStatus, 0, 5);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 7;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(584, 361);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // labelEncoderReading
            // 
            this.labelEncoderReading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEncoderReading.AutoSize = true;
            this.labelEncoderReading.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelEncoderReading.Location = new System.Drawing.Point(54, 0);
            this.labelEncoderReading.Name = "labelEncoderReading";
            this.labelEncoderReading.Padding = new System.Windows.Forms.Padding(10, 10, 0, 10);
            this.tableLayoutPanelMain.SetRowSpan(this.labelEncoderReading, 5);
            this.labelEncoderReading.Size = new System.Drawing.Size(232, 140);
            this.labelEncoderReading.TabIndex = 0;
            this.labelEncoderReading.Text = "00.000000";
            this.labelEncoderReading.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelEncoderReadingUnit
            // 
            this.labelEncoderReadingUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelEncoderReadingUnit.AutoSize = true;
            this.labelEncoderReadingUnit.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelEncoderReadingUnit.Location = new System.Drawing.Point(292, 0);
            this.labelEncoderReadingUnit.Name = "labelEncoderReadingUnit";
            this.labelEncoderReadingUnit.Padding = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this.tableLayoutPanelMain.SetRowSpan(this.labelEncoderReadingUnit, 5);
            this.labelEncoderReadingUnit.Size = new System.Drawing.Size(100, 140);
            this.labelEncoderReadingUnit.TabIndex = 1;
            this.labelEncoderReadingUnit.Text = "mm";
            this.labelEncoderReadingUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConnect.AutoSize = true;
            this.buttonConnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonConnect.Location = new System.Drawing.Point(398, 3);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(183, 22);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "Connect to QSB Encoder Reader";
            this.buttonConnect.UseVisualStyleBackColor = true;
            // 
            // buttonSetZero
            // 
            this.buttonSetZero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetZero.AutoSize = true;
            this.buttonSetZero.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSetZero.Location = new System.Drawing.Point(398, 31);
            this.buttonSetZero.Name = "buttonSetZero";
            this.buttonSetZero.Size = new System.Drawing.Size(183, 22);
            this.buttonSetZero.TabIndex = 3;
            this.buttonSetZero.Text = "Zero Encoder Count";
            this.buttonSetZero.UseVisualStyleBackColor = true;
            // 
            // buttonStartRecording
            // 
            this.buttonStartRecording.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartRecording.AutoSize = true;
            this.buttonStartRecording.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonStartRecording.Location = new System.Drawing.Point(398, 59);
            this.buttonStartRecording.Name = "buttonStartRecording";
            this.buttonStartRecording.Size = new System.Drawing.Size(183, 22);
            this.buttonStartRecording.TabIndex = 4;
            this.buttonStartRecording.Text = "Start Recording";
            this.buttonStartRecording.UseVisualStyleBackColor = true;
            // 
            // buttonStopRecording
            // 
            this.buttonStopRecording.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStopRecording.AutoSize = true;
            this.buttonStopRecording.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonStopRecording.Location = new System.Drawing.Point(398, 87);
            this.buttonStopRecording.Name = "buttonStopRecording";
            this.buttonStopRecording.Size = new System.Drawing.Size(183, 22);
            this.buttonStopRecording.TabIndex = 5;
            this.buttonStopRecording.Text = "Stop Recording";
            this.buttonStopRecording.UseVisualStyleBackColor = true;
            // 
            // buttonQuit
            // 
            this.buttonQuit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQuit.AutoSize = true;
            this.buttonQuit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonQuit.Location = new System.Drawing.Point(398, 115);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(183, 22);
            this.buttonQuit.TabIndex = 6;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(3, 140);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(40, 12);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "Status:";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.tableLayoutPanelMain.SetColumnSpan(this.textBox1, 3);
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 155);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(578, 203);
            this.textBox1.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.Text = "QSB Linear Encoder Reader";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
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
        private System.Windows.Forms.TextBox textBox1;
    }
}

