using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stoqa.OrderCatalog.Domain.Entities;
using Stoqa.OrderCatalog.Infraestrutura.ORM.EntitiesMapping.Base;

namespace Stoqa.OrderCatalog.Infraestrutura.ORM.EntitiesMapping;

public sealed class OrderMapping : BaseMapping, IEntityTypeConfiguration<Orders>
{
    public void Configure(EntityTypeBuilder<Orders> builder)
    {
        builder.ToTable(nameof(Orders), Schema);
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .HasColumnType("bigint")
            .HasColumnName("id")
            .HasColumnOrder(1);

        builder.Property(o => o.Code)
            .HasColumnType("varchar(10)")
            .HasColumnName("code")
            .HasColumnOrder(2);

        builder.Property(o => o.CreateDate)
            .HasColumnType("datetime2")
            .HasColumnName("createDate")
            .HasColumnOrder(3);
        
        builder.Property(o => o.Status)
            .HasColumnType("tinyint")
            .HasColumnName("status")
            .HasColumnOrder(4);

        builder.HasOne(o => o.Sale)
            .WithOne()
            .HasForeignKey<Sale>(s => s.OrderId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(o => o.Return)
            .WithOne()
            .HasForeignKey<Return>(r => r.OrderId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasMany(o => o.ProductOrders)
            .WithOne()
            .HasForeignKey(p => p.OrderId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}