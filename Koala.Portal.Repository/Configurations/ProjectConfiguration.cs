using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.ProjectCode);
            //Proje Yöneticisi
            builder.HasOne(x => x.ProjectManager)
                .WithMany(x => x.ManagedProjects)
                .HasForeignKey(x => x.ProjectManagerId);
            //Proje Dosyaları
            builder.HasMany(x => x.ProjectFiles)
                .WithOne(x => x.Project)
                .HasForeignKey(x => x.ProjectId);

            //Proje Fazları
            builder.HasMany(x => x.ProjectLines)
                .WithOne(x => x.Project)
                .HasForeignKey(x => x.ProjectId);
        }
    }
}

