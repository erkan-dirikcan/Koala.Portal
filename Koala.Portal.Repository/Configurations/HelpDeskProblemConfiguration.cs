using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class HelpDeskProblemConfiguration:IEntityTypeConfiguration<HelpDeskProblem>
    {
        public void Configure(EntityTypeBuilder<HelpDeskProblem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.HelpDeskSolitions)
                .WithOne(x => x.HelpDeskProblem)
                .HasForeignKey(x => x.HelpDeskProblemId);

            builder.HasMany(x => x.Catogory)
                .WithMany(x => x.HelpDeskProblems)
                .UsingEntity<HelpDeskProblemCatogory>(
                    x => x.HasOne<HelpDeskCategory>().WithMany().HasForeignKey(x => x.CatogoryId),
                    x => x.HasOne<HelpDeskProblem>().WithMany().HasForeignKey(x => x.HelpDeskProblemId),
                    x => x.HasKey(x => new { x.CatogoryId, x.HelpDeskProblemId })
                );

        }
    }
}
