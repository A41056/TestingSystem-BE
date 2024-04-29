using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Data.Entities;

namespace TestingSystem.Data.Configuration
{
    public class LessionTranslationConfiguration : IEntityTypeConfiguration<LessionTranslation>
    {
        public void Configure(EntityTypeBuilder<LessionTranslation> builder)
        {
            builder.ToTable("LessionTranslations");

            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Lession)
                   .WithMany(q => q.LessionTranslations)
                   .HasForeignKey(a => a.LessionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Language)
                   .WithMany(q => q.LessionTranslations)
                   .HasForeignKey(a => a.LanguageCode)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(a => a.Id);
        }
    }
}
