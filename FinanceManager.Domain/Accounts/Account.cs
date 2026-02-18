using FinanceManager.Domain.Shared;
using FinanceManager.Domain.Shared.Interfaces;
using FinanceManager.Domain.Users;

namespace FinanceManager.Domain.Accounts;

public sealed class Account : Entity<AccountId>, IAuditable, ISoftDelete
{
    public string Name { get; private set; }
    public AccountType Type { get; private set; }
    public UserId UserId { get; private  set; }
    public DateTime CreatedAt { get; set; }
    public UserId CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public UserId? UpdatedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
    public UserId? DeletedBy { get; set; }
    
    public User? User { get; set; }

    private Account(string name, AccountType type, UserId userId)
    {
        Name = name;
        Type = type;
        UserId = userId;
    }
    
    public static Account CreateAccount(string name, AccountType type, UserId userId) => new(name, type, userId);
}