namespace Koala.Portal.Core.CrmModels;

public partial class AA_CompetitorManagement_Proposals
{
    public Guid Oid { get; set; }

    public Guid? CompetitorOid { get; set; }

    public bool? OurProposal { get; set; }

    public double? LC_ProposalAmount { get; set; }

    public string? CompetitorNotes { get; set; }

    public Guid? RelatedProposal { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual MT_Firm? CompetitorO { get; set; }

    public virtual MT_Proposals? RelatedProposalNavigation { get; set; }
}
