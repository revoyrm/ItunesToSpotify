namespace ItunesToSpotifyForm
{
    partial class ItunesToSpotifyForm
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
            this.convertBtn = new System.Windows.Forms.Button();
            this.messageLbl = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileNameTB = new System.Windows.Forms.TextBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.ProgressLbl = new System.Windows.Forms.Label();
            this.clientIdTB = new System.Windows.Forms.TextBox();
            this.clientSecretTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loadConfigBtn = new System.Windows.Forms.Button();
            this.connectBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // convertBtn
            // 
            this.convertBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.convertBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.convertBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.convertBtn.ForeColor = System.Drawing.Color.Black;
            this.convertBtn.Location = new System.Drawing.Point(415, 183);
            this.convertBtn.Name = "convertBtn";
            this.convertBtn.Size = new System.Drawing.Size(75, 23);
            this.convertBtn.TabIndex = 0;
            this.convertBtn.Text = "Convert";
            this.convertBtn.UseVisualStyleBackColor = false;
            this.convertBtn.Click += new System.EventHandler(this.convertBtn_Click);
            // 
            // messageLbl
            // 
            this.messageLbl.AutoSize = true;
            this.messageLbl.Location = new System.Drawing.Point(27, 234);
            this.messageLbl.Name = "messageLbl";
            this.messageLbl.Size = new System.Drawing.Size(76, 13);
            this.messageLbl.TabIndex = 1;
            this.messageLbl.Text = "                       ";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xml";
            this.openFileDialog1.Filter = "xml files (*.xml)|*.xml";
            this.openFileDialog1.Title = "Choose playlist xml to convert";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // fileNameTB
            // 
            this.fileNameTB.Location = new System.Drawing.Point(12, 158);
            this.fileNameTB.Name = "fileNameTB";
            this.fileNameTB.Size = new System.Drawing.Size(397, 20);
            this.fileNameTB.TabIndex = 2;
            // 
            // browseBtn
            // 
            this.browseBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.browseBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.browseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.browseBtn.ForeColor = System.Drawing.Color.Black;
            this.browseBtn.Location = new System.Drawing.Point(415, 156);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 23);
            this.browseBtn.TabIndex = 3;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = false;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // ProgressLbl
            // 
            this.ProgressLbl.AutoSize = true;
            this.ProgressLbl.Location = new System.Drawing.Point(27, 210);
            this.ProgressLbl.Name = "ProgressLbl";
            this.ProgressLbl.Size = new System.Drawing.Size(97, 13);
            this.ProgressLbl.TabIndex = 4;
            this.ProgressLbl.Text = "                              ";
            // 
            // clientIdTB
            // 
            this.clientIdTB.Location = new System.Drawing.Point(85, 33);
            this.clientIdTB.Name = "clientIdTB";
            this.clientIdTB.Size = new System.Drawing.Size(405, 20);
            this.clientIdTB.TabIndex = 5;
            // 
            // clientSecretTB
            // 
            this.clientSecretTB.Location = new System.Drawing.Point(85, 59);
            this.clientSecretTB.Name = "clientSecretTB";
            this.clientSecretTB.Size = new System.Drawing.Size(405, 20);
            this.clientSecretTB.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Client ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Client Secret:";
            // 
            // loadConfigBtn
            // 
            this.loadConfigBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.loadConfigBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.loadConfigBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loadConfigBtn.ForeColor = System.Drawing.Color.Black;
            this.loadConfigBtn.Location = new System.Drawing.Point(334, 85);
            this.loadConfigBtn.Name = "loadConfigBtn";
            this.loadConfigBtn.Size = new System.Drawing.Size(75, 23);
            this.loadConfigBtn.TabIndex = 9;
            this.loadConfigBtn.Text = "Load Config";
            this.loadConfigBtn.UseVisualStyleBackColor = false;
            this.loadConfigBtn.Click += new System.EventHandler(this.loadConfigBtn_Click);
            // 
            // connectBtn
            // 
            this.connectBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.connectBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.connectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.connectBtn.ForeColor = System.Drawing.Color.Black;
            this.connectBtn.Location = new System.Drawing.Point(415, 85);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(75, 23);
            this.connectBtn.TabIndex = 10;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = false;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // ItunesToSpotifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(502, 372);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.loadConfigBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clientSecretTB);
            this.Controls.Add(this.clientIdTB);
            this.Controls.Add(this.ProgressLbl);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.fileNameTB);
            this.Controls.Add(this.messageLbl);
            this.Controls.Add(this.convertBtn);
            this.Name = "ItunesToSpotifyForm";
            this.Text = "ItunesToSpotify Playlist Creator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button convertBtn;
        private System.Windows.Forms.Label messageLbl;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox fileNameTB;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.Label ProgressLbl;
        private System.Windows.Forms.TextBox clientIdTB;
        private System.Windows.Forms.TextBox clientSecretTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button loadConfigBtn;
        private System.Windows.Forms.Button connectBtn;
    }
}

