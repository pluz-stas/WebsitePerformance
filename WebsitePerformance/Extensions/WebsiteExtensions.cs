using System;
using System.Collections.Generic;
using System.Linq;
using WebsitePerformance.Bll.Interfaces;
using WebsitePerformance.Bll.Models;
using WebsitePerformance.Mvc.Models;

namespace WebsitePerformance.Mvc.Extensions
{
    public static class WebsiteExtensions
    {
        public static WebsiteListViewModel ToListViewModel(this WebsiteModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(WebsiteModel));

            return new WebsiteListViewModel
            {
                Id = model.Id,
                Domain = model.Domain,
                AnalysisDate = model.AnalysisDate
            };
        }
        public static WebsiteDetailsViewModel ToDetailsViewModel(this WebsiteModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(WebsiteModel));

            return new WebsiteDetailsViewModel
            {
                Id = model.Id,
                Domain = model.Domain,
                AnalysisDate = model.AnalysisDate,
                Webpages = model.Webpages?.Select(x => x.ToViewModel()) ?? new List<WebpageViewModel>()
            };
        }
    }
}