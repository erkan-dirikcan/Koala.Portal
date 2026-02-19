namespace Koala.Portal.Core.CrmModels;

public partial class RL_Contact_Opportunity_Other
{
    public Guid? ContactOid { get; set; }

    public Guid? OpportunityOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Contact? ContactO { get; set; }

    public virtual MT_Opportunity? OpportunityO { get; set; }
}
