using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingSystem.Data.Entities;

namespace TestingSystem.Data.Configuration;
public class WebUserChooseConfiguration : IEntityTypeConfiguration<WebUserChoose>
{
    public void Configure(EntityTypeBuilder<WebUserChoose> builder)
    {
        builder.ToTable("WebUserChooses");

        builder.HasKey(wuc => wuc.Id);

        builder.HasOne(wuc => wuc.Question)
               .WithMany(q => q.WebUserChooses)
               .HasForeignKey(wuc => wuc.QuestionId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(wuc => wuc.Answer)
               .WithMany(wuc => wuc.WebUserChooses)
               .HasForeignKey(wuc => wuc.AnswerId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(wuc => wuc.WebUser)
               .WithMany()
               .HasForeignKey(wuc => wuc.WebUserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(a => a.WebUserId);
        builder.HasIndex(a => a.QuestionId);
        builder.HasIndex(a => a.AnswerId);
    }
}
