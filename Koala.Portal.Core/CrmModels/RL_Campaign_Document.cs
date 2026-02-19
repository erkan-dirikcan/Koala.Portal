namespace Koala.Portal.Core.CrmModels;

public partial class RL_Campaign_Document
{
    public Guid? CampaignOid { get; set; }

    public Guid? RelatedDocuments { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Campaign? CampaignO { get; set; }

    public virtual MT_Document? RelatedDocumentsNavigation { get; set; }
}
