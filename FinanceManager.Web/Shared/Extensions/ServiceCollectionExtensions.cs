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
            services.AddScoped<AuthenticationStateProvider, AppAuthenticationStateProvider>();
            services.AddScoped<StorageService>();
            services.AddScoped<LoginService>();
            services.AddScoped<LogoutService>();
            services.AddScoped<ExceptionInterceptor>();
            services.AddScoped<JwtInterceptor>();
        }

        public void AddApiClient(IConfiguration configuration)
        {
            var apiSettings = configuration.GetSection(SettingsConst.Api);
            var apiClientName = apiSettings.GetValue<string>(SettingsConst.ApiClientName) ?? string.Empty;
            var apiAddress = apiSettings.GetValue<string>(SettingsConst.ApiAddress) ?? string.Empty;
            var clientUri = new Uri(apiAddress);

            services.AddHttpClient(apiClientName, client => client.BaseAddress = clientUri)
                .AddHttpMessageHandler<ExceptionInterceptor>()
                .AddHttpMessageHandler<JwtInterceptor>();
        
            services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient(apiClientName));
        }
    }
}