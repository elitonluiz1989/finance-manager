using FinanceManager.Web.Shared.Components.Notification;
using FinanceManager.Web.Shared.Resources;
using Microsoft.Extensions.Localization;

namespace FinanceManager.Web.Shared.Interceptors;

public class ExceptionInterceptor(NotificationService notificationService, IStringLocalizer<SharedResources> localizer) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (!response.IsSuccessStatusCode)
                notificationService.Add(localizer["ApiDefaultError"]);
            
            return response;
        }
        catch (Exception)
        {
            notificationService.Add(localizer["ApiConnectionError"]);
        
            return new HttpResponseMessage(System.Net.HttpStatusCode.ServiceUnavailable)
            {
                Content = new StringContent(localizer["ServerUnavailable"])
            };
        }
    }
}