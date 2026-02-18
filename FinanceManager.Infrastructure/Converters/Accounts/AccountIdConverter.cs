using FinanceManager.Domain.Accounts;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinanceManager.Infrastructure.Converters.Accounts;

public sealed class AccountIdConverter() : ValueConverter<AccountId, Guid>(
    value => value.Value,
    value => AccountId.Parse(value)
);