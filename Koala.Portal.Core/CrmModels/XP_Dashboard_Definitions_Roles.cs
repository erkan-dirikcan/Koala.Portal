namespace Koala.Portal.Core.CrmModels;

public partial class XP_Dashboard_Definitions_Roles
{
    public Guid? Roles { get; set; }

    public Guid? DashboardDefinitions { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual XP_DashboardDefinition? DashboardDefinitionsNavigation { get; set; }

    public virtual CT_Role? RolesNavigation { get; set; }
}
