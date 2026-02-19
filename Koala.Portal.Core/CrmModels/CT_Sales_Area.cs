namespace Koala.Portal.Core.CrmModels;

public partial class CT_Sales_Area
{
    public Guid Oid { get; set; }

    public string? AreaName { get; set; }

    public bool? IsActive { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<CT_Sales_Rep> CT_Sales_Rep { get; set; } = new List<CT_Sales_Rep>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
