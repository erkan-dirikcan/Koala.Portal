namespace Koala.Portal.Core.CrmModels;

public partial class CT_Ticket_States
{
    public Guid Oid { get; set; }

    public string? TicketStateDescription { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsCompleted { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<MT_Ticket> MT_Ticket { get; set; } = new List<MT_Ticket>();

    public virtual ICollection<ST_Ticket_State> ST_Ticket_State { get; set; } = new List<ST_Ticket_State>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
