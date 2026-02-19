namespace Koala.Portal.Core.CrmModels;

public partial class ZD_External_Link_Object
{
    public Guid Oid { get; set; }

    public string? URL { get; set; }

    public Guid? UserOid { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? MenuCaption { get; set; }

    public string? LinkId { get; set; }
}
