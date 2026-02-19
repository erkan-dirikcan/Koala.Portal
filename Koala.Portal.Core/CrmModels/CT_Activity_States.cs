namespace Koala.Portal.Core.CrmModels;

public partial class CT_Activity_States
{
    public Guid Oid { get; set; }

    public string? ActivityStateDescription { get; set; }

    public int? Issue { get; set; }

    public bool? IsActive { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<MT_Activity> MT_Activity { get; set; } = new List<MT_Activity>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
