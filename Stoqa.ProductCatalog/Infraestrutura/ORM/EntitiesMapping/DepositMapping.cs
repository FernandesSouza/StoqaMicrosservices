using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Infraestrutura.ORM.EntitiesMapping.Base;

namespace Stoqa.ProductCatalog.Infraestrutura.ORM.EntitiesMapping;

public sealed class DepositMapping : BaseMapping, IEntityTypeConfiguration<Deposit>
{
    public void Configure(EntityTypeBuilder<Deposit> builder)
    {
        builder.ToTable(nameof(Deposit), Schema);
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .HasColumnType("bigint")
            .HasColumnName("id")
            .HasColumnOrder(1);

        builder.Property(d => d.DepositName)
            .HasColumnType("varchar(150)")
            .HasColumnName("product_id")
            .HasColumnOrder(2);

        builder.Property(d => d.Identifier)
            .HasColumnType("varchar(20)")
            .HasColumnName("identifier")
            .HasColumnOrder(3);

        builder.Property(d => d.Active)
            .HasColumnType("bit")
            .HasColumnName("active")
            .HasColumnOrder(4);

        builder.HasMany(d => d.StockItems)
            .WithOne()
            .HasForeignKey(d => d.DepositId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}