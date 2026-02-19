namespace Koala.Portal.Core.CrmModels;

public partial class RL_Product_Ticket
{
    public Guid? RelatedProductsOid { get; set; }

    public Guid? RelatedTicketOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Product? RelatedProductsO { get; set; }

    public virtual MT_Ticket? RelatedTicketO { get; set; }
}
