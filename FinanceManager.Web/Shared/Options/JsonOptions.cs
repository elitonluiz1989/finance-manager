using System.Text.Json;
using FinanceManager.Application.Accounts.Shared;
using FinanceManager.Application.Users.Shared;

namespace FinanceManager.Web.Shared.Options;

public static class JsonOptions
{
    public static readonly JsonSerializerOptions Default = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters =
        {
            new AccountIdJsonConverter(),
            new UserIdJsonConverter()
        }
    };
}