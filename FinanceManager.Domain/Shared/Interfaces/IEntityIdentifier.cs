namespace FinanceManager.Domain.Shared.Interfaces;

public interface IEntityIdentifier<out TId> where TId : struct
{
    Guid Value { get; }

    static abstract TId New();
    static abstract TId Parse(Guid value);
}