using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stoqa.Infra.ORM.EntitiesMapping.Base;
using Stoqa.OrderCatalog.Domain.Entities;

namespace Stoqa.OrderCatalog.Infraestrutura.ORM.EntitiesMapping;

public sealed class TransportMapping : BaseMapping, IEntityTypeConfiguration<Transport>
{
    public void Configure(EntityTypeBuilder<Transport> builder)
    {
        builder.ToTable(nameof(Transport), Schema);
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .HasColumnType("bigint")
            .HasColumnName("id")
            .HasColumnOrder(1);

        builder.Property(t => t.TransportType)
            .HasColumnType("tinyint")
            .HasColumnName("transportType")
            .HasColumnOrder(2);

        builder.Property(t => t.Freight)
            .HasColumnType("decimal(18,2)")
            .HasColumnName("freight")
            .HasColumnOrder(3);

        builder.Property(t => t.TrackingCode)
            .HasColumnType("varchar(100)")
            .HasColumnName("trackingCode")
            .HasColumnOrder(4);

        builder.Property(t => t.StandardQuote)
            .HasColumnType("decimal(18,2)")
            .HasColumnName("standardQuote")
            .HasColumnOrder(5);
    }
}