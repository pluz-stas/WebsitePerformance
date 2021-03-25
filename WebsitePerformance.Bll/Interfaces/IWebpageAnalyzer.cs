using System;
using System.Threading.Tasks;
using WebsitePerformance.Bll.Models;

namespace WebsitePerformance.Bll.Interfaces
{
    public interface IWebpageAnalyzer
    {
        Task AnalyzeAsync(WebpageModel webpage);
    }
}