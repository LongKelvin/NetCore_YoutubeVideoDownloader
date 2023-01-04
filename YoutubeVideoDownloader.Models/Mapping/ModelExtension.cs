namespace YoutubeVideoDownloader.Models.Mapping
{
    public static class ModelExtensions
    {
        public static YoutubeVideo ToYoutubeVideo(VideoLibrary.YouTubeVideo youtubeVideo)
        {
            return new YoutubeVideo
            {
                VideoName = youtubeVideo.FullName,
                VideoUrl = youtubeVideo.Uri,
                VideoId = string.Empty,
                LocalPath = youtubeVideo.WebSite.ToString(),
                Author = youtubeVideo.Info.Author.ToString(),
                Format = youtubeVideo.Format.ToString(),
                Resolution = youtubeVideo.Resolution.ToString(),
            };
        }
    }
}