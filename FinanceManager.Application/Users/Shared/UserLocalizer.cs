using FinanceManager.Application.Shared.Services;
using FinanceManager.Application.Users.Shared.Resources;
using Microsoft.Extensions.Localization;

namespace FinanceManager.Application.Users.Shared;

public sealed class UserLocalizer(IStringLocalizer<UserResources> localizer) : BaseLocalizer<UserResources>(localizer)
{
    public string Password => GetString(UserResources.Password);
    public string Surname => GetString(UserResources.Surname);
}