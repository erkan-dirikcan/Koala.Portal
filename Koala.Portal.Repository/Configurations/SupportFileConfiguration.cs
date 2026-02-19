using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class SupportFileConfiguration:IEntityTypeConfiguration<SupportFile>
    {
        public void Configure(EntityTypeBuilder<SupportFile> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
