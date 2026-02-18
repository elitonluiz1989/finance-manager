using FinanceManager.Domain.Shared.Interfaces;

namespace FinanceManager.Domain.Accounts;

public interface IAccountRepository : IRepository<Account, AccountId>;