using System.Linq.Expressions;
using FinanceManager.Application.Accounts.Shared;
using FinanceManager.Application.Shared.Handlers;
using FinanceManager.Domain.Accounts;

namespace FinanceManager.Application.Accounts.GetAll;

public interface IGetAllAccountsHandler : IHandler<GetAllAccountsQuery, AccountResponse[]>;

public class GetAllAccountsHandler(IAccountRepository repository) : IGetAllAccountsHandler
{
    public async Task<AccountResponse[]> HandleAsync(GetAllAccountsQuery request, CancellationToken cancellationToken = default)
    {
        var projection = GetProjection();
        var filter = GetFilter(request);
        
        return await repository.GetAllAsync(projection, filter, cancellationToken);
    }

    private static Expression<Func<Account, AccountResponse>> GetProjection() => account => account.ToAccountResponse(); 

    private static Expression<Func<Account, bool>> GetFilter(GetAllAccountsQuery request)
    {
        return account => account.DeletedAt == null &&
            (string.IsNullOrWhiteSpace(request.Nome) || account.Name.ToLower().Contains(request.Nome.ToLower())) &&
            (!request.Type.HasValue || account.Type == request.Type);
    }
}