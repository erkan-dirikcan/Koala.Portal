namespace Koala.Portal.Core.CrmModels;

public partial class CT_Units_Collections
{
    public Guid Oid { get; set; }

    public string? UnitCollectionCode { get; set; }

    public string? UnitCollectionDescription { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? UnitCollectionType { get; set; }

    public bool? IsActive { get; set; }

    public int? SystemPredefinedSetNo { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<EI_Unit_Collection_Relations> EI_Unit_Collection_Relations { get; set; } = new List<EI_Unit_Collection_Relations>();

    public virtual ICollection<MT_Product> MT_Product { get; set; } = new List<MT_Product>();

    public virtual ICollection<RI_Units_Collections_Properties> RI_Units_Collections_Properties { get; set; } = new List<RI_Units_Collections_Properties>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
