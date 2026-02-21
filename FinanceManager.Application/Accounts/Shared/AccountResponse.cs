using FinanceManager.Domain.Accounts;
using FinanceManager.Domain.Users;

namespace FinanceManager.Application.Accounts.Shared;

public record AccountResponse(AccountId Id, string Name, AccountType Type, UserId UserId);