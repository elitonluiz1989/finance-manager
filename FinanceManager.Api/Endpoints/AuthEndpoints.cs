using FinanceManager.Application.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("auth").WithTags("Auth");

        group.MapPost("/register", UsersEndpoints.CreateUserRoute);

        group.MapPost("/login", async (LoginRequest login, SignInManager<IdentityUser> manager) =>
        {
            var user = await manager.UserManager.FindByEmailAsync(login.Email);

            if (user is null) return Results.Unauthorized();

            var result = await manager.CheckPasswordSignInAsync(
                user,
                login.Password,
                lockoutOnFailure: false
            );

            if (!result.Succeeded) return Results.Unauthorized();

            var principal = await manager.CreateUserPrincipalAsync(user);

            return Results.SignIn(principal, authenticationScheme: IdentityConstants.BearerScheme);
        });

        group.MapPost("/refresh", async (
            [FromBody] RefreshRequest request,
            [FromServices] IIdentityService service) =>
        {
            var result = await service.RefreshTokenAsync(request.RefreshToken);
            
            return result.IsSuccess
                ? Results.SignIn(result.Value!, authenticationScheme: IdentityConstants.BearerScheme)
                : Results.Unauthorized();
        });
    }
}