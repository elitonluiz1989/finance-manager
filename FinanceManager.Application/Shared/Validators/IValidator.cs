using FinanceManager.Domain.Shared.Results;

namespace FinanceManager.Application.Shared.Validators;

public interface IValidator<in TRequest, TResponse>
{
    Result<TResponse> Validate(TRequest request);
}