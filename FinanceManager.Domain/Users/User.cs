using FinanceManager.Domain.Shared;
using FinanceManager.Domain.Shared.Interfaces;

namespace FinanceManager.Domain.Users;

public sealed class User : Entity<UserId>, ISoftDelete
{
    public string Name { get; private set; }
    public string? Surname { get; private set; }
    public string IdentityId { get; private set; }
    public DateTime? DeletedAt { get; set; }
    public UserId? DeletedBy { get; set; }

    private User(string name, string? surname, string identityId)
    {
        Id = UserId.New();
        Name = name;
        Surname = surname;
        IdentityId = identityId;
    }
    
    public static User CreateUser(string name, string? surname, string identityId) => new(name, surname, identityId);
    
    public static User CreateUser(string name, string? surname) => CreateUser(name, surname, string.Empty);
    
    public void UpdateIdentityId(string identityId) => IdentityId = identityId;
}