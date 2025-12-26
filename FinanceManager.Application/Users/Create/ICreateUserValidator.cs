using FinanceManager.Application.Shared.Validators;
using FinanceManager.Application.Users.Shared;

namespace FinanceManager.Application.Users.Create;

public interface ICreateUserValidator : IValidator<CreateUserCommand, UserResponse>;