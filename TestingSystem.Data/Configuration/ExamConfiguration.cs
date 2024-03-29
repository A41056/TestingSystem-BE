using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Data.Entities;

namespace TestingSystem.Data.Configuration;
public class ExamConfiguration : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder.ToTable("Exams");

        builder.HasKey(e => e.ExamId);
        builder.Property(e => e.Title).HasMaxLength(255);

        builder.HasOne(e => e.Teacher)
            .WithMany(u => u.Exams)
            .HasForeignKey(e => e.CreatedByUserId)
            .IsRequired(true);

        builder.HasMany(e => e.Questions)
               .WithOne(q => q.Exam)
               .HasForeignKey(q => q.ExamId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(a => a.ExamId);
    }
}
