using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class VacationRequestConfiguration : IEntityTypeConfiguration<VacationRequest>
    {
        public void Configure(EntityTypeBuilder<VacationRequest> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User)
                .WithMany(x => x.Vacations)
                .HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.VacationType)
               .WithMany(x => x.Vacations)
               .HasForeignKey(x => x.VacationTypeId);
            builder.HasMany(x => x.VacationHistories)
                .WithOne(x => x.Vacation)
                .HasForeignKey(x => x.VacationId);

        }
    }
}
