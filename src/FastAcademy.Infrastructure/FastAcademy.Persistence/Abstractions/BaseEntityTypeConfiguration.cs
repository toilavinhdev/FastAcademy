using FastAcademy.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastAcademy.Persistence.Abstractions;

public abstract class BaseEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : class, IBaseEntity
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.AutoId)
            .IsUnique();

        builder.Property(x => x.Id)
            .HasColumnOrder(0);
        builder.Property(x => x.AutoId)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn()
            .HasColumnOrder(1);
        
        ConfigureEntity(builder);
    }
    
    protected abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
}