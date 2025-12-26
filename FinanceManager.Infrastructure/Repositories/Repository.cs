using System.Linq.Expressions;
using FinanceManager.Domain.Shared;
using FinanceManager.Domain.Shared.Interfaces;
using FinanceManager.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Infrastructure.Repositories;

public abstract class Repository<TEntity, TId>(ApplicationDbContext context) : IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId: struct
{
    private DbSet<TEntity> DbSet => context.Set<TEntity>();
    
    public async Task<TProjection?> FindAsync<TProjection>(
        TId id,
        Expression<Func<TEntity, TProjection>> projection,
        CancellationToken cancellationToken = default
    ) =>  await DbSet.Where(p => p.Id.Equals(id)).Select(projection).FirstOrDefaultAsync(cancellationToken);

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default) =>
        await DbSet.AnyAsync(predicate, cancellationToken);
    
    public void Create(TEntity entity) => DbSet.Add(entity);
}