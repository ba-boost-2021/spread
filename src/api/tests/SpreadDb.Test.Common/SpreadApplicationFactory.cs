using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
            serviceProvider = services.BuildServiceProvider();
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<DbContext>();
                dbContext.Database.Migrate();
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