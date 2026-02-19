namespace Koala.Portal.Core.CrmModels;

public partial class X1_AuditDataItemPersistent
{
    public Guid Oid { get; set; }

    public string? UserName { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? OperationType { get; set; }

    public string? Description { get; set; }

    public Guid? AuditedObject { get; set; }

    public Guid? OldObject { get; set; }

    public Guid? NewObject { get; set; }

    public string? OldValue { get; set; }

    public string? NewValue { get; set; }

    public string? PropertyName { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual X1_AuditedObjectWeakReference? AuditedObjectNavigation { get; set; }

    public virtual X1_XPWeakReference? NewObjectNavigation { get; set; }

    public virtual X1_XPWeakReference? OldObjectNavigation { get; set; }
}
