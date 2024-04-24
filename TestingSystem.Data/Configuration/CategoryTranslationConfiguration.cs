using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Data.Entities.Category;

namespace TestingSystem.Data.Configuration
{
    public class CategoryTranslationConfiguration : IEntityTypeConfiguration<CategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<CategoryTranslation> builder)
        {
            builder.ToTable("CategoryTranslation");

            builder.HasKey(a => a.CategoryId);

            builder.HasOne(a => a.Category)
                   .WithMany(q => q.CategoryTranslations)
                   .HasForeignKey(a => a.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Language)
                   .WithMany(q => q.CategoryTranslations)
                   .HasForeignKey(a => a.LanguageCode)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(a => a.CategoryId);
        }
    }
}
