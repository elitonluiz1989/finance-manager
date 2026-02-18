using FinanceManager.Domain.Users;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinanceManager.Infrastructure.Converters.Users;

public sealed class UserIdConverter() : ValueConverter<UserId, Guid>(
    value => value.Value,
    value => UserId.Parse(value)
);
