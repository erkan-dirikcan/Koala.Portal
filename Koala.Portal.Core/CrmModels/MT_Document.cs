namespace Koala.Portal.Core.CrmModels;

public partial class MT_Document
{
    public Guid Oid { get; set; }

    public Guid? PhysicalFile { get; set; }

    public Guid? FileFolder { get; set; }

    public string? FilePath { get; set; }

    public string? Tags { get; set; }

    public string? NotifyUsers { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public int? SaveDocumentType { get; set; }

    public string? CloudDriveId { get; set; }

    public string? SharedFilePath { get; set; }

    public virtual MT_Document_Folder? FileFolderNavigation { get; set; }

    public virtual PO_File? PhysicalFileNavigation { get; set; }

    public virtual ICollection<RL_Campaign_Document> RL_Campaign_Document { get; set; } = new List<RL_Campaign_Document>();

    public virtual ICollection<RL_Document_Activity> RL_Document_Activity { get; set; } = new List<RL_Document_Activity>();

    public virtual ICollection<RL_Document_Contact> RL_Document_Contact { get; set; } = new List<RL_Document_Contact>();

    public virtual ICollection<RL_Document_Event> RL_Document_Event { get; set; } = new List<RL_Document_Event>();

    public virtual ICollection<RL_Document_Firm> RL_Document_Firm { get; set; } = new List<RL_Document_Firm>();

    public virtual ICollection<RL_Document_Opportunity> RL_Document_Opportunity { get; set; } = new List<RL_Document_Opportunity>();

    public virtual ICollection<RL_Document_Product> RL_Document_Product { get; set; } = new List<RL_Document_Product>();

    public virtual ICollection<RL_Document_Shares> RL_Document_Shares { get; set; } = new List<RL_Document_Shares>();

    public virtual ICollection<RL_Document_Task> RL_Document_Task { get; set; } = new List<RL_Document_Task>();

    public virtual ICollection<RL_Document_Ticket> RL_Document_Ticket { get; set; } = new List<RL_Document_Ticket>();

    public virtual ICollection<RL_Proposals_Documents> RL_Proposals_Documents { get; set; } = new List<RL_Proposals_Documents>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
