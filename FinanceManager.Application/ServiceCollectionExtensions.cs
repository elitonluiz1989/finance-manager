using FinanceManager.Application.Users.Create;
using FinanceManager.Application.Users.Get;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICreateUserHandler, CreateUserHandler>();
        services.AddScoped<ICreateUserValidator, CreateUserValidator>();
        services.AddScoped<IGetUserHandler, GetUserHandler>();
        
        return services;
    }
}