using FinanceManager.Domain.Accounts;

namespace FinanceManager.Application.Accounts.Shared;

public record AccountResponse(AccountId Id, string Name, AccountType Type, decimal Balance);
