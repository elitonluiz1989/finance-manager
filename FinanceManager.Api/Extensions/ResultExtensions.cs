using FinanceManager.Domain.Shared.Results;

namespace FinanceManager.Api.Extensions;

public static class ResultExtensions
{
    extension<TValue>(Result<TValue> result)
    {
        public IResult ToResults() =>
            result.IsFailure ? Results.BadRequest((object?)result) : Results.Ok((object?)result);

        public IResult ToGetResults() =>
            result.Value is null ? Results.NotFound() : result.ToResults();
    }
}