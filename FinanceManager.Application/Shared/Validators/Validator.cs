using FinanceManager.Domain.Shared.Results;
using FluentValidation;

namespace FinanceManager.Application.Shared.Validators;

public abstract class Validator<TRequest, TResponse> : AbstractValidator<TRequest>, IValidator<TRequest, TResponse>
{
    protected string RequestName = string.Empty;

    public new Result<TResponse> Validate(TRequest request)
    {
        var result = new Result<TResponse>();
        
        var validationResult = base.Validate(request);

        if (validationResult.IsValid) return result;

        var errors = validationResult.Errors.Select(e => e.ToError()).ToArray();
            
        result.AddErrors(errors);

        return result;
    }

    protected abstract void SetRequestName();

    protected string CreateErrorCode(string error)
    {
        if (string.IsNullOrWhiteSpace(RequestName)) SetRequestName();
        
        return $"{RequestName}.Validation.{error}";
    }
}