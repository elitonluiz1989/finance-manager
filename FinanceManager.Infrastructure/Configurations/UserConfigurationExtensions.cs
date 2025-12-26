using FinanceManager.Domain.Users;
using FinanceManager.Infrastructure.Converters;
using FinanceManager.Infrastructure.Extensions;
using FinanceManager.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.Configurations;

public sealed class UserConfigurationExtensions : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ConfigureEntityIdentifier<User, UserId, UserIdConverter>();
        
        builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Surname).HasMaxLength(100);
        builder.Property(p => p.IdentityId).IsRequired();
        
        builder.ConfigureSoftDeleteFields<User, UserId>();
        
        builder.HasOne<ApplicationUser>()
            .WithOne()
            .HasForeignKey<User>(p => p.IdentityId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}