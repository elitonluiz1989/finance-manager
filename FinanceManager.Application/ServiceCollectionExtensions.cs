using FinanceManager.Application.Users.Create;
using FinanceManager.Application.Users.Get;
using FinanceManager.Application.Users.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.Application;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICreateUserHandler, CreateUserHandler>();
        services.AddScoped<UserLocationService>();
        services.AddScoped<ICreateUserValidator, CreateUserValidator>();
        services.AddScoped<IGetUserHandler, GetUserHandler>();
    }
}