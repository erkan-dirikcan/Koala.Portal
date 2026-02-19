namespace Koala.Portal.Core.CrmModels;

public partial class RL_Mail_Task
{
    public Guid? MailOid { get; set; }

    public Guid? TaskOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Mail? MailO { get; set; }

    public virtual MT_Task? TaskO { get; set; }
}
