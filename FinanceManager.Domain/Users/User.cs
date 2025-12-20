using FinanceManager.Domain.Shared;
using FinanceManager.Domain.Shared.Interfaces;

namespace FinanceManager.Domain.Users;

public class User : Entity<UserId>, ISoftDelete
{
    public required string Name { get; set; }
    public required string IdentityId { get; set; }
    public DateTime? DeletedAt { get; set; }
    public UserId? DeletedBy { get; set; }
}