using Koala.Portal.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Module = Koala.Portal.Core.Models.Module;

namespace Koala.Portal.Repository
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<AgendaFirmOfficials> AgendaFirmOfficials { get; set; }
        public DbSet<AgendaFixtures> AgendaFixtures { get; set; }
        public DbSet<AgendaType> AgendaType { get; set; }
        public DbSet<AgendaUsers> AgendaUsers { get; set; }
        public DbSet<ApplicationFirms> ApplicationFirms { get; set; }
        public DbSet<ApplicationLicences> ApplicationLicences { get; set; }
        public DbSet<ApplicationModules> ApplicationModules { get; set; }
        public DbSet<Applications> Applications { get; set; }
        public DbSet<Claims> Claims { get; set; }
        public DbSet<CrmFirm> CrmFirm { get; set; }
        public DbSet<CrmFirmContact> CrmFirmContact { get; set; }
        public DbSet<CrmPhoneNumber> CrmPhoneNumber { get; set; }
        public DbSet<EmailTemplate> EmailTemplate { get; set; }
        public DbSet<Fixture> Fixture { get; set; }
        public DbSet<GeneratedIds> GeneratedIds { get; set; }
        public DbSet<HelpDeskCategory> HelpDeskCatogory { get; set; }
        public DbSet<HelpDeskProblem> HelpDeskProblem { get; set; }
        public DbSet<HelpDeskSolution> HelpDeskSolition { get; set; }


        public DbSet<AppNotification> AppNotification { get; set; }

        public DbSet<Module> Module { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectFiles> ProjectFiles { get; set; }
        public DbSet<ProjectLine> ProjectLine { get; set; }
        public DbSet<ProjectLineNote> ProjectLineNote { get; set; }
        public DbSet<ProjectLineWork> ProjectLineWork { get; set; }
        public DbSet<ProjectPerson> ProjectPerson { get; set; }
        public DbSet<SupportFile> SupportFile { get; set; }

        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<TransactionItem> TransactionItem { get; set; }
        public DbSet<TransactionType> TransactionType { get; set; }
        public DbSet<VacationHistory> VacationHistory { get; set; }
        public DbSet<VacationRequest> VacationRequest { get; set; }
        public DbSet<VacationTypes> VacationTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
