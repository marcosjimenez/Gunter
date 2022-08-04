using Flurl;
using Flurl.Http;

namespace Gunter.Infrastructure
{
    public static class WebManipulationHelper
    {

        public static async Task<T> Get<T>(string url, Dictionary<string,string> parameters)
        {
            var webUrl = url.WithHeader("Accept", "text/plain");

            foreach(var item in parameters)
                webUrl = webUrl.SetQueryParam(item.Key, item.Value);

            var result = await webUrl.GetJsonAsync<T>();

            return result;
        }

        public static async Task<string> DownloadFileAsStringAsync(string file)
        {
            using var client = new HttpClient();
            using var response = await client.GetAsync(file);
            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<byte[]> DownloadFileAsync(string file)
        {
            using var client = new HttpClient();
            using var response = await client.GetAsync(file);
            using var streamToReadFrom = await response.Content.ReadAsStreamAsync();

            const int BufferSize = 4096;
            int receivedBytes = 0;
            using var ms = new MemoryStream();
            var buffer = new byte[BufferSize];
            int read = 0;
            var totalBytes = streamToReadFrom.Length;

            while ((read = await streamToReadFrom.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
                receivedBytes += read;
            }
            var data = ms.ToArray();

            return data;
        }

    }
}
