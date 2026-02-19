using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class AgendaConfiguration:IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Users)
                .WithOne(x => x.Agenda)
                .HasForeignKey(x => x.AgendaId);
            builder.HasMany(x => x.AgendaFixtures)
                .WithOne(x => x.Agenda)
                .HasForeignKey(x => x.AgendaId);
            builder.HasMany(x => x.FirmOfficials)
                .WithOne(x => x.Agenda)
                .HasForeignKey(x => x.AgendaId);
            builder.HasOne(x => x.AgendaType)
                .WithMany(x => x.Agenda)
                .HasForeignKey(x => x.AgendaTypeId);


        }
    }
}
