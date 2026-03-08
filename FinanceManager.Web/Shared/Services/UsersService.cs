using FinanceManager.Application.Users.Shared;

namespace FinanceManager.Web.Shared.Services;

public interface IUsersService
{
    Task<UserResponse[]> GetAllAsync();
}

public sealed class UsersService(ApiClient api) : IUsersService
{
    public async Task<UserResponse[]> GetAllAsync() => await api.GetAsync<UserResponse[]>("/users") ?? [];
}