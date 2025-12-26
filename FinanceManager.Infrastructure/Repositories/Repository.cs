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
    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate) =>
        await context.Set<TEntity>().AnyAsync(predicate);
    
    public void Create(TEntity entity) => context.Set<TEntity>().Add(entity);
}