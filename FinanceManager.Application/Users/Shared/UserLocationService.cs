using FinanceManager.Application.Shared;
using FinanceManager.Application.Users.Shared.Resources;
using Microsoft.Extensions.Localization;

namespace FinanceManager.Application.Users.Shared;

public class UserLocationService(IStringLocalizer<UserResources> localizer) : LocalizationService<UserResources>(localizer)
{
    public string Name => GetString(UserResources.Name);
    public string Password => GetString(UserResources.Password);
    public string Surname => GetString(UserResources.Surname);
}