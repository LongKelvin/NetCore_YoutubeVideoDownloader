using Microsoft.AspNetCore.SignalR;

using YoutubeVideoDownloader.Hubs;

namespace YoutubeVideoDownloader.Services
{
    public interface IVideoService
    {
        Task<byte[]> DownloadVideoFromUrl(string url, IHubContext<NotificationHub, INotificationHub> notificationHub, string? filePath = null);
        string GetDefaultFolder();
        Task<IEnumerable<VideoLibrary.YouTubeVideo>> GetVideoInfos(string url, bool isOnlyVideoWithAudio = true);
    }
}