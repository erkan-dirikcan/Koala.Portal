namespace Koala.Portal.Core.CrmModels;

public partial class RL_Opportunity_Stage_Criteria
{
    public Guid? CriterionOid { get; set; }

    public Guid? OpportunityStageOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual CT_Opportunity_Stages_Criteria? CriterionO { get; set; }

    public virtual CT_Opportunity_Stages? OpportunityStageO { get; set; }
}
