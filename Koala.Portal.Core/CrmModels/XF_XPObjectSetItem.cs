namespace Koala.Portal.Core.CrmModels;

public partial class XF_XPObjectSetItem
{
    public Guid Oid { get; set; }

    public Guid? XPObjectSet { get; set; }

    public int? IntKey { get; set; }

    public Guid? GuidKey { get; set; }

    public string? StringKey { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual XF_XPObjectSet? XPObjectSetNavigation { get; set; }
}
