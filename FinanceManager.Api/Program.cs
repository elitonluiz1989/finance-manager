using FinanceManager.Api.Endpoints;
using FinanceManager.Api.Extensions;
using FinanceManager.Application;
using FinanceManager.Infrastructure.Contexts;
using FinanceManager.Infrastructure.Extensions;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddApiServices();
builder.Services.AddApiLocation(builder.Configuration);
builder.Services.AddApiAuthentication(builder.Configuration, builder.Environment);
builder.Services.AddApiJsonConverters();
builder.Services.AddApiCors(builder.Configuration);
builder.Services.AddHealthChecks()
    .AddDbContextCheck<ApplicationDbContext>(
        name: "sqlite",
        failureStatus: HealthStatus.Unhealthy
    );

var app = builder.Build();

app.ApplyMigrations();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.UseRequestLocalization();

app.MapInfoEndpoints();
app.MapHealthChecks("/health");
app.MapAuthEndpoints();
app.MapUsersEndpoints();
app.MapOpenApi();

app.Run();