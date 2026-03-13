using Hangfire;
using Koala.Portal.Core.CrmRepositories;
using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.GetPassRepositories;
using Koala.Portal.Core.GetPassServices;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Providers;
using Koala.Portal.Core.Repositories;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.UnitOfWork;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Koala.Portal.Repository;
using Koala.Portal.Repository.CrmRepositories;
using Koala.Portal.Repository.GetPassRepositories;
using Koala.Portal.Repository.Providers;
using Koala.Portal.Repository.Repositories;
using Koala.Portal.Service.CrmServices;
using Koala.Portal.Service.GetPassServices;
using Koala.Portal.Service.Helper;
using Koala.Portal.Service.Services;
using Koala.Portal.WebUI.Localizations;
using Koala.Portal.WebUI.Requirements;
using Microsoft.AspNetCore.Identity;

namespace Koala.Portal.WebUI.Extentions
{
    public static class StartupExtention
    {
        public static void AddIdentityConfExt(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<EmailSettingViewModel>(configuration.GetSection("EmailSettings"));

        }
        public static void AddIdentityWithExt(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;

                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequiredLength = 8;

                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(2);
            }).AddEntityFrameworkStores<AppDbContext>()
              //.AddUserValidator<>()
              .AddErrorDescriber<LocalizationIdentityErrorDescriber>()
              .AddEntityFrameworkStores<AppDbContext>()
              .AddDefaultTokenProviders();

            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(2);
            });

            services.ConfigureApplicationCookie(options =>
            {
                var cookieBuilder = new CookieBuilder();
                cookieBuilder.Name = "KoalaPortalApp";
                options.LoginPath = new PathString("/UserAccount/Login");
                options.LogoutPath = new PathString("/UserAccount/Logout");
                options.AccessDeniedPath = new PathString("/UserAccount/AccessDenied");
                options.Cookie = cookieBuilder;
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
                options.SlidingExpiration = true;

            });
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.FromSeconds(120);

            });

        }
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICrmBaseService<>), typeof(CrmBaseService<>));
            services.AddScoped<ICrmCategoryService, CrmCategoryService>();
            services.AddScoped<ICrmDepartmentService, CrmDepartmentService>();
            services.AddScoped<ICrmFirmService, CrmFirmService>();
            services.AddScoped<ICrmPhoneService, CrmPhoneService>();
            services.AddScoped<ICrmSelectListService, CrmSelectListService>();
            services.AddScoped<ICrmSqlService, CrmSqlService>();
            services.AddScoped<ICrmSupportService, CrmSupportService>();
            services.AddScoped<ICrmSupportStateService, CrmSupportStateService>();
            services.AddScoped<ICrmTicketHistoryService, CrmTicketHistoryService>();
            services.AddScoped<ICrmReportService, CrmReportService>();



            services.AddScoped(typeof(IGetPassBaseService<>), typeof(GetPassBaseService<>));
            services.AddScoped<IGetPassUserService, GetPassUserService>();
            services.AddScoped<IMyDataService, MyDataService>();



            services.AddScoped<IAgendaService,AgendaService >();
            services.AddScoped<IAgendaTypeService, AgendaTypeService>();
            services.AddScoped<IApplicationFirmService, ApplicationFirmService>();
            services.AddScoped<IApplicationLicencesService, ApplicationLicencesService>();
            services.AddScoped<IApplicationModulesService, ApplicationModulesService>();
            services.AddScoped<IApplicationsService, ApplicationsService>();
            services.AddScoped<IBackgroundServices, BackgroundServices>();
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IFirmContactService, FirmContactService>();
            services.AddScoped<IFirmService, FirmService>();
            services.AddScoped<IFixtureService, FixtureService>();
            services.AddScoped<IGeneratedIdsService, GeneratedIdsService>();
            services.AddScoped<IHelpDeskCategoryService, HelpDeskCategoryService>();
            services.AddScoped<IHelpDeskProblemService, HelpDeskProblemService>();
            services.AddScoped<IHelpDeskSolutionService, HelpDeskSolutionService>();
            services.AddScoped<IMailTemplateService, MailTemplateService>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<IProjectLineService, ProjectLineService>();
            services.AddScoped<IProjectLineWorkService, ProjectLineWorkService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ISelectListService, SelectListService>();
            services.AddScoped<ISupportFileService, SupportFileService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ITransactionTypeService, TransactionTypeService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVacationHistoryService, VacationHistoryService>();
            services.AddScoped<IVacationTypesService, VacationTypesService>();
            services.AddScoped<IVacationRequestService, VacationRequestService>();

            // Phase 3: Advanced Features
            services.AddScoped<IExportService, ExportService>();
            services.AddScoped<INotificationService, NotificationService>();

            //services.AddScoped<, >();
            //services.AddScoped<, >();
        }
        public static void AddApplicationRepositories(this IServiceCollection services)
        {
            //==============================CRM============================================================
            // CRM Adapters for data transformation
            services.AddScoped<Koala.Portal.Core.Adapters.ICrmPhoneAdapter, Koala.Portal.Core.Adapters.CrmPhoneAdapter>();
            services.AddScoped<Koala.Portal.Core.Adapters.ICrmContactAdapter, Koala.Portal.Core.Adapters.CrmContactAdapter>();
            services.AddScoped<Koala.Portal.Core.Adapters.ICrmFirmAdapter, Koala.Portal.Core.Adapters.CrmFirmAdapter>();

            services.AddScoped(typeof(ICrmBaseRepository<>), typeof(CrmBaseRepository<>));
            services.AddScoped<ICrmCategoryRepository, CrmCategoryRepository>();
            services.AddScoped<ICrmDepartmentRepository, CrmDepartmentRepository>();
            services.AddScoped<ICrmFirmRepository, CrmFirmRepository>();
            services.AddScoped<ICrmPhoneRepository, CrmPhoneRepository>();
            services.AddScoped<ICrmSelectListRepository, CrmSelectListRepository>();
            services.AddScoped<ICrmSqlRepository, CrmSqlRepository>();
            services.AddScoped<ICrmSupportRepository, CrmSupportRepository>();
            services.AddScoped<ICrmSupportStatesRepository, CrmSupportStateRepository>();
            services.AddScoped<ICrmSupportTypeRepository, CrmSupportTypeRepository>();
            services.AddScoped<ICrmTicketHistoryRepository, CrmTicketHistoryRepository>();
            services.AddScoped<ICrmReportRepository, CrmReportRepository>();


            //==============================GetPass========================================================
            services.AddScoped(typeof(IGetPassBaseRepository<>), typeof(GetPassBaseRepository<>));
            services.AddScoped<IGetPassUserRepository, GetPassUserRepository>();
            services.AddScoped<IMyDataRepository, MyDataRepository>();


            //==============================Local==========================================================
            services.AddScoped<IAgendaRepository, AgendaRepository>();
            services.AddScoped<IAgendaTypeRepository, AgendaTypeRepository>(); 
            services.AddScoped<IApplicationFirmRepository, ApplicationFirmRepository>();
            services.AddScoped<IApplicationLicencesRepository, ApplicationLicencesRepository>();
            services.AddScoped<IApplicationModulesRepository, ApplicationModulesRepository>();
            services.AddScoped<IApplicationsRepository, ApplicationsRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IClaimRepository, ClaimRepository>();
            services.AddScoped<IFirmContactRepository, FirmContactRepository>();
            services.AddScoped<IFirmRepository, FirmRepository>();
            services.AddScoped<IFixtureRepository, FixtureRepository>();
            services.AddScoped<IGeneratedIdsRepository, GeneratedIdsRepository>();
            services.AddScoped<IHelpDeskCategoryRepository, HelpDeskCategoryRepository>();
            services.AddScoped<IHelpDeskProblemRepository, HelpDeskProblemRepository>();
            services.AddScoped<IHelpDeskSolutionRepository, HelpDeskSolutionRepository>();
            services.AddScoped<IMailTemplateRepository, MailTemplateRepository>();
            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IProjectFileRepository, ProjectFileRepository>();
            services.AddScoped<IProjectLineNoteRepository, ProjectLineNoteRepository>();
            services.AddScoped<IProjectLineRepository, ProjectLineRepository>();
            services.AddScoped<IProjectLineWorkRepository, ProjectLineWorkRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ISupportFileRepository, SupportFileRepository>();
            services.AddScoped<ITransactionItemRepository, TransactionItemRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVacationHistoryRepository, VacationHistoryRepository>();
            services.AddScoped<IVacationTypesRepository, VacationTypesRepository>();
            services.AddScoped<IVacationRequestRepository, VacationRequestRepository>();

            // Phase 3: Advanced Features
            services.AddScoped<INotificationRepository, NotificationRepository>();

            //services.AddScoped<, >();
            //services.AddScoped<, >();
            //services.AddScoped<, >();
            //services.AddScoped<, >();
            //services.AddScoped<, >();
            //services.AddScoped<, >();
        }
        public static void AddApplicationProviders(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork<AppDbContext>, UnitOfWork<AppDbContext>>();
            services.AddScoped<ICrmSqlProvider, CrmSqlProvider>();
            services.AddHangfireServer();
        }
        public static void AddAuthorizationRules(this IServiceCollection services, AppDbContext context)
        {
            var claims = context.Claims.ToList();


            services.AddAuthorization(options =>
            {
                options.AddPolicy("Development", policy =>
                {
                    policy.AddRequirements(new DepartmentRequirement() { Department = "Yazılım Geliştirme" });
                });
                foreach (var claim in claims)
                {
                    options.AddPolicy(claim.Name, policy =>
                    {
                        policy.RequireClaim("Permission", claim.Name);

                    });
                };
            });
        }

    }
}
