using System.Collections.Generic;
using System.Threading.Tasks;
using WebsitePerformance.Bll.Models;
using WebsitePerformance.Dal.Entities;

namespace WebsitePerformance.Bll.Interfaces
{
    public interface IWebpageService : IService<WebpageModel, Webpage>
    {
        Task<IEnumerable<WebpageModel>> GetByWebsiteAsync(int websiteId, int skip, int top);
    }
}
