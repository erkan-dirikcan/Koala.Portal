namespace Koala.Portal.Core.CrmModels;

public partial class RL_Campaign_List_Types
{
    public Guid? ListTypes { get; set; }

    public Guid? CampaignOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Campaign? CampaignO { get; set; }

    public virtual CT_List_Types? ListTypesNavigation { get; set; }
}
