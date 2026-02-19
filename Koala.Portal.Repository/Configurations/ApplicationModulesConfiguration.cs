using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class ApplicationModulesConfiguration:IEntityTypeConfiguration<ApplicationModules>
    {
        public void Configure(EntityTypeBuilder<ApplicationModules> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Application)
                .WithMany(x => x.Modules)
                .HasForeignKey(x => x.ApplicationId);

        }
    }
}
