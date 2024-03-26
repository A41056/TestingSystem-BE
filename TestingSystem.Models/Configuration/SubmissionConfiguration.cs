using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Data.Entities;

namespace TestingSystem.Data.Configuration;
public class SubmissionConfiguration : IEntityTypeConfiguration<Submission>
{
    public void Configure(EntityTypeBuilder<Submission> builder)
    {
        builder.ToTable("Submissions");

        builder.HasKey(s => s.Id);
        builder.HasOne(s => s.Student)
               .WithMany(u => u.Submissions)
               .HasForeignKey(s => s.StudentId)
               .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(s => s.Exam)
               .WithMany(e => e.Submissions)
               .HasForeignKey(s => s.ExamId)
               .OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(a => a.Id);

    }
}
