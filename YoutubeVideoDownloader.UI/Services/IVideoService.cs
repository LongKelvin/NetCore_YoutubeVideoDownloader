using YoutubeVideoDownloader.Models;

namespace YoutubeVideoDownloader.UI.Services
{
    public interface IVideoService
    {
        Task<HttpResponseMessage> DownloadVideoFromUrl(string videoUrl);
        Task<IEnumerable<YoutubeVideo>> GetVideoInfos(string videoUrl);

    }
}
