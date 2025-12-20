namespace FinanceManager.Domain.Shared;

public abstract class Entity<TId> where TId : struct
{
    public TId Id { get; set; }
}