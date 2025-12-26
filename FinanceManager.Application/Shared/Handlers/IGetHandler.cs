using FinanceManager.Domain.Shared.Results;

namespace FinanceManager.Application.Shared.Handlers;

public interface IGetHandler<in TRequest, TResponse> : IHandler<TRequest, Result<TResponse>>;