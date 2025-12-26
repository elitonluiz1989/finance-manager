using FinanceManager.Application.Shared.Requests;
using FinanceManager.Application.Users.Shared;

namespace FinanceManager.Application.Users.Create;

public class CreateUserCommand : ICommand<UserResponse>
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public string? Email { get; set; }
    public required string Name { get; set; }
    public string? Surname { get; set; }
}