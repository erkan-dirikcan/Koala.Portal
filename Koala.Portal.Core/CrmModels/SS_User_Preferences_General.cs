namespace Koala.Portal.Core.CrmModels;

public partial class SS_User_Preferences_General
{
    public Guid Oid { get; set; }

    public bool? EditInPopupWindow { get; set; }

    public int? FullSearchMaxResultCount { get; set; }

    public bool? FullSearchOpenInPopup { get; set; }

    public bool? AutoRefreshShareView { get; set; }

    public int? AutoRefreshShareViewSeconds { get; set; }

    public string? StartupNavigationItem { get; set; }

    public Guid? OwnerUser { get; set; }

    public bool? SystemOverride { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public int? LookupSearchMode { get; set; }

    public double? CalendarStartTime { get; set; }

    public double? CalendarFinishTime { get; set; }

    public DateTime? GoogleCalendarSyncStartDate { get; set; }

    public int? GoogleCalendarSyncPeriodCoverage { get; set; }

    public int? GoogleCalendarSyncStartPeriod { get; set; }

    public int? ContactLookupListViewPreference { get; set; }

    public virtual ST_User? OwnerUserNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
