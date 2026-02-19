using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class ApplicationFirmsConfiguration:IEntityTypeConfiguration<ApplicationFirms>
    {
        public void Configure(EntityTypeBuilder<ApplicationFirms> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Application)
                .WithMany(x => x.Firms)
                .HasForeignKey(x => x.ApplicationId);
            builder.HasOne(x => x.Firm)
                .WithMany(x => x.Applications)
                .HasForeignKey(x => x.FirmId);

        }
    }
}
