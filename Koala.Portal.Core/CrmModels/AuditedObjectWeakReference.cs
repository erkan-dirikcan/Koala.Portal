namespace Koala.Portal.Core.CrmModels;

public partial class AuditedObjectWeakReference
{
    public Guid Oid { get; set; }

    public Guid? GuidId { get; set; }

    public int? IntId { get; set; }

    public string? DisplayName { get; set; }

    public virtual ICollection<AuditDataItemPersistent> AuditDataItemPersistent { get; set; } = new List<AuditDataItemPersistent>();

    public virtual XPWeakReference OidNavigation { get; set; } = null!;
}
