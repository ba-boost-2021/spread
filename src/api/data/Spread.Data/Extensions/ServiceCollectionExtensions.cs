using Microsoft.Extensions.Configuration;
using Spread.Common;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection($"{nameof(Settings)}:Database");
        var settings = section.Get<Settings.DatabaseConfiguration>();
        services.AddDbContext<SpreadDbContext>(builder =>
        {
            builder.UseSqlServer(settings.ConnectionString);
        });
        return services;
    }
}