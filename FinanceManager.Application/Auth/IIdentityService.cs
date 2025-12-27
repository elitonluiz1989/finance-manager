using System.Security.Claims;
using FinanceManager.Domain.Shared.Results;

namespace FinanceManager.Application.Auth;

public interface IIdentityService
{
    Task<Result<ClaimsPrincipal>> RefreshTokenAsync(string refreshToken);
}