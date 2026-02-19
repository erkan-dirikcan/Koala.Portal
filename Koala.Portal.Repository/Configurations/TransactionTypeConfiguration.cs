using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class TransactionTypeConfiguration:IEntityTypeConfiguration<TransactionType>
    {
        public void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            builder.HasMany(x => x.Transactions)
                .WithOne(x => x.TransactionType)
                .HasForeignKey(x => x.TransactionTypeId);
        }
    }
}
