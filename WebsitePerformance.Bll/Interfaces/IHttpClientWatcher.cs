using System;
using System.Threading.Tasks;

namespace WebsitePerformance.Bll.Interfaces
{
    public interface IHttpClientWatcher
    {
        Task<TimeSpan> GetRequestTimeAsync(string uri);
    }
}