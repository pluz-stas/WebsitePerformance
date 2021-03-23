using WebsitePerformance.Dal.Entities;
using WebsitePerformance.Dal.Interfaces;

namespace WebsitePerformance.Dal.Repository
{
    public class WebsiteRepository : AbstractRepository<Website>, IWebsiteRepository
    {
        public WebsiteRepository(WebsitePerformanceDbContext context) : base(context)
        {
        }
    }
}