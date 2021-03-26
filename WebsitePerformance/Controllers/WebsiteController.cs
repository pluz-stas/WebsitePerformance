using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebsitePerformance.Bll.Interfaces;
using WebsitePerformance.Mvc.Extensions;
using WebsitePerformance.Mvc.Models;

namespace WebsitePerformance.Mvc.Controllers
{
    public class WebsiteController : Controller
    {
        private const double DefaultSlowLimit = 200;

        private readonly IWebsiteService _websiteService;

        public WebsiteController(IWebsiteService websiteService)
        {
            _websiteService = websiteService;
        }

        public async Task<IActionResult> Index()
        {
            var websites = (await _websiteService.GetAllAsync()).Select(x => x.ToListViewModel());
            return View(websites);
        }

        public async Task<IActionResult> Details(int websiteId, double? slowLimit)
        {
            var website = (await _websiteService.GetByIdAsync(websiteId)).ToDetailsViewModel();
            slowLimit ??= DefaultSlowLimit;
            website.SlowPagesRatio = new SlowPagesRatio
            {
                SlowPagesCount =
                    website.Webpages.Count(x => (x.MaxResponseTime + x.MinResponseTime) / 2 < slowLimit)
            };
            website.SlowPagesRatio.FastPagesCount = website.Webpages.Count() - website.SlowPagesRatio.SlowPagesCount;
            return View(website);
        }
    }
}