using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class EmailTemplateConfiguration:IEntityTypeConfiguration<EmailTemplate>
    {
        public void Configure(EntityTypeBuilder<EmailTemplate> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(b => b.Name)
                .HasFilter("[Name] IS NOT NULL");
        }
    }
}
