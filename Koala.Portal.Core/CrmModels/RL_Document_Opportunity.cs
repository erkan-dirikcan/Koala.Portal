namespace Koala.Portal.Core.CrmModels;

public partial class RL_Document_Opportunity
{
    public Guid? DocumentOid { get; set; }

    public Guid? OpportunityOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Document? DocumentO { get; set; }

    public virtual MT_Opportunity? OpportunityO { get; set; }
}
