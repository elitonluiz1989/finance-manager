using System.Text.Json;
using FinanceManager.Web.Shared.Constants;
using Microsoft.JSInterop;

namespace FinanceManager.Web.Shared.Services;

public sealed class StorageService(IJSRuntime js)
{
    public async Task<TValue?> GetAsync<TValue>(string key, CancellationToken cancellationToken = default)
    {
        try
        {
            var json = await js.InvokeAsync<string?>(LocalStorageConst.GetItem, cancellationToken, key, cancellationToken);

            return string.IsNullOrWhiteSpace(json)
                ? default
                : JsonSerializer.Deserialize<TValue>(json);
        } catch
        {
            return default;
        }
    }

    public async Task SetAsync<TValue>(string key, TValue value, CancellationToken cancellationToken = default)
    {
        var json = JsonSerializer.Serialize(value);
        
        await js.InvokeVoidAsync(LocalStorageConst.SetItem, cancellationToken, key, json);
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken = default) =>
        await js.InvokeVoidAsync(LocalStorageConst.RemoveItem, cancellationToken, key);

    public async Task ClearAsync(CancellationToken cancellationToken = default) => 
        await js.InvokeVoidAsync(LocalStorageConst.Clear, cancellationToken);
}