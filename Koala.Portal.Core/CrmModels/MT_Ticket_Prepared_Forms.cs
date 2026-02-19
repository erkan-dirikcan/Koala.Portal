namespace Koala.Portal.Core.CrmModels;

public partial class MT_Ticket_Prepared_Forms
{
    public Guid Oid { get; set; }

    public Guid? RelatedTicket { get; set; }

    public string? FormName { get; set; }

    public Guid? PreparedForm { get; set; }

    public string? Notes { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public bool? Initiated { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public int? DocumentType { get; set; }

    public string? TicketReportName { get; set; }

    public virtual PO_Prepared_Form? PreparedFormNavigation { get; set; }

    public virtual MT_Ticket? RelatedTicketNavigation { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
