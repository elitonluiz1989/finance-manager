namespace FinanceManager.Application.Auth;

public sealed record RefreshRequest
{
    public required string RefreshToken { get; init; }
}