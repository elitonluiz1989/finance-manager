using Microsoft.Extensions.Configuration;

namespace FinanceManager.Infrastructure.Seeds;

public static class Seeds
{
    public static async Task SeedAsync(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        await UserSeed.SeedAsync(serviceProvider, configuration);
    }
}