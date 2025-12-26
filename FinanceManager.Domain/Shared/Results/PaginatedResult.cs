using FinanceManager.Domain.Shared.Errors;

namespace FinanceManager.Domain.Shared.Results;

public record PaginatedResult<TValue> : Result<IList<TValue>>
{
    public int TotalCount { get; private set; }
    
    public PaginatedResult(Error[] errors) : base(errors) { }

    public PaginatedResult(IList<TValue>? value, int totalCount) : base(value)
    {
        TotalCount = totalCount;
    }
}