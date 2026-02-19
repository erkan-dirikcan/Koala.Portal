using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            //Etkinlikleri
            builder.HasMany(x => x.Events)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            //Yöneticisi Olduğu Projeler
            builder.HasMany(x => x.ManagedProjects)
                .WithOne(x => x.ProjectManager)
                .HasForeignKey(x => x.ProjectManagerId);
            //Sorumlu Olduğu Fazlar
            builder.HasMany(x => x.ManagedProjectLine)
                .WithOne(x => x.LineOffcial)
                .HasForeignKey(x => x.LineOfficialId);
            //Çalıştığı Projeler
            builder.HasMany(x => x.WorkedProjectLineWorks)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);



            //Departmanları
            builder.HasMany(x => x.UserDepartments)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.AppUserId);
            //Onayladığı Lisanslar
            builder.HasMany(x => x.ApplicationLicences)
                .WithOne(x => x.ApprovedByUser)
                .HasForeignKey(x => x.ApprovedByUserId);
            //Transaction Kayıtları
            builder.HasMany(x => x.Transactions)
                .WithOne(x => x.AppUser)
                .HasForeignKey(x => x.UserId);
            //İzinleri
            builder.HasMany(x => x.Vacations)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
            //İzin Geçmişi
            builder.HasMany(x => x.VacationHistory)
                .WithOne(x => x.ReleatedUser)
                .HasForeignKey(x => x.ReleatedUserId);
        }
    }
}
