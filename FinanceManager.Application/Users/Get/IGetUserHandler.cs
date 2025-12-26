using FinanceManager.Application.Shared.Handlers;
using FinanceManager.Application.Users.Shared;
using FinanceManager.Domain.Users;

namespace FinanceManager.Application.Users.Get;

public interface IGetUserHandler : IGetHandler<UserId, UserResponse>;