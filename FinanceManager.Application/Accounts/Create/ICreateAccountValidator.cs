using FinanceManager.Application.Accounts.Shared;
using FinanceManager.Application.Shared.Validators;

namespace FinanceManager.Application.Accounts.Create;

public interface ICreateAccountValidator : IValidator<CreateAccountCommand, AccountResponse>;