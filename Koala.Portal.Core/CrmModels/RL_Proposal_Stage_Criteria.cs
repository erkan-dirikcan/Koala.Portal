namespace Koala.Portal.Core.CrmModels;

public partial class RL_Proposal_Stage_Criteria
{
    public Guid? CriterionOid { get; set; }

    public Guid? ProposalStageOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual CT_Proposal_Stages_Criteria? CriterionO { get; set; }

    public virtual CT_Proposal_Stages? ProposalStageO { get; set; }
}
