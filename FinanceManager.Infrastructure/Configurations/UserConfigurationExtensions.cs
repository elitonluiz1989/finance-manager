using FinanceManager.Domain.Users;
using FinanceManager.Infrastructure.Comparers;
using FinanceManager.Infrastructure.Converters;
using FinanceManager.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.Configurations;

public sealed class UserConfigurationExtensions : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        
        builder.ConfigureEntityIdentifier<User, UserId, UserIdConverter, UserIdComparer>();
        
        builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Surname).HasMaxLength(100);
        builder.Property(p => p.IdentityId).IsRequired();
        
        builder.ConfigureSoftDeleteFields<User, UserId>();
        
        builder.HasOne<IdentityUser>()
            .WithOne()
            .HasForeignKey<User>(p => p.IdentityId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}