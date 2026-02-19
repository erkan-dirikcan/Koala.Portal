namespace Koala.Portal.Core.CrmModels;

public partial class CT_Role
{
    public Guid Oid { get; set; }

    public bool? IsSystemDefined { get; set; }

    public int? DefaultSetnumber { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? DashboardOperation { get; set; }

    public bool? ModifyLayout { get; set; }

    public virtual ICollection<DashboardDefinitionDashboardDefinitions> DashboardDefinitionDashboardDefinitions { get; set; } = new List<DashboardDefinitionDashboardDefinitions>();

    public virtual X1_SecuritySystemRole OidNavigation { get; set; } = null!;

    public virtual ICollection<RL_User_Role> RL_User_Role { get; set; } = new List<RL_User_Role>();

    public virtual ICollection<XP_Dashboard_Definitions_Roles> XP_Dashboard_Definitions_Roles { get; set; } = new List<XP_Dashboard_Definitions_Roles>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }

    public virtual ICollection<logocrm_net_Module_BusinessObjects_Codes_CT_RoleDashboardDefinitionDashboardDefinitions> logocrm_net_Module_BusinessObjects_Codes_CT_RoleDashboardDefinitionDashboardDefinitions { get; set; } = new List<logocrm_net_Module_BusinessObjects_Codes_CT_RoleDashboardDefinitionDashboardDefinitions>();
}
