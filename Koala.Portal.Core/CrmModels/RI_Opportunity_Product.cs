namespace Koala.Portal.Core.CrmModels;

public partial class RI_Opportunity_Product
{
    public Guid Oid { get; set; }

    public Guid? Opportunity { get; set; }

    public Guid? RelatedProduct { get; set; }

    public double? Amount { get; set; }

    public string? NotesAndDescription { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual MT_Opportunity? OpportunityNavigation { get; set; }

    public virtual MT_Product? RelatedProductNavigation { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
