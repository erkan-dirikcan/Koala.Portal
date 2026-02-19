using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class TransactionConfiguration:IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.TransactionItems)
                .WithOne(x => x.Transaction)
                .HasForeignKey(x => x.TransactionId);
            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.TransactionType)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.TransactionTypeId);
        }
    }
}
