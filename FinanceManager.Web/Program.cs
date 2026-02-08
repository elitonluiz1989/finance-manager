using System.Globalization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FinanceManager.Web;
using FinanceManager.Web.Extensions;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

builder.Services.AddAuthorizationCore();
builder.Services.AddLocalization();
builder.Services.AddWebServices();
builder.Services.AddApiClient(builder.Configuration);

var host = builder.Build();

var result = await host.Services.GetRequiredService<IJSRuntime>().InvokeAsync<string>("localStorage.getItem", "culture");

if (!string.IsNullOrEmpty(result))
{
    var culture = new CultureInfo(result);
    
    CultureInfo.DefaultThreadCurrentCulture = culture;
    CultureInfo.DefaultThreadCurrentUICulture = culture;
}

await host.RunAsync();