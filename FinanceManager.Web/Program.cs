using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FinanceManager.Web;
using FinanceManager.Web.Shared.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

builder.Services.AddAuthorizationCore();
builder.Services.AddLocalization();
builder.Services.AddWebServices();
builder.Services.AddApiClient(builder.Configuration);

var host = builder.Build();

await host.Services.LocalizationHandler();

await host.RunAsync();