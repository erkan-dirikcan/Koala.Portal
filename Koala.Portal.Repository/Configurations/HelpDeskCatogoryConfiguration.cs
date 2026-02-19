using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class HelpDeskCatogoryConfiguration : IEntityTypeConfiguration<HelpDeskCategory>
    {
        public void Configure(EntityTypeBuilder<HelpDeskCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.HelpDeskProblems)
                .WithMany(x => x.Catogory)
                .UsingEntity<HelpDeskProblemCatogory>(
                    x => x.HasOne<HelpDeskProblem>().WithMany().HasForeignKey(x => x.HelpDeskProblemId),
                    x => x.HasOne<HelpDeskCategory>().WithMany().HasForeignKey(x => x.CatogoryId),
                    x => x.HasKey(x => new { x.CatogoryId, x.HelpDeskProblemId })
                );
            builder.HasMany(x => x.Children)
                .WithOne(x => x.Parent)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(x => x.ParentId);

            builder.HasIndex(x => x.Name).IsUnique();


        }
    }
}
