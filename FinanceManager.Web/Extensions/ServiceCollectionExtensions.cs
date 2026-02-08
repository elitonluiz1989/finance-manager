using FinanceManager.Web.Login;
using FinanceManager.Web.Logout;
using FinanceManager.Web.Services;
using FinanceManager.Web.Shared.Components.Notification;
using FinanceManager.Web.Shared.Interceptors;
using FinanceManager.Web.Shared.Interfaces;
using FinanceManager.Web.Shared.Providers;
using Microsoft.AspNetCore.Components.Authorization;

namespace FinanceManager.Web.Extensions;

public static class ServiceCollectionExtensions
{
    private const string ApiAddressKey = "ApiAddress";
    private const string ApiClientName = "FinanceManager.API";
    
    extension(IServiceCollection services)
    {
        public void AddWebServices()
        {
            services.AddSingleton<NotificationService>();
            services.AddScoped<AuthenticationStateProvider, AppAuthenticationStateProvider>();
            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<LoginService>();
            services.AddScoped<LogoutService>();
            services.AddScoped<ExceptionInterceptor>();
            services.AddScoped<JwtInterceptor>();
        }

        public void AddApiClient(IConfiguration configuration)
        {
            var apiAddress = configuration.GetValue<string>(ApiAddressKey) ?? string.Empty;
            var clientUri = new Uri(apiAddress);
        
            services.AddHttpClient(ApiClientName, client => client.BaseAddress = clientUri)
                .AddHttpMessageHandler<ExceptionInterceptor>()
                .AddHttpMessageHandler<JwtInterceptor>();
        
            services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient(ApiClientName));
        }
    }
}