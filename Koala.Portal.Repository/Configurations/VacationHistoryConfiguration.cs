using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class VacationHistoryConfiguration : IEntityTypeConfiguration<VacationHistory>
    {
        public void Configure(EntityTypeBuilder<VacationHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Vacation)
                .WithMany(x => x.VacationHistories)
                .HasForeignKey(x => x.VacationId);

            builder.HasOne(x => x.ReleatedUser)
               .WithMany(x => x.VacationHistory)
               .HasForeignKey(x => x.VacationId);
        }
    }
}
