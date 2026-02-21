using FinanceManager.Application.Accounts.Shared;
using FinanceManager.Application.Shared.Handlers;

namespace FinanceManager.Application.Accounts.Create;

public interface ICreateAccountHandler : ICreateHandler<CreateAccountCommand, AccountResponse>;