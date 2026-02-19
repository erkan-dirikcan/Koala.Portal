namespace Koala.Portal.Core.CrmModels;

public partial class CT_Personnel
{
    public Guid Oid { get; set; }

    public Guid? PersonnelPersonInfo { get; set; }

    public bool? IsActive { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual PO_Person? PersonnelPersonInfoNavigation { get; set; }

    public virtual ICollection<RL_Ticket_Personnel> RL_Ticket_Personnel { get; set; } = new List<RL_Ticket_Personnel>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
