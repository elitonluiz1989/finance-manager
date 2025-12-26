using FinanceManager.Domain.Shared.Errors;

namespace FinanceManager.Domain.Shared.Results;

public record Result<TValue>
{
    public TValue? Value { get; private set; }
    public Error[] Errors { get; private set; } = [];
    
    public bool IsFailure => Errors.Length > 0;
    public bool IsSuccess => !IsFailure;

    public Result(Error[] errors)
    {
        Errors = errors;
    }

    public Result(TValue? value)
    {
        Value = value;
    }
    
    public Result() {}
    
    public static Result<TValue> Success() => new();
    
    public static Result<TValue> Failure(params Error[] errors) => new(errors);
    
    public static implicit operator Result<TValue>(TValue? value) => new(value);
    public static implicit operator Result<TValue>(Error[] errors) => new(errors);
    
    public void AddErrors(Error[] errors) => Errors = errors;
}