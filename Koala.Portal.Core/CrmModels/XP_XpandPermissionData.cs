namespace Koala.Portal.Core.CrmModels;

public partial class XP_XpandPermissionData
{
    public Guid Oid { get; set; }

    public string? ChangedProperties { get; set; }

    public Guid? Role { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public int? ObjectType { get; set; }

    public int? Modifier { get; set; }

    public virtual X1_XPObjectType? ObjectTypeNavigation { get; set; }

    public virtual X1_SecuritySystemRole? RoleNavigation { get; set; }

    public virtual XP_AnonymousLoginOperationPermissionData? XP_AnonymousLoginOperationPermissionData { get; set; }

    public virtual XP_MyDetailsOperationPermissionData? XP_MyDetailsOperationPermissionData { get; set; }
}
