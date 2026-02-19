using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class ProjectLineNoteConfiguration : IEntityTypeConfiguration<ProjectLineNote>
    {
        public void Configure(EntityTypeBuilder<ProjectLineNote> builder)
        {
            builder.HasKey(x => x.Id);
            //İlişkili Faz
            builder.HasOne(x => x.ProjectLine)
                .WithMany(x => x.LineNotes)
                .HasForeignKey(x => x.ProjectLineId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => x.ProjectLineId);
        }
    }
}
