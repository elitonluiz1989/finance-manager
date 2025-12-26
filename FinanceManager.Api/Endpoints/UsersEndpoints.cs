using FinanceManager.Api.Extensions;
using FinanceManager.Application.Users.Create;
using FinanceManager.Application.Users.Get;
using FinanceManager.Domain.Users;

namespace FinanceManager.Api.Endpoints;

public static class UsersEndpoints
{
    public static void MapUsersEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/users").WithTags("Users");

        group.MapGet("/{id:guid}", async (Guid id, IGetUserHandler handler, CancellationToken cancellationToken) =>
        {
            var result = await handler.HandleAsync((UserId)id, cancellationToken);

            return result.ToGetResults();
        });

        group.MapPost("/", async (CreateUserCommand command, ICreateUserHandler handler, CancellationToken cancellationToken) =>
        {
            var result = await handler.HandleAsync(command, cancellationToken);

            return result.ToResults();
        });
    }
}