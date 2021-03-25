using System;
using System.Threading.Tasks;

namespace WebsitePerformance.Bll.Interfaces
{
    public interface IRequestTimeService
    {
        Task<TimeSpan> GetResponseTimeAsync(string uri);
    }
}