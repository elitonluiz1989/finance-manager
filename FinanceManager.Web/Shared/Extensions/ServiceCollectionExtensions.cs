using System.Text.Json;
using FinanceManager.Application.Accounts.Shared;
using FinanceManager.Application.Users.Shared;
using FinanceManager.Web.Home.Accounts;
using FinanceManager.Web.Login;
using FinanceManager.Web.Logout;
using FinanceManager.Web.Shared.Components.Notification;
using FinanceManager.Web.Shared.Constants;
using FinanceManager.Web.Shared.Interceptors;
using FinanceManager.Web.Shared.Providers;
using FinanceManager.Web.Shared.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace FinanceManager.Web.Shared.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public void AddWebServices()
        {
            services.AddSingleton<NotificationService>();
            services.AddScoped<StorageService>();
            services.AddScoped<LoginService>();
            services.AddScoped<LogoutService>();
            services.AddScoped<ExceptionInterceptor>();
            services.AddScoped<JwtInterceptor>();
            services.AddScoped<AppAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider>(provider => provider.GetService<AppAuthenticationStateProvider>()!);
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IAccountsService, AccountsService>();
        }

        public void AddApiClient(IConfiguration configuration)
        {
            var apiSettings = configuration.GetSection(SettingsConst.Api);
            var apiClientName = apiSettings.GetValue<string>(SettingsConst.ApiClientName) ?? string.Empty;
            var apiAddress = apiSettings.GetValue<string>(SettingsConst.ApiAddress) ?? string.Empty;
            
            Console.WriteLine(apiAddress);

            services.AddHttpClient<ApiClient>(apiClientName, client => client.BaseAddress = new Uri(apiAddress))
                .AddHttpMessageHandler<ExceptionInterceptor>()
                .AddHttpMessageHandler<JwtInterceptor>();
        }
    }
}