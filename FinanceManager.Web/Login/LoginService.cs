using System.Net.Http.Json;
using FinanceManager.Application.Auth;
using FinanceManager.Web.Shared.Interfaces;
using FinanceManager.Web.Shared.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace FinanceManager.Web.Login;

public sealed class LoginService(
    HttpClient httpClient,
    IStorageService storageService,
    AuthenticationStateProvider provider) : AuthenticationService(provider)
{
    private const string AuthEndpoint = "auth/login";
    
    public async Task<bool> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync(AuthEndpoint, request, cancellationToken);

        if (!response.IsSuccessStatusCode) return false;
        
        var result = await response.Content.ReadFromJsonAsync<LoginResponse>(cancellationToken);

        if (result is null) return false;

        await storageService.SetAsync(AuthKey, result, cancellationToken);
        
        AuthenticationStateProvider.NotifyUserLogin(result.AccessToken);
        
        return true;
    }
}