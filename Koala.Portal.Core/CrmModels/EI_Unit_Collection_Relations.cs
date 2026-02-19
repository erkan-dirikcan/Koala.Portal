namespace Koala.Portal.Core.CrmModels;

public partial class EI_Unit_Collection_Relations
{
    public Guid Oid { get; set; }

    public Guid? SetOid { get; set; }

    public Guid? UnitCollectionOid { get; set; }

    public string? Ref { get; set; }

    public string? Code_ { get; set; }

    public string? Name_ { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual EI_Integration_Sets? SetO { get; set; }

    public virtual CT_Units_Collections? UnitCollectionO { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
