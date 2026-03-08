using FinanceManager.Api.Extensions;
using FinanceManager.Application.Users.Create;
using FinanceManager.Application.Users.Get;
using FinanceManager.Application.Users.GetAll;
using FinanceManager.Domain.Users;

namespace FinanceManager.Api.Endpoints;

public static class UsersEndpoints
{
    public static void MapUsersEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/users");

        group.MapGet("/", GetAllEndpoint);
        group.MapGet("/{id:guid}", GetEndpoint);
        group.MapPost("/", CreateEndpoint);
    }

    private static async Task<IResult> GetAllEndpoint([AsParameters] GetAllUserQuery query, IGetAllUserHandler handler, CancellationToken cancellationToken)
    {
        var results = await handler.HandleAsync(query, cancellationToken);

        return Results.Ok(results);
    }

    private static async Task<IResult> GetEndpoint(Guid id, IGetUserHandler handler, CancellationToken cancellationToken)
    {
        var result = await handler.HandleAsync((UserId)id, cancellationToken);

        return result.ToGetResults();
    }

    public static async Task<IResult> CreateEndpoint(
        CreateUserCommand command,
        ICreateUserHandler handler,
        CancellationToken cancellationToken
    )
    {
        var result = await handler.HandleAsync(command, cancellationToken);

        return result.ToResults();
    }
}