namespace Koala.Portal.Core.CrmModels;

public partial class MT_Notifications
{
    public Guid Oid { get; set; }

    public string? NotificationDescription { get; set; }

    public int? Priority { get; set; }

    public string? ObjectClassName { get; set; }

    public Guid? ObjectOid { get; set; }

    public string? ObjectDescription { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public string? NotifyUsers { get; set; }

    public string? SeenBy { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public int? NotificationType { get; set; }

    public Guid? Firm { get; set; }

    public virtual MT_Firm? FirmNavigation { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
