namespace Koala.Portal.Core.CrmModels;

public partial class RL_Product_Opportunity
{
    public Guid? RelatedOpportunityOid { get; set; }

    public Guid? RelatedProductsOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Opportunity? RelatedOpportunityO { get; set; }

    public virtual MT_Product? RelatedProductsO { get; set; }
}
