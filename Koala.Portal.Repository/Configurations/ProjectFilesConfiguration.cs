using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class ProjectFilesConfiguration : IEntityTypeConfiguration<ProjectFiles>
    {
        public void Configure(EntityTypeBuilder<ProjectFiles> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Project).WithMany(x => x.ProjectFiles).HasForeignKey(x => x.ProjectId);
            builder.HasIndex(x => x.ProjectId);
        }
    }
}
