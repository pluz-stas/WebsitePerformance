using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebsitePerformance.Bll.Interfaces
{
    public interface ISitemapService
    {
        Task<List<Uri>> GetUrlsAsync(string domain);
    }
}