using FinanceManager.Web.Shared.Interfaces;
using FinanceManager.Web.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace FinanceManager.Web.Logout;

public sealed class LogoutService(
    AuthenticationStateProvider provider,
    IStorageService storageService,
    NavigationManager navigationManager) : AuthenticationService(provider)
{
    public async Task LogoutAsync(CancellationToken cancellationToken = default)
    {
        await storageService.RemoveAsync(AuthKey, cancellationToken);
        
        AuthenticationStateProvider.NotifyUserLogout();
        
        navigationManager.NavigateTo("/login");
    }
}