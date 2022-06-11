using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Spread.Data.Seed;

namespace Spread.Test.Common;

public class SpreadApplicationFactory : WebApplicationFactory<Program>
{
    private IServiceProvider serviceProvider;

    public SpreadApplicationFactory()
    {
        Client = base.CreateClient();
    }

    public HttpClient Client { get; set; }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test");
        builder.ConfigureServices(services =>
        {
            var baseSeeder = typeof(ITestSeeder);
            var seeders = AppDomain.CurrentDomain.GetAssemblies()
                                                 .SelectMany(x => x.GetTypes())
                                                 .Where(t => baseSeeder.IsAssignableFrom(t) && t.IsClass);

            serviceProvider = services.BuildServiceProvider();
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<DbContext>();
                dbContext.Database.Migrate();

                foreach (var seeder in seeders)
                {
                    var testSeeder = (ITestSeeder)Activator.CreateInstance(seeder);
                    testSeeder.Seed(dbContext);
                }
                dbContext.SaveChanges();
            }
        });
    }

    internal void Clean()
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetService<DbContext>();
            dbContext.Database.EnsureDeleted();
        }
    }

    protected override TestServer CreateServer(IWebHostBuilder builder)
    {
        return base.CreateServer(builder);
    }
}