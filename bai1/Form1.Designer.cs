namespace bai1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.gbFiles = new System.Windows.Forms.GroupBox();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.btnBrowseInput = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblInput = new System.Windows.Forms.Label();
            this.gbAlgorithm = new System.Windows.Forms.GroupBox();
            this.rbRSA = new System.Windows.Forms.RadioButton();
            this.rb3DES = new System.Windows.Forms.RadioButton();
            this.rbDES = new System.Windows.Forms.RadioButton();
            this.rbAES = new System.Windows.Forms.RadioButton();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.lblKey = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.gbFiles.SuspendLayout();
            this.gbAlgorithm.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFiles
            // 
            this.gbFiles.Controls.Add(this.btnBrowseOutput);
            this.gbFiles.Controls.Add(this.btnBrowseInput);
            this.gbFiles.Controls.Add(this.txtOutput);
            this.gbFiles.Controls.Add(this.txtInput);
            this.gbFiles.Controls.Add(this.lblOutput);
            this.gbFiles.Controls.Add(this.lblInput);
            this.gbFiles.Location = new System.Drawing.Point(12, 12);
            this.gbFiles.Name = "gbFiles";
            this.gbFiles.Size = new System.Drawing.Size(460, 110);
            this.gbFiles.TabIndex = 0;
            this.gbFiles.TabStop = false;
            this.gbFiles.Text = "Files";
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Location = new System.Drawing.Point(405, 68);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(40, 23);
            this.btnBrowseOutput.TabIndex = 5;
            this.btnBrowseOutput.Text = "📁";
            this.btnBrowseOutput.UseVisualStyleBackColor = true;
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // btnBrowseInput
            // 
            this.btnBrowseInput.Location = new System.Drawing.Point(405, 28);
            this.btnBrowseInput.Name = "btnBrowseInput";
            this.btnBrowseInput.Size = new System.Drawing.Size(40, 23);
            this.btnBrowseInput.TabIndex = 4;
            this.btnBrowseInput.Text = "📁";
            this.btnBrowseInput.UseVisualStyleBackColor = true;
            this.btnBrowseInput.Click += new System.EventHandler(this.btnBrowseInput_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(85, 70);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(314, 20);
            this.txtOutput.TabIndex = 3;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(85, 30);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(314, 20);
            this.txtInput.TabIndex = 2;
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(15, 73);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(58, 13);
            this.lblOutput.TabIndex = 1;
            this.lblOutput.Text = "Output File";
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(15, 33);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(50, 13);
            this.lblInput.TabIndex = 0;
            this.lblInput.Text = "Input File";
            // 
            // gbAlgorithm
            // 
            this.gbAlgorithm.Controls.Add(this.rbRSA);
            this.gbAlgorithm.Controls.Add(this.rb3DES);
            this.gbAlgorithm.Controls.Add(this.rbDES);
            this.gbAlgorithm.Controls.Add(this.rbAES);
            this.gbAlgorithm.Location = new System.Drawing.Point(12, 130);
            this.gbAlgorithm.Name = "gbAlgorithm";
            this.gbAlgorithm.Size = new System.Drawing.Size(460, 115);
            this.gbAlgorithm.TabIndex = 1;
            this.gbAlgorithm.TabStop = false;
            this.gbAlgorithm.Text = "Algorithm";
            // 
            // rbRSA
            // 
            this.rbRSA.AutoSize = true;
            this.rbRSA.Location = new System.Drawing.Point(30, 88);
            this.rbRSA.Name = "rbRSA";
            this.rbRSA.Size = new System.Drawing.Size(47, 17);
            this.rbRSA.TabIndex = 3;
            this.rbRSA.Text = "RSA";
            this.rbRSA.UseVisualStyleBackColor = true;
            this.rbRSA.CheckedChanged += new System.EventHandler(this.rbAlgorithm_CheckedChanged);
            // 
            // rb3DES
            // 
            this.rb3DES.AutoSize = true;
            this.rb3DES.Location = new System.Drawing.Point(30, 65);
            this.rb3DES.Name = "rb3DES";
            this.rb3DES.Size = new System.Drawing.Size(76, 17);
            this.rb3DES.TabIndex = 2;
            this.rb3DES.Text = "Triple DES";
            this.rb3DES.UseVisualStyleBackColor = true;
            this.rb3DES.CheckedChanged += new System.EventHandler(this.rbAlgorithm_CheckedChanged);
            // 
            // rbDES
            // 
            this.rbDES.AutoSize = true;
            this.rbDES.Location = new System.Drawing.Point(30, 42);
            this.rbDES.Name = "rbDES";
            this.rbDES.Size = new System.Drawing.Size(47, 17);
            this.rbDES.TabIndex = 1;
            this.rbDES.Text = "DES";
            this.rbDES.UseVisualStyleBackColor = true;
            this.rbDES.CheckedChanged += new System.EventHandler(this.rbAlgorithm_CheckedChanged);
            // 
            // rbAES
            // 
            this.rbAES.AutoSize = true;
            this.rbAES.Checked = true;
            this.rbAES.Location = new System.Drawing.Point(30, 19);
            this.rbAES.Name = "rbAES";
            this.rbAES.Size = new System.Drawing.Size(51, 17);
            this.rbAES.TabIndex = 0;
            this.rbAES.TabStop = true;
            this.rbAES.Text = "AES*";
            this.rbAES.UseVisualStyleBackColor = true;
            this.rbAES.CheckedChanged += new System.EventHandler(this.rbAlgorithm_CheckedChanged);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(140, 290);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(90, 30);
            this.btnEncrypt.TabIndex = 2;
            this.btnEncrypt.Text = "🔒 Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(250, 290);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(90, 30);
            this.btnDecrypt.TabIndex = 3;
            this.btnDecrypt.Text = "🔓 Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(27, 258);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(56, 13);
            this.lblKey.TabIndex = 4;
            this.lblKey.Text = "Key (Text):";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(97, 255);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(348, 20);
            this.txtKey.TabIndex = 5;
            this.txtKey.Text = "1234567890123456";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 336);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.gbAlgorithm);
            this.Controls.Add(this.gbFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Practice of Information Security - Đề 1";
            this.gbFiles.ResumeLayout(false);
            this.gbFiles.PerformLayout();
            this.gbAlgorithm.ResumeLayout(false);
            this.gbAlgorithm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFiles;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.Button btnBrowseInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.GroupBox gbAlgorithm;
        private System.Windows.Forms.RadioButton rbRSA;
        private System.Windows.Forms.RadioButton rb3DES;
        private System.Windows.Forms.RadioButton rbDES;
        private System.Windows.Forms.RadioButton rbAES;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox txtKey;
    }
}