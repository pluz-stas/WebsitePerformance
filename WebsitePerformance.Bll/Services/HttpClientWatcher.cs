using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using WebsitePerformance.Bll.Interfaces;
using WebsitePerformance.Bll.Resources;

namespace WebsitePerformance.Bll.Services
{
    public class HttpClientWatcher : IHttpClientWatcher
    {
        private readonly IHttpClientFactory _httpClientFactory;

        
        public HttpClientWatcher(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<TimeSpan> GetRequestTimeAsync(string uri)
        {
            var client = _httpClientFactory.CreateClient(AppConstants.Monitoring);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            await client.SendAsync(request);

            var watcher = (Stopwatch)request.Properties[AppConstants.StopWatch];
            return watcher.Elapsed;
        }
    }
}