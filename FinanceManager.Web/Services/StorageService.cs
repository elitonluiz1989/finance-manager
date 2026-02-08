using System.Text.Json;
using FinanceManager.Web.Shared.Interfaces;
using Microsoft.JSInterop;

namespace FinanceManager.Web.Services;

public sealed class StorageService(IJSRuntime js) : IStorageService
{
    private const string LocalStorageGetItem = "localStorage.getItem";
    private const string LocalStorageSetItem = "localStorage.setItem";
    private const string LocalStorageRemoveItem = "localStorage.removeItem";
    private const string LocalStorageClear = "localStorage.clear";
    
    public async Task<TValue?> GetAsync<TValue>(string key, CancellationToken cancellationToken = default)
    {
        var json = await js.InvokeAsync<string?>(LocalStorageGetItem, cancellationToken, key, cancellationToken);
        
        return string.IsNullOrWhiteSpace(json)
            ? default
            : JsonSerializer.Deserialize<TValue>(json);
    }

    public async Task SetAsync<TValue>(string key, TValue value, CancellationToken cancellationToken = default)
    {
        var json = JsonSerializer.Serialize(value);
        
        await js.InvokeVoidAsync(LocalStorageSetItem, cancellationToken, key, json);
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        await js.InvokeVoidAsync(LocalStorageRemoveItem, cancellationToken, key);
    }

    public async Task ClearAsync(CancellationToken cancellationToken = default)
    {
        await js.InvokeVoidAsync(LocalStorageClear, cancellationToken);
    }
}