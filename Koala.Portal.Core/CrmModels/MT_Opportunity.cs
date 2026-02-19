namespace Koala.Portal.Core.CrmModels;

public partial class MT_Opportunity
{
    public Guid Oid { get; set; }

    public string? Id { get; set; }

    public string? OpportunitySubject { get; set; }

    public Guid? OpportunityFirm { get; set; }

    public Guid? OpportunityContact { get; set; }

    public Guid? SalesRep { get; set; }

    public int? Priority { get; set; }

    public Guid? OpportunitySource { get; set; }

    public Guid? OpportunityType { get; set; }

    public Guid? OpportunityStage { get; set; }

    public int? OpportunityGeneralStatus { get; set; }

    public DateTime? OpportunityStartDate { get; set; }

    public DateTime? OpportunityEstEndDate { get; set; }

    public string? Notes { get; set; }

    public Guid? Campaign { get; set; }

    public string? Tags { get; set; }

    public string? NotifyUsers { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public DateTime? OpportunityGeneralStatusDate { get; set; }

    public double? EstimatedAmount { get; set; }

    public Guid? WinningCompetitor { get; set; }

    public double? WinningTotal { get; set; }

    public bool? cmo_ChartVisible { get; set; }

    public Guid? WinLoseReason { get; set; }

    public virtual ICollection<AA_CompetitorManagement_Opportunity> AA_CompetitorManagement_Opportunity { get; set; } = new List<AA_CompetitorManagement_Opportunity>();

    public virtual MT_Campaign? CampaignNavigation { get; set; }

    public virtual ICollection<MT_Proposals> MT_Proposals { get; set; } = new List<MT_Proposals>();

    public virtual ICollection<MT_Proposals_Approvals_Details> MT_Proposals_Approvals_Details { get; set; } = new List<MT_Proposals_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Revisals> MT_Proposals_Revisals { get; set; } = new List<MT_Proposals_Revisals>();

    public virtual MT_Contact? OpportunityContactNavigation { get; set; }

    public virtual MT_Firm? OpportunityFirmNavigation { get; set; }

    public virtual CT_Opportunity_Sources? OpportunitySourceNavigation { get; set; }

    public virtual CT_Opportunity_Stages? OpportunityStageNavigation { get; set; }

    public virtual CT_Opportunity_Types? OpportunityTypeNavigation { get; set; }

    public virtual ICollection<RI_Opportunity_Product> RI_Opportunity_Product { get; set; } = new List<RI_Opportunity_Product>();

    public virtual ICollection<RL_Contact_Opportunity_Other> RL_Contact_Opportunity_Other { get; set; } = new List<RL_Contact_Opportunity_Other>();

    public virtual ICollection<RL_Document_Opportunity> RL_Document_Opportunity { get; set; } = new List<RL_Document_Opportunity>();

    public virtual ICollection<RL_Mail_Opportunity> RL_Mail_Opportunity { get; set; } = new List<RL_Mail_Opportunity>();

    public virtual ICollection<RL_Opportunity_Activity> RL_Opportunity_Activity { get; set; } = new List<RL_Opportunity_Activity>();

    public virtual ICollection<RL_Opportunity_Event> RL_Opportunity_Event { get; set; } = new List<RL_Opportunity_Event>();

    public virtual ICollection<RL_Opportunity_Task> RL_Opportunity_Task { get; set; } = new List<RL_Opportunity_Task>();

    public virtual ICollection<RL_Product_Opportunity> RL_Product_Opportunity { get; set; } = new List<RL_Product_Opportunity>();

    public virtual ICollection<RL_SalesRep_Opportunity> RL_SalesRep_Opportunity { get; set; } = new List<RL_SalesRep_Opportunity>();

    public virtual CT_Sales_Rep? SalesRepNavigation { get; set; }

    public virtual AA_CompetitorManagement_Reason? WinLoseReasonNavigation { get; set; }

    public virtual MT_Firm? WinningCompetitorNavigation { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
