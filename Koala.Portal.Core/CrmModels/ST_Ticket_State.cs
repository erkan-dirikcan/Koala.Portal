namespace Koala.Portal.Core.CrmModels;

public partial class ST_Ticket_State
{
    public Guid Oid { get; set; }

    public Guid? TicketOid { get; set; }

    public Guid? TicketState { get; set; }

    public string? Notes { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? Duration { get; set; }

    public virtual MT_Ticket? TicketO { get; set; }

    public virtual CT_Ticket_States? TicketStateNavigation { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
