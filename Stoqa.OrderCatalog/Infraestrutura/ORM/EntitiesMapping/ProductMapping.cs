using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stoqa.OrderCatalog.Domain.Entities;
using Stoqa.OrderCatalog.Infraestrutura.ORM.EntitiesMapping.Base;

namespace Stoqa.OrderCatalog.Infraestrutura.ORM.EntitiesMapping;

public sealed class ProductMapping : BaseMapping, IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product), Schema);
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnType("bigint")
            .HasColumnName("id")
            .HasColumnOrder(1);

        builder.Property(p => p.Name)
            .HasColumnType("varchar(150)")
            .HasColumnName("name")
            .HasColumnOrder(2);

        builder.Property(p => p.Price)
            .HasColumnType("decimal(18,2)")
            .HasColumnName("price")
            .HasColumnOrder(3);

        builder.Property(p => p.Code)
            .HasColumnType("varchar(50)")
            .HasColumnName("code")
            .HasColumnOrder(4);
    }
}