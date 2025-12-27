using FinanceManager.Api.Endpoints;
using FinanceManager.Api.Extensions;
using FinanceManager.Application;
using FinanceManager.Infrastructure.Extensions;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddApiServices();
builder.Services.AddApiLocation();
builder.Services.AddApiAuthentication(builder.Environment);
builder.Services.AddApiJsonConverters();

var app = builder.Build();

app.ApplyMigrations();

app.UseRequestLocalization();

app.MapAuthEndpoints();
app.MapUsersEndpoints();
app.MapOpenApi();

app.Run();