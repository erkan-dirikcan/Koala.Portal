namespace Koala.Portal.Core.CrmModels;

public partial class MT_Document_Folder
{
    public Guid Oid { get; set; }

    public Guid? Parent { get; set; }

    public string? Name { get; set; }

    public string? Tags { get; set; }

    public string? NotifyUsers { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? DriveFolderId { get; set; }

    public string? OneDriveFolderId { get; set; }

    public virtual ICollection<MT_Document_Folder> InverseParentNavigation { get; set; } = new List<MT_Document_Folder>();

    public virtual ICollection<MT_Document> MT_Document { get; set; } = new List<MT_Document>();

    public virtual MT_Document_Folder? ParentNavigation { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
