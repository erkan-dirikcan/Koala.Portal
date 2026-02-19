namespace Koala.Portal.Core.CrmModels;

public partial class RL_Ticket_Event
{
    public Guid? EventOid { get; set; }

    public Guid? TicketOid { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual MT_Event? EventO { get; set; }

    public virtual MT_Ticket? TicketO { get; set; }
}
