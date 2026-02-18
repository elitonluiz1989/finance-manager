using FinanceManager.Application.Shared;
using FinanceManager.Domain.Shared.Errors;
using FinanceManager.Infrastructure.Constants;
using FinanceManager.Infrastructure.Resources;
using Microsoft.Extensions.Localization;

namespace FinanceManager.Infrastructure.Services.Identity;

public sealed class IdentityLocalizationService(IStringLocalizer<IdentityResources> localizer) : LocalizationService<IdentityResources>(localizer)
{
    public Error RefreshInvalidToken =>
        new(IdentityConst.RefreshInvalidTokenError, GetString(IdentityResources.RefreshInvalidToken));
    public Error RefreshUserNotFound =>
        new(IdentityConst.RefreshUserNotFoundError, GetString(IdentityResources.RefreshUserNotFound));
}