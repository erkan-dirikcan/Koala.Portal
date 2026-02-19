using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    internal class ApplicationsConfiguration : IEntityTypeConfiguration<Applications>
    {
        public void Configure(EntityTypeBuilder<Applications> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.HasMany(x=>x.ApplicationLicences)
                .WithOne(x=>x.Applications)
                .HasForeignKey(x=>x.ApplicationId);
           
            builder.HasMany(x => x.ApplicationLicences)
                .WithOne(x => x.Applications)
                .HasForeignKey(x => x.ApplicationId);

            builder.HasMany(x => x.Firms)
                .WithOne(x => x.Application)
                .HasForeignKey(x => x.ApplicationId);

            builder.HasMany(x => x.Modules)
                .WithOne(x => x.Application)
                .HasForeignKey(x => x.ApplicationId);
        }
    }
}
