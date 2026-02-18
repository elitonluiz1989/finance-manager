using FinanceManager.Domain.Accounts;
using FinanceManager.Infrastructure.Comparers;
using FinanceManager.Infrastructure.Constants;
using FinanceManager.Infrastructure.Converters.Accounts;
using FinanceManager.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.Configurations;

public sealed class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable(ConfigurationsConst.Accounts);
        
        builder.ConfigureEntityIdentifier<Account, AccountId, AccountIdConverter, AccountIdComparer>();

        builder.Property(a => a.Name).HasMaxLength(50).IsRequired();
        builder.Property(a => a.Type).IsRequired();
        builder.Property(a => a.UserId).IsRequired();
        
        builder.ConfigureAuditableFields<Account, AccountId>();
        builder.ConfigureSoftDeleteFields<Account, AccountId>();
        
        builder.HasOne(a => a.User)
            .WithMany(u => u.Accounts)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}