using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Data.Entities;

namespace TestingSystem.Data.Configuration
{
    public class LanguageTagConfiguration : IEntityTypeConfiguration<LanguageTag>
    {
        public void Configure(EntityTypeBuilder<LanguageTag> builder)
        {
            builder.ToTable("LanguageTags");

            builder.HasKey(a => a.Code);

            builder.Property(l => l.Code).HasMaxLength(5).IsUnicode(false);
        }
    }
}
