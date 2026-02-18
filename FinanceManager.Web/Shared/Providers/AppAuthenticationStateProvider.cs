using System.Security.Claims;
using System.Text.Json;
using FinanceManager.Application.Auth;
using FinanceManager.Web.Shared.Constants;
using FinanceManager.Web.Shared.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace FinanceManager.Web.Shared.Providers;

public sealed class AppAuthenticationStateProvider(StorageService storageService) : AuthenticationStateProvider
{
    private readonly ClaimsPrincipal _anonymousUser = new(new ClaimsIdentity());
    
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var auth = await storageService.GetAsync<LoginResponse>(StorageKeyConst.Auth);

            if (auth is null || string.IsNullOrWhiteSpace(auth.AccessToken)) return new AuthenticationState(_anonymousUser);

            var claims = ParseClaimsFromJwt(auth.AccessToken);

            var expiration = claims.FirstOrDefault(c => c.Type == ClaimTypes.Expiration)?.Value;

            if (!string.IsNullOrWhiteSpace(expiration))
            {
                var datetime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(expiration));

                if (datetime.UtcDateTime < DateTime.UtcNow)
                {
                    await storageService.RemoveAsync(StorageKeyConst.Auth);
                    
                    return new AuthenticationState(_anonymousUser);
                }
            }

            var identity = new ClaimsIdentity(claims, DefaultConst.AuthenticationTypeJwt);

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }
        catch
        {
            return new AuthenticationState(_anonymousUser);
        }
    }

    public void NotifyUserLogin(string token)
    {
        var claims = ParseClaimsFromJwt(token);
        var identity = new ClaimsIdentity(claims, DefaultConst.AuthenticationTypeJwt);
        var user =  new ClaimsPrincipal(identity);
            
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }
    
    public void NotifyUserLogout()
    {
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymousUser)));
    }

    private static Claim[] ParseClaimsFromJwt(string jwt)
    {
        var parts = jwt.Split('.');

        if (parts.Length < 2) return [];
        
        var payload = parts[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValues = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

        return keyValues is null
            ? []
            : keyValues.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString() ?? string.Empty)).ToArray();
    }
    
    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        base64 = ConvertBase64UrlToBase64Default(base64);

        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
    
        return Convert.FromBase64String(base64);
    }

    private static string ConvertBase64UrlToBase64Default(string base64) => base64.Replace('-', '+').Replace('_', '/');
}