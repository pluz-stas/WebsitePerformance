using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsitePerformance.Dal.Interfaces;

namespace WebsitePerformance.Bll.Models
{
    public class WebpageModel
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public double MaxResponseTime { get; set; }
        public double MinResponseTime { get; set; }
        
        public int WebsiteId { get; set; }
        public WebsiteModel Website { get; set; }
    }
}
