namespace Koala.Portal.Core.CrmModels;

public partial class RL_Product_Event
{
    public Guid? RelatedEventsOid { get; set; }

    public Guid? RelatedProductsOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Event? RelatedEventsO { get; set; }

    public virtual MT_Product? RelatedProductsO { get; set; }
}
