using FinanceManager.Domain.Accounts;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FinanceManager.Infrastructure.Comparers;

public sealed class AccountIdComparer() : ValueComparer<AccountId>(
    (a, b) => a.Value.Equals(b.Value),
    id => id.Value.GetHashCode(),
    id => AccountId.Parse(id.Value)
);