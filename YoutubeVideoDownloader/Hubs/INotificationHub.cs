namespace YoutubeVideoDownloader.Hubs
{
    public interface INotificationHub
    {
        Task SendNotification(string msg, string metaData);
    }
}
