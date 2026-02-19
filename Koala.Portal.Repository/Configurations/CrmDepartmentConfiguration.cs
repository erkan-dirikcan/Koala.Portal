using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class CrmDepartmentConfiguration:IEntityTypeConfiguration<CrmDepartment>
    {
        public void Configure(EntityTypeBuilder<CrmDepartment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.DepartmentUsers)
                .WithOne(x => x.Department)
                .HasForeignKey(x => x.DepartmanId);
        }
    }
}
