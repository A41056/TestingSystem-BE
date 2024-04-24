using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Data.Entities.Course;

namespace TestingSystem.Data.Configuration
{
    public class CourseDetailConfiguration : IEntityTypeConfiguration<CourseDetail>
    {
        public void Configure(EntityTypeBuilder<CourseDetail> builder)
        {
            builder.ToTable("CourseDetails");

            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Course)
                   .WithMany(q => q.CourseDetails)
                   .HasForeignKey(a => a.CourseId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(a => a.CourseId);
        }
    }
}
