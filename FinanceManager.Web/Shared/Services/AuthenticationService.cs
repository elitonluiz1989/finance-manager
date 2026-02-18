using FinanceManager.Web.Shared.Providers;
using Microsoft.AspNetCore.Components.Authorization;

namespace FinanceManager.Web.Shared.Services;

public abstract class AuthenticationService(AuthenticationStateProvider provider)
{
    protected AppAuthenticationStateProvider AuthenticationStateProvider => (AppAuthenticationStateProvider)provider;
}