namespace Koala.Portal.Core.CrmModels;

public partial class AA_GoogleCalendar_Events
{
    public Guid Oid { get; set; }

    public Guid? Event { get; set; }

    public Guid? User { get; set; }

    public string? GoogleCalendarId { get; set; }

    public string? GoogleEventId { get; set; }

    public string? GoogleAttendees { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual MT_Event? EventNavigation { get; set; }

    public virtual ST_User? UserNavigation { get; set; }
}
