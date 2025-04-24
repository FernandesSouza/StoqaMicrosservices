using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stoqa.Identity.Domain.Entities;
using Stoqa.Identity.Infraestrutura.EntitiesMapping.Base;

namespace Stoqa.Identity.Infraestrutura.EntitiesMapping;

public sealed class UserRoleMapping : BaseMapping, IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable(nameof(UserRole), Schema);
        builder.HasKey(ur => new { ur.UserId, ur.RoleId });

        builder.Property(ur => ur.UserId)
            .HasColumnType("uuid")
            .HasColumnName("user_id")
            .HasColumnOrder(1);

        builder.Property(ur => ur.RoleId)
            .HasColumnType("uuid")
            .HasColumnName("role_id")
            .HasColumnOrder(2);

        builder.HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}