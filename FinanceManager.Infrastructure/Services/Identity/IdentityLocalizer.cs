using FinanceManager.Application.Shared.Services;
using FinanceManager.Domain.Shared.Errors;
using FinanceManager.Infrastructure.Constants;
using FinanceManager.Infrastructure.Resources;
using Microsoft.Extensions.Localization;

namespace FinanceManager.Infrastructure.Services.Identity;

public sealed class IdentityLocalizer(IStringLocalizer<IdentityResources> localizer) : BaseLocalizer<IdentityResources>(localizer)
{
    public Error RefreshInvalidToken =>
        new(IdentityConst.RefreshInvalidTokenError, GetString(IdentityResources.RefreshInvalidToken));
    public Error RefreshUserNotFound =>
        new(IdentityConst.RefreshUserNotFoundError, GetString(IdentityResources.RefreshUserNotFound));
}