using FinanceManager.Application.Users.Create;
using FinanceManager.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace FinanceManager.Application.Users.Shared;

public static class UserExtensions
{
    extension(CreateUserCommand command)
    {
        public IdentityUser ToIdentityUser() => new()
        {
            UserName = command.Email,
            Email = command.Email
        };

        public User ToUser() => User.CreateUser(command.Name, command.Surname);
    }

    public static UserResponse ToUserResponse(this User user) => new(user.Id, user.Name, user.Surname);
}