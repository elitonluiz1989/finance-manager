using FinanceManager.Domain.Shared.Interfaces;

namespace FinanceManager.Domain.Users;

public interface IUserRepository : IRepository<User, UserId>;