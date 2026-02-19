namespace Koala.Portal.Core.CrmModels;

public partial class ST_Update_Schema_Logic
{
    public Guid Oid { get; set; }

    public string? LogicKey { get; set; }

    public bool? Updated { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }
}
