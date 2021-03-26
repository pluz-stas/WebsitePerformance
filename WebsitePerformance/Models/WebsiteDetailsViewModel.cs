using System;
using System.Collections.Generic;
using WebsitePerformance.Bll.Models;

namespace WebsitePerformance.Mvc.Models
{
    public class WebsiteDetailsViewModel
    {
        public int Id { get; set; }
        public string Domain { get; set; }
        public DateTime AnalysisDate { get; set; }
        public SlowPagesRatio SlowPagesRatio { get; set; }
        
        public IEnumerable<WebpageViewModel> Webpages { get; set; }
    }
}