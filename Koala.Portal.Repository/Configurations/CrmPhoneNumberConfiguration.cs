using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations;

public class CrmPhoneNumberConfiguration : IEntityTypeConfiguration<CrmPhoneNumber>
{
    public void Configure(EntityTypeBuilder<CrmPhoneNumber> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.RelatedContactNavigation).WithMany(x => x.Phones).HasForeignKey(x => x.RelatedContact);
        builder.HasOne(x => x.RelatedFirmNavigation).WithMany(x => x.Phones).HasForeignKey(x => x.RelatedFirm);
    }
}