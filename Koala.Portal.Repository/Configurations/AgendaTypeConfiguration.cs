using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class AgendaTypeConfiguration:IEntityTypeConfiguration<AgendaType>
    {
        public void Configure(EntityTypeBuilder<AgendaType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Agenda)
                .WithOne(x => x.AgendaType)
                .HasForeignKey(x => x.AgendaTypeId);
       
        }
    }
}
