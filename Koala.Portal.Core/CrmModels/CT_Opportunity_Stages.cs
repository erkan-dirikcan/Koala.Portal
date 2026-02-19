namespace Koala.Portal.Core.CrmModels;

public partial class CT_Opportunity_Stages
{
    public Guid Oid { get; set; }

    public int? _Order { get; set; }

    public string? StageCode { get; set; }

    public string? StageDescription { get; set; }

    public int? PercentComplete { get; set; }

    public int? GeneralStatus { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsSystemPredefined { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<MT_Opportunity> MT_Opportunity { get; set; } = new List<MT_Opportunity>();

    public virtual ICollection<MT_Proposals_History> MT_Proposals_History { get; set; } = new List<MT_Proposals_History>();

    public virtual ICollection<RL_Opportunity_Stage_Criteria> RL_Opportunity_Stage_Criteria { get; set; } = new List<RL_Opportunity_Stage_Criteria>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
