using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stoqa.Infra.ORM.EntitiesMapping.Base;
using Stoqa.Order.Domain.Entities;
using Stoqa.OrderCatalog.Domain.Entities;

namespace Stoqa.OrderCatalog.Infraestrutura.ORM.EntitiesMapping;

public sealed class OrderMapping : BaseMapping, IEntityTypeConfiguration<Orders>
{
    public void Configure(EntityTypeBuilder<Orders> builder)
    {
        builder.ToTable(nameof(Order), Schema);
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .HasColumnType("bigint")
            .HasColumnName("id")
            .HasColumnOrder(1);

        builder.Property(o => o.CollaboratorId)
            .HasColumnType("uniqueidentifier")
            .HasColumnName("collaboratorId")
            .HasColumnOrder(2);

        builder.Property(o => o.Code)
            .HasColumnType("varchar(10)")
            .HasColumnName("code")
            .HasColumnOrder(3);

        builder.Property(o => o.CreateDate)
            .HasColumnType("datetime")
            .HasColumnName("createDate")
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

        builder.HasMany(o => o.Product)
            .WithOne()
            .HasForeignKey(p => p.Id)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasOne(o => o.Collaborator)
            .WithOne()
            .HasForeignKey<Orders>(o => o.CollaboratorId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}