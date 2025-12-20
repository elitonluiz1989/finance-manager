namespace FinanceManager.Domain.Users;

public record struct UserId
{
    private Guid Value { get; }

    private UserId(Guid value) => Value = value;
    
    public static implicit operator UserId(Guid value) => new(value);
    public static implicit operator Guid(UserId id) => id.Value;
}