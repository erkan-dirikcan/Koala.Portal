namespace Koala.Portal.Core.CrmModels;

public partial class ST_User_DockPanelLayouts
{
    public Guid Oid { get; set; }

    public Guid? UserOId { get; set; }

    public string? LayoutData { get; set; }

    public string? WindowName { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }
}
