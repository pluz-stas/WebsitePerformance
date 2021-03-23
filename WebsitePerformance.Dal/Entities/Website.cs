using System;
using System.Collections.Generic;
using WebsitePerformance.Dal.Interfaces;

namespace WebsitePerformance.Dal.Entities
{
    public class Website : IDbEntity
    {
        public int Id { get; set; }
        public string Domain { get; set; }
        public DateTime AnalysisDate { get; set; }
        
        public IEnumerable<Webpage> Webpages { get; set; }
    }
}
