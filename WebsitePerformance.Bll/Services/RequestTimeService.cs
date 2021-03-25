using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using WebsitePerformance.Bll.Interfaces;
using WebsitePerformance.Bll.Resources;

namespace WebsitePerformance.Bll.Services
{
    public class RequestTimeService : IRequestTimeService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RequestTimeService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<TimeSpan> GetResponseTimeAsync(string uri)
        {
            var client = _httpClientFactory.CreateClient(AppConstants.Measuring);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            await client.SendAsync(request);
            
            HttpRequestOptionsKey<Stopwatch> key = new HttpRequestOptionsKey<Stopwatch>(AppConstants.StopWatch);
            request.Options.TryGetValue(key, out var watcher);
            return watcher.Elapsed;
        }
    }
}