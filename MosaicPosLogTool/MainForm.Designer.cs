namespace MosaicPosLogTool
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
            this.processLogFilesBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.selectFolderBtn = new System.Windows.Forms.Button();
            this.folderTBox = new System.Windows.Forms.TextBox();
            this.filesLBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.detailLBox = new System.Windows.Forms.ListBox();
            this.cancelProcessBtn = new System.Windows.Forms.Button();
            this.clearBoxBtn = new System.Windows.Forms.Button();
            this.enableErrorCheckCBox = new System.Windows.Forms.CheckBox();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.currentProgressBar = new System.Windows.Forms.ProgressBar();
            this.totalProgressBar = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.currentProgressLabel = new System.Windows.Forms.Label();
            this.totalProgressLabel = new System.Windows.Forms.Label();
            this.enableAnalysisCBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // processLogFilesBtn
            // 
            this.processLogFilesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processLogFilesBtn.Location = new System.Drawing.Point(8, 116);
            this.processLogFilesBtn.Name = "processLogFilesBtn";
            this.processLogFilesBtn.Size = new System.Drawing.Size(724, 32);
            this.processLogFilesBtn.TabIndex = 0;
            this.processLogFilesBtn.Text = "Process log files";
            this.processLogFilesBtn.UseVisualStyleBackColor = true;
            this.processLogFilesBtn.Click += new System.EventHandler(this.processLogFilesBtn_Click);
            // 
            // selectFolderBtn
            // 
            this.selectFolderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectFolderBtn.Location = new System.Drawing.Point(570, 4);
            this.selectFolderBtn.Name = "selectFolderBtn";
            this.selectFolderBtn.Size = new System.Drawing.Size(162, 31);
            this.selectFolderBtn.TabIndex = 1;
            this.selectFolderBtn.Text = "Select Log Files Floder";
            this.selectFolderBtn.UseVisualStyleBackColor = true;
            this.selectFolderBtn.Click += new System.EventHandler(this.selectFolderBtn_Click);
            // 
            // folderTBox
            // 
            this.folderTBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderTBox.Location = new System.Drawing.Point(8, 8);
            this.folderTBox.Name = "folderTBox";
            this.folderTBox.Size = new System.Drawing.Size(557, 22);
            this.folderTBox.TabIndex = 2;
            // 
            // filesLBox
            // 
            this.filesLBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filesLBox.BackColor = System.Drawing.SystemColors.Info;
            this.filesLBox.FormattingEnabled = true;
            this.filesLBox.HorizontalScrollbar = true;
            this.filesLBox.ItemHeight = 16;
            this.filesLBox.Location = new System.Drawing.Point(8, 294);
            this.filesLBox.Name = "filesLBox";
            this.filesLBox.Size = new System.Drawing.Size(725, 100);
            this.filesLBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Log files to be processed:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 409);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Process Details:";
            // 
            // detailLBox
            // 
            this.detailLBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailLBox.FormattingEnabled = true;
            this.detailLBox.ItemHeight = 16;
            this.detailLBox.Location = new System.Drawing.Point(8, 429);
            this.detailLBox.Name = "detailLBox";
            this.detailLBox.Size = new System.Drawing.Size(725, 148);
            this.detailLBox.TabIndex = 6;
            // 
            // cancelProcessBtn
            // 
            this.cancelProcessBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelProcessBtn.Location = new System.Drawing.Point(8, 588);
            this.cancelProcessBtn.Name = "cancelProcessBtn";
            this.cancelProcessBtn.Size = new System.Drawing.Size(725, 32);
            this.cancelProcessBtn.TabIndex = 7;
            this.cancelProcessBtn.Text = "Cancel Process";
            this.cancelProcessBtn.UseVisualStyleBackColor = true;
            this.cancelProcessBtn.Click += new System.EventHandler(this.cancelProcessBtn_Click);
            // 
            // clearBoxBtn
            // 
            this.clearBoxBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clearBoxBtn.Location = new System.Drawing.Point(8, 626);
            this.clearBoxBtn.Name = "clearBoxBtn";
            this.clearBoxBtn.Size = new System.Drawing.Size(725, 32);
            this.clearBoxBtn.TabIndex = 8;
            this.clearBoxBtn.Text = "Clear Box";
            this.clearBoxBtn.UseVisualStyleBackColor = true;
            this.clearBoxBtn.Click += new System.EventHandler(this.clearBoxBtn_Click);
            // 
            // enableErrorCheckCBox
            // 
            this.enableErrorCheckCBox.AutoSize = true;
            this.enableErrorCheckCBox.Checked = true;
            this.enableErrorCheckCBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableErrorCheckCBox.Location = new System.Drawing.Point(8, 36);
            this.enableErrorCheckCBox.Name = "enableErrorCheckCBox";
            this.enableErrorCheckCBox.Size = new System.Drawing.Size(153, 21);
            this.enableErrorCheckCBox.TabIndex = 9;
            this.enableErrorCheckCBox.Text = "Enable Error Check";
            this.enableErrorCheckCBox.UseVisualStyleBackColor = true;
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Checked = false;
            this.startDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss ";
            this.startDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDateTimePicker.Location = new System.Drawing.Point(88, 58);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.ShowCheckBox = true;
            this.startDateTimePicker.ShowUpDown = true;
            this.startDateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.startDateTimePicker.TabIndex = 10;
            this.startDateTimePicker.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Checked = false;
            this.endDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss ";
            this.endDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDateTimePicker.Location = new System.Drawing.Point(88, 84);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.ShowCheckBox = true;
            this.endDateTimePicker.ShowUpDown = true;
            this.endDateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.endDateTimePicker.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Start Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "End Time:";
            // 
            // currentProgressBar
            // 
            this.currentProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentProgressBar.Location = new System.Drawing.Point(8, 154);
            this.currentProgressBar.Name = "currentProgressBar";
            this.currentProgressBar.Size = new System.Drawing.Size(725, 23);
            this.currentProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.currentProgressBar.TabIndex = 14;
            // 
            // totalProgressBar
            // 
            this.totalProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalProgressBar.Location = new System.Drawing.Point(8, 209);
            this.totalProgressBar.Name = "totalProgressBar";
            this.totalProgressBar.Size = new System.Drawing.Size(725, 23);
            this.totalProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.totalProgressBar.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Total Files Progress: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Current File Progress:  ";
            // 
            // currentProgressLabel
            // 
            this.currentProgressLabel.AutoSize = true;
            this.currentProgressLabel.Location = new System.Drawing.Point(176, 180);
            this.currentProgressLabel.Name = "currentProgressLabel";
            this.currentProgressLabel.Size = new System.Drawing.Size(109, 17);
            this.currentProgressLabel.TabIndex = 18;
            this.currentProgressLabel.Text = "Processing Line";
            // 
            // totalProgressLabel
            // 
            this.totalProgressLabel.AutoSize = true;
            this.totalProgressLabel.Location = new System.Drawing.Point(176, 235);
            this.totalProgressLabel.Name = "totalProgressLabel";
            this.totalProgressLabel.Size = new System.Drawing.Size(104, 17);
            this.totalProgressLabel.TabIndex = 19;
            this.totalProgressLabel.Text = "Processing File";
            // 
            // enableAnalysisCBox
            // 
            this.enableAnalysisCBox.AutoSize = true;
            this.enableAnalysisCBox.Checked = true;
            this.enableAnalysisCBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableAnalysisCBox.Location = new System.Drawing.Point(173, 36);
            this.enableAnalysisCBox.Name = "enableAnalysisCBox";
            this.enableAnalysisCBox.Size = new System.Drawing.Size(130, 21);
            this.enableAnalysisCBox.TabIndex = 20;
            this.enableAnalysisCBox.Text = "Enable Analysis";
            this.enableAnalysisCBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 663);
            this.Controls.Add(this.enableAnalysisCBox);
            this.Controls.Add(this.totalProgressLabel);
            this.Controls.Add(this.currentProgressLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.totalProgressBar);
            this.Controls.Add(this.currentProgressBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.enableErrorCheckCBox);
            this.Controls.Add(this.clearBoxBtn);
            this.Controls.Add(this.cancelProcessBtn);
            this.Controls.Add(this.detailLBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filesLBox);
            this.Controls.Add(this.folderTBox);
            this.Controls.Add(this.selectFolderBtn);
            this.Controls.Add(this.processLogFilesBtn);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mosaic POS Log Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button processLogFilesBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button selectFolderBtn;
        private System.Windows.Forms.TextBox folderTBox;
        private System.Windows.Forms.ListBox filesLBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox detailLBox;
        private System.Windows.Forms.Button cancelProcessBtn;
        private System.Windows.Forms.Button clearBoxBtn;
        private System.Windows.Forms.CheckBox enableErrorCheckCBox;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar currentProgressBar;
        private System.Windows.Forms.ProgressBar totalProgressBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label currentProgressLabel;
        private System.Windows.Forms.Label totalProgressLabel;
        private System.Windows.Forms.CheckBox enableAnalysisCBox;
    }
}

