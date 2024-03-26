using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Data.Entities;

namespace TestingSystem.Data.Configuration;
public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRoles");

        builder.HasKey(ur => ur.RoleId);
        builder.Property(ur => ur.RoleName).HasMaxLength(255);

        builder.HasIndex(ur => ur.RoleId);
    }
}
