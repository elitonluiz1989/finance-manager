using FinanceManager.Domain.Shared.Results;

namespace FinanceManager.Domain.Shared.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<Result<TValue>> EncapsulateTransaction<TValue>(
        Func<Task<Result<TValue>>> funcAsync,
        CancellationToken cancellationToken = default
    );
}