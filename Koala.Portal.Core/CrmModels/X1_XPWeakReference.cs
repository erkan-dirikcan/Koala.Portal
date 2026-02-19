namespace Koala.Portal.Core.CrmModels;

public partial class X1_XPWeakReference
{
    public Guid Oid { get; set; }

    public int? TargetType { get; set; }

    public string? TargetKey { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public int? ObjectType { get; set; }

    public virtual X1_XPObjectType? ObjectTypeNavigation { get; set; }

    public virtual X1_XPObjectType? TargetTypeNavigation { get; set; }

    public virtual ICollection<X1_AuditDataItemPersistent> X1_AuditDataItemPersistentNewObjectNavigation { get; set; } = new List<X1_AuditDataItemPersistent>();

    public virtual ICollection<X1_AuditDataItemPersistent> X1_AuditDataItemPersistentOldObjectNavigation { get; set; } = new List<X1_AuditDataItemPersistent>();

    public virtual X1_AuditedObjectWeakReference? X1_AuditedObjectWeakReference { get; set; }
}
