using System.Reflection;

namespace FinanceManager.Api.Endpoints;

public static class InfoEndpoints
{
    public static void MapInfoEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("/info", (IHostEnvironment environment) =>
        {
            var assembly = Assembly.GetExecutingAssembly();

            return Results.Ok(new
            {
                Application = environment.ApplicationName,
                Environment = environment.EnvironmentName,
                Version = assembly.GetName().Version?.ToString(),
                ServerTimeUtc = DateTimeOffset.UtcNow,
            });
        });
    }
}