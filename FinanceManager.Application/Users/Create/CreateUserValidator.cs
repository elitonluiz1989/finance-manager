using FinanceManager.Application.Shared.Validators;
using FinanceManager.Application.Users.Shared;
using FinanceManager.Application.Users.Shared.Resources;
using FluentValidation;

namespace FinanceManager.Application.Users.Create;

public class CreateUserValidator : Validator<CreateUserCommand, UserResponse>, ICreateUserValidator
{
    public CreateUserValidator()
    {
        RuleFor(user => user.Username)
            .NotEmpty()
            .WithMessage(UserResource.UsernameRequired);
        
        RuleFor(user => user.Password)
            .NotEmpty()
            .WithMessage(UserResource.PasswordIsRequired);
        
        RuleFor(user => user.Email)
            .EmailAddress()
            .WithMessage(UserResource.EmailIsInvalid);
        
        RuleFor(user => user.Name)
            .NotEmpty()
            .WithMessage(UserResource.NameIsRequired)
            .MaximumLength(50)
            .WithMessage(UserResource.NameMaximumLength);

        RuleFor(user => user.Surname)
            .MaximumLength(100)
            .WithMessage(UserResource.SurnameMaximumLength);
    }
}