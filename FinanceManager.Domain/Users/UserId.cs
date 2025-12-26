using FinanceManager.Domain.Shared.Interfaces;

namespace FinanceManager.Domain.Users;

public readonly record struct UserId : IEntityIdentifier<UserId>
{
    public Guid Value { get; }

    private UserId(Guid value) => Value = value;
    
    public static UserId New() => new(Guid.NewGuid());
    public static UserId Parse(Guid value) => new(value);
    
    public static explicit operator UserId(Guid value) => new(value);
    public static explicit operator Guid(UserId id) => id.Value;
    
    public override string ToString() => Value.ToString();
}