using System.Collections.Generic;
using System.Threading.Tasks;
using WebsitePerformance.Dal.Entities;
using WebsitePerformance.Dal.Interfaces;

namespace WebsitePerformance.Dal.Repository
{
    public class WebpageRepository : AbstractRepository<Webpage>, IWebpageRepository
    {
        public WebpageRepository(WebsitePerformanceDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<Webpage>> GetByWebsiteAsync(int WebsiteId, int skip, int top)
        {
            throw new System.NotImplementedException();
        }
    }
}