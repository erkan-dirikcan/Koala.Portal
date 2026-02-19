namespace Koala.Portal.Core.CrmModels;

public partial class logocrm_net_Module_BusinessObjects_Codes_CT_RoleDashboardDefinitionDashboardDefinitions
{
    public Guid? Roles { get; set; }

    public Guid? DashboardDefinitions { get; set; }

    public Guid OID { get; set; }

    public int? OptimisticLockField { get; set; }

    public virtual XP_DashboardDefinition? DashboardDefinitionsNavigation { get; set; }

    public virtual CT_Role? RolesNavigation { get; set; }
}
