using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class ProjectPersonConfiguration : IEntityTypeConfiguration<ProjectPerson>
    {
        public void Configure(EntityTypeBuilder<ProjectPerson> builder)
        {
            builder.HasKey(p => p.Id);
            //İş ile İlişkili Kullanıcı
            builder.HasOne(x=>x.User)
                .WithMany(x=>x.WorkedProjectLineWorks)
                .HasForeignKey(x=>x.UserId);         

            //İlişkili İş
            builder.HasOne(x => x.ProjectLineWork)
                .WithMany(x => x.WorkPersons)
                .HasForeignKey(x => x.ProjectLineWorkId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
