using Hangfire;
using Koala.Portal.Core.CrmRepositories;
using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.GetPassRepositories;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.UnitOfWork;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Koala.Portal.Repository;
using Koala.Portal.Repository.CrmRepositories;
using Koala.Portal.Repository.GetPassRepositories;
using Koala.Portal.Repository.Repositories;
using Koala.Portal.Service.CrmServices;
using Koala.Portal.Service.Helper;
using Koala.Portal.Service.Services;

namespace Koala.Portal.WebApi.Extentions
{
    public static class StartupExtention
    {
        public static void AddIdentityConfExt(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<EmailSettingViewModel>(configuration.GetSection("EmailSettings"));
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICrmBaseService<>), typeof(CrmBaseService<>));
            services.AddScoped<ICrmCategoryService, CrmCategoryService>();
            services.AddScoped<ICrmDepartmentService, CrmDepartmentService>();
            services.AddScoped<ICrmFirmService, CrmFirmService>();
            services.AddScoped<ICrmPhoneService, CrmPhoneService>();
            //services.AddScoped<ICrmSupportService, CrmSupportService>();
            //services.AddScoped<ICrmSupportStateService, CrmSupportStateService>();
            services.AddScoped<ICrmTicketHistoryService, CrmTicketHistoryService>();


            //services.AddScoped(typeof(IGetPassBaseService<>), typeof(GetPassBaseService<>));
            //services.AddScoped<IGetPassUserService, GetPassUserService>();


            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<IAgendaTypeService, AgendaTypeService>();
            //services.AddScoped<ICrmSelectListService, CrmSelectListService>();
            //services.AddScoped<ICrmSqlService, CrmSqlService>();
            services.AddScoped<IFirmService, FirmService>();
            services.AddScoped<IFixtureService, FixtureService>();
            services.AddScoped<IMailTemplateService, MailTemplateService>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<ISelectListService, SelectListService>();
            services.AddScoped<IBackgroundServices, BackgroundServices>();
            services.AddScoped<IEmailService, EmailService>();
            //services.AddScoped<IRoleService, RoleService>();
            //services.AddScoped<IClaimService, ClaimService>();
            //services.AddScoped<ISupportFileService, SupportFileService>();
            //services.AddScoped<IUserService, UserService>();
            services.AddScoped<IApplicationsService, ApplicationsService>();
            services.AddScoped<IApplicationLicencesService, ApplicationLicencesService>();
            services.AddScoped<ITransactionTypeService, TransactionTypeService>();

            //services.AddScoped(typeof(IGetPassBaseService<>), typeof(GetPassBaseService<>));
            //services.AddScoped<IGetPassUserService, GetPassUserService>();
            //services.AddScoped<IMyDataService, MyDataService>();

            services.AddScoped<IHelpDeskCategoryService, HelpDeskCategoryService>();
            services.AddScoped<IHelpDeskProblemService, HelpDeskProblemService>();
            services.AddScoped<IHelpDeskSolutionService, HelpDeskSolutionService>();

            services.AddScoped<IGeneratedIdsService, GeneratedIdsService>();

        }
        public static void AddApplicationRepositories(this IServiceCollection services)
        {
            // CRM Adapters for data transformation
            services.AddScoped<Koala.Portal.Core.Adapters.ICrmPhoneAdapter, Koala.Portal.Core.Adapters.CrmPhoneAdapter>();
            services.AddScoped<Koala.Portal.Core.Adapters.ICrmContactAdapter, Koala.Portal.Core.Adapters.CrmContactAdapter>();
            services.AddScoped<Koala.Portal.Core.Adapters.ICrmFirmAdapter, Koala.Portal.Core.Adapters.CrmFirmAdapter>();

            services.AddScoped(typeof(ICrmBaseRepository<>), typeof(CrmBaseRepository<>));
            services.AddScoped<ICrmCategoryRepository, CrmCategoryRepository>();
            services.AddScoped<ICrmDepartmentRepository, CrmDepartmentRepository>();
            services.AddScoped<ICrmFirmRepository, CrmFirmRepository>();
            services.AddScoped<ICrmPhoneRepository, CrmPhoneRepository>();
            //services.AddScoped<ICrmSupportRepository, CrmSupportRepository>();
            //services.AddScoped<ICrmSupportStatesRepository, CrmSupportStateRepository>();
            //services.AddScoped<ICrmSupportTypeRepository, CrmSupportTypeRepository>();
            services.AddScoped<ICrmTicketHistoryRepository, CrmTicketHistoryRepository>();


            //services.AddScoped(typeof(IGetPassBaseRepository<>), typeof(GetPassBaseRepository<>));
            //services.AddScoped<IGetPassUserRepository, GetPassUserRepository>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IAgendaTypeRepository, AgendaTypeRepository>();
            services.AddScoped<IMailTemplateRepository, MailTemplateRepository>();
            //services.AddScoped<ICrmSqlRepository, CrmSqlRepository>();
            services.AddScoped<IFixtureRepository, FixtureRepository>();
            //services.AddScoped<ICrmSelectListRepository, CrmSelectListRepository>();
            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IFirmRepository, FirmRepository>();
            services.AddScoped<IClaimRepository, ClaimRepository>();
            services.AddScoped<ISupportFileRepository, SupportFileRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IApplicationsRepository, ApplicationsRepository>();
            services.AddScoped<IApplicationLicencesRepository, ApplicationLicencesRepository>();
            services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();

            services.AddScoped(typeof(IGetPassBaseRepository<>), typeof(GetPassBaseRepository<>));
            //services.AddScoped<IGetPassUserRepository, GetPassUserRepository>();
            //services.AddScoped<IMyDataRepository, MyDataRepository>();

            services.AddScoped<IHelpDeskCategoryRepository, HelpDeskCategoryRepository>();
            services.AddScoped<IHelpDeskProblemRepository, HelpDeskProblemRepository>();
            services.AddScoped<IHelpDeskSolutionRepository, HelpDeskSolutionRepository>();

            services.AddScoped<IGeneratedIdsRepository, GeneratedIdsRepository>();



        }
        public static void AddApplicationProviders(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork<AppDbContext>, UnitOfWork<AppDbContext>>();
            //services.AddScoped<ICrmSqlProvider, CrmSqlProvider>();
            services.AddHangfireServer();
        }

    }
}
