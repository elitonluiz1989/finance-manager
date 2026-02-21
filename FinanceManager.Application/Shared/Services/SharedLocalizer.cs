using FinanceManager.Application.Shared.Resources;
using Microsoft.Extensions.Localization;

namespace FinanceManager.Application.Shared.Services;

public sealed class SharedLocalizer(IStringLocalizer<SharedResources> localizer) :
    BaseLocalizer<SharedResources>(localizer)
{
    public string Name => GetString(SharedResources.Name);
    public string Type => GetString(SharedResources.Type);
    public string UserId => GetString(SharedResources.UserId);
}