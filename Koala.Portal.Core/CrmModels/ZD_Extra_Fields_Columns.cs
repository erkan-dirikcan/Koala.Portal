namespace Koala.Portal.Core.CrmModels;

public partial class ZD_Extra_Fields_Columns
{
    public Guid Oid { get; set; }

    public Guid? ExtraFieldOid { get; set; }

    public int? ColumnNumber { get; set; }

    public string? ColumnCaption { get; set; }

    public bool? IsActive { get; set; }

    public string? ColumnFieldName { get; set; }

    public bool? VisibleInDisplay { get; set; }

    public int? ColumnWidth { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ZD_Extra_Fields? ExtraFieldO { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
