using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebsitePerformance.Bll.Handlers;
using WebsitePerformance.Bll.Interfaces;
using WebsitePerformance.Bll.Mapper;
using WebsitePerformance.Bll.Resources;
using WebsitePerformance.Bll.Services;
using WebsitePerformance.Dal;
using WebsitePerformance.Dal.Interfaces;
using WebsitePerformance.Dal.Repository;

namespace WebsitePerformance.Mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<WebsitePerformanceDbContext>(o => o.UseSqlServer(connectionString));
            services.AddAutoMapper(config => config.AddProfile(new MappingProfile()), typeof(Startup));
            
            services.AddScoped<IWebsiteRepository, WebsiteRepository>();
            services.AddScoped<IWebpageRepository, WebpageRepository>();
            
            services.AddScoped<IWebsiteService, WebsiteService>();
            services.AddScoped<IWebpageService, WebpageService>();

            services.AddScoped<ISitemapService, SitemapService>();
            services.AddScoped<RequestTimeHandler>();
            services.AddHttpClient(
                    AppConstants.Measuring, 
                    options => options.DefaultRequestHeaders.ConnectionClose = true)
                .AddHttpMessageHandler<RequestTimeHandler>();
            services.AddScoped<IRequestTimeService, RequestTimeService>();
            services.AddScoped<IWebpageAnalyzer, WebpageAnalyzer>();
            services.AddScoped<IWebsiteAnalyzer, WebsiteAnalyzer>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
