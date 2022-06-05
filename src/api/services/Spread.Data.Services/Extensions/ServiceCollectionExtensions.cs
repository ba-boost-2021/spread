using Spread.Data.Services.Concretes;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        //services.AddMediatR();
        return services;
    }
}
