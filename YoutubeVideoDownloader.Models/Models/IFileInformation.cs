namespace YoutubeVideoDownloader.Models
{
    public interface IFileInformation
    {
        string Format { get; set; }

        DateTime? DateCreated { get; set; }
        DateTime? DateModified { get; set; }
        DateTime? DateAccessed { get; set; }
        double Size { get; set; }
        string Location { get; set; }
    }
}