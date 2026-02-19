namespace Koala.Portal.Core.CrmModels;

public partial class ZD_External_Links
{
    public Guid Oid { get; set; }

    public string? LinkId { get; set; }

    public string? ParentId { get; set; }

    public bool? IsActive { get; set; }

    public string? MenuCaption { get; set; }

    public string? URL { get; set; }

    public string? Users { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public int? OpenTarget { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
