using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebsitePerformance.Bll.Interfaces;
using WebsitePerformance.Mvc.Extensions;

namespace WebsitePerformance.Mvc.Controllers
{
    public class WebsiteController : Controller
    {
        private readonly IWebsiteService _websiteService;

        public WebsiteController(IWebsiteService websiteService)
        {
            _websiteService = websiteService;
        }

        public async Task<IActionResult> WebsiteList()
        {
            var websites = (await _websiteService.GetAllAsync(0, 20)).Select(x => x.ToViewModel());
            return View(websites);
        }
    }
}