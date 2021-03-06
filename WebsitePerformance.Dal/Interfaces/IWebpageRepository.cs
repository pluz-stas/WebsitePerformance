using System.Collections.Generic;
using System.Threading.Tasks;
using WebsitePerformance.Dal.Entities;

namespace WebsitePerformance.Dal.Interfaces
{
    public interface IWebpageRepository : IRepository<Webpage>
    {
        Task<IEnumerable<Webpage>> GetByWebsiteAsync(int websiteId, int skip, int top);
    }
}
