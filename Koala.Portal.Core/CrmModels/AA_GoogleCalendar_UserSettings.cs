namespace Koala.Portal.Core.CrmModels;

public partial class AA_GoogleCalendar_UserSettings
{
    public Guid Oid { get; set; }

    public Guid? User { get; set; }

    public string? AuthKey { get; set; }

    public bool? IsAuthorized { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<AA_GoogleCalendar_UserCalendar> AA_GoogleCalendar_UserCalendar { get; set; } = new List<AA_GoogleCalendar_UserCalendar>();

    public virtual ST_User? UserNavigation { get; set; }
}
