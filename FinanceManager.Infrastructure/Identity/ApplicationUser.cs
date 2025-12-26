using Microsoft.AspNetCore.Identity;

namespace FinanceManager.Infrastructure.Identity;

public sealed class ApplicationUser : IdentityUser
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
}