using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class GeneratedIdsConfiguration:IEntityTypeConfiguration<GeneratedIds>
    {
        public void Configure(EntityTypeBuilder<GeneratedIds> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Module)
                .WithMany(x => x.GeneratedIds)
                .HasForeignKey(x => x.ModuleId);
        }
    }
}
