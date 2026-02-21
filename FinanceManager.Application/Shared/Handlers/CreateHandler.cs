using FinanceManager.Application.Shared.Requests;
using FinanceManager.Application.Shared.Validators;
using FinanceManager.Domain.Shared;
using FinanceManager.Domain.Shared.Interfaces;
using FinanceManager.Domain.Shared.Results;

namespace FinanceManager.Application.Shared.Handlers;

public abstract class CreateHandler<TEntity, TId, TValidator, TRepository, TCommand, TResponse>(
    TValidator validator,
    TRepository repository) :
    ICreateHandler<TCommand, TResponse>
    where TEntity : Entity<TId>, IAuditable
    where TId : struct
    where TValidator: IValidator<TCommand, TResponse>
    where TRepository : IRepository<TEntity, TId>
    where TCommand : CreateCommand<TResponse>
{
    public Result<TResponse> Handle(TCommand request)
    {
        var result = validator.Validate(request);
        
        if (result.IsFailure) return result;
        
        var entity = MapToEntity(request);
        entity.CreatedAt = DateTime.Now;
        entity.CreatedBy = request.CreatedBy;
        
        repository.Create(entity);

        return MapToResponse(entity);
    } 
    
    protected abstract TEntity MapToEntity(TCommand request);
    protected abstract TResponse MapToResponse(TEntity entity);
}