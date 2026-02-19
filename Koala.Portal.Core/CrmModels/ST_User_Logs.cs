namespace Koala.Portal.Core.CrmModels;

public partial class ST_User_Logs
{
    public Guid Oid { get; set; }

    public DateTime? Date_ { get; set; }

    public string? UserName { get; set; }

    public Guid? UserOid { get; set; }

    public string? ClassName { get; set; }

    public int? LogType { get; set; }

    public string? CreatedByUserName { get; set; }

    public Guid? CreatedByUserOid { get; set; }

    public Guid? ObjectId { get; set; }

    public string? ObjectDescription { get; set; }

    public string? ObjectKeyValue { get; set; }

    public string? LocalIP { get; set; }

    public string? WanIP { get; set; }

    public string? Notes { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public bool? IsMobile { get; set; }

    public string? OldValue { get; set; }

    public string? PropertyName { get; set; }

    public string? NewValue { get; set; }
}
