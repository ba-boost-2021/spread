using Microsoft.Extensions.DependencyInjection;
using Spread.FileStorage.Abstractions;
using Spread.FileStorage.Concretes;

namespace Microsoft.AspNetCore.Builder;

public static class ServiceCollectionExtensions
{
    public static void AddFileStorage(this IServiceCollection services)
    {
        services.AddScoped<IFileStorageService, MinIOStorageService>();
    }
}