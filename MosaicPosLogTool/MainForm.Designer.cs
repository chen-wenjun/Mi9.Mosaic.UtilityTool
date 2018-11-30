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
            this.SuspendLayout();
            // 
            // processLogFilesBtn
            // 
            this.processLogFilesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processLogFilesBtn.Location = new System.Drawing.Point(8, 36);
            this.processLogFilesBtn.Name = "processLogFilesBtn";
            this.processLogFilesBtn.Size = new System.Drawing.Size(642, 32);
            this.processLogFilesBtn.TabIndex = 0;
            this.processLogFilesBtn.Text = "Process log files";
            this.processLogFilesBtn.UseVisualStyleBackColor = true;
            this.processLogFilesBtn.Click += new System.EventHandler(this.processLogFilesBtn_Click);
            // 
            // selectFolderBtn
            // 
            this.selectFolderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectFolderBtn.Location = new System.Drawing.Point(488, 4);
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
            this.folderTBox.Size = new System.Drawing.Size(474, 22);
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
            this.filesLBox.Location = new System.Drawing.Point(8, 101);
            this.filesLBox.Name = "filesLBox";
            this.filesLBox.Size = new System.Drawing.Size(642, 100);
            this.filesLBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Log files to be processed:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 216);
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
            this.detailLBox.Location = new System.Drawing.Point(8, 236);
            this.detailLBox.Name = "detailLBox";
            this.detailLBox.Size = new System.Drawing.Size(642, 308);
            this.detailLBox.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 561);
            this.Controls.Add(this.detailLBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filesLBox);
            this.Controls.Add(this.folderTBox);
            this.Controls.Add(this.selectFolderBtn);
            this.Controls.Add(this.processLogFilesBtn);
            this.Name = "MainForm";
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
    }
}

