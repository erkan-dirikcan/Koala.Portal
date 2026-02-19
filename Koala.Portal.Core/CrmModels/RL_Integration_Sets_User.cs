namespace Koala.Portal.Core.CrmModels;

public partial class RL_Integration_Sets_User
{
    public Guid? IntegrationSetOid { get; set; }

    public Guid? UserOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual EI_Integration_Sets? IntegrationSetO { get; set; }

    public virtual ST_User? UserO { get; set; }
}
