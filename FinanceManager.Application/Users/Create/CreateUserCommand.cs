using FinanceManager.Application.Shared.Requests;
using FinanceManager.Application.Users.Shared;

namespace FinanceManager.Application.Users.Create;

public sealed record CreateUserCommand : ICommand<UserResponse>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Surname { get; set; }
}