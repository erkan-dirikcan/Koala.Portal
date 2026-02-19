using Microsoft.AspNetCore.Mvc.Rendering;

namespace Koala.Portal.WebUI
{
    public class ManageNavPages
    {
        private static string Dashboard => "Dashboard";
        private static string Agenda => "Agenda";
        private static string Projects => "Projects";
        private static string CustomerPortal => "CustomerPortal";
        private static string Firm => "Firm";
        private static string UserList => "UserList";
        private static string CreateUser => "CreateUser";
        private static string Roles => "Roles";
        private static string Claims => "Claims";
        private static string Fixtures => "Fixtures";
        private static string AgendaTypes => "AgendaTypes";
        private static string VacationTypes => "VacationTypes";
        private static string TransactionTypes => "TransactionTypes";
        private static string Modules => "Modules";
        private static string GeneratedIds => "GeneratedIds";
        
        private static string SupportFilter => "SupportFilter";

        private static string Applications => "Applications";



        private static string ApplicationsList => "ApplicationsList";
        private static string CreateApplications => "CreateApplications";
        private static string CreateApplicationModule => "CreateApplicationModule";
        private static string WaitingLicence => "WaitingLicence";
        //private static string Claims => "Claims";
        //private static string Claims => "Claims";
        //private static string Claims => "Claims";
        //private static string Claims => "Claims";


        //================================================================//
        private static string UserAccount => "UserAccount";
        private static string Settings => "Settings";
        private static string HelpDesk => "HelpDesk";

        //================================================================//
        private static string UserDashboard => "UserDashboard";
        private static string UserProfile => "UserProfile";
        private static string UserEvents => "UserEvents";
        private static string ChangePassword => "ChangePassword";
        private static string GetPass => "GetPass";


        //================================================================//
        private static string HelpDeskCategory => "HelpDeskCategory";
        private static string HelpDeskProblem => "HelpDeskProblem";
        private static string HelpDeskSolution => "HelpDeskSolution";


        //================================================================//
        /******************************************************************/
        //================================================================//


        public static string DashboardNavClass(ViewContext viewContext) => PageMainNavClass(viewContext,Dashboard);
        public static string CustomerPortalNavClass(ViewContext viewContext) => PageMainNavClass(viewContext, CustomerPortal);
        public static string ProjectsNavClass(ViewContext viewContext) => PageMainNavClass(viewContext, Projects);
        public static string AgendaNavClass(ViewContext viewContext) => PageMainNavClass(viewContext, Agenda);
        public static string UserListNavClass(ViewContext viewContext) => PageMainNavClass(viewContext,UserList);
        public static string CreateUserNavClass(ViewContext viewContext) => PageMainNavClass(viewContext,CreateUser);
        public static string RolesNavClass(ViewContext viewContext) => PageMainNavClass(viewContext,Roles);
        public static string ClaimsNavClass(ViewContext viewContext) => PageMainNavClass(viewContext,Claims);
        public static string FixturesNavClass(ViewContext viewContext) => PageMainNavClass(viewContext,Fixtures);
        public static string AgendaTypesNavClass(ViewContext viewContext) => PageMainNavClass(viewContext,AgendaTypes);
        public static string VacationTypesNavClass(ViewContext viewContext) => PageMainNavClass(viewContext,VacationTypes);
        public static string TransactionTypesNavClass(ViewContext viewContext) => PageMainNavClass(viewContext,TransactionTypes);
        public static string FirmNavClass(ViewContext viewContext) => PageMainNavClass(viewContext,Firm);
        public static string ModuleNavClass(ViewContext viewContext) => PageMainNavClass(viewContext,Modules);
        public static string GeneratedIdsNavClass(ViewContext viewContext) => PageMainNavClass(viewContext,GeneratedIds);
        public static string SupportFilterNavClass(ViewContext viewContext) => PageMainNavClass(viewContext, SupportFilter);
        public static string CreateApplicationsNavClass(ViewContext viewContext) => PageMainNavClass(viewContext,CreateApplications);
        public static string WaitingLicenceNavClass(ViewContext viewContext) => PageMainNavClass(viewContext,WaitingLicence);
        public static string ApplicationModuleNavClass(ViewContext viewContext) => PageMainNavClass(viewContext,CreateApplicationModule);
        public static string ApplicationsListNavClass(ViewContext viewContext) => PageMainNavClass(viewContext, ApplicationsList);
        public static string HelpDeskCategoryNavClass(ViewContext viewContext) => PageMainNavClass(viewContext, HelpDeskCategory);
        public static string HelpDeskProblemNavClass(ViewContext viewContext) => PageMainNavClass(viewContext, HelpDeskProblem);
        public static string HelpDeskSolutionNavClass(ViewContext viewContext) => PageMainNavClass(viewContext, HelpDeskSolution);

        //public static string NavClass(ViewContext viewContext) => PageMainNavClass(viewContext,);
        //public static string NavClass(ViewContext viewContext) => PageMainNavClass(viewContext,);

        //================================================================//
        public static string ApplicationNavClass(ViewContext viewContext) => PageMainToogleNavClass(viewContext, Applications);
        public static string UserAccountNavClass(ViewContext viewContext) => PageMainToogleNavClass(viewContext,UserAccount);
        public static string SettingsNavClass(ViewContext viewContext) => PageMainToogleNavClass(viewContext,Settings);
        public static string HelpDeskNavClass(ViewContext viewContext) => PageMainToogleNavClass(viewContext, HelpDesk);
        //================User Management=======================//


        public static string UserDashboardNavClass(ViewContext viewContext) => PageUserProfileNavClass(viewContext, UserDashboard);
        public static string UserProfileNavClass(ViewContext viewContext) => PageUserProfileNavClass(viewContext,UserProfile);
        public static string UserEventsNavClass(ViewContext viewContext) => PageUserProfileNavClass(viewContext, UserEvents);
        public static string ChangePasswordNavClass(ViewContext viewContext) => PageUserProfileNavClass(viewContext, ChangePassword);
        public static string GetPassNavClass(ViewContext viewContext) => PageUserProfileNavClass(viewContext, GetPass);


        //================================================================//
        /******************************************************************/
        //================================================================//


        private static string PageMainNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                             ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "menu-item-active" : null;
        }
        private static string PageMainToogleNavClass(ViewContext viewContext, string page)
        {
            var menuToogle = viewContext.ViewData["MenuToggle"] as string
                             ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(menuToogle, page, StringComparison.OrdinalIgnoreCase) ? "menu-item-open" : "";
        }
        private static string PageUserProfileNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                             ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : "";
        }
       
    }
   
}
