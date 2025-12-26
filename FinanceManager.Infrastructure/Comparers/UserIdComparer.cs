using FinanceManager.Domain.Users;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FinanceManager.Infrastructure.Comparers;

public class UserIdComparer() : ValueComparer<UserId>(
    (a, b) => a.Value.Equals(b.Value),
    id => id.Value.GetHashCode(),
    id => UserId.Parse(id.Value)
);