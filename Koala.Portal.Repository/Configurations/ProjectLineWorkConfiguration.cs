using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class ProjectLineWorkConfiguration : IEntityTypeConfiguration<ProjectLineWork>
    {
        public void Configure(EntityTypeBuilder<ProjectLineWork> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.RowOrder);
            //İlişkili Faz
            builder.HasOne(x => x.Line)
                .WithMany(x => x.LineWorks)
                .HasForeignKey(x => x.LineId)
                .OnDelete(DeleteBehavior.NoAction);

            //Teslim Edilen Personel - DeliveredPersonOid now stores CRM OID directly, no FK constraint
            // The navigation property DeliveredPerson is kept for compatibility but won't be loaded from local DB
            builder.Ignore(x => x.DeliveredPerson);

            //Firma iş Sorumlusu - LineFirmOfficialId now stores CRM OID directly, no FK constraint
            // The navigation property WorkFirmOffcial is kept for compatibility but won't be loaded from local DB
            builder.Ignore(x => x.WorkFirmOffcial);

            //Sadece bir destek kaydı olacağı için burası iptal edildi
            ////İlişkili Destek Kayıtları
            //builder.HasMany(x=>x.ReleatedSupport)
            //    .WithOne(x=>x.ProjectLineWork)
            //    .HasForeignKey(x => x.ProjectLinetWorkId)
            //    .OnDelete(DeleteBehavior.NoAction);
            //Çalışan Kullanıcılar
            builder.HasMany(x => x.WorkPersons)
                .WithOne(x => x.ProjectLineWork)
                .HasForeignKey(x => x.ProjectLineWorkId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
