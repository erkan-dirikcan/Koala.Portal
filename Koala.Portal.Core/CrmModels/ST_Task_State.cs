namespace Koala.Portal.Core.CrmModels;

public partial class ST_Task_State
{
    public Guid Oid { get; set; }

    public Guid? TaskOid { get; set; }

    public int? Status { get; set; }

    public string? Notes { get; set; }

    public string? Duration { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual MT_Task? TaskO { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
