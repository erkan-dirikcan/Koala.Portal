using Koala.Portal.Core.Mapping;
using Koala.Portal.Service.Mapping;

namespace Koala.Portal.WebApi.Extentions
{
    public static class MappingExtention
    {
        public static void AddMappingConfExt(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AgendaProfile));
            services.AddAutoMapper(typeof(AgendaTypeProfile));
            services.AddAutoMapper(typeof(AgendaUserProfile));
            services.AddAutoMapper(typeof(ContactPhonesProfile));
            services.AddAutoMapper(typeof(CrmDepartmentProfile));
            services.AddAutoMapper(typeof(CrmCategoryProfile));
            services.AddAutoMapper(typeof(CrmFirmContactProfile));
            services.AddAutoMapper(typeof(CrmFirmProfile));
            services.AddAutoMapper(typeof(CrmSupportProfile));
            services.AddAutoMapper(typeof(CrmSupportStateProfile));
            services.AddAutoMapper(typeof(FixtureProfile));
            services.AddAutoMapper(typeof(RoleProfile));
            services.AddAutoMapper(typeof(UserProfile));
            services.AddAutoMapper(typeof(ClaimProfile));
            services.AddAutoMapper(typeof(SupportFileProfile));
            services.AddAutoMapper(typeof(CrmSupportHistoryProfile));
            services.AddAutoMapper(typeof(ApplicationsProfile));
            services.AddAutoMapper(typeof(HelpDeskCategoryProfile));
            services.AddAutoMapper(typeof(HelpDeskProblemProfile));


        }
    }
}
