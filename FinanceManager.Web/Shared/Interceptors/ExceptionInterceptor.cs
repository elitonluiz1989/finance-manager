using FinanceManager.Web.Shared.Components.Notification;

namespace FinanceManager.Web.Shared.Interceptors;

public class ExceptionInterceptor(NotificationService notificationService) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (!response.IsSuccessStatusCode)
                notificationService.Add("Erro na API");
            
            return response;
        }
        catch (Exception)
        {
            notificationService.Add("Não foi possível conectar ao servidor. Verifique sua internet.");
        
            return new HttpResponseMessage(System.Net.HttpStatusCode.ServiceUnavailable)
            {
                Content = new StringContent("Servidor Indisponível")
            };
        }
    }
}