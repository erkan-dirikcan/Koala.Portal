namespace Koala.Portal.Core.CrmModels;

public partial class CT_Opportunity_Stages_Criteria
{
    public Guid Oid { get; set; }

    public string? Description { get; set; }

    public int? ObjectTypeInt { get; set; }

    public string? ObjectType { get; set; }

    public string? Criterion { get; set; }

    public string? CriterionText { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<RL_Opportunity_Stage_Criteria> RL_Opportunity_Stage_Criteria { get; set; } = new List<RL_Opportunity_Stage_Criteria>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
