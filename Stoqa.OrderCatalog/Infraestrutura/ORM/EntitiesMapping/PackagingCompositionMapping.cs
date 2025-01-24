using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stoqa.Infra.ORM.EntitiesMapping.Base;
using Stoqa.OrderCatalog.Domain.Entities;

namespace Stoqa.OrderCatalog.Infraestrutura.ORM.EntitiesMapping;

public sealed class PackagingCompositionMapping : BaseMapping, IEntityTypeConfiguration<PackagingComposition>
{
    public void Configure(EntityTypeBuilder<PackagingComposition> builder)
    {
        builder.ToTable(nameof(PackagingComposition), Schema);
        builder.HasKey(a => a.Id);

        builder.Property(pc => pc.Level)
            .HasColumnType("int")
            .HasColumnName("level")
            .HasColumnOrder(1);

        builder.Property(pc => pc.Quantity)
            .HasColumnType("int")
            .HasColumnName("quantity")
            .HasColumnOrder(2);

        builder.Property(pc => pc.ProductId)
            .HasColumnType("bigint")
            .HasColumnName("productId")
            .HasColumnOrder(3);

        builder.Property(pc => pc.Packing)
            .HasColumnType("tinyint")
            .HasColumnName("packing")
            .HasColumnOrder(4);
    }
}