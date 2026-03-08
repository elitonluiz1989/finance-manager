using FinanceManager.Domain.Shared.Results;

namespace FinanceManager.Application.Shared.Requests;

public interface IQuery<TResponse> : IRequest<PaginatedResult<TResponse>>;