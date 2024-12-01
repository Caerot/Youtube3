
namespace Youtube2
{
    partial class Form1
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblDownloadLocation = new System.Windows.Forms.Label();
            this.btnChooseLocation = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbResolutionlabel = new System.Windows.Forms.Label();
            this.cmbFps = new System.Windows.Forms.ComboBox();
            this.cmbResolution = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.txtYouTubeLink = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(50, 211);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(391, 23);
            this.progressBar.TabIndex = 19;
            // 
            // lblDownloadLocation
            // 
            this.lblDownloadLocation.Location = new System.Drawing.Point(228, 140);
            this.lblDownloadLocation.Name = "lblDownloadLocation";
            this.lblDownloadLocation.Size = new System.Drawing.Size(213, 23);
            this.lblDownloadLocation.TabIndex = 18;
            this.lblDownloadLocation.Text = "(PATH)";
            // 
            // btnChooseLocation
            // 
            this.btnChooseLocation.Location = new System.Drawing.Point(50, 135);
            this.btnChooseLocation.Name = "btnChooseLocation";
            this.btnChooseLocation.Size = new System.Drawing.Size(140, 23);
            this.btnChooseLocation.TabIndex = 17;
            this.btnChooseLocation.Text = "Choose Location";
            this.btnChooseLocation.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(447, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Fps";
            // 
            // cmbResolutionlabel
            // 
            this.cmbResolutionlabel.AutoSize = true;
            this.cmbResolutionlabel.Location = new System.Drawing.Point(447, 47);
            this.cmbResolutionlabel.Name = "cmbResolutionlabel";
            this.cmbResolutionlabel.Size = new System.Drawing.Size(57, 13);
            this.cmbResolutionlabel.TabIndex = 15;
            this.cmbResolutionlabel.Text = "Resolution";
            // 
            // cmbFps
            // 
            this.cmbFps.FormattingEnabled = true;
            this.cmbFps.Location = new System.Drawing.Point(320, 97);
            this.cmbFps.Name = "cmbFps";
            this.cmbFps.Size = new System.Drawing.Size(121, 21);
            this.cmbFps.TabIndex = 14;
            // 
            // cmbResolution
            // 
            this.cmbResolution.FormattingEnabled = true;
            this.cmbResolution.Location = new System.Drawing.Point(320, 43);
            this.cmbResolution.Name = "cmbResolution";
            this.cmbResolution.Size = new System.Drawing.Size(121, 21);
            this.cmbResolution.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "yt link";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(220, 42);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 11;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // txtYouTubeLink
            // 
            this.txtYouTubeLink.Location = new System.Drawing.Point(50, 44);
            this.txtYouTubeLink.Name = "txtYouTubeLink";
            this.txtYouTubeLink.Size = new System.Drawing.Size(100, 20);
            this.txtYouTubeLink.TabIndex = 10;
            // this.txtYouTubeLink.TextChanged += new System.EventHandler(this.txtYouTubeLink_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 286);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblDownloadLocation);
            this.Controls.Add(this.btnChooseLocation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbResolutionlabel);
            this.Controls.Add(this.cmbFps);
            this.Controls.Add(this.cmbResolution);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.txtYouTubeLink);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblDownloadLocation;
        private System.Windows.Forms.Button btnChooseLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label cmbResolutionlabel;
        private System.Windows.Forms.ComboBox cmbFps;
        private System.Windows.Forms.ComboBox cmbResolution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.TextBox txtYouTubeLink;
    }
}

