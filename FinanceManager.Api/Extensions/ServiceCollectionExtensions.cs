using System.Globalization;
using FinanceManager.Api.JsonContexts;
using FinanceManager.Api.Services;
using FinanceManager.Infrastructure.Contexts;
using FinanceManager.Infrastructure.Converters.Accounts;
using FinanceManager.Infrastructure.Converters.Users;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;

namespace FinanceManager.Api.Extensions;

public static class ServiceCollectionExtensions
{
    private const string SupportedCulturesKey = "supportedCultures";
    private const string PersistKeyFolderKey = "PersistKeyFolder";
    private const string ApplicationNameKey = "ApplicationName";
    private const string CorsOriginsKey = "CorsOrigins";
    
    extension(IServiceCollection services)
    {
        public void AddApiServices()
        {
            services.AddScoped<IUserClaimsPrincipalFactory<IdentityUser>, CustomClaimsPrincipalFactory>();
        }

        public void AddApiLocation(IConfiguration configuration)
        {
            services.AddLocalization();

            var supportedCultures = configuration.GetSection(SupportedCulturesKey).Get<string[]>();

            if (supportedCultures is null || supportedCultures.Length == 0)
                supportedCultures = [CultureInfo.CurrentCulture.Name];
        
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.SetDefaultCulture(supportedCultures[0])
                    .AddSupportedCultures(supportedCultures)
                    .AddSupportedUICultures(supportedCultures);
            });
        }

        public void AddApiAuthentication(IConfiguration configuration, IHostEnvironment environment)
        {
            services.ConfigureHttpJsonOptions(options =>  
                options.SerializerOptions.TypeInfoResolverChain.Insert(0, UsersJsonContext.Default)
            );
            services.AddAuthentication(IdentityConstants.BearerScheme)
                .AddBearerToken(IdentityConstants.BearerScheme);
            services.AddAuthorizationBuilder();
            services.AddIdentityCore<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddSignInManager();

            var persistKeyFolder = configuration.GetValue<string>(PersistKeyFolderKey) ?? string.Empty;
            var appName = configuration.GetValue<string>(ApplicationNameKey) ?? string.Empty;
            
            services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(environment.ContentRootPath, persistKeyFolder)))
                .SetApplicationName(appName);
            services.AddOpenApi();
        }

        public void AddApiJsonConverters()
        {
            services.ConfigureHttpJsonOptions(options =>
            {
                options.SerializerOptions.Converters.Add(new UserIdJsonConverter());
                options.SerializerOptions.Converters.Add(new AccountIdJsonConverter());
            });
        }

        public void AddApiCors(IConfiguration configuration)
        {
            var origins = configuration.GetSection(CorsOriginsKey).Get<string[]>();
            
            if (origins is null || origins.Length == 0) return;
            
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(origins)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }
    }
}