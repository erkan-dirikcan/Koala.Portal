namespace Koala.Portal.Core.Permissions
{
    public static class Permissions
    {
        public static class EventCallendar
        {
            public const string View = "EventCallendar.View";
            public const string Create = "EventCallendar.Create";
            public const string Update = "EventCallendar.Update";
            public const string Cancel = "EventCallendar.Cancel";
            public const string Complate = "EventCallendar.Complate";
        }
        public static class SupportTicket
        {
            public const string View = "SupportTicket.View";
            public const string Create = "SupportTicket.Create";
            public const string Update = "SupportTicket.Update";
            public const string Complate = "SupportTicket.Complate";
            public const string TransferToUser = "SupportTicket.TransferToUser";
            public const string GetItOn = "SupportTicket.GetItOn";
            public const string Start = "SupportTicket.Start";
        }
        public static class ManageUser
        {
            public const string ViewDetail = "ManageUser.ViewDetail";
            public const string ViewList = "ManageUser.ViewList";
            public const string Create = "ManageUser.Create";
            public const string Update = "ManageUser.Update";
            public const string ChangeStatus = "ManageUser.ChangeStatus";
            public const string Authorize = "ManageUser.Authorize";//Rol Ata
            public const string ViewRoleList = "ManageUser.ViewRoleList";
            public const string CreateRole = "ManageUser.CreateRole";
            public const string UpdateRole = "ManageUser.UpdateRole";
            public const string DeleteRole = "ManageUser.DeleteRole";
            public const string Claims = "ManageUser.Claims";
        }
        public static class Project
        {
            public const string View = "Project.View";
            public const string Create = "Project.Create";
            public const string Update = "Project.Update";
            public const string Edit = "Project.Edit";
            public const string Cancel = "Project.Cancel";
            public const string Complete = "Project.Complete";
            public const string Complate = "Project.Complate"; // Keep for backward compatibility
            public const string Delete = "Project.Delete";

        }
        public static class CrmFirm
        {
            public const string View = "Firm.View";
            public const string Sencron = "Firm.Sencron";
            public const string Update = "Firm.Update";
            public const string Remove = "Firm.Remove";
        }
        public static class LogoCrmFirmAndContact
        {
            public const string View = "LogoCrmFirmAndContact.View";
            public const string Sencron = "LogoCrmFirmAndContact.Sencron";
            public const string Update = "LogoCrmFirmAndContact.Update";
            public const string Remove = "LogoCrmFirmAndContact.Remove";
            public const string TicketStatusChange = "LogoCrmFirmAndContact.TicketStatusChange";
        }
        public static class HelpDesc
        {
            public const string ViewSolitions = "HelpDesc.ViewSolitions";
            public const string Create = "HelpDesc.Create";
            public const string Update = "HelpDesc.Update";
            public const string ChangeStatus = "HelpDesc.ChangeStatus";
        }
        public static class Koala
        {
            public const string DashboardView = "Koala.DashboardView";
            //public const string Create = "HelpDesc.Create";
            //public const string Update = "HelpDesc.Update";
            //public const string ChangeStatus = "HelpDesc.ChangeStatus";
        }
        public static class Module
        {
            public const string Create = "Module.Create";
            public const string Update = "Module.Update";
            public const string ChangeStatus = "Module.ChangeStatus";
        }


    }
}
