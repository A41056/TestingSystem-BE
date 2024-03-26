using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Data.Entities;

namespace TestingSystem.Data.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.UserName).HasMaxLength(255);
        builder.Property(u => u.Email).HasMaxLength(255);
        builder.Property(u => u.PhoneNumber).HasMaxLength(20);
        builder.Property(u => u.Gender).HasMaxLength(10);
        builder.Property(u => u.FullTextSearch).HasMaxLength(255);

        builder.HasOne(u => u.UserRole)
               .WithMany(ur => ur.Users)
               .HasForeignKey(u => u.RoleId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(u => u.UserName);
        builder.HasIndex(u => u.Email);
        builder.HasIndex(u => u.PhoneNumber);
    }
}
