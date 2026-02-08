using System.Net.Http.Headers;
using FinanceManager.Web.Shared.Interfaces;

namespace FinanceManager.Web.Shared.Interceptors;

public sealed class JwtInterceptor(IStorageService storageService): DelegatingHandler
{
    private const string AccessTokenKey = "accessToken";
    private const string BearerScheme = "Bearer";
    
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            var accessToken = await storageService.GetAsync<string>(AccessTokenKey, cancellationToken);

            if (!string.IsNullOrWhiteSpace(accessToken))
                request.Headers.Authorization = new AuthenticationHeaderValue(BearerScheme, accessToken);

            return await base.SendAsync(request, cancellationToken);
        }
        catch
        {
            // Ignored
        }
        
        return await base.SendAsync(request, cancellationToken);
    }
}