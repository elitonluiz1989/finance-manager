using FinanceManager.Application.Shared.Requests;
using FinanceManager.Application.Users.Shared;

namespace FinanceManager.Application.Users.GetAll;

public class GetAllUserQuery : IRequest<UserResponse[]>;