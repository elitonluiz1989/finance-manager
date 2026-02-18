using System.Net;
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
            
            if (response.IsSuccessStatusCode) return response;

            var errorMessage = response.StatusCode == HttpStatusCode.Unauthorized
                ? localizer["AuthenticationFailed"]
                : localizer["ApiDefaultError"];
                
            notificationService.Add(errorMessage);
            
            return response;
        }
        catch (Exception)
        {
            notificationService.Add(localizer["ApiConnectionError"]);
        
            return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable)
            {
                Content = new StringContent(localizer["ServerUnavailable"])
            };
        }
    }
}