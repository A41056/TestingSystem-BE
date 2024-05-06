using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Data.Entities;

namespace TestingSystem.Data.Configuration
{
    public class UserHistoryConfiguration : IEntityTypeConfiguration<UserHistory>
    {
        public void Configure(EntityTypeBuilder<UserHistory> builder)
        {
            builder.ToTable("UserHistories");

            builder.HasKey(ur => ur.Id);

            builder.HasOne(uh => uh.User)
                .WithMany(u => u.UserHistories)
                .HasForeignKey(uh => uh.UserId);

            builder.HasOne(uh => uh.Course)
                .WithMany(u => u.UserHistories)
                .HasForeignKey(uh => uh.CourseId);

            builder.HasIndex(ur => ur.Id);
        }
    }
}
