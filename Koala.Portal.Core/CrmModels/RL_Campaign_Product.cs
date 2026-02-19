namespace Koala.Portal.Core.CrmModels;

public partial class RL_Campaign_Product
{
    public Guid? RelatedCampaigns { get; set; }

    public Guid? RelatedProducts { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Campaign? RelatedCampaignsNavigation { get; set; }

    public virtual MT_Product? RelatedProductsNavigation { get; set; }
}
