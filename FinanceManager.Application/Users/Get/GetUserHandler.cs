using FinanceManager.Application.Users.Shared;
using FinanceManager.Domain.Shared.Results;
using FinanceManager.Domain.Users;

namespace FinanceManager.Application.Users.Get;

public class GetUserHandler(IUserRepository repository) : IGetUserHandler
{
    public async Task<Result<UserResponse>> HandleAsync(UserId request, CancellationToken cancellationToken = default) => 
        await repository.FindAsync(request, user => new UserResponse(user.Id, user.Name, user.Surname), cancellationToken); 
}