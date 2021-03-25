using System;
using WebsitePerformance.Bll.Models;
using WebsitePerformance.Mvc.Models;

namespace WebsitePerformance.Mvc.Extensions
{
    public static class WebsiteExtensions
    {
        public static WebsiteListViewModel ToViewModel(this WebsiteModel model)
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
    }
}