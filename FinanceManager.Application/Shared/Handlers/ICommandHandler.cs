using FinanceManager.Domain.Shared.Results;

namespace FinanceManager.Application.Shared.Handlers;

public interface ICommandHandler<in TRequest, TResponse> : IHandler<TRequest, Result<TResponse>>;