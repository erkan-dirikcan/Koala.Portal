namespace Koala.Portal.Core.CrmModels;

public partial class RL_Opportunity_Event
{
    public Guid? EventOid { get; set; }

    public Guid? OpportunityOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Event? EventO { get; set; }

    public virtual MT_Opportunity? OpportunityO { get; set; }
}
