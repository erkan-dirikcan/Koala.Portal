using Koala.Portal.Core.Mapping;
using Koala.Portal.Service.Mapping;

namespace Koala.Portal.WebUI.Extentions
{
    public static class MappingExtention
    {
        public static void AddMappingConfExt(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AgendaProfile));
            services.AddAutoMapper(typeof(AgendaTypeProfile));
            services.AddAutoMapper(typeof(AgendaUserProfile));
            services.AddAutoMapper(typeof(ApplicationFirmProfile));
            services.AddAutoMapper(typeof(ApplicationLicencesProfile));
            services.AddAutoMapper(typeof(ApplicationModulesProfile));
            services.AddAutoMapper(typeof(ApplicationsProfile));
            services.AddAutoMapper(typeof(ClaimProfile));
            services.AddAutoMapper(typeof(ContactPhonesProfile));
            services.AddAutoMapper(typeof(CrmCategoryProfile));
            services.AddAutoMapper(typeof(CrmDepartmentProfile));
            services.AddAutoMapper(typeof(CrmFirmContactProfile));
            services.AddAutoMapper(typeof(CrmFirmProfile));
            services.AddAutoMapper(typeof(CrmSupportHistoryProfile));
            services.AddAutoMapper(typeof(CrmSupportProfile));
            services.AddAutoMapper(typeof(CrmSupportStateProfile));
            services.AddAutoMapper(typeof(FixtureProfile));
            services.AddAutoMapper(typeof(GeneratedIdsProfile));
            services.AddAutoMapper(typeof(GetPassMyDatasProfile));
            services.AddAutoMapper(typeof(GetPassUserProfile));
            services.AddAutoMapper(typeof(HelpDeskCategoryProfile));
            services.AddAutoMapper(typeof(HelpDeskProblemProfile));
            services.AddAutoMapper(typeof(HelpDeskSolutionProfile));
            services.AddAutoMapper(typeof(ModuleProfile));
            services.AddAutoMapper(typeof(ProjectLineNoteProfile));
            services.AddAutoMapper(typeof(ProjectLineProfile));
            services.AddAutoMapper(typeof(ProjectLineWorkProfile));
            services.AddAutoMapper(typeof(ProjectProfile));
            services.AddAutoMapper(typeof(RoleProfile));
            services.AddAutoMapper(typeof(SupportFileProfile));
            services.AddAutoMapper(typeof(TransactionProfile));
            services.AddAutoMapper(typeof(TransactionItemProfile));
            services.AddAutoMapper(typeof(TransactionTypeProfile));
            services.AddAutoMapper(typeof(UserProfile));
            services.AddAutoMapper(typeof(VacationHistoryProfile));
            services.AddAutoMapper(typeof(VacationRequestProfile));
            services.AddAutoMapper(typeof(VacationTypesProfile));

            // Phase 3: Advanced Features
            services.AddAutoMapper(typeof(AppNotificationProfile));

            //services.AddAutoMapper(typeof());
            //services.AddAutoMapper(typeof());
            //services.AddAutoMapper(typeof());
            //services.AddAutoMapper(typeof());
            //services.AddAutoMapper(typeof());

        }
    }
}
