using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    internal class CrmFirmConfiguration : IEntityTypeConfiguration<CrmFirm>
    {
        public void Configure(EntityTypeBuilder<CrmFirm> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Code);
            builder.HasMany(x => x.Contacts).WithOne(x => x.Firm).HasForeignKey(x => x.FirmId);
            builder.HasMany(x => x.Phones).WithOne(x => x.RelatedFirmNavigation).HasForeignKey(x => x.RelatedFirm);
            builder.HasMany(x => x.Licences).WithOne(x => x.LicancedFirm).HasForeignKey(x => x.LisansFirmId);
            builder.HasMany(x => x.Applications).WithOne(x => x.Firm).HasForeignKey(x => x.FirmId);
        }
    }
}
