namespace Koala.Portal.Core.CrmModels;

public partial class RL_Mail_Activity
{
    public Guid? ActivityOid { get; set; }

    public Guid? MailOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Activity? ActivityO { get; set; }

    public virtual MT_Mail? MailO { get; set; }
}
