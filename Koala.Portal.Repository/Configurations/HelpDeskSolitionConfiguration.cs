using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class HelpDeskSolitionConfiguration:IEntityTypeConfiguration<HelpDeskSolution>
    {
        public void Configure(EntityTypeBuilder<HelpDeskSolution> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.HelpDeskProblem)
                .WithMany(x => x.HelpDeskSolitions)
                .HasForeignKey(x => x.HelpDeskProblemId);

        }
    }
}
