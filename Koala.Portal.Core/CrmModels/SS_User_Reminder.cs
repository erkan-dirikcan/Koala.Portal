namespace Koala.Portal.Core.CrmModels;

public partial class SS_User_Reminder
{
    public Guid Oid { get; set; }

    public string? ReminderId { get; set; }

    public string? ReminderText { get; set; }

    public int? ReminderIcon { get; set; }

    public string? User { get; set; }

    public bool? DoNotShowAgain { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }
}
