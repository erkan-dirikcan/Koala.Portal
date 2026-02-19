namespace Koala.Portal.Core.CrmModels;

public partial class CT_Product_Classes
{
    public Guid Oid { get; set; }

    public string? ProductClassCode { get; set; }

    public string? ProductClassDescription { get; set; }

    public bool? IsActive { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<MT_Product> MT_Product { get; set; } = new List<MT_Product>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
