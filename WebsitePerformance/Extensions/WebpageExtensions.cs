using System;
using WebsitePerformance.Bll.Models;
using WebsitePerformance.Mvc.Models;

namespace WebsitePerformance.Mvc.Extensions
{
    public static class WebpageExtensions
    {
        public static WebpageViewModel ToViewModel(this WebpageModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(WebpageViewModel));

            return new WebpageViewModel
            {
                Id = model.Id,
                Path = model.Path,
                MaxResponseTime = model.MaxResponseTime,
                MinResponseTime = model.MinResponseTime,
            };
        }
    }
}