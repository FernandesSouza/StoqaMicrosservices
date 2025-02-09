using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Infraestrutura.ORM.EntitiesMapping.Base;

namespace Stoqa.ProductCatalog.Infraestrutura.ORM.EntitiesMapping;

public sealed class StockItemMapping : BaseMapping, IEntityTypeConfiguration<StockItem>
{
    public void Configure(EntityTypeBuilder<StockItem> builder)
    {
        builder.ToTable(nameof(StockItem), Schema);
        builder.HasKey(a => a.Id);

        builder.Property(p => p.Id)
            .HasColumnType("bigint")
            .HasColumnName("id")
            .HasColumnOrder(1);

        builder.Property(pc => pc.ProductId)
            .HasColumnType("bigint")
            .HasColumnName("product_id")
            .HasColumnOrder(2);

        builder.Property(pc => pc.Quantity)
            .HasColumnType("int")
            .HasColumnName("quantity")
            .HasColumnOrder(3);

        builder.Property(pc => pc.DepositId)
            .HasColumnType("bigint")
            .HasColumnName("deposit_id")
            .HasColumnOrder(4);

        builder.HasOne(p => p.Product)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasOne(p => p.Product)
            .WithMany(p => p.StockItems)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasOne(p => p.Deposit)
            .WithMany(d => d.StockItems)
            .HasForeignKey(p => p.DepositId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}