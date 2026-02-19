namespace Koala.Portal.Core.CrmModels;

public partial class ST_Scheduler_User_Settings
{
    public Guid Oid { get; set; }

    public string? UserOid { get; set; }

    public string? SelectedUsers { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }
}
