using FinanceManager.Domain.Shared.Interfaces;

namespace FinanceManager.Domain.Accounts;

public readonly record struct AccountId: IEntityIdentifier<AccountId>
{
    public Guid Value { get; }
    
    private AccountId(Guid value) => Value = value;
    
    public static AccountId New() => new(Guid.NewGuid());

    public static AccountId Parse(Guid value) => new(value);
    
    public static explicit operator AccountId(Guid value) => Parse(value);
    public static explicit operator Guid(AccountId value) => value.Value;
    
    public override string ToString() => Value.ToString();
}