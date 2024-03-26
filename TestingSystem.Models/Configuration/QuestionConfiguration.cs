using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Data.Entities;

namespace TestingSystem.Data.Configuration;
public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable("Questions");

        builder.HasKey(q => q.Id);
        builder.Property(q => q.Explanation).HasMaxLength(500);
        builder.Property(q => q.Note).HasMaxLength(500);
        builder.HasMany(q => q.Answers)
               .WithOne(a => a.Question)
               .HasForeignKey(a => a.QuestionId)
               .OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex(a => a.Id);

    }
}
