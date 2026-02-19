namespace Koala.Portal.Core.CrmModels;

public partial class X1_Security_System_Parent_Child_Roles
{
    public Guid? ChildRoles { get; set; }

    public Guid? ParentRoles { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual X1_SecuritySystemRole? ChildRolesNavigation { get; set; }

    public virtual X1_SecuritySystemRole? ParentRolesNavigation { get; set; }
}
