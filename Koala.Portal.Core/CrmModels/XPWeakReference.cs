namespace Koala.Portal.Core.CrmModels;

public partial class XPWeakReference
{
    public Guid Oid { get; set; }

    public int? TargetType { get; set; }

    public string? TargetKey { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public int? ObjectType { get; set; }

    public virtual ICollection<AuditDataItemPersistent> AuditDataItemPersistentNewObjectNavigation { get; set; } = new List<AuditDataItemPersistent>();

    public virtual ICollection<AuditDataItemPersistent> AuditDataItemPersistentOldObjectNavigation { get; set; } = new List<AuditDataItemPersistent>();

    public virtual AuditedObjectWeakReference? AuditedObjectWeakReference { get; set; }

    public virtual X1_XPObjectType? ObjectTypeNavigation { get; set; }

    public virtual X1_XPObjectType? TargetTypeNavigation { get; set; }
}
