using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dasync.Collections;
using WebsitePerformance.Bll.Interfaces;
using WebsitePerformance.Dal.Entities;

namespace WebsitePerformance.Bll.Services
{
    public class WebsiteAnalyzer : IWebsiteAnalyzer
    {
        private readonly IWebpageAnalyzer _webpageAnalyzer;
        private readonly ISitemapService _sitemapService;

        public WebsiteAnalyzer(IWebpageAnalyzer webpageAnalyzer, ISitemapService sitemapService)
        {
            _webpageAnalyzer = webpageAnalyzer;
            _sitemapService = sitemapService;
        }

        public async Task AnalyzeAsync(Website website)
        {
            var urls = await _sitemapService.GetUrlsAsync(website.Domain);

            if (urls.Count > 0)
            {
                var webpages = new ConcurrentBag<Webpage>();

                await urls.ParallelForEachAsync(async url =>
                {
                    Webpage webpage = new Webpage{Path = url.ToString(), Website = website};
                    await _webpageAnalyzer.AnalyzeAsync(webpage);
                    webpages.Add(webpage);
                }, maxDegreeOfParallelism: 10);

                website.Webpages = webpages.ToList();
            }
        }
    }
}