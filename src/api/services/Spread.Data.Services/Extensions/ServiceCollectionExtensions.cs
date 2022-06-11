﻿using Spread.Data.Services.Concretes;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        var queriesAssembly = AppDomain.CurrentDomain.Load("Spread.Data.Management.Queries");
        var commandsAssembly = AppDomain.CurrentDomain.Load("Spread.Data.Management.Commands");
        services.AddMediatR(queriesAssembly, commandsAssembly);
        return services;
    }
}
