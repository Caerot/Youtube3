
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.LblDownloadLocation = new System.Windows.Forms.Label();
            this.BtnChooseLocation = new System.Windows.Forms.Button();
            this.FpsLabel = new System.Windows.Forms.Label();
            this.CmbResolutionlabel = new System.Windows.Forms.Label();
            this.CmbFps = new System.Windows.Forms.ComboBox();
            this.CmbResolution = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnDownload = new System.Windows.Forms.Button();
            this.TxtYouTubeLink = new System.Windows.Forms.TextBox();
            this.NotifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 215);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(501, 25);
            this.progressBar.TabIndex = 29;
            this.progressBar.Click += new System.EventHandler(this.progressBar_Click);
            // 
            // LblDownloadLocation
            // 
            this.LblDownloadLocation.Location = new System.Drawing.Point(162, 166);
            this.LblDownloadLocation.Name = "LblDownloadLocation";
            this.LblDownloadLocation.Size = new System.Drawing.Size(213, 23);
            this.LblDownloadLocation.TabIndex = 28;
            this.LblDownloadLocation.Text = "(PATH)";
            this.LblDownloadLocation.Click += new System.EventHandler(this.lblDownloadLocation_Click);
            // 
            // BtnChooseLocation
            // 
            this.BtnChooseLocation.Location = new System.Drawing.Point(16, 166);
            this.BtnChooseLocation.Name = "BtnChooseLocation";
            this.BtnChooseLocation.Size = new System.Drawing.Size(140, 23);
            this.BtnChooseLocation.TabIndex = 27;
            this.BtnChooseLocation.Text = "Choose Location";
            this.BtnChooseLocation.UseVisualStyleBackColor = true;
            this.BtnChooseLocation.Click += new System.EventHandler(this.btnChooseLocation_Click);
            // 
            // FpsLabel
            // 
            this.FpsLabel.AutoSize = true;
            this.FpsLabel.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FpsLabel.Location = new System.Drawing.Point(421, 84);
            this.FpsLabel.Name = "FpsLabel";
            this.FpsLabel.Size = new System.Drawing.Size(29, 14);
            this.FpsLabel.TabIndex = 26;
            this.FpsLabel.Text = "Fps";
            // 
            // CmbResolutionlabel
            // 
            this.CmbResolutionlabel.AutoSize = true;
            this.CmbResolutionlabel.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbResolutionlabel.Location = new System.Drawing.Point(421, 51);
            this.CmbResolutionlabel.Name = "CmbResolutionlabel";
            this.CmbResolutionlabel.Size = new System.Drawing.Size(77, 14);
            this.CmbResolutionlabel.TabIndex = 25;
            this.CmbResolutionlabel.Text = "Resolution";
            // 
            // CmbFps
            // 
            this.CmbFps.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold);
            this.CmbFps.FormattingEnabled = true;
            this.CmbFps.Location = new System.Drawing.Point(294, 81);
            this.CmbFps.Name = "CmbFps";
            this.CmbFps.Size = new System.Drawing.Size(121, 22);
            this.CmbFps.TabIndex = 24;
            this.CmbFps.SelectedIndexChanged += new System.EventHandler(this.cmbFps_SelectedIndexChanged);
            // 
            // CmbResolution
            // 
            this.CmbResolution.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold);
            this.CmbResolution.FormattingEnabled = true;
            this.CmbResolution.Items.AddRange(new object[] {
            "1080p",
            "720p",
            "360p",
            "240p",
            "144p"});
            this.CmbResolution.Location = new System.Drawing.Point(294, 47);
            this.CmbResolution.Name = "CmbResolution";
            this.CmbResolution.Size = new System.Drawing.Size(121, 22);
            this.CmbResolution.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 14);
            this.label1.TabIndex = 22;
            this.label1.Text = "(YouTube Link)";
            // 
            // BtnDownload
            // 
            this.BtnDownload.Location = new System.Drawing.Point(111, 68);
            this.BtnDownload.Name = "BtnDownload";
            this.BtnDownload.Size = new System.Drawing.Size(75, 23);
            this.BtnDownload.TabIndex = 21;
            this.BtnDownload.Text = "Download";
            this.BtnDownload.UseVisualStyleBackColor = true;
            this.BtnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // TxtYouTubeLink
            // 
            this.TxtYouTubeLink.Location = new System.Drawing.Point(16, 47);
            this.TxtYouTubeLink.Name = "TxtYouTubeLink";
            this.TxtYouTubeLink.Size = new System.Drawing.Size(272, 20);
            this.TxtYouTubeLink.TabIndex = 20;
            // 
            // NotifyIcon1
            // 
            this.NotifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon1.Icon")));
            this.NotifyIcon1.Text = "notifyIcon1";
            this.NotifyIcon1.Visible = true;
            this.NotifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 269);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.LblDownloadLocation);
            this.Controls.Add(this.BtnChooseLocation);
            this.Controls.Add(this.FpsLabel);
            this.Controls.Add(this.CmbResolutionlabel);
            this.Controls.Add(this.CmbFps);
            this.Controls.Add(this.CmbResolution);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnDownload);
            this.Controls.Add(this.TxtYouTubeLink);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "YouTube Downloader";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label LblDownloadLocation;
        private System.Windows.Forms.Button BtnChooseLocation;
        private System.Windows.Forms.Label FpsLabel;
        private System.Windows.Forms.Label CmbResolutionlabel;
        private System.Windows.Forms.ComboBox CmbFps;
        private System.Windows.Forms.ComboBox CmbResolution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnDownload;
        private System.Windows.Forms.TextBox TxtYouTubeLink;
        private System.Windows.Forms.NotifyIcon NotifyIcon1;
    }
}

