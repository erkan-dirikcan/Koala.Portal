using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class ApplicationLicencesConfiguration : IEntityTypeConfiguration<ApplicationLicences>
    {
        public void Configure(EntityTypeBuilder<ApplicationLicences> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ApprovedByUser).WithMany(x => x.ApplicationLicences).HasForeignKey(x => x.ApprovedByUserId);
            builder.HasOne(x => x.Applications).WithMany(x => x.ApplicationLicences).HasForeignKey(x => x.ApplicationId);
            builder.HasOne(x => x.LicancedFirm).WithMany(x => x.Licences).HasForeignKey(x => x.LisansFirmId);
        }
    }
}
