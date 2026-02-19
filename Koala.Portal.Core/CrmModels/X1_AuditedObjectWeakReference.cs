namespace Koala.Portal.Core.CrmModels;

public partial class X1_AuditedObjectWeakReference
{
    public Guid Oid { get; set; }

    public Guid? GuidId { get; set; }

    public int? IntId { get; set; }

    public string? DisplayName { get; set; }

    public virtual X1_XPWeakReference OidNavigation { get; set; } = null!;

    public virtual ICollection<X1_AuditDataItemPersistent> X1_AuditDataItemPersistent { get; set; } = new List<X1_AuditDataItemPersistent>();
}
