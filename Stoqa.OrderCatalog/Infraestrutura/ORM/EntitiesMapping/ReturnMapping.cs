using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stoqa.OrderCatalog.Domain.Entities;
using Stoqa.OrderCatalog.Infraestrutura.ORM.EntitiesMapping.Base;

namespace Stoqa.OrderCatalog.Infraestrutura.ORM.EntitiesMapping;

public sealed class ReturnMapping : BaseMapping, IEntityTypeConfiguration<Return>
{
    public void Configure(EntityTypeBuilder<Return> builder)
    {
        builder.ToTable(nameof(Return), Schema);
        builder.HasKey(r => r.Id);

        builder.Property(r => r.OrderId)
            .HasColumnType("bigint")
            .HasColumnName("orderId")
            .HasColumnOrder(1);

        builder.Property(r => r.Description)
            .HasColumnType("varchar(250)")
            .HasColumnName("description")
            .HasColumnOrder(2);

        builder.Property(r => r.Approved)
            .HasColumnType("bit")
            .HasColumnName("approved")
            .HasColumnOrder(3);

        builder.Property(r => r.Code)
            .HasColumnType("varchar(50)")
            .HasColumnName("code")
            .HasColumnOrder(4);

        builder.Property(r => r.CreateDate)
            .HasColumnType("datetime")
            .HasColumnName("createDate")
            .HasColumnOrder(5);

        builder.HasOne(r => r.Transport)
            .WithOne()
            .HasForeignKey<Return>(r => r.OrderId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}