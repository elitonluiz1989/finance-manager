using FinanceManager.Application.Shared;
using FinanceManager.Application.Users.Shared;
using FinanceManager.Domain.Shared.Interfaces;
using FinanceManager.Domain.Shared.Results;
using FinanceManager.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace FinanceManager.Application.Users.Create;

public sealed class CreateUserHandler(
    ICreateUserValidator validator,
    UserManager<IdentityUser> userManager,
    IUserRepository repository,
    IUnitOfWork unitOfWork
)
    : ICreateUserHandler
{
    public async Task<Result<UserResponse>> HandleAsync(CreateUserCommand request, CancellationToken cancellationToken = default)
    {
        var validationResult = validator.Validate(request);

        if (validationResult.IsFailure) return validationResult;

        return await unitOfWork.EncapsulateTransaction(async () =>
        {
            var identityUserResult = await HandleIdentityUserAsync(request);
            
            if (identityUserResult.IsFailure) return Result<UserResponse>.Failure(identityUserResult.Errors);
            
            var domainUser = request.ToUser();
            domainUser.UpdateIdentityId(identityUserResult.Value!.Id);
            
            repository.Create(domainUser);

            await unitOfWork.SaveChangesAsync(cancellationToken);
            
            return domainUser.ToUserResponse();
        });
    }

    private async Task<Result<IdentityUser?>> HandleIdentityUserAsync(CreateUserCommand command)
    {
        var identityUser = command.ToIdenityUser();
        
        var result = await userManager.CreateAsync(identityUser, command.Password);
        
        if (result.Succeeded) return identityUser;

        var errors = result.Errors.Select(e => e.ToError()).ToArray();
        
        return new Result<IdentityUser?>(errors);
    }
}