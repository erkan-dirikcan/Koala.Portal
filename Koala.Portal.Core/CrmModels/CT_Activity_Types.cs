namespace Koala.Portal.Core.CrmModels;

public partial class CT_Activity_Types
{
    public Guid Oid { get; set; }

    public string? ActivityTypeDescription { get; set; }

    public bool? IsActive { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<MT_Activity> MT_Activity { get; set; } = new List<MT_Activity>();

    public virtual ICollection<ST_Activity_Planning> ST_Activity_Planning { get; set; } = new List<ST_Activity_Planning>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
