using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
namespace DataLayer.DbContexts
{
    public class SuperMarketDbContextFactory : IDesignTimeDbContextFactory<SuperMarketDbContext>
    {
        public SuperMarketDbContext CreateDbContext(string[] args)
        {
            // Assumes your appsettings.json is in SuperMarket/
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../SuperMarket"))
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<SuperMarketDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new SuperMarketDbContext(optionsBuilder.Options);
        }
    }
}
