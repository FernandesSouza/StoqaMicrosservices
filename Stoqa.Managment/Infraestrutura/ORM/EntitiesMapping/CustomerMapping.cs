using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stoqa.Managment.Domain.Entities;
using Stoqa.Managment.Infraestrutura.ORM.EntitiesMapping.Base;

namespace Stoqa.Managment.Infraestrutura.ORM.EntitiesMapping;

public sealed class CustomerMapping : BaseMapping, IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(nameof(Customer), Schema);
        builder.HasKey(a => a.Id);

        builder.Property(c => c.Id)
            .HasColumnType("bigint")
            .HasColumnName("id")
            .HasColumnOrder(1);

        builder.Property(c => c.Name)
            .HasColumnType("varchar(150)")
            .HasColumnName("name")
            .HasColumnOrder(2);

        builder.Property(c => c.Document)
            .HasColumnType("varchar(50)")
            .HasColumnName("document")
            .HasColumnOrder(3);

        builder.Property(c => c.CreateDate)
            .HasColumnType("datetime")
            .HasColumnName("createDate")
            .HasColumnOrder(4);

        builder.Property(c => c.CustomerType)
            .HasColumnType("tinyint")
            .HasColumnName("customerType")
            .HasColumnOrder(5);
        
        builder.Property(f => f.AddressId)
            .HasColumnType("bigint")
            .HasColumnName("address_id")
            .HasColumnOrder(6)
            .IsRequired();

        builder.HasOne(c => c.Address)
            .WithOne()
            .HasForeignKey<Customer>(c => c.AddressId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
    }
}