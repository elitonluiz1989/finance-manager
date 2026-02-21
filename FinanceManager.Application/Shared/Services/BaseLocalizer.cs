using System.Runtime.CompilerServices;
using Microsoft.Extensions.Localization;

namespace FinanceManager.Application.Shared.Services;

public abstract class BaseLocalizer<TResources>(IStringLocalizer<TResources> localizer)
{
    protected string GetString(object? value, [CallerArgumentExpression("value")] string expression = "")
    {
        var key = expression.Contains('.') 
            ? expression[(expression.LastIndexOf('.') + 1)..] 
            : expression;

        return localizer.GetString(key);
    }
}