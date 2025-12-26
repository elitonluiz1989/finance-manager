namespace FinanceManager.Domain.Shared.Errors;

public struct Error(string code, string message)
{
    public string Code { get; } = code;
    public string Message { get; } = message;
}