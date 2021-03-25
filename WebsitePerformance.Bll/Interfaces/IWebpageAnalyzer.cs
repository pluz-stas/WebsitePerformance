using System;
using System.Threading.Tasks;
using WebsitePerformance.Dal.Entities;

namespace WebsitePerformance.Bll.Interfaces
{
    public interface IWebpageAnalyzer
    {
        Task AnalyzeAsync(Webpage webpage);
    }
}