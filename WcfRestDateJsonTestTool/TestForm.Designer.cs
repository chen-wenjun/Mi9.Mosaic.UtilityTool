namespace WcfRestDateJsonTestTool
{
    partial class testForm
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
            this.wcfJsonDateTimeTBox = new System.Windows.Forms.TextBox();
            this.toWcfJsonDateTimeBtn = new System.Windows.Forms.Button();
            this.dateTimeTBox = new System.Windows.Forms.TextBox();
            this.wcfJsonToDateTimeBtn = new System.Windows.Forms.Button();
            this.kindCBox = new System.Windows.Forms.ComboBox();
            this.timezoneTBox = new System.Windows.Forms.TextBox();
            this.localNowBtn = new System.Windows.Forms.Button();
            this.utcNowBtn = new System.Windows.Forms.Button();
            this.timezoneTBox2 = new System.Windows.Forms.TextBox();
            this.dateTimeTBox2 = new System.Windows.Forms.TextBox();
            this.otherTimezoneToLocalTimeBtn = new System.Windows.Forms.Button();
            this.milisecondTBox = new System.Windows.Forms.TextBox();
            this.milisecondTBox2 = new System.Windows.Forms.TextBox();
            this.otherTimezoneToUtcTimeBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toLocalBtn = new System.Windows.Forms.Button();
            this.toUtcBtn = new System.Windows.Forms.Button();
            this.webApiJsonToDateTimeBtn = new System.Windows.Forms.Button();
            this.webApiJsonDateTimeTBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toWebApiJsonBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // wcfJsonDateTimeTBox
            // 
            this.wcfJsonDateTimeTBox.Location = new System.Drawing.Point(157, 12);
            this.wcfJsonDateTimeTBox.Name = "wcfJsonDateTimeTBox";
            this.wcfJsonDateTimeTBox.Size = new System.Drawing.Size(260, 22);
            this.wcfJsonDateTimeTBox.TabIndex = 0;
            this.wcfJsonDateTimeTBox.Text = "\"\\/Date(1297367252340-0500)\\/\"";
            // 
            // toWcfJsonDateTimeBtn
            // 
            this.toWcfJsonDateTimeBtn.Location = new System.Drawing.Point(411, 19);
            this.toWcfJsonDateTimeBtn.Name = "toWcfJsonDateTimeBtn";
            this.toWcfJsonDateTimeBtn.Size = new System.Drawing.Size(151, 26);
            this.toWcfJsonDateTimeBtn.TabIndex = 1;
            this.toWcfJsonDateTimeBtn.Text = "To WCF JSON";
            this.toWcfJsonDateTimeBtn.UseVisualStyleBackColor = true;
            this.toWcfJsonDateTimeBtn.Click += new System.EventHandler(this.toWcfJsonDateTimeBtn_Click);
            // 
            // dateTimeTBox
            // 
            this.dateTimeTBox.Location = new System.Drawing.Point(7, 21);
            this.dateTimeTBox.Name = "dateTimeTBox";
            this.dateTimeTBox.Size = new System.Drawing.Size(153, 22);
            this.dateTimeTBox.TabIndex = 2;
            // 
            // wcfJsonToDateTimeBtn
            // 
            this.wcfJsonToDateTimeBtn.Location = new System.Drawing.Point(423, 10);
            this.wcfJsonToDateTimeBtn.Name = "wcfJsonToDateTimeBtn";
            this.wcfJsonToDateTimeBtn.Size = new System.Drawing.Size(151, 26);
            this.wcfJsonToDateTimeBtn.TabIndex = 3;
            this.wcfJsonToDateTimeBtn.Text = "To DateTime";
            this.wcfJsonToDateTimeBtn.UseVisualStyleBackColor = true;
            this.wcfJsonToDateTimeBtn.Click += new System.EventHandler(this.wcfJsonToDateTimeBtn_Click);
            // 
            // kindCBox
            // 
            this.kindCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kindCBox.FormattingEnabled = true;
            this.kindCBox.Items.AddRange(new object[] {
            "Unspecified",
            "Local",
            "Utc"});
            this.kindCBox.Location = new System.Drawing.Point(225, 21);
            this.kindCBox.Name = "kindCBox";
            this.kindCBox.Size = new System.Drawing.Size(107, 24);
            this.kindCBox.TabIndex = 4;
            // 
            // timezoneTBox
            // 
            this.timezoneTBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.timezoneTBox.Enabled = false;
            this.timezoneTBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.timezoneTBox.Location = new System.Drawing.Point(338, 21);
            this.timezoneTBox.Name = "timezoneTBox";
            this.timezoneTBox.ReadOnly = true;
            this.timezoneTBox.Size = new System.Drawing.Size(67, 22);
            this.timezoneTBox.TabIndex = 5;
            this.timezoneTBox.TabStop = false;
            // 
            // localNowBtn
            // 
            this.localNowBtn.Location = new System.Drawing.Point(7, 50);
            this.localNowBtn.Name = "localNowBtn";
            this.localNowBtn.Size = new System.Drawing.Size(92, 23);
            this.localNowBtn.TabIndex = 6;
            this.localNowBtn.Text = "Local Now";
            this.localNowBtn.UseVisualStyleBackColor = true;
            this.localNowBtn.Click += new System.EventHandler(this.localNowBtn_Click);
            // 
            // utcNowBtn
            // 
            this.utcNowBtn.Location = new System.Drawing.Point(105, 50);
            this.utcNowBtn.Name = "utcNowBtn";
            this.utcNowBtn.Size = new System.Drawing.Size(89, 23);
            this.utcNowBtn.TabIndex = 7;
            this.utcNowBtn.Text = "UCT Now";
            this.utcNowBtn.UseVisualStyleBackColor = true;
            this.utcNowBtn.Click += new System.EventHandler(this.utcNowBtn_Click);
            // 
            // timezoneTBox2
            // 
            this.timezoneTBox2.Location = new System.Drawing.Point(219, 26);
            this.timezoneTBox2.Name = "timezoneTBox2";
            this.timezoneTBox2.Size = new System.Drawing.Size(67, 22);
            this.timezoneTBox2.TabIndex = 11;
            // 
            // dateTimeTBox2
            // 
            this.dateTimeTBox2.Location = new System.Drawing.Point(6, 26);
            this.dateTimeTBox2.Name = "dateTimeTBox2";
            this.dateTimeTBox2.Size = new System.Drawing.Size(147, 22);
            this.dateTimeTBox2.TabIndex = 9;
            // 
            // otherTimezoneToLocalTimeBtn
            // 
            this.otherTimezoneToLocalTimeBtn.Location = new System.Drawing.Point(6, 54);
            this.otherTimezoneToLocalTimeBtn.Name = "otherTimezoneToLocalTimeBtn";
            this.otherTimezoneToLocalTimeBtn.Size = new System.Drawing.Size(280, 26);
            this.otherTimezoneToLocalTimeBtn.TabIndex = 8;
            this.otherTimezoneToLocalTimeBtn.Text = "Convert to current time zone LOCAL time";
            this.otherTimezoneToLocalTimeBtn.UseVisualStyleBackColor = true;
            this.otherTimezoneToLocalTimeBtn.Click += new System.EventHandler(this.otherTimezoneToLocalTimeBtn_Click);
            // 
            // milisecondTBox
            // 
            this.milisecondTBox.Location = new System.Drawing.Point(166, 21);
            this.milisecondTBox.Name = "milisecondTBox";
            this.milisecondTBox.Size = new System.Drawing.Size(54, 22);
            this.milisecondTBox.TabIndex = 13;
            this.milisecondTBox.Text = "000";
            // 
            // milisecondTBox2
            // 
            this.milisecondTBox2.Location = new System.Drawing.Point(159, 26);
            this.milisecondTBox2.Name = "milisecondTBox2";
            this.milisecondTBox2.Size = new System.Drawing.Size(54, 22);
            this.milisecondTBox2.TabIndex = 14;
            this.milisecondTBox2.Text = "000";
            // 
            // otherTimezoneToUtcTimeBtn
            // 
            this.otherTimezoneToUtcTimeBtn.Location = new System.Drawing.Point(6, 86);
            this.otherTimezoneToUtcTimeBtn.Name = "otherTimezoneToUtcTimeBtn";
            this.otherTimezoneToUtcTimeBtn.Size = new System.Drawing.Size(280, 26);
            this.otherTimezoneToUtcTimeBtn.TabIndex = 15;
            this.otherTimezoneToUtcTimeBtn.Text = "Convert to UTC time";
            this.otherTimezoneToUtcTimeBtn.UseVisualStyleBackColor = true;
            this.otherTimezoneToUtcTimeBtn.Click += new System.EventHandler(this.otherTimezoneToUtcTimeBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.otherTimezoneToUtcTimeBtn);
            this.groupBox1.Controls.Add(this.otherTimezoneToLocalTimeBtn);
            this.groupBox1.Controls.Add(this.dateTimeTBox2);
            this.groupBox1.Controls.Add(this.timezoneTBox2);
            this.groupBox1.Controls.Add(this.milisecondTBox2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(12, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 129);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate time based on specified time zone local time";
            // 
            // toLocalBtn
            // 
            this.toLocalBtn.Location = new System.Drawing.Point(210, 50);
            this.toLocalBtn.Name = "toLocalBtn";
            this.toLocalBtn.Size = new System.Drawing.Size(89, 23);
            this.toLocalBtn.TabIndex = 17;
            this.toLocalBtn.Text = "To Local";
            this.toLocalBtn.UseVisualStyleBackColor = true;
            this.toLocalBtn.Click += new System.EventHandler(this.toLocalBtn_Click);
            // 
            // toUtcBtn
            // 
            this.toUtcBtn.Location = new System.Drawing.Point(309, 50);
            this.toUtcBtn.Name = "toUtcBtn";
            this.toUtcBtn.Size = new System.Drawing.Size(89, 23);
            this.toUtcBtn.TabIndex = 18;
            this.toUtcBtn.Text = "To UTC";
            this.toUtcBtn.UseVisualStyleBackColor = true;
            this.toUtcBtn.Click += new System.EventHandler(this.toUtcBtn_Click);
            // 
            // webApiJsonToDateTimeBtn
            // 
            this.webApiJsonToDateTimeBtn.Location = new System.Drawing.Point(423, 38);
            this.webApiJsonToDateTimeBtn.Name = "webApiJsonToDateTimeBtn";
            this.webApiJsonToDateTimeBtn.Size = new System.Drawing.Size(151, 26);
            this.webApiJsonToDateTimeBtn.TabIndex = 20;
            this.webApiJsonToDateTimeBtn.Text = "To DateTime";
            this.webApiJsonToDateTimeBtn.UseVisualStyleBackColor = true;
            this.webApiJsonToDateTimeBtn.Click += new System.EventHandler(this.webApiJsonToDateTimeBtn_Click);
            // 
            // webApiJsonDateTimeTBox
            // 
            this.webApiJsonDateTimeTBox.Location = new System.Drawing.Point(157, 40);
            this.webApiJsonDateTimeTBox.Name = "webApiJsonDateTimeTBox";
            this.webApiJsonDateTimeTBox.Size = new System.Drawing.Size(260, 22);
            this.webApiJsonDateTimeTBox.TabIndex = 19;
            this.webApiJsonDateTimeTBox.Text = "\"2017-02-10T11:24:40.12-05:00\"";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Info;
            this.groupBox2.Controls.Add(this.toWebApiJsonBtn);
            this.groupBox2.Controls.Add(this.kindCBox);
            this.groupBox2.Controls.Add(this.toWcfJsonDateTimeBtn);
            this.groupBox2.Controls.Add(this.dateTimeTBox);
            this.groupBox2.Controls.Add(this.toUtcBtn);
            this.groupBox2.Controls.Add(this.timezoneTBox);
            this.groupBox2.Controls.Add(this.toLocalBtn);
            this.groupBox2.Controls.Add(this.localNowBtn);
            this.groupBox2.Controls.Add(this.utcNowBtn);
            this.groupBox2.Controls.Add(this.milisecondTBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(571, 86);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Time in the current time zone";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "WCF JSON Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Web API JSON Time:";
            // 
            // toWebApiJsonBtn
            // 
            this.toWebApiJsonBtn.Location = new System.Drawing.Point(411, 48);
            this.toWebApiJsonBtn.Name = "toWebApiJsonBtn";
            this.toWebApiJsonBtn.Size = new System.Drawing.Size(151, 26);
            this.toWebApiJsonBtn.TabIndex = 19;
            this.toWebApiJsonBtn.Text = "To Web API JSON";
            this.toWebApiJsonBtn.UseVisualStyleBackColor = true;
            this.toWebApiJsonBtn.Click += new System.EventHandler(this.toWebApiJsonBtn_Click);
            // 
            // testForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 315);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.webApiJsonToDateTimeBtn);
            this.Controls.Add(this.webApiJsonDateTimeTBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.wcfJsonToDateTimeBtn);
            this.Controls.Add(this.wcfJsonDateTimeTBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "testForm";
            this.Text = "Date Time JSON Test Tool";
            this.Load += new System.EventHandler(this.testForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox wcfJsonDateTimeTBox;
        private System.Windows.Forms.Button toWcfJsonDateTimeBtn;
        private System.Windows.Forms.TextBox dateTimeTBox;
        private System.Windows.Forms.Button wcfJsonToDateTimeBtn;
        private System.Windows.Forms.ComboBox kindCBox;
        private System.Windows.Forms.TextBox timezoneTBox;
        private System.Windows.Forms.Button localNowBtn;
        private System.Windows.Forms.Button utcNowBtn;
        private System.Windows.Forms.TextBox timezoneTBox2;
        private System.Windows.Forms.TextBox dateTimeTBox2;
        private System.Windows.Forms.Button otherTimezoneToLocalTimeBtn;
        private System.Windows.Forms.TextBox milisecondTBox;
        private System.Windows.Forms.TextBox milisecondTBox2;
        private System.Windows.Forms.Button otherTimezoneToUtcTimeBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button toLocalBtn;
        private System.Windows.Forms.Button toUtcBtn;
        private System.Windows.Forms.Button webApiJsonToDateTimeBtn;
        private System.Windows.Forms.TextBox webApiJsonDateTimeTBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button toWebApiJsonBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

