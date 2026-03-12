using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class CrmFirmContactConfiguration : IEntityTypeConfiguration<CrmFirmContact>
    {
        public void Configure(EntityTypeBuilder<CrmFirmContact> builder)
        {
            builder.HasKey(x => x.Id);
            //İlişkili Firma
            builder.HasOne(x => x.Firm)
                .WithMany(x => x.Contacts)
                .HasForeignKey(x => x.FirmId)
                .OnDelete(DeleteBehavior.NoAction);


            //Telefon Numaraları
            builder.HasMany(x => x.Phones)
                .WithOne(x => x.RelatedContactNavigation)
                .HasForeignKey(x => x.RelatedContact).
                OnDelete(DeleteBehavior.NoAction);
        }
    }
}
