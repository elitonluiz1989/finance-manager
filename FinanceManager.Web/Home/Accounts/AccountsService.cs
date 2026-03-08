using FinanceManager.Application.Accounts.Create;
using FinanceManager.Application.Accounts.Shared;
using FinanceManager.Domain.Shared.Results;
using FinanceManager.Web.Home.Accounts.Form;
using FinanceManager.Web.Shared.Services;

namespace FinanceManager.Web.Home.Accounts;

public interface IAccountsService
{
    Task<AccountResponse[]> GetAllAsync();
    Task<Result<AccountResponse>> CreateAsync(AccountModel model);
}

public sealed class AccountsService(ApiClient client) : IAccountsService
{
    public async Task<AccountResponse[]> GetAllAsync() => await client.GetAsync<AccountResponse[]>("/accounts") ?? [];

    public async Task<Result<AccountResponse>> CreateAsync(AccountModel model)
    {
        var command = (CreateAccountCommand)model;
        throw new NotImplementedException();
    }
}