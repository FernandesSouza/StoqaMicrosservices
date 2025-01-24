using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stoqa.Infra.ORM.EntitiesMapping.Base;
using Stoqa.OrderCatalog.Domain.Entities;

namespace Stoqa.OrderCatalog.Infraestrutura.ORM.EntitiesMapping;

public sealed class SaleMapping : BaseMapping, IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable(nameof(Sale), Schema);
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .HasColumnType("bigint")
            .HasColumnName("id")
            .HasColumnOrder(1);

        builder.Property(s => s.Invoice)
            .HasColumnType("varchar(100)")
            .HasColumnName("invoice")
            .HasColumnOrder(2);

        builder.Property(s => s.Value)
            .HasColumnType("decimal(18,2)")
            .HasColumnName("value")
            .HasColumnOrder(3);

        builder.Property(s => s.Shipping)
            .HasColumnType("bit")
            .HasColumnName("shipping")
            .HasColumnOrder(4);

        builder.Property(s => s.OrderId)
            .HasColumnType("bigint")
            .HasColumnName("orderId")
            .HasColumnOrder(5);

        builder.HasOne(s => s.Transport)
            .WithOne()
            .HasForeignKey<Sale>(s => s.OrderId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(s => s.Customer)
            .WithOne()
            .HasForeignKey<Sale>(s => s.Id)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}