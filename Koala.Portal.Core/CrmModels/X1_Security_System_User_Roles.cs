namespace Koala.Portal.Core.CrmModels;

public partial class X1_Security_System_User_Roles
{
    public Guid? Roles { get; set; }

    public Guid? Users { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual X1_SecuritySystemRole? RolesNavigation { get; set; }

    public virtual X1_SecuritySystemUser? UsersNavigation { get; set; }
}
