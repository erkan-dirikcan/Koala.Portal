using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations;

public class AgendaFirmOfficialsConfiguration:IEntityTypeConfiguration<AgendaFirmOfficials>
{
    public void Configure(EntityTypeBuilder<AgendaFirmOfficials> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Agenda)
            .WithMany(x => x.FirmOfficials)
            .HasForeignKey(x => x.AgendaId);
    }
}