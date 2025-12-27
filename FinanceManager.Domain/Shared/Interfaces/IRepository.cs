using System.Linq.Expressions;

namespace FinanceManager.Domain.Shared.Interfaces;

public interface IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId: struct
{
    Task<TProjection?> FindAsync<TProjection>(
        Expression<Func<TEntity, bool>> predicate,
        Expression<Func<TEntity, TProjection>> projection,
        CancellationToken cancellationToken = default
    );
    Task<TProjection?> FindAsync<TProjection>(
        TId id,
        Expression<Func<TEntity, TProjection>> projection,
        CancellationToken cancellationToken = default
    );
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate,  CancellationToken cancellationToken = default);
    void Create(TEntity entity);
}