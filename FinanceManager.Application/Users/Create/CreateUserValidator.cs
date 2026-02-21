using FinanceManager.Application.Shared;
using FinanceManager.Application.Shared.Services;
using FinanceManager.Application.Shared.Validators;
using FinanceManager.Application.Users.Shared;
using FluentValidation;

namespace FinanceManager.Application.Users.Create;

public sealed class CreateUserValidator : Validator<CreateUserCommand, UserResponse>, ICreateUserValidator
{   
    public CreateUserValidator(UserLocalizer localizer, SharedLocalizer sharedLocation)
    {
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithErrorCode(CreateErrorCode(ValidationConst.EmailIsRequired));

        RuleFor(user => user.Email)
            .EmailAddress()
            .WithErrorCode(CreateErrorCode(ValidationConst.EmailIsInvalid));

        RuleFor(user => user.Password)
            .NotEmpty()
            .WithErrorCode(CreateErrorCode(ValidationConst.PasswordIsRequired))
            .WithName(localizer.Password);

        RuleFor(user => user.Name)
            .NotEmpty()
            .WithErrorCode(CreateErrorCode(ValidationConst.NameIsRequired))
            .WithName(sharedLocation.Name);
            
        RuleFor(user => user.Name)
            .MaximumLength(50)
            .WithErrorCode(CreateErrorCode(ValidationConst.NameMaximumLength))
            .WithName(sharedLocation.Name);

        RuleFor(user => user.Surname)
            .MaximumLength(100)
            .WithErrorCode(CreateErrorCode(ValidationConst.SurnameMaximumLength))
            .WithName(localizer.Surname);
    }

    protected override string SetRequestName() => nameof(CreateUserCommand);
}