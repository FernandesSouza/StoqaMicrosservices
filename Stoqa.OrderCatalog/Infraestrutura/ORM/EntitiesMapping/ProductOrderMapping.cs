using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stoqa.OrderCatalog.Domain.Entities;
using Stoqa.OrderCatalog.Infraestrutura.ORM.EntitiesMapping.Base;

namespace Stoqa.OrderCatalog.Infraestrutura.ORM.EntitiesMapping;

public sealed class ProductOrderMapping : BaseMapping, IEntityTypeConfiguration<ProductOrder>
{
    public void Configure(EntityTypeBuilder<ProductOrder> builder)
    {
        builder.ToTable(nameof(ProductOrder), Schema);
        builder.HasKey(po => po.Id);

        builder.Property(s => s.Id)
            .HasColumnType("bigint")
            .HasColumnName("id")
            .HasColumnOrder(1);

        builder.Property(s => s.OrderId)
            .HasColumnType("bigint")
            .HasColumnName("order_id")
            .HasColumnOrder(2);

        builder.Property(s => s.ProductId)
            .HasColumnType("bigint")
            .HasColumnName("product_id")
            .HasColumnOrder(3);
    }
}