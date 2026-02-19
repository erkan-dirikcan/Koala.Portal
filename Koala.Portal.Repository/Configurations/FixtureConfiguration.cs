using Koala.Portal.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Koala.Portal.Repository.Configurations
{
    public class FixtureConfiguration : IEntityTypeConfiguration<Fixture>
    {
        public void Configure(EntityTypeBuilder<Fixture> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.AgendaFixtures)
                .WithOne(x => x.Fixture)
                .HasForeignKey(x => x.FixtureId);

            //builder.HasData(new List<Fixture>()
            //{
            //    new Fixture
            //    {
            //        Id = Tools.CreateGuidStr(),
            //        Name = "Fiat Egea",
            //        Description = "34-BIG-293",
            //        IsActive = true,
            //        IsVehicle = true
            //    },
            //    new Fixture
            //    {
            //        Id = Tools.CreateGuidStr(),
            //        Name = "Volkswagen - Cady",
            //        Description = "34-FR-4680",
            //        IsActive = true,
            //        IsVehicle = true
            //    },
            //    new Fixture
            //    {
            //        Id = Tools.CreateGuidStr(),
            //        Name = "Logo Notebook",
            //        Description = "Logo Departman Notebook",
            //        IsActive = true,
            //        IsVehicle = false
            //    },
            //    new Fixture
            //    {
            //        Id = Tools.CreateGuidStr(),
            //        Name = "Teknik Notebook",
            //        Description = "Teknik Departman Notebook",
            //        IsActive = true,
            //        IsVehicle = false
            //    },
            //    new Fixture
            //    {
            //        Id = Tools.CreateGuidStr(),
            //        Name = "Fiat Punto",
            //        Description = "34-FC-1504",
            //        IsActive = true,
            //        IsVehicle = true
            //    }
            //});
        }
    }
}
