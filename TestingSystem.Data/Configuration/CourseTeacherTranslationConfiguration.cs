using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Data.Entities.Course;

namespace TestingSystem.Data.Configuration
{
    public class CourseTeacherTranslationConfiguration : IEntityTypeConfiguration<CourseTeacherTranslation>
    {
        public void Configure(EntityTypeBuilder<CourseTeacherTranslation> builder)
        {
            builder.ToTable("CourseTeacherTranslations");

            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.CourseTeacher)
                   .WithMany(q => q.CourseTeacherTranslations)
                   .HasForeignKey(a => a.CourseTeacherId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Language)
                   .WithMany(q => q.CourseTeacherTranslations)
                   .HasForeignKey(a => a.LanguageCode)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(a => a.Id);
        }
    }
}
