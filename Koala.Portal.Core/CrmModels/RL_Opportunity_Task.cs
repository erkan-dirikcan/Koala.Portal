namespace Koala.Portal.Core.CrmModels;

public partial class RL_Opportunity_Task
{
    public Guid? OpportunityOid { get; set; }

    public Guid? TaskOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Opportunity? OpportunityO { get; set; }

    public virtual MT_Task? TaskO { get; set; }
}
