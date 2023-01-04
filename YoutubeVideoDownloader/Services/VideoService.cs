using Microsoft.AspNetCore.SignalR;

using System.Diagnostics;

using VideoLibrary;

using YoutubeVideoDownloader.Hubs;
using YoutubeVideoDownloader.Models;

namespace YoutubeVideoDownloader.Services
{
    public class VideoService : IVideoService
    {
        public async Task<byte[]> DownloadVideoFromUrl(string url, IHubContext<NotificationHub, INotificationHub> notificationHub, string? filePath = null)
        {
            var youtube = YouTube.Default;
            var videos = await youtube.GetAllVideosAsync(url);
            var video = GetHighVideoResolution(videos);

            string fileLocation = Path.Combine(GetDefaultFolder(), video.FullName);

            Debug.WriteLine("Starting Download ......... ");

            var videoAsByteArray = await video.GetBytesAsync();

            Debug.WriteLine($"Download completed");

            await notificationHub.Clients.All.SendNotification("Download completed", fileLocation);

            return videoAsByteArray;
        }

        public string GetDefaultFolder()
        {
            return Environment.GetFolderPath(
                Environment.SpecialFolder.Desktop);
        }

        public async Task<IEnumerable<VideoLibrary.YouTubeVideo>> GetVideoInfos(string url, bool isOnlyVideoWithAudio = true)
        {
            var youtube = YouTube.Default;

            Debug.WriteLine("Getting Video Information ......... ");
            var videos = await youtube.GetAllVideosAsync(url);
            Debug.WriteLine($"Getting completed");

            return videos;
        }

        private YouTubeVideo GetHighVideoResolution(IEnumerable<YouTubeVideo> youTubeVideos)
        {
            //Get video with audio
            var videos = youTubeVideos
                .Where(v => v.AdaptiveKind == AdaptiveKind.Video
                && v.AudioBitrate != -1).OrderByDescending(x => x.Resolution);

            if (videos == null)
                return youTubeVideos.FirstOrDefault()!;

            if (videos.Count() == 1)
                return videos.FirstOrDefault()!;

            //var video = videos.FirstOrDefault(v =>
            //v.Resolution == (int)VideoResolution.UltraHD ||
            //v.Resolution == (int)VideoResolution.FullHD ||
            //v.Resolution == (int)VideoResolution.High);

            var video = videos.FirstOrDefault();

            if (video == null)
                video = videos.FirstOrDefault();

            return video!;
        }

        private YoutubeVideo MapLibraryVideoToCustomYoutubeVideo(YouTubeVideo video)
        {
            return new YoutubeVideo
            {
                VideoName = video.Title,
                //VideoUrl = video.Uri,
                //VideoDetailInformation = MapToCustomYoutubeVideoDetail(video),
            };
        }

        private VideoDetailInformation MapToCustomYoutubeVideoDetail(YouTubeVideo video)
        {
            return new VideoDetailInformation
            {
                //DateCreated = DateTime.Now,
                //DateAccessed = DateTime.Now,
                //DateModified = DateTime.Now,
                Format = video.Format.ToString(),
                Resolution = video.Resolution.ToString(),
            };
        }

        private IEnumerable<YoutubeVideo> MapLibraryVideosToCustomYoutubeVideos(IEnumerable<YouTubeVideo> videos)
        {
            var listVideos = new List<YoutubeVideo>();
            Debug.WriteLine($"Getstarted__MapLibraryVideosToCustomYoutubeVideos");

            try
            {
                foreach (var video in videos)
                {
                    //Debug.WriteLine($"Video Name: {video.FullName} _ {video.Format}");
                    listVideos.Add(MapLibraryVideoToCustomYoutubeVideo(video));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"MapLibraryVideosToCustomYoutubeVideos: {ex.Message}");
            }

            //try
            //{
            //    Debug.WriteLine($"Total Video: {listVideos.Count()}");
            //    foreach (var video in listVideos)
            //    {
            //        Debug.WriteLine($"List Video Name: {video.VideoName}");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine($"List extract: {ex.Message}");
            //}
            return listVideos;
        }
    }
}