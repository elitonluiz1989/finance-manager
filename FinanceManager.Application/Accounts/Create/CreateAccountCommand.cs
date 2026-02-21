using FinanceManager.Application.Accounts.Shared;
using FinanceManager.Application.Shared.Requests;
using FinanceManager.Domain.Accounts;
using FinanceManager.Domain.Users;

namespace FinanceManager.Application.Accounts.Create;

public sealed record CreateAccountCommand : CreateCommand<AccountResponse>
{
    public string Name { get; set; } =  string.Empty;
    public AccountType Type { get; set; }
    public UserId UserId { get; set; }
}