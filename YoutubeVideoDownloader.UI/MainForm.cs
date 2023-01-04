using System.Configuration;
using System.Diagnostics;
using System.Net.NetworkInformation;

using YoutubeVideoDownloader.UI.Services;

namespace YoutubeVideoDownloader.UI
{
    public partial class MainForm : Form
    {
        private readonly IVideoService _videosService;

        public MainForm(IVideoService videosService)
        {
            InitializeComponent();

            CheckNetworkAvaliable();
            _videosService = videosService;
        }

        private async Task DownloadVideo(string url, string filePath)
        {
            Debug.WriteLine("Call Api for download video");
            var result = await _videosService.DownloadVideoFromUrl(url);

            if (!result.IsSuccessStatusCode)
            {
                MessageBox.Show("Can not download this video!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Get the file content
                var fileData = result.Content.ReadAsByteArrayAsync();

                string fileLocation = Path.Combine(filePath, $"video_{DateTime.Now:ddMMyyyyhhmmss}.mp4");

                var fileDataResult = fileData.Result;

                // Save the file to the local filesystem
                await File.WriteAllBytesAsync(fileLocation, fileDataResult);

                MessageBox.Show($"Download completed, Location {fileLocation}", "Completed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            if (textVideoUrl.Text == string.Empty)
            {
                MessageBox.Show("Video Url is not provide, Please provide some valid url",
                    "Url Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SpinWheelProgressBar.Visible = true;
            // Set the value of the ProgressBar to 0
            SpinWheelProgressBar.Value = 0;

            // Set the style of the ProgressBar to Marquee
            SpinWheelProgressBar.Style = ProgressBarStyle.Marquee;

            // Start the spin wheel animation
            SpinWheelProgressBar.MarqueeAnimationSpeed = 30;

            // Download the video
            await DownloadVideo(textVideoUrl.Text,
               ConfigurationManager.AppSettings["VideoDownloadLocation"]!);

            // Stop the spin wheel animation
            SpinWheelProgressBar.Style = ProgressBarStyle.Continuous;
            SpinWheelProgressBar.Visible = false;
        }

        private void btnSetDownloadLocation_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // Set the download location to the selected folder
                    var downloadLocation = folderDialog.SelectedPath;

                    // Get the configuration file
                    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                    // Set the value of the "DownloadLocation" app setting
                    config.AppSettings.Settings["VideoDownloadLocation"].Value = downloadLocation;

                    // Save the configuration file
                    config.Save(ConfigurationSaveMode.Modified);
                }
            }
        }

        private void btnGetVideos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The funtion is not implement yet!", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CheckNetworkAvaliable()
        {
            if (!NetworkInterface.GetIsNetworkAvailable())

            {
                MessageBox.Show("Internet connection is not available.", "Internet Connection",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}