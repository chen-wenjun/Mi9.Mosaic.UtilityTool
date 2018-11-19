namespace PublicWebServiceEncryption
{
    partial class EncryptionForm
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
            this.encryptBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.passkeyTBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.decryptedValueTBox = new System.Windows.Forms.TextBox();
            this.encryptedValueTBox = new System.Windows.Forms.TextBox();
            this.valueTBox = new System.Windows.Forms.TextBox();
            this.decryptBtn = new System.Windows.Forms.Button();
            this.ivTBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // encryptBtn
            // 
            this.encryptBtn.Location = new System.Drawing.Point(205, 166);
            this.encryptBtn.Name = "encryptBtn";
            this.encryptBtn.Size = new System.Drawing.Size(101, 27);
            this.encryptBtn.TabIndex = 0;
            this.encryptBtn.Text = "Encrypt";
            this.encryptBtn.UseVisualStyleBackColor = true;
            this.encryptBtn.Click += new System.EventHandler(this.encryptBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "WebServicePublicPassword:";
            // 
            // passkeyTBox
            // 
            this.passkeyTBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passkeyTBox.Location = new System.Drawing.Point(205, 43);
            this.passkeyTBox.Name = "passkeyTBox";
            this.passkeyTBox.Size = new System.Drawing.Size(295, 22);
            this.passkeyTBox.TabIndex = 2;
            this.passkeyTBox.Text = "ClientMotDePasse";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Value:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Encrypted Value:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Decrypted Value:";
            // 
            // decryptedValueTBox
            // 
            this.decryptedValueTBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.decryptedValueTBox.Location = new System.Drawing.Point(205, 128);
            this.decryptedValueTBox.Name = "decryptedValueTBox";
            this.decryptedValueTBox.Size = new System.Drawing.Size(295, 22);
            this.decryptedValueTBox.TabIndex = 6;
            // 
            // encryptedValueTBox
            // 
            this.encryptedValueTBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.encryptedValueTBox.Location = new System.Drawing.Point(205, 101);
            this.encryptedValueTBox.Name = "encryptedValueTBox";
            this.encryptedValueTBox.Size = new System.Drawing.Size(295, 22);
            this.encryptedValueTBox.TabIndex = 7;
            // 
            // valueTBox
            // 
            this.valueTBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.valueTBox.Location = new System.Drawing.Point(205, 74);
            this.valueTBox.Name = "valueTBox";
            this.valueTBox.Size = new System.Drawing.Size(295, 22);
            this.valueTBox.TabIndex = 8;
            this.valueTBox.Text = "ping";
            // 
            // decryptBtn
            // 
            this.decryptBtn.Location = new System.Drawing.Point(343, 166);
            this.decryptBtn.Name = "decryptBtn";
            this.decryptBtn.Size = new System.Drawing.Size(101, 27);
            this.decryptBtn.TabIndex = 9;
            this.decryptBtn.Text = "Decrypt";
            this.decryptBtn.UseVisualStyleBackColor = true;
            this.decryptBtn.Click += new System.EventHandler(this.decryptBtn_Click);
            // 
            // ivTBox
            // 
            this.ivTBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ivTBox.Location = new System.Drawing.Point(205, 12);
            this.ivTBox.Name = "ivTBox";
            this.ivTBox.Size = new System.Drawing.Size(295, 22);
            this.ivTBox.TabIndex = 11;
            this.ivTBox.Text = "tu89geji340t89u2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "IV:";
            // 
            // EncryptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 210);
            this.Controls.Add(this.ivTBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.decryptBtn);
            this.Controls.Add(this.valueTBox);
            this.Controls.Add(this.encryptedValueTBox);
            this.Controls.Add(this.decryptedValueTBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passkeyTBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.encryptBtn);
            this.Name = "EncryptionForm";
            this.Text = "Encryption Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button encryptBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passkeyTBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox decryptedValueTBox;
        private System.Windows.Forms.TextBox encryptedValueTBox;
        private System.Windows.Forms.TextBox valueTBox;
        private System.Windows.Forms.Button decryptBtn;
        private System.Windows.Forms.TextBox ivTBox;
        private System.Windows.Forms.Label label5;
    }
}

