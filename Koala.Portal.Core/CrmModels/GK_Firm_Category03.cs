namespace Koala.Portal.Core.CrmModels;

public partial class GK_Firm_Category03
{
    public Guid Oid { get; set; }

    public string? CategoryDescription { get; set; }

    public bool? IsActive { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<MT_Firm> MT_Firm { get; set; } = new List<MT_Firm>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
