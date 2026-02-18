using System.Globalization;
using FinanceManager.Web.Shared.Constants;
using FinanceManager.Web.Shared.Services;

namespace FinanceManager.Web.Shared.Extensions;

public static class ServiceProviderExtensions
{
    public static async Task LocalizationHandler(this IServiceProvider provider)
    {
        var result = await provider.GetRequiredService<StorageService>().GetAsync<string>(StorageKeyConst.Culture);

        if (string.IsNullOrEmpty(result)) return;
        
        var culture = new CultureInfo(result);

        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
    }
}