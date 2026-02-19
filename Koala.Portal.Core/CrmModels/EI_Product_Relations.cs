namespace Koala.Portal.Core.CrmModels;

public partial class EI_Product_Relations
{
    public Guid Oid { get; set; }

    public Guid? SetOid { get; set; }

    public Guid? ProductOid { get; set; }

    public string? Ref { get; set; }

    public string? Code_ { get; set; }

    public string? Name_ { get; set; }

    public int? ProductType { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual MT_Product? ProductO { get; set; }

    public virtual EI_Integration_Sets? SetO { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
