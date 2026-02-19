namespace Koala.Portal.Core.CrmModels;

public partial class AA_CompetitorManagement_Opportunity
{
    public Guid Oid { get; set; }

    public Guid? CompetitorOid { get; set; }

    public bool? OurOpportunity { get; set; }

    public double? LC_Amount { get; set; }

    public string? CompetitorNotes { get; set; }

    public Guid? RelatedOpportunity { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual MT_Firm? CompetitorO { get; set; }

    public virtual MT_Opportunity? RelatedOpportunityNavigation { get; set; }
}
