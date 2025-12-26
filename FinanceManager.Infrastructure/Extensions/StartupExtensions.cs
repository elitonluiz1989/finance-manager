using FinanceManager.Domain.Shared.Interfaces;
using FinanceManager.Domain.Users;
using FinanceManager.Infrastructure.Contexts;
using FinanceManager.Infrastructure.Repositories;
using FinanceManager.Infrastructure.Seeds;
using FinanceManager.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.Infrastructure.Extensions;

public static class StartupExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ApplicationConnection");
        
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserRepository, UserRepository>();
    }

    extension(IApplicationBuilder app)
    {
        public void ApplyMigrations()
        {
            using var scope = app.ApplicationServices.CreateScope();
        
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();
        }

        public async Task ApplySeeds(IConfiguration configuration)
        {
            await UserSeed.SeedAsync(app.ApplicationServices, configuration);
        }
    }
}