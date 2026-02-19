namespace Koala.Portal.Core.CrmModels;

public partial class CT_Product_Groups
{
    public Guid Oid { get; set; }

    public string? ProductGroupCode { get; set; }

    public string? ProductGroupDescription { get; set; }

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
