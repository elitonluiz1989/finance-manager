using FinanceManager.Domain.Users;

namespace FinanceManager.Application.Users.Shared;

public record UserResponse(UserId Id, string Name, string? Surname);