using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations;

public class AgendaFixturesConfiguration:IEntityTypeConfiguration<AgendaFixtures>
{
    public void Configure(EntityTypeBuilder<AgendaFixtures> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Fixture)
            .WithMany(x => x.AgendaFixtures)
            .HasForeignKey(x => x.FixtureId);
        builder.HasOne(x => x.Agenda)
            .WithMany(x => x.AgendaFixtures)
            .HasForeignKey(x => x.AgendaId);
    }
}