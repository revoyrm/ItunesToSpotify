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
            this.SuspendLayout();
            // 
            // convertBtn
            // 
            this.convertBtn.Location = new System.Drawing.Point(415, 107);
            this.convertBtn.Name = "convertBtn";
            this.convertBtn.Size = new System.Drawing.Size(75, 23);
            this.convertBtn.TabIndex = 0;
            this.convertBtn.Text = "Convert";
            this.convertBtn.UseVisualStyleBackColor = true;
            this.convertBtn.Click += new System.EventHandler(this.convertBtn_Click);
            // 
            // messageLbl
            // 
            this.messageLbl.AutoSize = true;
            this.messageLbl.Location = new System.Drawing.Point(29, 138);
            this.messageLbl.Name = "messageLbl";
            this.messageLbl.Size = new System.Drawing.Size(49, 13);
            this.messageLbl.TabIndex = 1;
            this.messageLbl.Text = "message";
            this.messageLbl.Click += new System.EventHandler(this.messageLbl_Click);
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
            this.fileNameTB.Location = new System.Drawing.Point(12, 82);
            this.fileNameTB.Name = "fileNameTB";
            this.fileNameTB.Size = new System.Drawing.Size(397, 20);
            this.fileNameTB.TabIndex = 2;
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(415, 80);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 23);
            this.browseBtn.TabIndex = 3;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // ItunesToSpotifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 372);
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
    }
}

