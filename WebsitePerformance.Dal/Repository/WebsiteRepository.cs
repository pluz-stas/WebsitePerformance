using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebsitePerformance.Dal.Entities;
using WebsitePerformance.Dal.Interfaces;

namespace WebsitePerformance.Dal.Repository
{
    public class WebsiteRepository : AbstractRepository<Website>, IWebsiteRepository
    {
        public WebsiteRepository(WebsitePerformanceDbContext context) : base(context)
        {
        }
        
        public override async Task<IEnumerable<Website>> GetAllAsync(int skip, int top) => 
            await dbContext.Websites.AsNoTracking().OrderByDescending(x => x.AnalysisDate)
                .Skip(skip)
                .Take(top)
                .ToListAsync();

    }
}