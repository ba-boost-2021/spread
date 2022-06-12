using Spread.Api.Middlewares;

namespace Microsoft.AspNetCore.Builder;

public static class IApplicationBuilderExtensions
{
    public static void UseClaims(this IApplicationBuilder app)
    {
        app.UseMiddleware<ClaimSetupMiddleware>();
    }
}
