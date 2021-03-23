using System;
using System.Collections.Generic;
using WebsitePerformance.Dal.Interfaces;

namespace WebsitePerformance.Bll.Models
{
    public class WebsiteModel
    {
        public int Id { get; set; }
        public string Domain { get; set; }
        public DateTime AnalysisDate { get; set; }
        
        public IEnumerable<WebpageModel> Webpages { get; set; }
    }
}
