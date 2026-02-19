namespace Koala.Portal.Core.CrmModels;

public partial class RL_Ticket_Task
{
    public Guid? TaskOid { get; set; }

    public Guid? TicketOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Task? TaskO { get; set; }

    public virtual MT_Ticket? TicketO { get; set; }
}
