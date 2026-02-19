namespace Koala.Portal.Core.CrmModels;

public partial class AA_GoogleCalendar_UserCalendar
{
    public Guid Oid { get; set; }

    public Guid? UserSettingOid { get; set; }

    public bool? DoSync { get; set; }

    public bool? MainCalendar { get; set; }

    public string? CalendarId { get; set; }

    public string? Summary { get; set; }

    public string? Description { get; set; }

    public bool? ApplyDeletesToCRM { get; set; }

    public bool? ApplyDeletesToGoogle { get; set; }

    public bool? NewActivityForMeetings { get; set; }

    public DateTime? LastSyncDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual AA_GoogleCalendar_UserSettings? UserSettingO { get; set; }
}
