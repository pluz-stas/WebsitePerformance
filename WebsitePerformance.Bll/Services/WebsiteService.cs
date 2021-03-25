using AutoMapper;
using WebsitePerformance.Bll.Interfaces;
using WebsitePerformance.Bll.Models;
using WebsitePerformance.Dal.Entities;
using WebsitePerformance.Dal.Interfaces;

namespace WebsitePerformance.Bll.Services
{
    public class WebsiteService : AbstractService<WebsiteModel, Website>, IWebsiteService
    {
        public WebsiteService(IWebsiteRepository repository, IMapper mapper) : base(repository, mapper) { }
    }
}
