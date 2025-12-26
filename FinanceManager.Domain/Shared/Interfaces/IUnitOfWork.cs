namespace FinanceManager.Domain.Shared.Interfaces;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}