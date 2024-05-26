using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Data.Entities;

namespace TestingSystem.Data.Configuration
{
    public class AnswerTranslationConfiguration : IEntityTypeConfiguration<AnswerTranslation>
    {
        public void Configure(EntityTypeBuilder<AnswerTranslation> builder)
        {
            builder.ToTable("AnswerTranslations");

            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Answer)
                   .WithMany(q => q.AnswerTranslations)
                   .HasForeignKey(a => a.AnswerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(a => a.Id);
        }
    }
}
