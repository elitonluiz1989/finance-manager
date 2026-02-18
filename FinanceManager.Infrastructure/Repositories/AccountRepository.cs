using FinanceManager.Domain.Accounts;
using FinanceManager.Infrastructure.Contexts;

namespace FinanceManager.Infrastructure.Repositories;

public sealed class AccountRepository(ApplicationDbContext context) : Repository<Account, AccountId>(context), IAccountRepository;