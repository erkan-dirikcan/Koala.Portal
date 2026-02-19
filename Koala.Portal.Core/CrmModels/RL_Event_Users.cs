namespace Koala.Portal.Core.CrmModels;

public partial class RL_Event_Users
{
    public Guid? EventOid { get; set; }

    public Guid? Resources { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Event? EventO { get; set; }

    public virtual ST_User? ResourcesNavigation { get; set; }
}
