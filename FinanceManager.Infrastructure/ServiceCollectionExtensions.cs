using FinanceManager.Domain.Shared.Interfaces;
using FinanceManager.Domain.Users;
using FinanceManager.Infrastructure.Contexts;
using FinanceManager.Infrastructure.Repositories;
using FinanceManager.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ApplicationConnection");
        
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }
}