using FinanceManager.Domain.Shared.Errors;
using FinanceManager.Domain.Shared.Interfaces;
using FinanceManager.Domain.Shared.Results;
using FinanceManager.Infrastructure.Contexts;

namespace FinanceManager.Infrastructure.Services;

public sealed class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default) => await context.SaveChangesAsync(cancellationToken);
    
    public async Task<Result<TValue>> EncapsulateTransaction<TValue>(
        Func<Task<Result<TValue>>> funcAsync,
        CancellationToken cancellationToken = default
    )
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var result = await funcAsync.Invoke();

            if (result.IsFailure) await transaction.RollbackAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return result;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync(cancellationToken);
            
            return new Result<TValue>([ new Error(nameof(e), e.Message) ]);
        }
    }
}