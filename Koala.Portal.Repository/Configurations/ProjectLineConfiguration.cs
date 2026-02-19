using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class ProjectLineConfiguration : IEntityTypeConfiguration<ProjectLine>
    {
        public void Configure(EntityTypeBuilder<ProjectLine> builder)
        {
            builder.HasKey(x => x.Id);
            //Proje
            builder.HasOne(x => x.Project)
                .WithMany(x => x.ProjectLines)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);
            //Faz Sorumlusu
            builder.HasOne(x => x.LineOffcial)
                .WithMany(x => x.ManagedProjectLine)
                .HasForeignKey(x => x.LineOfficialId)
                .OnDelete(DeleteBehavior.NoAction);        
            //Firma Faz Sorumlusu
            builder.HasOne(x => x.LineFirmOffcial)
                .WithMany(x => x.PersonProjectLines)
                .HasForeignKey(x => x.LineFirmOfficialId);
            //İlişkili İşler
            builder.HasMany(x => x.LineWorks)
                .WithOne(x => x.Line)
                .HasForeignKey(x => x.LineId)
                .OnDelete(DeleteBehavior.NoAction);
            //Faz Notları
            builder.HasMany(x => x.LineNotes)
                .WithOne(x => x.ProjectLine)
                .HasForeignKey(x => x.ProjectLineId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
