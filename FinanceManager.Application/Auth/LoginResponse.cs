namespace FinanceManager.Application.Auth;

public record LoginResponse(
    string TokenType,
    string AccessToken,
    long ExpiresIn,
    string RefreshToken
);