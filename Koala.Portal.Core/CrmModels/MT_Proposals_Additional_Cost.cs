namespace Koala.Portal.Core.CrmModels;

public partial class MT_Proposals_Additional_Cost
{
    public Guid Oid { get; set; }

    public int? AdditionalCostDivideType { get; set; }

    public double? AdditionalCostAmount { get; set; }

    public Guid? CurrencyType { get; set; }

    public double? ExchangeRate { get; set; }

    public Guid? Proposal { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual CT_Currency_Types? CurrencyTypeNavigation { get; set; }

    public virtual ICollection<MT_Proposals> MT_Proposals { get; set; } = new List<MT_Proposals>();

    public virtual ICollection<MT_Proposals_Approvals_Details> MT_Proposals_Approvals_Details { get; set; } = new List<MT_Proposals_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Revisals> MT_Proposals_Revisals { get; set; } = new List<MT_Proposals_Revisals>();

    public virtual MT_Proposals? ProposalNavigation { get; set; }
}
