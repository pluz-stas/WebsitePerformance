namespace WebsitePerformance.Mvc.Models
{
    public class WebpageViewModel
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public double MaxResponseTime { get; set; }
        public double MinResponseTime { get; set; }
    }
}