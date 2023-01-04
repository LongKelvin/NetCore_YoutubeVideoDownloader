namespace YoutubeVideoDownloader.Services
{
    public class DownloadFileHostedService : BackgroundService
    {
        private readonly BackgroundWorkerQueue _queue;

        public DownloadFileHostedService(BackgroundWorkerQueue queue)
        {
            this._queue = queue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var workItem = await _queue.DequeueAsync(stoppingToken);

                await workItem(stoppingToken);
            }
        }

    }
}
