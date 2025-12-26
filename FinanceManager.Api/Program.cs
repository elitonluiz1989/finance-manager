using FinanceManager.Api.Endpoints;
using FinanceManager.Api.JsonContexts;
using FinanceManager.Application;
using FinanceManager.Infrastructure.Contexts;
using FinanceManager.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.ConfigureHttpJsonOptions(options =>  
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, UsersJsonContext.Default)
);
builder.Services.AddAuthentication(IdentityConstants.BearerScheme).AddBearerToken();
builder.Services.AddAuthorizationBuilder();
builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddApiEndpoints();
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();

app.ApplyMigrations();

await app.ApplySeeds(app.Configuration);

app.MapUsersEndpoints();

app.Run();