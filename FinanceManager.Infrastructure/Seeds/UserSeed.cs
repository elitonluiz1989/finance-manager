using FinanceManager.Domain.Shared.Interfaces;
using FinanceManager.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.Infrastructure.Seeds;

public static class UserSeed
{
    public static async Task SeedAsync(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        var usersConfigurations = configuration.GetSection("Users").GetChildren().ToArray();

        if (usersConfigurations.Length == 0) return;
        
        using var scope = serviceProvider.CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

        foreach (var userConfiguration in usersConfigurations)
        {
            var role = await HandleRoleAsync(userConfiguration, roleManager);
            
            if (role is null) continue;
            
            var identityUser = await HandleIdentityUserAsync(userConfiguration, role, userManager);
            
            if (identityUser is null) continue;
            
            await HandleDomainUserAsync(userConfiguration, identityUser, userRepository);
        }

        await unitOfWork.SaveChangesAsync();
    }

    private static async Task<IdentityRole?> HandleRoleAsync(IConfigurationSection userConfig, RoleManager<IdentityRole> roleManager)
    {
        var roleName = userConfig["Role"];

        if (string.IsNullOrWhiteSpace(roleName)) return null;
        
        var role = await roleManager.FindByNameAsync(roleName);

        if (role is not null) return role;
        
        role = new IdentityRole(roleName);

        var result = await roleManager.CreateAsync(role);

        return result.Succeeded ? role : null;
    }

    private static async Task<IdentityUser?> HandleIdentityUserAsync(
        IConfigurationSection userConfig,
        IdentityRole role,
        UserManager<IdentityUser> userManager
    )
    {
        var username = userConfig["Username"];
        var password = userConfig["Password"];

        if (string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(password) ||
            string.IsNullOrWhiteSpace(role.Name)) return null;
        
        var user = await userManager.FindByNameAsync(username);

        if (user is not null) return null;
        
        user = new IdentityUser
        {
            UserName = username,
            Email = userConfig["Email"],
            EmailConfirmed = true,
        };
        
        var result = await userManager.CreateAsync(user, password);
        
        if (!result.Succeeded) return null;
        
        var isInRole = await userManager.IsInRoleAsync(user, role.Name);

        if (isInRole) return user;
        
        await userManager.AddToRoleAsync(user, role.Name);

        return user;
    }

    private static async Task HandleDomainUserAsync(
        IConfigurationSection userConfig,
        IdentityUser identityUser,
        IUserRepository userRepository
    )
    {
        var userExists = await userRepository.AnyAsync(p => p.IdentityId == identityUser.Id);

        if (userExists) return;
        
        var user = new User
        {
            Name = userConfig["Name"] ?? string.Empty,
            Surname = userConfig["Surname"],
            IdentityId = identityUser.Id,
        };
        
        userRepository.Create(user);
    }
}