using WebsitePerformance.Dal.Interfaces;

namespace WebsitePerformance.Dal.Entities
{
    public class Webpage : IDbEntity
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public double MaxResponseTime { get; set; }
        public double MinResponseTime { get; set; }
        
        public int WebsiteId { get; set; }
        public Website Website { get; set; }
    }
}
