using FinanceManager.Application.Accounts.Shared;
using FinanceManager.Application.Shared.Requests;
using FinanceManager.Domain.Accounts;

namespace FinanceManager.Application.Accounts.GetAll;

public sealed record GetAllAccountsQuery : IRequest<AccountResponse[]>
{
    public string? Nome { get; set; }
    public AccountType? Type { get; set; }
}