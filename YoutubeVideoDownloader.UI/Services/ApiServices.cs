using System.Diagnostics;

namespace YoutubeVideoDownloader.UI.Services
{
    internal class ApiServices
    {
        public async Task<HttpResponseMessage> PostWithHeaderRequest(string data, string url, bool isHeaderRequest = false)
        {
            var _httpClient = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            _httpClient.DefaultRequestHeaders.Add("url", data);
            return await _httpClient.PostAsync(url, null);
        }

        public async Task<HttpResponseMessage> GetWithHeaderRequest(string data, string url)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            try
            {
                var _httpClient = new HttpClient
                {
                    BaseAddress = new Uri(url),
                    Timeout = TimeSpan.FromMinutes(10)
                };

                _httpClient.DefaultRequestHeaders.Add("url", data);
                httpResponse = await _httpClient.GetAsync(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.Message);
            }

            return httpResponse;
        }
    }
}