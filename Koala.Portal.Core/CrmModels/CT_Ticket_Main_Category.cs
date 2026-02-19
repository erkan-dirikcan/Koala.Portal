namespace Koala.Portal.Core.CrmModels;

public partial class CT_Ticket_Main_Category
{
    public Guid Oid { get; set; }

    public string? TicketMainCategoryDescription { get; set; }

    public bool? IsActive { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public int? DepartmentType { get; set; }

    public virtual ICollection<CT_Ticket_Sub_Category> CT_Ticket_Sub_Category { get; set; } = new List<CT_Ticket_Sub_Category>();

    public virtual ICollection<MT_Ticket> MT_Ticket { get; set; } = new List<MT_Ticket>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
