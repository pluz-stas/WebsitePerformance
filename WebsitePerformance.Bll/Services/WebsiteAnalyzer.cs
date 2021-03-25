using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Dasync.Collections;
using WebsitePerformance.Bll.Interfaces;
using WebsitePerformance.Bll.Models;

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

        public async Task AnalyzeAsync(WebsiteModel website)
        {
            var urls = await _sitemapService.GetUrlsAsync(website.Domain);

            if (urls.Count > 0)
            {
                var webpages = new ConcurrentBag<WebpageModel>();

                await urls.ParallelForEachAsync(async url =>
                {
                    WebpageModel webpage = new WebpageModel{Path = url.ToString(), Website = website};
                    await _webpageAnalyzer.AnalyzeAsync(webpage);
                    webpages.Add(webpage);
                }, maxDegreeOfParallelism: 10);

                website.Webpages = webpages.ToList();
            }
        }
    }
}