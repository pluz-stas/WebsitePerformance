using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebsitePerformance.Bll.Interfaces;
using WebsitePerformance.Dal.Entities;
using WebsitePerformance.Mvc.Models;

namespace WebsitePerformance.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebsiteAnalyzer _websiteAnalyzer;

        public HomeController(ILogger<HomeController> logger, IWebsiteAnalyzer websiteAnalyzer)
        {
            _logger = logger;
            _websiteAnalyzer = websiteAnalyzer;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateWebsiteViewModel websiteViewModel)
        {
            if (ModelState.IsValid)
            {
                Website website = new Website {Domain = websiteViewModel.Domain};
                await _websiteAnalyzer.AnalyzeAsync(website);
                if(website.Webpages == null)
                    ModelState.AddModelError("Domain", "Sitemap not found!");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
