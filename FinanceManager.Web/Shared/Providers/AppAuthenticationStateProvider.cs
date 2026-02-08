using System.Security.Claims;
using System.Text.Json;
using FinanceManager.Web.Shared.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;

namespace FinanceManager.Web.Shared.Providers;

public sealed class AppAuthenticationStateProvider(IStorageService storageService) : AuthenticationStateProvider
{
    private readonly ClaimsPrincipal _anonymousUser = new(new ClaimsIdentity());
    
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var token = await storageService.GetAsync<string>("accessToken");

            if (string.IsNullOrWhiteSpace(token)) return new AuthenticationState(_anonymousUser);

            var claims = ParseClaimsFromJwt(token);

            var expiry = claims.FirstOrDefault(c => c.Type == ClaimTypes.Expiration)?.Value;

            if (!string.IsNullOrWhiteSpace(expiry))
            {
                var datetime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(expiry));

                if (datetime.DateTime > DateTime.UtcNow)
                {
                    await storageService.RemoveAsync("accessToken");
                    
                    return new AuthenticationState(_anonymousUser);
                }
            }

            var identity = new ClaimsIdentity(claims, "jwt");

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
        var identity = new ClaimsIdentity(claims, "jwt");
        var user =  new ClaimsPrincipal(identity);
            
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }
    
    public void NotifyUserLogout()
    {
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymousUser)));
    }

    private static Claim[] ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.').Last();
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValues = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

        return keyValues is null
            ? []
            : keyValues.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString() ?? string.Empty)).ToArray();
    }
    
    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        
        return Convert.FromBase64String(base64);
    }
}