using FinanceManager.Application.Accounts.Create;
using FinanceManager.Domain.Accounts;

namespace FinanceManager.Application.Accounts.Shared;

public static class AccountsExtensions
{
    public static Account ToAccount(this CreateAccountCommand command) =>
        Account.CreateAccount(command.Name, command.Type, command.UserId);

    public static AccountResponse ToAccountResponse(this Account entity) =>
        new(entity.Id, entity.Name, entity.Type, entity.UserId);
}