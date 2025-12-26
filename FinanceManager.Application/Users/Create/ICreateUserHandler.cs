using FinanceManager.Application.Shared.Handlers;
using FinanceManager.Application.Users.Shared;

namespace FinanceManager.Application.Users.Create;

public interface ICreateUserHandler : ICommandHandler<CreateUserCommand, UserResponse>;