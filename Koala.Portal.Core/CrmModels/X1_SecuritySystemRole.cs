namespace Koala.Portal.Core.CrmModels;

public partial class X1_SecuritySystemRole
{
    public Guid Oid { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public int? ObjectType { get; set; }

    public string? Name { get; set; }

    public bool? IsAdministrative { get; set; }

    public bool? CanEditModel { get; set; }

    public string? HiddenNavigationItems { get; set; }

    public int? DashboardOperation { get; set; }

    public virtual CT_Role? CT_Role { get; set; }

    public virtual X1_XPObjectType? ObjectTypeNavigation { get; set; }

    public virtual ICollection<X1_SecuritySystemTypePermissionsObject> X1_SecuritySystemTypePermissionsObject { get; set; } = new List<X1_SecuritySystemTypePermissionsObject>();

    public virtual ICollection<X1_Security_System_Parent_Child_Roles> X1_Security_System_Parent_Child_RolesChildRolesNavigation { get; set; } = new List<X1_Security_System_Parent_Child_Roles>();

    public virtual ICollection<X1_Security_System_Parent_Child_Roles> X1_Security_System_Parent_Child_RolesParentRolesNavigation { get; set; } = new List<X1_Security_System_Parent_Child_Roles>();

    public virtual ICollection<X1_Security_System_User_Roles> X1_Security_System_User_Roles { get; set; } = new List<X1_Security_System_User_Roles>();

    public virtual ICollection<XP_XpandPermissionData> XP_XpandPermissionData { get; set; } = new List<XP_XpandPermissionData>();
}
