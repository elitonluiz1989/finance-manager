using FinanceManager.Domain.Shared.Interfaces;
using FinanceManager.Infrastructure.Contexts;

namespace FinanceManager.Infrastructure.Services;

public sealed class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
}