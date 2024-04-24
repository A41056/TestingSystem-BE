using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Data.Entities.Course;

namespace TestingSystem.Data.Configuration
{
    public class CourseDetailTranslationConfiguration : IEntityTypeConfiguration<CourseDetailTranslation>
    {
        public void Configure(EntityTypeBuilder<CourseDetailTranslation> builder)
        {
            builder.ToTable("CourseDetailTranslations");

            builder.HasKey(a => a.CourseDetailId);

            builder.HasOne(a => a.CourseDetail)
                   .WithMany(q => q.CourseDetailTranslations)
                   .HasForeignKey(a => a.CourseDetailId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Language)
                   .WithMany(q => q.CourseDetailTranslations)
                   .HasForeignKey(a => a.LanguageCode)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(a => a.CourseDetailId);
        }
    }
}
