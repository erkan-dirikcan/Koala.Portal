using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class AgendaUsersConfiguration:IEntityTypeConfiguration<AgendaUsers>
    {
        public void Configure(EntityTypeBuilder<AgendaUsers> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User)
                .WithMany(x => x.Events)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Agenda)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.AgendaId);
        }
    }
}
