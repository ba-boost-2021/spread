using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Spread.Data.Context;

public class DesignTimeContext : IDesignTimeDbContextFactory<SpreadDbContext>
{
    public SpreadDbContext CreateDbContext(string[] args)
    {
        var connectionString = new ConfigurationBuilder()
                        .SetBasePath(System.IO.Path.Combine(Directory.GetCurrentDirectory()))
                        .AddJsonFile("appsettings.json", false, true).Build()
                        .GetValue<string>("MigrationConnectionString");


        var optionsBuilder = new DbContextOptionsBuilder<SpreadDbContext>();
        optionsBuilder.UseSqlServer(connectionString);
        return new SpreadDbContext(optionsBuilder.Options);
    }
}