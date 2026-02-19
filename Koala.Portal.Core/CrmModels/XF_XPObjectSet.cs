namespace Koala.Portal.Core.CrmModels;

public partial class XF_XPObjectSet
{
    public Guid Oid { get; set; }

    public string? GlobalContext { get; set; }

    public string? CurrentUserName { get; set; }

    public string? LocalContext { get; set; }

    public string? OwnerId { get; set; }

    public int? SelectionType { get; set; }

    public string? Criteria { get; set; }

    public string? ObjectsSelectableType { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual ICollection<XF_XPObjectSetItem> XF_XPObjectSetItem { get; set; } = new List<XF_XPObjectSetItem>();
}
