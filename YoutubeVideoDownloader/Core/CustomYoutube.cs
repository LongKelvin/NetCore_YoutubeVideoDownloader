using System.Net;

using VideoLibrary;

namespace YoutubeVideoDownloader.Core
{
    internal class CustomHandler
    {
        public HttpMessageHandler GetHandler()
        {
            CookieContainer cookieContainer = new CookieContainer();
            cookieContainer.Add(new Cookie("CONSENT", "YES+cb", "/", "youtube.com"));
            return new HttpClientHandler
            {
                UseCookies = true,
                CookieContainer = cookieContainer
            };
        }
    }

    //internal class CustomYouTube : YouTube
    //{
    //    private long chunkSize = 10_485_760;
    //    private long _fileSize = 0L;
    //    private readonly HttpClient _client = new();

    //    protected override HttpClient MakeClient(HttpMessageHandler handler)
    //    {
    //        return base.MakeClient(handler);
    //    }

    //    protected override HttpMessageHandler MakeHandler()
    //    {
    //        return new CustomHandler().GetHandler();
    //    }

    //    public async Task<byte[]> CreateDownloadAsync(Uri uri, IProgress<Tuple<long, long>>? progress = null)
    //    {
    //        /*Check if file is empty
    //        * If it does, thrown exception
    //        * Open stream to write file
    //        * caculate segment size
    //        * foreach segment size
    //        */
    //        var totalBytesCopied = 0L;

    //        _fileSize = await GetContentLengthAsync(uri.AbsoluteUri) ?? 0;
    //        if (IsEmptyFile())
    //        {
    //            throw new Exception("File has no any content !");
    //        }

    //        // Create a list to store the chunks
    //        var chunks = new List<byte[]>();

    //        var segmentCount = (int)Math.Ceiling(1.0 * _fileSize / chunkSize);
    //        for (var i = 0; i < segmentCount; i++)
    //        {
    //            var from = i * chunkSize;
    //            var to = (i + 1) * chunkSize - 1;
    //            var request = new HttpRequestMessage(HttpMethod.Get, uri);
    //            request.Headers.Range = new RangeHeaderValue(from, to);
    //            using (request)
    //            {
    //                // Download Stream
    //                var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
    //                if (response.IsSuccessStatusCode)
    //                    response.EnsureSuccessStatusCode();

    //                var stream = await response.Content.ReadAsStreamAsync();

    //                //File Steam
    //                var buffer = new byte[81920];
    //                int bytesCopied;

    //                do
    //                {
    //                    bytesCopied = await stream.ReadAsync(buffer, 0, buffer.Length);
    //                    //output.Write(buffer, 0, bytesCopied);

    //                    if (bytesCopied > 0)
    //                    {
    //                        chunks.Add(buffer.Take(bytesCopied).ToArray());
    //                    }

    //                    totalBytesCopied += bytesCopied;
    //                    //progress.Report(new Tuple<long, long>(totalBytesCopied, _fileSize));
    //                } while (bytesCopied > 0);
    //            }
    //        }

    //        // Merge the chunks into a single byte array
    //        var fileAsByteArray = new byte[_fileSize];
    //        int offset = 0;
    //        foreach (var chunk in chunks)
    //        {
    //            Buffer.BlockCopy(chunk, 0, fileAsByteArray, offset, chunk.Length);
    //            offset += chunk.Length;
    //        }

    //        return fileAsByteArray;
    //    }

    //    private async Task<long?> GetContentLengthAsync(string requestUri, bool ensureSuccess = true)
    //    {
    //        using var request = new HttpRequestMessage(HttpMethod.Head, requestUri);
    //        var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
    //        if (ensureSuccess)
    //            response.EnsureSuccessStatusCode();
    //        return response.Content.Headers.ContentLength;
    //    }

    //    private bool IsEmptyFile()
    //    {
    //        return _fileSize == 0;
    //    }
    //}

    public class CustomYouTube : YouTube
    {
        private const int ChunkSize = 1024 * 1000; // 1MB chunk size

        public async Task<byte[]> DownloadVideoAsync(string url)
        {
            //// Get the file size
            //var fileSize = await GetContentLengthAsync(url);

            //// Calculate the total number of chunks
            //var chunkCount = (int)Math.Ceiling((double)fileSize / ChunkSize);

            //// Create a list to hold the chunks
            //var chunks = new List<byte[]>(chunkCount);

            //// Create an HTTP client
            //using var client = new HttpClient();

            //// Download each chunk
            //for (int i = 0; i < chunkCount; i++)
            //{
            //    // Calculate the start and end indices of the current chunk
            //    var startIndex = i * ChunkSize;
            //    var endIndex = (i + 1) * ChunkSize - 1;
            //    if (endIndex > fileSize - 1)
            //    {
            //        endIndex = (int)(fileSize - 1);
            //    }

            //    // Create a request to download the chunk
            //    var request = new HttpRequestMessage(HttpMethod.Get, url);
            //    request.Headers.Range = new RangeHeaderValue(startIndex, endIndex);

            //    // Send the request and get the response
            //    var response = await client.SendAsync(request);

            //    // Read the response into a byte array
            //    using var stream = await response.Content.ReadAsStreamAsync();
            //    using var memoryStream = new MemoryStream();
            //    await stream.CopyToAsync(memoryStream);
            //    var chunkData = memoryStream.ToArray();

            //    // Add the chunk to the list
            //    chunks.Add(chunkData);
            //}

            //// Merge the chunks back into the original file
            //var file = MergeChunks(chunks);

            //return file;

            // Create an HTTP client
            //using var client = new HttpClient();

            //// Send a GET request and get the response as a byte array
            //var data = await client.GetByteArrayAsync(url);

            //return data;

            // Create a YouTube client
            return null;
        }

        private static byte[] MergeChunks(List<byte[]> chunks)
        {
            // Create a new memory stream to hold the merged chunks
            using var mergedStream = new MemoryStream();

            // Write each chunk to the stream
            foreach (var chunk in chunks)
            {
                mergedStream.Write(chunk, 0, chunk.Length);
            }

            // Return the merged chunks as a byte array
            return mergedStream.ToArray();
        }


        private async Task<long> GetContentLengthAsync(string url)
        {
            // Create an HTTP client
            using var client = new HttpClient();

            // Create a HEAD request
            var request = new HttpRequestMessage(HttpMethod.Head, url);

            // Send the request and get the response
            var response = await client.SendAsync(request);

            // Get the content length from the response
            return response.Content.Headers.ContentLength ?? -1;
        }
    }
}