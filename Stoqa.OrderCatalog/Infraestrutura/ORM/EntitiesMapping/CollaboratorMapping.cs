using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stoqa.Infra.ORM.EntitiesMapping.Base;
using Stoqa.OrderCatalog.Domain.Entities;

namespace Stoqa.OrderCatalog.Infraestrutura.ORM.EntitiesMapping;

public sealed class CollaboratorMapping : BaseMapping, IEntityTypeConfiguration<Collaborator>
{
    public void Configure(EntityTypeBuilder<Collaborator> builder)
    {
        builder.ToTable(nameof(Collaborator), Schema);
        builder.HasKey(a => a.Id);

        builder.HasOne(c => c.Address)
            .WithOne()
            .HasForeignKey<Collaborator>(c => c.AddressId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.Property(c => c.Id)
            .HasColumnType("uniqueidentifier")
            .HasColumnName("id")
            .HasColumnOrder(1);

        builder.Property(c => c.Name)
            .HasColumnType("varchar(150)")
            .HasColumnName("name")
            .HasColumnOrder(2);

        builder.Property(c => c.Password)
            .HasColumnType("varchar(30)")
            .HasColumnName("password")
            .HasColumnOrder(3);

        builder.Property(c => c.Document)
            .HasColumnType("varchar(150)")
            .HasColumnName("document")
            .HasColumnOrder(4);

        builder.Property(c => c.Role)
            .HasColumnType("tinyint")
            .HasColumnName("role")
            .HasColumnOrder(5);

        builder.Property(c => c.Gender)
            .HasColumnType("tinyint")
            .HasColumnName("gender")
            .HasColumnOrder(6);

        builder.Property(c => c.CreateDate)
            .HasColumnType("datetime")
            .HasColumnName("createDate")
            .HasColumnOrder(7);
    }
}