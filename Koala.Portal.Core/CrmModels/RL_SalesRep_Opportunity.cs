namespace Koala.Portal.Core.CrmModels;

public partial class RL_SalesRep_Opportunity
{
    public Guid? RelatedSalesRep { get; set; }

    public Guid? OpportunityOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Opportunity? OpportunityO { get; set; }

    public virtual CT_Sales_Rep? RelatedSalesRepNavigation { get; set; }
}
