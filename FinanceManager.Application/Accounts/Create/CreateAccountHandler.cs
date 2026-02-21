using FinanceManager.Application.Accounts.Shared;
using FinanceManager.Application.Shared.Handlers;
using FinanceManager.Domain.Accounts;

namespace FinanceManager.Application.Accounts.Create;

public class CreateAccountHandler(ICreateAccountValidator validator, IAccountRepository repository) :
    CreateHandler<Account, AccountId, ICreateAccountValidator, IAccountRepository, CreateAccountCommand, AccountResponse>(validator, repository), ICreateAccountHandler
{
    protected override Account MapToEntity(CreateAccountCommand request) => request.ToAccount();

    protected override AccountResponse MapToResponse(Account entity) => entity.ToAccountResponse();
}