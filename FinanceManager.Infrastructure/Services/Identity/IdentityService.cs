using System.Security.Claims;
using FinanceManager.Application.Auth;
using FinanceManager.Domain.Shared.Results;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace FinanceManager.Infrastructure.Services.Identity;

public sealed class IdentityService(
    IOptionsMonitor<BearerTokenOptions> options,
    UserManager<IdentityUser> userManager,
    SignInManager<IdentityUser> signInManager,
    IdentityLocalizer localization) : IIdentityService
{
    public async Task<Result<ClaimsPrincipal>> RefreshTokenAsync(string refreshToken)
    {
        var bearerOptions = options.Get(IdentityConstants.BearerScheme);
        var ticket = bearerOptions.RefreshTokenProtector.Unprotect(refreshToken);

        if (ticket?.Properties.ExpiresUtc == null || ticket.Properties.ExpiresUtc < DateTimeOffset.UtcNow)
            return localization.RefreshInvalidToken;

        var userId = ticket.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
        
        if (string.IsNullOrEmpty(userId)) return localization.RefreshUserNotFound;
        
        var user = await userManager.FindByIdAsync(userId);

        if (user == null) return localization.RefreshUserNotFound;

        var principal = await signInManager.CreateUserPrincipalAsync(user);

        return principal;
    }
}