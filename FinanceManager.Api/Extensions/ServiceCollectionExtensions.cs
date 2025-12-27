using FinanceManager.Api.JsonContexts;
using FinanceManager.Api.Services;
using FinanceManager.Infrastructure.Contexts;
using FinanceManager.Infrastructure.Converters;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;

namespace FinanceManager.Api.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public void AddApiServices()
        {
            services.AddScoped<IUserClaimsPrincipalFactory<IdentityUser>, CustomClaimsPrincipalFactory>();
        }

        public void AddApiLocation()
        {
            services.AddLocalization();

            var supportedCultures = new[] { "pt-BR", "en-US" };
        
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.SetDefaultCulture(supportedCultures[0])
                    .AddSupportedCultures(supportedCultures)
                    .AddSupportedUICultures(supportedCultures);
            });
        }

        public void AddApiAuthentication(IHostEnvironment environment)
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
            services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(environment.ContentRootPath, "keys")))
                .SetApplicationName("FinanceManager");
            services.AddOpenApi();
        }

        public void AddApiJsonConverters()
        {
            services.ConfigureHttpJsonOptions(options =>
            {
                options.SerializerOptions.Converters.Add(new UserIdJsonConverter());
            });
        }
    }
}