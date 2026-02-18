using FinanceManager.Domain.Shared;
using FinanceManager.Domain.Shared.Interfaces;
using FinanceManager.Infrastructure.Converters.Users;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinanceManager.Infrastructure.Extensions;

public static class EntityConfigurationExtensions
{
    public static void ConfigureEntityIdentifier<TEntity, TId, TIdConverter, TIdComparer>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : Entity<TId>
        where TId : struct
        where TIdConverter : ValueConverter
        where TIdComparer :  ValueComparer<TId>
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasConversion<TIdConverter, TIdComparer>();
    }
    
    public static void ConfigureAuditableFields<TEntity, TId>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : Entity<TId>, IAuditable
        where TId : struct
    {
        builder.Property(p => p.CreatedAt);
        builder.Property(x => x.CreatedBy).HasConversion<UserIdConverter>().IsRequired();
        builder.Property(p => p.UpdatedAt);
        builder.Property(x => x.UpdatedBy).HasConversion<UserIdConverter>();
    }
    
    public static void ConfigureSoftDeleteFields<TEntity, TId>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : Entity<TId>, ISoftDelete
        where TId : struct
    {
        builder.Property(x => x.DeletedAt);
        builder.Property(x => x.DeletedBy).HasConversion<UserIdConverter>();
    }
}