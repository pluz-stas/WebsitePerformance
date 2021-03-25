using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebsitePerformance.Bll.Models;

namespace WebsitePerformance.Bll.Interfaces
{
    public interface IWebsiteAnalyzer
    {
        Task AnalyzeAsync(WebsiteModel website);
    }
}