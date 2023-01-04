using Microsoft.AspNetCore.SignalR;

namespace YoutubeVideoDownloader.Hubs
{
    public class NotificationHub : Hub<INotificationHub>
    {
        public async Task SendNotification(string msg, string meta)
        {
            await Clients.All.SendNotification(msg, meta);
        }
    }
}