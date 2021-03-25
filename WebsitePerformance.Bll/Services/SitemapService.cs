using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TurnerSoftware.SitemapTools;
using WebsitePerformance.Bll.Interfaces;

namespace WebsitePerformance.Bll.Services
{
    public class SitemapService : ISitemapService
    {
        private readonly ILogger<SitemapService> _logger;

        public SitemapService(ILogger<SitemapService> logger)
        {
            _logger = logger;
        }
        
        public async Task<List<Uri>> GetUrlsAsync(string domain)
        {
            var urls = new List<Uri>();
            var sitemapQuery = new SitemapQuery();
            
            IEnumerable<SitemapFile> sitemaps = null;
            
            try
            {
                sitemaps = await sitemapQuery
                    .GetAllSitemapsForDomainAsync(domain);
            }
            catch (NullReferenceException ex)
            {
                _logger.LogError(ex.Message);
            }
            catch (InvalidOperationException)
            {
                _logger.LogInformation($"Invalid sitemap");
            }
            catch (HttpRequestException)
            {
                _logger.LogInformation($"Invalid host");
            }
            finally
            {
                if (sitemaps == null)
                {
                    sitemaps = new List<SitemapFile>();
                }
            }

            urls.AddRange(
                sitemaps.SelectMany(
                        s => s.Urls.Select(u => u.Location))
                    .Distinct());

            return urls;
        }

    }
}