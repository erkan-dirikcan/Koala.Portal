namespace Koala.Portal.Core.CrmModels;

public partial class X1_SecuritySystemUser
{
    public Guid Oid { get; set; }

    public string? StoredPassword { get; set; }

    public bool? ChangePasswordOnFirstLogon { get; set; }

    public string? UserName { get; set; }

    public bool? IsActive { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public int? ObjectType { get; set; }

    public virtual X1_XPObjectType? ObjectTypeNavigation { get; set; }

    public virtual ICollection<X1_Security_System_User_Roles> X1_Security_System_User_Roles { get; set; } = new List<X1_Security_System_User_Roles>();

    public virtual XP_XpandUser? XP_XpandUser { get; set; }
}
