using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

using YoutubeVideoDownloader.Hubs;
using YoutubeVideoDownloader.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YoutubeVideoDownloader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVideoService _videoService;
        private readonly BackgroundWorkerQueue _backgroundWorkerQueue;
        private IHubContext<NotificationHub, INotificationHub> _notificationHub;

        public VideoController(IVideoService videoService,
            BackgroundWorkerQueue backgroundWorkerQueue,
            IHubContext<NotificationHub, INotificationHub> notificationHub)
        {
            _videoService = videoService;
            _backgroundWorkerQueue = backgroundWorkerQueue;
            _notificationHub = notificationHub;
        }

        // POST api/<VideoController>
        [HttpPost]
        public async Task<IActionResult> DownloadVideoFromUrl([FromHeader] string url)
        {
            //_backgroundWorkerQueue.QueueBackgroundWorkItem(async token =>
            //{
            //    result = await _videoService.DownloadVideoFromUrl(url, _notificationHub);
            //});

            var result = await _videoService.DownloadVideoFromUrl(url, _notificationHub);
            return File(result, "application/octet-stream", $"video_{DateTime.Now.ToString("yyyyMMddHHmmss")}.mp4");
        }

        // GET: api/<VideoController>
        [HttpGet]
        public async Task<IActionResult> GetVideoInfos([FromHeader] string url)
        {
            var result = await _videoService.GetVideoInfos(url);
            return Ok(result);
        }
    }
}