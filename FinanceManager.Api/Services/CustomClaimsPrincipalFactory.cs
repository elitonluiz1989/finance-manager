using System.Security.Claims;
using FinanceManager.Application.Users.Shared;
using FinanceManager.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace FinanceManager.Api.Services;

public sealed class CustomClaimsPrincipalFactory(
    UserManager<IdentityUser> userManager,
    IUserRepository userRepository,
    IOptions<IdentityOptions> options)
    : UserClaimsPrincipalFactory<IdentityUser>(userManager, options)
{
    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser identityUser)
    {
        var identity = await base.GenerateClaimsAsync(identityUser);

        await HandleDomainUserInfo(identityUser.Id, identity);
        
        return identity;
    }

    private async Task HandleDomainUserInfo(string identityId, ClaimsIdentity identity)
    {
        var domainUser = await userRepository.FindAsync(
            user => user.IdentityId.Equals(identityId),
            user => new UserResponse(user.Id, user.Name, user.Surname)
        );
        
        if (domainUser is null) return;
        
        identity.AddClaim(new Claim("user_id", domainUser.Id.ToString()));
        identity.AddClaim(new Claim(ClaimTypes.Name, domainUser.Name));
        identity.AddClaim(new Claim(ClaimTypes.Surname, domainUser.Surname ?? string.Empty));
    }
}