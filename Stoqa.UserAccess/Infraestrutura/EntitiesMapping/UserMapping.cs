using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stoqa.Identity.Domain.Entities;
using Stoqa.Identity.Infraestrutura.EntitiesMapping.Base;

namespace Stoqa.Identity.Infraestrutura.EntitiesMapping;

public sealed class UserMapping : BaseMapping, IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User), Schema);
        builder.HasKey(a => a.Id);

        builder.Property(c => c.Id)
            .HasColumnType("uuid")
            .HasColumnName("id")
            .HasColumnOrder(1);

        builder.Property(u => u.CreationDate)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("creation_date")
            .HasColumnOrder(2);

        builder.Property(u => u.DisplayName)
            .HasColumnType("varchar(150)")
            .HasColumnName("display_name")
            .HasColumnOrder(3);

        builder.Property(u => u.NormalizedDisplayName)
            .HasColumnType("varchar(150)")
            .HasColumnName("normalized_display_name")
            .HasColumnOrder(4);

        builder.Property(u => u.Document)
            .HasColumnType("varchar(150)")
            .HasColumnName("document")
            .HasColumnOrder(5);

        builder.Property(u => u.PasswordHash)
            .HasColumnType("text")
            .HasColumnName("password")
            .HasColumnOrder(6);

        builder.Property(u => u.Status)
            .HasColumnType("smallint")
            .HasColumnName("status")
            .HasColumnOrder(7)
            .IsRequired();

        builder.Property(u => u.UserType)
            .HasColumnType("smallint")
            .HasColumnName("user_type")
            .HasColumnOrder(8)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasColumnType("varchar(256)")
            .HasColumnName("email");

        builder.Property(u => u.EmailConfirmed)
            .HasColumnType("boolean")
            .HasColumnName("email_confirmed");

        builder.Property(u => u.PhoneNumber)
            .HasColumnType("varchar(20)")
            .HasColumnName("cell_phone");

        builder.Property(u => u.PhoneNumberConfirmed)
            .HasColumnType("boolean")
            .HasColumnName("cell_phone_confirmed");

        builder.Property(u => u.AccessFailedCount)
            .HasColumnName("access_failed_count");

        builder.Property(u => u.NormalizedEmail)
            .HasColumnType("varchar(256)")
            .HasColumnName("normalized_email");
    }
}