using FinanceManager.Application.Shared.Handlers;
using FinanceManager.Application.Users.Shared;
using FinanceManager.Domain.Users;

namespace FinanceManager.Application.Users.GetAll;

public interface IGetAllUserHandler : IHandler<GetAllUserQuery, UserResponse[]>;

public sealed class GetAllUserHandler(IUserRepository repository) : IGetAllUserHandler
{
    public async Task<UserResponse[]> HandleAsync(GetAllUserQuery request, CancellationToken cancellationToken = default)
    {
        return await repository.GetAllAsync(
            user => new UserResponse(user.Id, user.Name, user.Surname),
            predicate: null,
            cancellationToken
        );
    }
}