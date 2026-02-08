namespace FinanceManager.Application.Auth;

public sealed class LoginRequest
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? TwoFactorCode { get; set; }
    public string? TwoFactorRecoveryCode { get; set; }
}