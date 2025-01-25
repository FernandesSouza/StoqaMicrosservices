using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stoqa.Managment.Domain.Entities;
using Stoqa.Managment.Infraestrutura.ORM.EntitiesMapping.Base;

namespace Stoqa.Managment.Infraestrutura.ORM.EntitiesMapping;

public sealed class AddressMapping : BaseMapping, IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable(nameof(Address), Schema);
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasColumnType("bigint")
            .HasColumnName("id")
            .HasColumnOrder(1);

        builder.Property(a => a.Street)
            .HasColumnType("varchar(150)")
            .HasColumnName("street")
            .HasColumnOrder(2);

        builder.Property(a => a.District)
            .HasColumnType("varchar(150)")
            .HasColumnName("district")
            .HasColumnOrder(3);

        builder.Property(a => a.City)
            .HasColumnType("varchar(150)")
            .HasColumnName("city")
            .HasColumnOrder(4);

        builder.Property(a => a.Number)
            .HasColumnType("varchar(150)")
            .HasColumnName("number")
            .HasColumnOrder(5);

        builder.Property(a => a.Complement)
            .HasColumnType("varchar(150)")
            .HasColumnName("complement")
            .HasColumnOrder(6);

        builder.Property(a => a.State)
            .HasColumnType("varchar(150)")
            .HasColumnName("state")
            .HasColumnOrder(7);

        builder.Property(a => a.ZipCode)
            .HasColumnType("varchar(150)")
            .HasColumnName("zipCode")
            .HasColumnOrder(8);

        builder.Property(a => a.Country)
            .HasColumnType("varchar(150)")
            .HasColumnName("country")
            .HasColumnOrder(9);
    }
}