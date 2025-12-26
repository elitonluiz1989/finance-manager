using FinanceManager.Domain.Shared;
using FinanceManager.Domain.Shared.Interfaces;
using FinanceManager.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinanceManager.Infrastructure.Extensions;

public static class EntityConfigurationExtensions
{
    public static void ConfigureEntityIdentifier<TEntity, TId, TIdConverter>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : Entity<TId>
        where TId : struct
        where TIdConverter : ValueConverter
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasConversion<TIdConverter>();
    }
    
    public static void ConfigureAuditableFields<TEntity, TId>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : Entity<TId>, IAuditable
        where TId : struct
    {
        builder.Property(x => x.CreatedAt).HasConversion<UserIdConverter>().IsRequired();
        builder.Property(x => x.UpdatedAt).HasConversion<UserIdConverter>();
    }
    
    public static void ConfigureSoftDeleteFields<TEntity, TId>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : Entity<TId>, ISoftDelete
        where TId : struct
    {
        builder.Property(x => x.DeletedAt);
        builder.Property(x => x.DeletedBy).HasConversion<UserIdConverter>();
    }
}