using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace Youtube2
{
    
   
    public partial class Form1 : Form
    {
        private readonly YoutubeClient _youtubeClient;
        private string _downloadPath; // To store the selected download path

        public Form1()
        {
            InitializeComponent();
            _youtubeClient = new YoutubeClient();

            // Populate FPS combo box with common FPS values
            CmbFps.Items.AddRange(new[] { "60", "24", "12", "4", "1"});

            // Set default download location to Downloads folder
            _downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            LblDownloadLocation.Text = $"Download Location: {_downloadPath}";

        }


        private void CmbResolution_SelectedIndexChanged(object sender, EventArgs e) { }
        private void CmbFps_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblDownloadLocation_Click(object sender, EventArgs e) { }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            _ = DownloadVideoAsync(); // Fire and forget async call
        }

        private void btnChooseLocation_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select Download Location";
                folderDialog.SelectedPath = _downloadPath;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    _downloadPath = folderDialog.SelectedPath; // Update the selected path
                    LblDownloadLocation.Text = $"Download Location: {_downloadPath}";
                }
            }
        }

        private async Task<bool> RunFFmpegAsync(string arguments)
        {
            var ffmpegPath = "ffmpeg"; // Ensure FFmpeg is installed and accessible via PATH
            var tcs = new TaskCompletionSource<bool>();

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

            process.OutputDataReceived += (sender, args) =>
            {
                if (!string.IsNullOrEmpty(args.Data))
                    Console.WriteLine($"FFmpeg Output: {args.Data}");
            };

            process.ErrorDataReceived += (sender, args) =>
            {
                if (!string.IsNullOrEmpty(args.Data))
                    Console.WriteLine($"FFmpeg Error: {args.Data}");
            };

            process.EnableRaisingEvents = true;
            process.Exited += (sender, args) =>
            {
                tcs.TrySetResult(process.ExitCode == 0); // Set the task result based on FFmpeg success
            };

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            await tcs.Task; // Wait for FFmpeg to complete
            return process.ExitCode == 0;
        }

        private async Task DownloadVideoAsync()
        {
            var videoUrl = TxtYouTubeLink.Text.Trim();
            var selectedResolution = CmbResolution.SelectedItem?.ToString();
            var selectedFps = CmbFps.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(videoUrl))
            {
                MessageBox.Show("Please enter a valid YouTube link.");
                return;
            }

            if (string.IsNullOrEmpty(selectedResolution))
            {
                MessageBox.Show("Please select a resolution.");
                return;
            }

            if (string.IsNullOrEmpty(selectedFps))
            {
                MessageBox.Show("Please select an FPS value.");
                return;
            }

            string videoPath = string.Empty;
            string adjustedVideoPath = string.Empty;
            string audioPath = string.Empty;
            string outputPath = string.Empty;

            try
            {
                var video = await _youtubeClient.Videos.GetAsync(videoUrl);
                var streamManifest = await _youtubeClient.Videos.Streams.GetManifestAsync(videoUrl);

                int targetFps = int.Parse(selectedFps);

                int GetFpsFromLabel(string label)
                {
                    // Extract FPS from the label or default to 30 if missing
                    var match = System.Text.RegularExpressions.Regex.Match(label, @"(\d+)p(\d+)?");
                    if (match.Success)
                    {
                        return int.TryParse(match.Groups[2].Value, out int fps) ? fps : 30; // Default FPS: 30
                    }
                    return 30; // Default to 30 if no FPS found
                }

                var videoStreams = streamManifest.GetVideoStreams()
                    .Where(s => s.VideoQuality.Label.StartsWith(selectedResolution))
                    .OrderByDescending(s => GetFpsFromLabel(s.VideoQuality.Label)) // Sort by FPS (highest first)
                    .ThenByDescending(s => s.Bitrate)
                    .ToList();

                if (!videoStreams.Any())
                {
                    MessageBox.Show($"No video stream found for resolution: {selectedResolution}.");
                    return;
                }

                var closestVideoStream = videoStreams
                    .FirstOrDefault(s => GetFpsFromLabel(s.VideoQuality.Label) == targetFps);

                if (closestVideoStream == null)
                {
                    closestVideoStream = videoStreams.First(); // Default to the highest available FPS
                    var closestFps = GetFpsFromLabel(closestVideoStream.VideoQuality.Label);

                    if (closestFps > targetFps)
                    {
                        MessageBox.Show($"Desired FPS {targetFps} not available. Using FFmpeg to lower from {closestFps} FPS.");
                    }
                    else
                    {
                        MessageBox.Show($"Desired FPS {targetFps} not available. Using the highest available FPS: {closestFps}.");
                        targetFps = closestFps; // Use the closest FPS as the target
                    }
                }

                var audioStream = streamManifest.GetAudioStreams()
                    .OrderByDescending(s => s.Bitrate)
                    .FirstOrDefault();

                if (audioStream == null)
                {
                    MessageBox.Show("No audio stream available.");
                    return;
                }

                videoPath = Path.Combine(_downloadPath, "temp_video.mp4");
                adjustedVideoPath = Path.Combine(_downloadPath, "adjusted_video.mp4");
                audioPath = Path.Combine(_downloadPath, "temp_audio.mp3");
                outputPath = Path.Combine(_downloadPath, $"{video.Title}.mp4");

                // Download video and audio
                await _youtubeClient.Videos.Streams.DownloadAsync(closestVideoStream, videoPath);
                await _youtubeClient.Videos.Streams.DownloadAsync(audioStream, audioPath);

                // Adjust FPS with FFmpeg if needed
                if (GetFpsFromLabel(closestVideoStream.VideoQuality.Label) > targetFps)
                {
                    var fpsAdjustmentArguments = $"-i \"{videoPath}\" -filter:v fps={targetFps} -c:v libx264 -preset fast -crf 23 \"{adjustedVideoPath}\"";
                    var success = await RunFFmpegAsync(fpsAdjustmentArguments);
                    if (!success)
                    {
                        MessageBox.Show("An error occurred during FPS adjustment.");
                        return;
                    }

                    videoPath = adjustedVideoPath;
                }

                // Merge video and audio
                var ffmpegMergeArguments = $"-i \"{videoPath}\" -i \"{audioPath}\" -c:v copy -c:a aac \"{outputPath}\"";
                var mergeSuccess = await RunFFmpegAsync(ffmpegMergeArguments);
                if (!mergeSuccess)
                {
                    MessageBox.Show("An error occurred during merging.");
                    return;
                }

                MessageBox.Show("Download and merging finished!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                CleanupTemporaryFiles(videoPath, audioPath, adjustedVideoPath);
            }
        }





        private static void CleanupTemporaryFiles(string videoPath, string audioPath, string adjustedVideoPath)
        {
            try
            {
                // Delete temp_video.mp4
                if (File.Exists(videoPath))
                {
                    Console.WriteLine($"Deleting file: {videoPath}");
                    File.Delete("videoPath");
                    Console.WriteLine($"Deleted file: {videoPath}");
                }
                else
                {
                    Console.WriteLine($"File not found for cleanup: {videoPath}");
                }

                // Delete temp_audio.mp3
                if (File.Exists(audioPath))
                {
                    Console.WriteLine($"Deleting file: {audioPath}");
                    File.Delete(audioPath);
                    Console.WriteLine($"Deleted file: {audioPath}");
                }
                else
                {
                    Console.WriteLine($"File not found for cleanup: {audioPath}");
                }

                // Delete adjusted_video.mp4
                if (File.Exists(adjustedVideoPath))
                {
                    Console.WriteLine($"Deleting file: {adjustedVideoPath}");
                    File.Delete(adjustedVideoPath);
                    Console.WriteLine($"Deleted file: {adjustedVideoPath}");
                }
                else
                {
                    Console.WriteLine($"File not found for cleanup: {adjustedVideoPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during cleanup: {ex.Message}");
            }
        }

        // Update call to CleanupTemporaryFiles to pass all required paths
        // CleanupTemporaryFiles(videoPath, audioPath, adjustedVideoPath);




        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                NotifyIcon1.Visible = true;
                NotifyIcon1.ShowBalloonTip(1000, "App Minimized", "The application is running in the background.", ToolTipIcon.Info);
                Hide();
            }
        }
        
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            NotifyIcon1.Visible = false;
        }
        private void cmbFps_SelectedIndexChanged(object sender, EventArgs e) { }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }


    }
}