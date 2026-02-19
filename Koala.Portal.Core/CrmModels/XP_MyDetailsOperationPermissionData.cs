namespace Koala.Portal.Core.CrmModels;

public partial class XP_MyDetailsOperationPermissionData
{
    public Guid Oid { get; set; }

    public virtual XP_XpandPermissionData OidNavigation { get; set; } = null!;
}
