namespace Koala.Portal.Core.CrmModels;

public partial class XP_AnonymousLoginOperationPermissionData
{
    public Guid Oid { get; set; }

    public virtual XP_XpandPermissionData OidNavigation { get; set; } = null!;
}
