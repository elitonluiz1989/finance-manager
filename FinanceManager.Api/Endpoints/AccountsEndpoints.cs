using FinanceManager.Api.Extensions;
using FinanceManager.Application.Accounts.Create;
using FinanceManager.Application.Accounts.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.Api.Endpoints;

public static class AccountsEndpoints
{
    public static void MapAccountsEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/accounts");

        group.MapGet("/", GetAllEndpoint).WithName("GetAllAccounts");
        group.MapPost("/", CreateEndpoint).WithName("CreateAccount");
    }

    private static async Task<IResult> GetAllEndpoint([AsParameters] GetAllAccountsQuery request, IGetAllAccountsHandler handler)
    {
        var accounts = await handler.HandleAsync(request);
            
        return Results.Ok(accounts);
    }

    private static IResult CreateEndpoint([FromBody] CreateAccountCommand command, ICreateAccountHandler handler) =>
        handler.Handle(command).ToResults();
}