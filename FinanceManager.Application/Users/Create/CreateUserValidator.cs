using FinanceManager.Application.Shared.Validators;
using FinanceManager.Application.Users.Shared;
using FluentValidation;

namespace FinanceManager.Application.Users.Create;

public sealed class CreateUserValidator : Validator<CreateUserCommand, UserResponse>, ICreateUserValidator
{   
    private const string EmailIsRequired = "EmailIsRequired";
    private const string EmailIsInvalid = "EmailIsInvalid";
    private const string NameIsRequired = "NameIsRequired";
    private const string NameMaximumLength = "NameMaximumLength";
    private const string PasswordIsRequired = "PasswordIsRequired";
    private const string SurnameMaximumLength = "SurnameMaximumLength";
    
    public CreateUserValidator(UserLocationService localization)
    {
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithErrorCode(CreateErrorCode(EmailIsRequired));

        RuleFor(user => user.Email)
            .EmailAddress()
            .WithErrorCode(CreateErrorCode(EmailIsInvalid));

        RuleFor(user => user.Password)
            .NotEmpty()
            .WithErrorCode(CreateErrorCode(nameof(PasswordIsRequired)))
            .WithName(localization.Password);

        RuleFor(user => user.Name)
            .NotEmpty()
            .WithErrorCode(CreateErrorCode(nameof(NameIsRequired)))
            .WithName(localization.Name);
            
        RuleFor(user => user.Name)
            .MaximumLength(50)
            .WithErrorCode(CreateErrorCode(nameof(NameMaximumLength)))
            .WithName(localization.Name);

        RuleFor(user => user.Surname)
            .MaximumLength(100)
            .WithErrorCode(CreateErrorCode(nameof(SurnameMaximumLength)))
            .WithName(localization.Surname);
    }

    protected override void SetRequestName() =>  RequestName = nameof(CreateUserCommand);
}