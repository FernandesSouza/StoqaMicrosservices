using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Infraestrutura.ORM.EntitiesMapping.Base;

namespace Stoqa.ProductCatalog.Infraestrutura.ORM.EntitiesMapping;

public class ItemMapping : BaseMapping, IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable(nameof(Item), Schema);
        builder.HasKey(a => a.Id);

        builder.Property(i => i.SerialCode)
            .HasColumnType("varchar(30)")
            .HasColumnName("serial_code")
            .IsRequired()
            .HasColumnOrder(1);

        builder.Property(i => i.CreateDate)
            .HasColumnType("datetime")
            .HasColumnName("create_date")
            .IsRequired()
            .HasColumnOrder(2);

        builder.Property(i => i.StatusItem)
            .HasColumnType("tinyint")
            .HasColumnName("status_item")
            .IsRequired()
            .HasColumnOrder(3);

        builder.Property(pc => pc.ProductId)
            .HasColumnType("bigint")
            .HasColumnName("product_id")
            .IsRequired()
            .HasColumnOrder(4);

        builder.HasOne(p => p.Product)
            .WithMany(p => p.Items)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

    }
}