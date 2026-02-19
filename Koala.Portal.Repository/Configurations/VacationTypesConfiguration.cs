using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class VacationTypesConfiguration : IEntityTypeConfiguration<VacationTypes>
    {
        public void Configure(EntityTypeBuilder<VacationTypes> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Vacations)
                .WithOne(x => x.VacationType)
                .HasForeignKey(x => x.VacationTypeId);
        }
    }
}
