namespace FinanceManager.Web.Shared.Interfaces;

public interface IStorageService
{
    Task<TValue?> GetAsync<TValue>(string key, CancellationToken cancellationToken = default);
    Task SetAsync<TValue>(string key, TValue value, CancellationToken cancellationToken = default);
    Task RemoveAsync(string key, CancellationToken cancellationToken = default);
    Task ClearAsync(CancellationToken cancellationToken = default);
}