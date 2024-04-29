using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Data.Entities.Course;

namespace TestingSystem.Data.Configuration
{
    public class CourseTeacherConfiguration : IEntityTypeConfiguration<CourseTeacher>
    {
        public void Configure(EntityTypeBuilder<CourseTeacher> builder)
        {
            builder.ToTable("CourseTeachers");

            builder.HasKey(a => a.Id);

            builder.HasOne(ct => ct.Teacher)
                .WithMany(ct => ct.CourseTeachers)
                .HasForeignKey(ct => ct.TeacherId);

            builder.HasOne(ct => ct.Course)
                .WithMany(c => c.CourseTeachers)
                .HasForeignKey(d => d.CourseId);

            builder.HasIndex(a => a.Id);
        }
    }
}
