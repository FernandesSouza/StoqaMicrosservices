using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stoqa.Identity.Domain.Entities;
using Stoqa.Identity.Infraestrutura.EntitiesMapping.Base;

namespace Stoqa.Identity.Infraestrutura.EntitiesMapping;

public sealed class RoleMapping : BaseMapping, IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(nameof(Role), Schema);
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .HasColumnType("uuid")
            .HasColumnName("id")
            .HasColumnOrder(1)
            .ValueGeneratedOnAdd();

        builder.Property(r => r.Name)
            .HasColumnType("varchar(250)")
            .HasMaxLength(250)
            .IsUnicode()
            .HasColumnName("name")
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(r => r.Active)
            .HasColumnType("boolean")
            .HasColumnName("active")
            .HasColumnOrder(3)
            .IsRequired();


        builder.HasIndex(r => r.NormalizedName).IsUnique(false);
        builder.Property(r => r.NormalizedName)
            .HasColumnType("varchar(250)")
            .HasMaxLength(250)
            .IsUnicode()
            .HasColumnName("normalized_name")
            .HasColumnOrder(5)
            .IsRequired(false);

        builder.Property(r => r.ConcurrencyStamp)
            .HasColumnName("concurrency_stamp")
            .HasColumnOrder(6)
            .IsRequired(false);
    }
}