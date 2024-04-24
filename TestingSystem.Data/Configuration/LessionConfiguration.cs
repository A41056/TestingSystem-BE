using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Data.Entities;

namespace TestingSystem.Data.Configuration
{
    public class LessionConfiguration : IEntityTypeConfiguration<Lession>
    {
        public void Configure(EntityTypeBuilder<Lession> builder)
        {
            builder.ToTable("Lessions");

            builder.HasKey(a => a.Id);

            builder.HasOne(l => l.Course)
                .WithMany(c => c.Lessions)
                .HasForeignKey(l => l.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
