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
using System.Diagnostics;


namespace Youtube2
{
    public partial class Form1 : Form
    {
        private readonly YoutubeClient _youtubeClient;

        public Form1()
        {
            InitializeComponent();
            _youtubeClient = new YoutubeClient(); // Initialize the YoutubeClient once
        }

        private async void DownloadVideoAsync()
        {
            var videoUrl = txtYouTubeLink.Text; // Get video URL from the label

            try
            {
                // Get the video and stream manifest
                var video = await _youtubeClient.Videos.GetAsync(videoUrl);
                var streamManifest = await _youtubeClient.Videos.Streams.GetManifestAsync(videoUrl);

                // Select the best video and audio streams
                var videoStream = streamManifest.GetVideoStreams()
                    .FirstOrDefault(s => s.VideoQuality.Label == "360p");
                var audioStream = streamManifest.GetAudioStreams()
                    .GetWithHighestBitrate();

                if (videoStream == null || audioStream == null)
                {
                    MessageBox.Show("Suitable video or audio stream not found.");
                    return;
                }

                // Define temporary file paths
                var videoPath = Path.Combine("D:\\", "temp_video.mp4");
                var audioPath = Path.Combine("D:\\", "temp_audio.mp3");
                var outputPath = Path.Combine("D:\\", $"{video.Title}.mp4");

                // Download video and audio streams
                await _youtubeClient.Videos.Streams.DownloadAsync(videoStream, videoPath);
                await _youtubeClient.Videos.Streams.DownloadAsync(audioStream, audioPath);

                // Merge video and audio using FFmpeg
                var ffmpegPath = "ffmpeg"; // Ensure FFmpeg is in your system's PATH
                var arguments = $"-i \"{videoPath}\" -i \"{audioPath}\" -c:v copy -c:a aac \"{outputPath}\"";

                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = ffmpegPath,
                        Arguments = arguments,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                process.Start();
                await process.WaitForExitAsync();

                // Clean up temporary files
                File.Delete(videoPath);
                File.Delete(audioPath);

                MessageBox.Show("Download and merging finished!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DownloadVideoAsync();
        }
    }
}