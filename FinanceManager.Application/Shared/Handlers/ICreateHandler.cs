using FinanceManager.Application.Shared.Requests;
using FinanceManager.Domain.Shared.Results;

namespace FinanceManager.Application.Shared.Handlers;

public interface ICreateHandler<in TCommand, TResponse> where TCommand : ICommand<TResponse>
{
    Result<TResponse> Handle(TCommand request);
}