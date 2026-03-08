using FinanceManager.Application.Shared.Extensions;
using FinanceManager.Web.Shared.Components.FormField;

namespace FinanceManager.Web.Shared.Extensions;

public static class EnumExtensions
{
    public static FormSelectOption<T?>[] ToSelectOptions<T>() where T : struct, Enum
    {
        return Enum.GetValues<T>()
            .Select(t => new FormSelectOption<T?>(t.GetDisplayName(), t))
            .ToArray();
    }
}