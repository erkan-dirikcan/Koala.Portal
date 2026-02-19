using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class AppUserCrmDepartmentConfiguration:IEntityTypeConfiguration<AppUserCrmDepartment>
    {
        public void Configure(EntityTypeBuilder<AppUserCrmDepartment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User)
                .WithMany(x => x.UserDepartments)
                .HasForeignKey(x => x.AppUserId);
            builder.HasOne(x => x.Department)
                .WithMany(x => x.DepartmentUsers)
                .HasForeignKey(x => x.DepartmanId);
        }
    }
}
