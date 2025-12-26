using FinanceManager.Domain.Shared.Results;

namespace FinanceManager.Application.Shared.Requests;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>;