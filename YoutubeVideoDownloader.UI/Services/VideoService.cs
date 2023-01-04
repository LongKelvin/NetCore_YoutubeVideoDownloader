using Newtonsoft.Json;

using System.Configuration;
using System.Diagnostics;

using YoutubeVideoDownloader.Models;
using YoutubeVideoDownloader.Models.Convert;

namespace YoutubeVideoDownloader.UI.Services
{
    internal class VideoService : ApiServices, IVideoService
    {
        private string VIDEO_API_URL = ConfigurationManager.AppSettings["VideoApiUrl"]!;

        public async Task<HttpResponseMessage> DownloadVideoFromUrl(string videoUrl)
        {
            return await PostWithHeaderRequest(videoUrl, VIDEO_API_URL);

        }

        public async Task<IEnumerable<YoutubeVideo>?> GetVideoInfos(string videoUrl)
        {
            var response = await GetWithHeaderRequest(videoUrl, VIDEO_API_URL);
            //IEnumerable<VideoLibrary.YouTubeVideo>? listVideos = null;
            //IEnumerable<YoutubeVideo>? listVideos = null;

            List<YoutubeVideo> youtubeVideos = new List<YoutubeVideo>();
            try
            {
                // Convert the HttpResponseMessage to string
                //var jsonResult = await response.Content.ReadAsAsync<List<YoutubeVideo>>();
                var jsonArrayResult = await response.Content.ReadAsStringAsync();


                // YoutubeVideo video = JsonConvert.DeserializeObject<YoutubeVideo>(jsonArrayResult!, converters: new CustomJsonConvert());

                youtubeVideos = JsonConvert.DeserializeObject<List<YoutubeVideo>>(jsonArrayResult, new CustomJsonConvert());

                // Deserialize the Json string into type using JsonConvert
                //listVideos = JsonConvert.DeserializeObject<List<YoutubeVideo>>(jsonResult, Formatting.Indented);

                //foreach (var video in listVideos!)
                //{
                //    Debug.WriteLine($"{video.VideoName} __ {video.VideoUrl} __ {video.Resolution} __ {video.Format}");
                //    Trace.WriteLine($"{video.VideoName} __ {video.VideoUrl} __ {video.Resolution} __ {video.Format}");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.Message);
            }

            return youtubeVideos;
        }
    }
}