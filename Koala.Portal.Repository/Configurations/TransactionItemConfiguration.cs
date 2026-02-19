using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class TransactionItemConfiguration:IEntityTypeConfiguration<TransactionItem>
    {
        public void Configure(EntityTypeBuilder<TransactionItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Transaction)
                .WithMany(x => x.TransactionItems)
                .HasForeignKey(x => x.TransactionId);
        }
    }
}
