using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebsitePerformance.Dal.Entities;

namespace WebsitePerformance.Bll.Interfaces
{
    public interface IWebsiteAnalyzer
    {
        Task AnalyzeAsync(string domain);
        Task<IEnumerable<Uri>> GetSitemapUrlsAsync(string domain);

    }
}