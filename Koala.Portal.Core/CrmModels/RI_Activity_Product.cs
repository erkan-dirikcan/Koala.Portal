namespace Koala.Portal.Core.CrmModels;

public partial class RI_Activity_Product
{
    public Guid Oid { get; set; }

    public Guid? Activity { get; set; }

    public Guid? RelatedProduct { get; set; }

    public double? Amount { get; set; }

    public string? NotesAndDescription { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? VariantCode { get; set; }

    public string? VariantName { get; set; }

    public string? VariantDescription { get; set; }

    public string? VariantRef { get; set; }

    public string? VariantCanConfig { get; set; }

    public virtual MT_Activity? ActivityNavigation { get; set; }

    public virtual MT_Product? RelatedProductNavigation { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
