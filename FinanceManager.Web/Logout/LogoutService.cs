using FinanceManager.Web.Shared.Constants;
using FinanceManager.Web.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace FinanceManager.Web.Logout;

public sealed class LogoutService(
    AuthenticationStateProvider provider,
    StorageService storageService,
    NavigationManager navigationManager) : AuthenticationService(provider)
{
    public async Task LogoutAsync(CancellationToken cancellationToken = default)
    {
        await storageService.RemoveAsync(StorageKeyConst.Auth, cancellationToken);
        
        AuthenticationStateProvider.NotifyUserLogout();
        
        navigationManager.NavigateTo("/login");
    }
}