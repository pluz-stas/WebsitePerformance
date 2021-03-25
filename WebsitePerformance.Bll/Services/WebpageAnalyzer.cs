using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using WebsitePerformance.Bll.Interfaces;
using WebsitePerformance.Dal.Entities;

namespace WebsitePerformance.Bll.Services
{
    public class WebpageAnalyzer : IWebpageAnalyzer
    {
        private const int NumberOfRequests = 3;

        private readonly IHttpClientWatcher _httpClientWatcher;

        public WebpageAnalyzer(IHttpClientWatcher httpClientWatcher)
        {
            _httpClientWatcher = httpClientWatcher;
        }
        
        public async Task AnalyzeAsync(Webpage webpage)
        {
            var responseTimeArray = new double[NumberOfRequests];
            
            TimeSpan requestTime;
            
            for (int i = 0; i < NumberOfRequests; i++)
            {
                requestTime = await _httpClientWatcher.GetRequestTimeAsync(webpage.Path);
                responseTimeArray[i] = requestTime.TotalMilliseconds;
            }

            webpage.MinResponseTime = responseTimeArray.Min();
            webpage.MaxResponseTime = responseTimeArray.Max();
        }
    }
}