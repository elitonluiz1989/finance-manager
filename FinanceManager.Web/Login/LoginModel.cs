using System.ComponentModel.DataAnnotations;
using FinanceManager.Application.Auth;

namespace FinanceManager.Web.Login;

public sealed record LoginModel
{
    [Required(ErrorMessageResourceType = typeof(LoginResources), ErrorMessageResourceName = "EmailRequired")]
    public string? Email { get; set; }
    [Required(ErrorMessageResourceType = typeof(LoginResources), ErrorMessageResourceName = "PasswordRequired")]
    public string? Password { get; set; }
    public string? TwoFactorCode { get; set; }
    public string? TwoFactorRecoveryCode { get; set; }

    public static explicit operator LoginRequest?(LoginModel? model)
    {
        if (model is null) return null;

        return new LoginRequest
        {
            Email = model.Email ?? string.Empty,
            Password = model.Password ?? string.Empty,
            TwoFactorCode = model.TwoFactorCode,
            TwoFactorRecoveryCode = model.TwoFactorRecoveryCode
        };
    }
}