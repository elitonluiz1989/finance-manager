using FinanceManager.Application.Accounts.Create;
using FinanceManager.Application.Shared.Services;
using FinanceManager.Application.Users.Create;
using FinanceManager.Application.Users.Get;
using FinanceManager.Application.Users.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.Application;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<SharedLocalizer>();
        AddAccounts(services);
        AddUsers(services);
    }

    private static void AddAccounts(IServiceCollection services)
    {
        services.AddScoped<ICreateAccountHandler, CreateAccountHandler>();
        services.AddScoped<ICreateAccountValidator, CreateAccountValidator>();
    }

    private static void AddUsers(IServiceCollection services)
    {
        services.AddScoped<UserLocalizer>();
        services.AddScoped<ICreateUserHandler, CreateUserHandler>();
        services.AddScoped<ICreateUserValidator, CreateUserValidator>();
        services.AddScoped<IGetUserHandler, GetUserHandler>();
    }
}