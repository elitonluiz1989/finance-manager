using FinanceManager.Domain.Shared.Errors;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace FinanceManager.Application.Shared;

public static class ErrorExtensions
{
    public static Error ToError(this ValidationFailure error) => new(error.ErrorCode, error.ErrorMessage);

    public static Error ToError(this IdentityError error) => new(error.Code, error.Description);
}