namespace Koala.Portal.Core.CrmModels;

public partial class CT_Sales_Rep
{
    public Guid Oid { get; set; }

    public Guid? SalesRepPersonInfo { get; set; }

    public Guid? SalesArea { get; set; }

    public bool? IsActive { get; set; }

    public bool? CanOfferProposalToOtherPortfolios { get; set; }

    public bool? CanOfferProposalToEmptyPortfolios { get; set; }

    public bool? CanEditOtherPortfolios { get; set; }

    public bool? CanEditEmptyPortfolios { get; set; }

    public bool? CanActivityToOtherPortfolios { get; set; }

    public bool? CanActivityToEmptyPortfolios { get; set; }

    public bool? CanLeadToOtherPortfolios { get; set; }

    public bool? CanLeadToEmptyPortfolios { get; set; }

    public bool? CanSaleToOtherPortfolios { get; set; }

    public bool? CanSaleToEmptyPortfolios { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? ERPSalesman { get; set; }

    public string? _photoBase64Url { get; set; }

    public Guid? _RelatedUser { get; set; }

    public virtual ICollection<MT_Activity> MT_Activity { get; set; } = new List<MT_Activity>();

    public virtual ICollection<MT_Contact> MT_Contact { get; set; } = new List<MT_Contact>();

    public virtual ICollection<MT_Firm> MT_Firm { get; set; } = new List<MT_Firm>();

    public virtual ICollection<MT_Opportunity> MT_Opportunity { get; set; } = new List<MT_Opportunity>();

    public virtual ICollection<MT_Proposals> MT_Proposals { get; set; } = new List<MT_Proposals>();

    public virtual ICollection<MT_Proposals_Approvals_Details> MT_Proposals_Approvals_Details { get; set; } = new List<MT_Proposals_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Revisals> MT_Proposals_Revisals { get; set; } = new List<MT_Proposals_Revisals>();

    public virtual ICollection<RL_Activity_SalesRep> RL_Activity_SalesRep { get; set; } = new List<RL_Activity_SalesRep>();

    public virtual ICollection<RL_SalesRep_Opportunity> RL_SalesRep_Opportunity { get; set; } = new List<RL_SalesRep_Opportunity>();

    public virtual ICollection<RL_User_Sales_Rep> RL_User_Sales_Rep { get; set; } = new List<RL_User_Sales_Rep>();

    public virtual ICollection<ST_Activity_Planning> ST_Activity_Planning { get; set; } = new List<ST_Activity_Planning>();

    public virtual CT_Sales_Area? SalesAreaNavigation { get; set; }

    public virtual PO_Person? SalesRepPersonInfoNavigation { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }

    public virtual ST_User? _RelatedUserNavigation { get; set; }
}
