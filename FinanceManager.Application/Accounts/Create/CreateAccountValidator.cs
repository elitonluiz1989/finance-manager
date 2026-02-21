using FinanceManager.Application.Accounts.Shared;
using FinanceManager.Application.Shared;
using FinanceManager.Application.Shared.Services;
using FinanceManager.Application.Shared.Validators;
using FluentValidation;

namespace FinanceManager.Application.Accounts.Create;

public class CreateAccountValidator : Validator<CreateAccountCommand, AccountResponse>, ICreateAccountValidator
{
    public CreateAccountValidator(SharedLocalizer sharedLocalizer)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithErrorCode(CreateErrorCode(ValidationConst.NameIsRequired))
            .WithName(sharedLocalizer.Name);
        
        RuleFor(p => p.Type)
            .IsInEnum()
            .WithErrorCode(CreateErrorCode(AccountsConst.TypeIsRequired))
            .WithName(sharedLocalizer.Type);
        
        RuleFor(p => p.UserId)
            .NotNull()
            .NotEmpty()
            .WithErrorCode(CreateErrorCode(ValidationConst.UserIdIsRequired))
            .WithName(sharedLocalizer.UserId);
    }
    
    protected override string SetRequestName() => nameof(CreateAccountCommand);
}