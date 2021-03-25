using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebsitePerformance.Bll.Resources;

namespace WebsitePerformance.Bll.Handlers
{
    public class RequestTimeHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var watcher = new Stopwatch();
            HttpRequestOptionsKey<Stopwatch> key = new HttpRequestOptionsKey<Stopwatch>(AppConstants.StopWatch);
            request.Options.Set(key, watcher);

            watcher.Start();
            var response = await base.SendAsync(request, cancellationToken);
            watcher.Stop();

            return response;
        }
    }
}