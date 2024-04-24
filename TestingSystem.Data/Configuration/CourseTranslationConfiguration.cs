using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Data.Entities.Course;

namespace TestingSystem.Data.Configuration
{
    public class CourseTranslationConfiguration : IEntityTypeConfiguration<CourseTranslation>
    {
        public void Configure(EntityTypeBuilder<CourseTranslation> builder)
        {
            builder.ToTable("CourseTranslations");

            builder.HasKey(a => a.CourseId);

            builder.HasOne(a => a.Course)
                   .WithMany(q => q.CourseTranslations)
                   .HasForeignKey(a => a.CourseId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(a => a.CourseId);
        }
    }
}
