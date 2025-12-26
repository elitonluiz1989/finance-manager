using FinanceManager.Domain.Users;
using FinanceManager.Infrastructure.Contexts;

namespace FinanceManager.Infrastructure.Repositories;

public sealed class UserRepository(ApplicationDbContext context) : Repository<User, UserId>(context), IUserRepository;