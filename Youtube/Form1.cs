using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using System.IO;



namespace Youtube
{
	public partial class Form1 : Form
	{
		private void Form1_Load(object sender, EventArgs e)
		{

		}
		private void btnChooseLocation_Click(object sender, EventArgs e)
		{
			using (var dialog = new FolderBrowserDialog())
			{

			}
		}

		void Download()
		{
			var youtubeClient = new YoutubeClient();
			var videoId = txtYouTubeLink.Text;  // Get video URL or ID from textbox

			// Get the stream manifest and find a suitable stream in 360p MP4 format
			var streamInfo = youtubeClient.Videos.Streams
				.GetManifestAsync(videoId).Result
				.GetVideoStreams()
				.FirstOrDefault(s => s.VideoQuality.Label == "360p" && s.Container.ToString().Equals("mp4", StringComparison.OrdinalIgnoreCase));

			if (streamInfo == null)
			{
				MessageBox.Show("No suitable stream found.");
				return;
			}

			// Define output file path (assuming MP4 container)
			var outputPath = Path.Combine("D:\\", $"{videoId}.mp4");

			// Download the video stream asynchronously
			youtubeClient.Videos.Streams.DownloadAsync(streamInfo, outputPath).Continuewith(task =>
			{
				MessageBox.Show(task.IsCompleted ? "Download finished!" : "Download failed.");
			});
		}

		void vidoedownload_downloadFinished(object s, EventArgs e)
		{
			MessageBox.Show("download finshed");
		}



        public Form1()
		{
			InitializeComponent();
		}
		private void button1_Click_1(object sender, EventArgs e)
		{
			Download();
		}

		private void txtYouTubeLink_TextChanged(object sender, EventArgs e)
		{

		}

		private void lblDownloadLocation_Click(object sender, EventArgs e)
		{

		}

		private void btnChooseLocation_Click_1(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void cmbResolutionlabel_Click(object sender, EventArgs e)
		{

		}

		private void cmbFps_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void cmbResolution_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void progressBar_Click(object sender, EventArgs e)
		{

		}
	}
}
