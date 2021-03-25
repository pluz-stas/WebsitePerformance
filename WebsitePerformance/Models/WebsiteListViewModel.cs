using System;

namespace WebsitePerformance.Mvc.Models
{
    public class WebsiteListViewModel
    {
        public int Id { get; set; }
        public string Domain { get; set; }
        public DateTime AnalysisDate { get; set; }
    }
}