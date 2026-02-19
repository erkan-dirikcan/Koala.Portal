namespace Koala.Portal.Core.CrmModels;

public partial class MT_Notes
{
    public Guid Oid { get; set; }

    public string? NoteDescription { get; set; }

    public string? NoteContent { get; set; }

    public bool? IsActive { get; set; }

    public bool? RemindInActivities { get; set; }

    public bool? RemindInOpportunities { get; set; }

    public bool? RemindInProposals { get; set; }

    public bool? RemindInContracts { get; set; }

    public bool? RemindInSupportTickets { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<RL_Notes_Contact> RL_Notes_Contact { get; set; } = new List<RL_Notes_Contact>();

    public virtual ICollection<RL_Notes_Departments> RL_Notes_Departments { get; set; } = new List<RL_Notes_Departments>();

    public virtual ICollection<RL_Notes_Firm> RL_Notes_Firm { get; set; } = new List<RL_Notes_Firm>();

    public virtual ICollection<RL_Notes_User> RL_Notes_User { get; set; } = new List<RL_Notes_User>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
