using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stoqa.Infra.ORM.EntitiesMapping.Base;
using Stoqa.OrderCatalog.Domain.Entities;

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

        builder.Property(p => p.Description)
            .HasColumnType("varchar(250)")
            .HasColumnName("description")
            .HasColumnOrder(4);

        builder.Property(p => p.Code)
            .HasColumnType("varchar(50)")
            .HasColumnName("code")
            .HasColumnOrder(5);

        builder.Property(p => p.Active)
            .HasColumnType("bit")
            .HasColumnName("active")
            .HasColumnOrder(6);

        builder.Property(p => p.CreateDate)
            .HasColumnType("datetime")
            .HasColumnName("createDate")
            .HasColumnOrder(7);

        builder.HasMany(p => p.PackingCompositions)
            .WithOne()
            .HasForeignKey(pc => pc.ProductId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}