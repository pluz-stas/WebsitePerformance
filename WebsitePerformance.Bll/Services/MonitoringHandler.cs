using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebsitePerformance.Bll.Resources;

namespace WebsitePerformance.Bll.Services
{
    public class MonitoringHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var watcher = new Stopwatch();

            request.Properties.Add(
                new KeyValuePair<string, object>(AppConstants.Monitoring, watcher));

            watcher.Start();
            var response = await base.SendAsync(request, cancellationToken);
            watcher.Stop();

            return response;
        }
    }
}