

using YoutubeVideoDownloader.Constant;

namespace YoutubeVideoDownloader.Models
{
    public class VideoDetailInformation : IFileInformation
    {
        public string Format { get; set; } = VideoDefaultConstant.DEFAULT_FORMAT;
        public double Size { get => Size; set => Size = value; }
        public string Location { get => Location; set => Location = value; }

        public string Resolution { get; set; } = VideoResolution.Standard.ToString();
        public DateTime? DateCreated { get => DateCreated; set => DateCreated = value; }
        public DateTime? DateModified { get => DateModified; set => DateModified = value; }
        public DateTime? DateAccessed { get => DateAccessed; set => DateAccessed = value; }

    }
}