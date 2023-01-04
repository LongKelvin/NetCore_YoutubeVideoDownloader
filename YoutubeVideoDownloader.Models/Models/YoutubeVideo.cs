using System.Text.Json.Serialization;

using YoutubeVideoDownloader.Constant;

namespace YoutubeVideoDownloader.Models
{
    public class YoutubeVideo
    {
        [JsonPropertyName("title")]
        public string VideoTitle { get; set; } = VideoDefaultConstant.DEFAULT_NAME;

        [JsonPropertyName("fullName")]
        public string VideoName { get; set; } = VideoDefaultConstant.DEFAULT_NAME;

        [JsonPropertyName("uri")]
        public string VideoUrl { get; set; } = VideoDefaultConstant.DEFAULT_VIDEO_URL;

        public string VideoId { get; set; } = string.Empty;
        public string LocalPath { get; set; } = VideoDefaultConstant.DEFAULT_PATH;

        [JsonPropertyName("author")]
        public string Author { get; set; } = string.Empty;

        [JsonPropertyName("fileExtension")]
        public string Format { get; set; } = VideoDefaultConstant.DEFAULT_FORMAT;

        public double Size { get => Size; set => Size = value; }
        public string Location { get => Location; set => Location = value; }

        [JsonPropertyName("resolution")]
        public string Resolution { get; set; } = VideoResolution.Standard.ToString();

        public DateTime? DateCreated { get => DateCreated; set => DateCreated = value; }
        public DateTime? DateModified { get => DateModified; set => DateModified = value; }
        public DateTime? DateAccessed { get => DateAccessed; set => DateAccessed = value; }
    }
}