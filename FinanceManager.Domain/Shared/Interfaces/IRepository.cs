using System.Linq.Expressions;

namespace FinanceManager.Domain.Shared.Interfaces;

public interface IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId: struct
{
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
    void Create(TEntity entity);
}