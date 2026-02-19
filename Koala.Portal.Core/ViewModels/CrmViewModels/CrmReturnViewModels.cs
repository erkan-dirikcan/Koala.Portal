namespace Koala.Portal.Core.ViewModels.CrmViewModels
{
    public class CrmUserDepartmentsViewModel
    {
        public string Oid { get; set; }
        public string DepartmentName { get; set; }
    }

    public class CrmDashboardKpiViewModel
    {
        public CrmDashboardKpiViewModel()
        {

        }
        public CrmDashboardKpiViewModel(List<int>? weeklyComplatedSupports, int waitingSupportCount, int waitOnLogoSupportCount, int waitWebUserSupportCount, int waitOnWaitingForAccess, List<int>? weeklyIcomplatedSupports, List<int>? weeklyOpenedForMeSupports, List<int>? weeklyTotalOpenedSupports, List<int>? weeklyOpenedFromWebsiteSupports)
        {
            WeeklyComplatedSupports = weeklyComplatedSupports;
            WaitingSupportCount = waitingSupportCount;
            WaitOnLogoSupportCount = waitOnLogoSupportCount;
            WaitWebUserSupportCount = waitWebUserSupportCount;
            WaitOnWaitingForAccessCount = waitOnWaitingForAccess;
            WeeklyIcomplatedSupports = weeklyIcomplatedSupports;
            WeeklyOpenedForMeSupports = weeklyOpenedForMeSupports;
            WeeklyTotalOpenedSupports = weeklyTotalOpenedSupports;
            WeeklyOpenedFromWebsiteSupports = weeklyOpenedFromWebsiteSupports;
        }

        public List<int>? WeeklyComplatedSupports { get; set; }
        public int WaitingSupportCount { get; set; }
        public int WaitOnLogoSupportCount { get; set; }
        public int WaitWebUserSupportCount { get; set; }
        public int WaitOnWaitingForAccessCount { get; set; }
        public List<string> Dates { get; set; }
        public List<int>? WeeklyIcomplatedSupports { get; set; }
        public List<int>? WeeklyOpenedForMeSupports { get; set; }
        public List<int>? WeeklyTotalOpenedSupports { get; set; }
        public List<int>? WeeklyOpenedFromWebsiteSupports { get; set; }
    }

    //public class CrmDashboardKpiDbViewModel
    //{

    //    public int WaitingSupportCount { get; set; }
    //    public int WaitOnLogoSupportCount { get; set; }
    //    public int WaitWebUserSupportCount { get; set; }
    //    public int WaitOnWaitingForAccess { get; set; }
    //    public string AssignedTo { get; set; }
    //    public string TicketState { get; set; }
    //    public DateTime CallTime { get; set; }
    //    public DateTime CloseTime { get; set; }
    //    public string ActiveWorkingUser { get; set; }

    //}
    public class CrmDashboardKpiDbViewModel
    {

        public int WaitingMySupportCount { get; set; }
        public int WaitAnswerSupportCount { get; set; }
        public int WaitingdDepartmentSupportCount { get; set; }
        public int WaitWebUserSupportCount { get; set; }
        public int WaitOnLogoSupportCount { get; set; }
        //public string AssignedTo { get; set; }
        //public string TicketState { get; set; }
        //public DateTime CallTime { get; set; }
        //public DateTime CloseTime { get; set; }
        //public string ActiveWorkingUser { get; set; }

    }
}
