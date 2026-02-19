namespace Koala.Portal.Core.CrmModels;

public partial class RI_Units_Collections_Properties
{
    public Guid Oid { get; set; }

    public Guid? RelatedUnit { get; set; }

    public bool? IsMainUnit { get; set; }

    public double? ConversionFactorMultiply { get; set; }

    public double? ConversionFactorDivide { get; set; }

    public Guid? UnitCollectionsOid { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? SystemPredefinedSetNo { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual CT_Units? RelatedUnitNavigation { get; set; }

    public virtual CT_Units_Collections? UnitCollectionsO { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
