namespace Koala.Portal.Core.CrmModels;

public partial class MT_Mail
{
    public Guid Oid { get; set; }

    public int? Direction { get; set; }

    public string? EntryId { get; set; }

    public int? Priority { get; set; }

    public DateTime? SendDate { get; set; }

    public string? MailSubject { get; set; }

    public string? From_ { get; set; }

    public string? FromName_ { get; set; }

    public string? To_ { get; set; }

    public string? Cc_ { get; set; }

    public string? Bcc_ { get; set; }

    public string? Tags { get; set; }

    public int? Size { get; set; }

    public byte[]? Content { get; set; }

    public string? TextBody { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? FileName { get; set; }

    public virtual ICollection<RL_Mail_Activity> RL_Mail_Activity { get; set; } = new List<RL_Mail_Activity>();

    public virtual ICollection<RL_Mail_Contact> RL_Mail_Contact { get; set; } = new List<RL_Mail_Contact>();

    public virtual ICollection<RL_Mail_Firm> RL_Mail_Firm { get; set; } = new List<RL_Mail_Firm>();

    public virtual ICollection<RL_Mail_Opportunity> RL_Mail_Opportunity { get; set; } = new List<RL_Mail_Opportunity>();

    public virtual ICollection<RL_Mail_Proposal> RL_Mail_Proposal { get; set; } = new List<RL_Mail_Proposal>();

    public virtual ICollection<RL_Mail_Task> RL_Mail_Task { get; set; } = new List<RL_Mail_Task>();

    public virtual ICollection<RL_Mail_Ticket> RL_Mail_Ticket { get; set; } = new List<RL_Mail_Ticket>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
