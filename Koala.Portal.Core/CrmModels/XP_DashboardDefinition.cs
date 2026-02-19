namespace Koala.Portal.Core.CrmModels;

public partial class XP_DashboardDefinition
{
    public Guid Oid { get; set; }

    public string? ChangedProperties { get; set; }

    public string? TargetObjectTypes { get; set; }

    public int? Index { get; set; }

    public string? Name { get; set; }

    public bool? Active { get; set; }

    public string? Xml { get; set; }

    public byte[]? Icon { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public bool? DataViewService { get; set; }

    public int? EditParameters { get; set; }

    public virtual ICollection<DashboardDefinitionDashboardDefinitions> DashboardDefinitionDashboardDefinitions { get; set; } = new List<DashboardDefinitionDashboardDefinitions>();

    public virtual ICollection<XP_Dashboard_Definitions_Roles> XP_Dashboard_Definitions_Roles { get; set; } = new List<XP_Dashboard_Definitions_Roles>();

    public virtual ICollection<logocrm_net_Module_BusinessObjects_Codes_CT_RoleDashboardDefinitionDashboardDefinitions> logocrm_net_Module_BusinessObjects_Codes_CT_RoleDashboardDefinitionDashboardDefinitions { get; set; } = new List<logocrm_net_Module_BusinessObjects_Codes_CT_RoleDashboardDefinitionDashboardDefinitions>();
}
