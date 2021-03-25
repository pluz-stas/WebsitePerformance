using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebsitePerformance.Bll.Interfaces;
using WebsitePerformance.Dal.Entities;

namespace WebsitePerformance.Bll.Services
{
    public class WebsiteAnalyzer:IWebsiteAnalyzer
    {
        private readonly IWebpageAnalyzer _webpageAnalyzer;

        public WebsiteAnalyzer(IWebpageAnalyzer webpageAnalyzer)
        {
            _webpageAnalyzer = webpageAnalyzer;
        }
        
        public async Task AnalyzeAsync(string domain)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Uri>> GetSitemapUrlsAsync(string domain)
        {
            throw new NotImplementedException();
        }
    }
}