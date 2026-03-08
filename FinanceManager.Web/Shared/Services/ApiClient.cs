using System.Net.Http.Json;
using FinanceManager.Web.Shared.Options;

namespace FinanceManager.Web.Shared.Services;

public sealed class ApiClient(HttpClient client)
{
    public async Task<T?> GetAsync<T>(string uri) => await client.GetFromJsonAsync<T>(uri, JsonOptions.Default);

    public async Task<HttpResponseMessage> PostAsync<T>(string uri, T data) => 
        await client.PostAsJsonAsync(uri, data, JsonOptions.Default);

    public async Task<HttpResponseMessage> PutAsync<T>(string uri, T data) => 
        await client.PutAsJsonAsync(uri, data, JsonOptions.Default);

    public async Task<HttpResponseMessage> DeleteAsync(string uri) => await client.DeleteAsync(uri);
}