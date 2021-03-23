using Microsoft.EntityFrameworkCore;
using WebsitePerformance.Dal.Entities;

namespace WebsitePerformance.Dal
{
    public class WebsitePerformanceDbContext : DbContext
    {
        public DbSet<Webpage> Webpages { get; set; }
        public DbSet<Website> Websites { get; set; }
        
        public WebsitePerformanceDbContext(DbContextOptions<WebsitePerformanceDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Website>(entity =>
            {
                entity.Property(e => e.Domain)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.AnalysisDate)
                    .IsRequired();
            });

            modelBuilder.Entity<Webpage>(entity =>
            {
                entity.Property(e => e.Path)
                    .IsRequired();
                entity.Property(e => e.MaxResponseTime)
                    .IsRequired();
                entity.Property(e => e.MinResponseTime)
                    .IsRequired();
                entity.Property(e => e.WebsiteId)
                    .IsRequired();
            });
        }
    }
}
