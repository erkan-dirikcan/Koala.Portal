
using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class ModuleConfiguration : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.GeneratedIds)
                .WithOne(x => x.Module)
                .HasForeignKey(x => x.ModuleId);
            builder.HasMany(x => x.Claims)
                .WithOne(x => x.Module)
                .HasForeignKey(x => x.ModuleId);
            //builder.HasData(
            //new List<Module>{
            //    new() {Name = "Proje", Description = "Sistem bilgisayar proje yönetim uygulaması."},
            //    new () {Name = "Yardım Masası", Description = "Yardım masası uygulaması."},
            //    new () {Name = "Ajanda", Description = "Personel izin, toplantı gibi etkinliklerinin takibi amacıyla oluşturulan ajanda uygulaması."}
            //});
        }
    }
}
