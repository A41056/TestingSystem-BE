using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Data.Entities;

namespace TestingSystem.Data.Configuration
{
    public class QuestionTranslationConfiguration : IEntityTypeConfiguration<QuestionTranslation>
    {
        public void Configure(EntityTypeBuilder<QuestionTranslation> builder)
        {
            builder.ToTable("QuestionTranslations");

            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Question)
                   .WithMany(q => q.QuestionTranslations)
                   .HasForeignKey(a => a.QuestionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(a => a.Id);
        }
    }
}
