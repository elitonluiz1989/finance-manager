using System.Net.Http.Headers;
using FinanceManager.Application.Auth;
using FinanceManager.Web.Shared.Constants;
using FinanceManager.Web.Shared.Services;

namespace FinanceManager.Web.Shared.Interceptors;

public sealed class JwtInterceptor(StorageService storageService): DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            var auth = await storageService.GetAsync<LoginResponse>(StorageKeyConst.Auth, cancellationToken);

            if (auth is not null && !string.IsNullOrWhiteSpace(auth.AccessToken))
                request.Headers.Authorization = new AuthenticationHeaderValue(DefaultConst.BearerScheme, auth.AccessToken);

            return await base.SendAsync(request, cancellationToken);
        }
        catch
        {
            // Ignored
        }
        
        return await base.SendAsync(request, cancellationToken);
    }
}