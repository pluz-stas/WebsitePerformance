using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebsitePerformance.Dal.Entities;
using WebsitePerformance.Dal.Interfaces;

namespace WebsitePerformance.Dal.Repository
{
    public class WebpageRepository : AbstractRepository<Webpage>, IWebpageRepository
    {
        public WebpageRepository(WebsitePerformanceDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Webpage>> GetByWebsiteAsync(int websiteId, int skip, int top) =>
            await dbContext.Webpages.AsNoTracking()
                .Where(x => x.WebsiteId == websiteId).OrderByDescending(x => x.MaxResponseTime)
                .Skip(skip).Take(top).ToListAsync();
    }
}