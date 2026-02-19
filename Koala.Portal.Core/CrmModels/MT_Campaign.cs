namespace Koala.Portal.Core.CrmModels;

public partial class MT_Campaign
{
    public Guid Oid { get; set; }

    public string? CampaignName { get; set; }

    public int? Priority { get; set; }

    public int? Status { get; set; }

    public Guid? CampaignType { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public double? EstimatedRevenue { get; set; }

    public double? EstimatedCost { get; set; }

    public string? Notes { get; set; }

    public string? Tags { get; set; }

    public string? NotifyUsers { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual CT_Campaign_Types? CampaignTypeNavigation { get; set; }

    public virtual ICollection<MT_Activity> MT_Activity { get; set; } = new List<MT_Activity>();

    public virtual ICollection<MT_Campaign_Lists> MT_Campaign_Lists { get; set; } = new List<MT_Campaign_Lists>();

    public virtual ICollection<MT_Event> MT_Event { get; set; } = new List<MT_Event>();

    public virtual ICollection<MT_Opportunity> MT_Opportunity { get; set; } = new List<MT_Opportunity>();

    public virtual ICollection<MT_Proposals> MT_Proposals { get; set; } = new List<MT_Proposals>();

    public virtual ICollection<MT_Proposals_Approvals_Details> MT_Proposals_Approvals_Details { get; set; } = new List<MT_Proposals_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Revisals> MT_Proposals_Revisals { get; set; } = new List<MT_Proposals_Revisals>();

    public virtual ICollection<RL_Campaign_Document> RL_Campaign_Document { get; set; } = new List<RL_Campaign_Document>();

    public virtual ICollection<RL_Campaign_List_Types> RL_Campaign_List_Types { get; set; } = new List<RL_Campaign_List_Types>();

    public virtual ICollection<RL_Campaign_Product> RL_Campaign_Product { get; set; } = new List<RL_Campaign_Product>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
