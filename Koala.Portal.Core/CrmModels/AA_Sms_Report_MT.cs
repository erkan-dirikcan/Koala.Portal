namespace Koala.Portal.Core.CrmModels;

public partial class AA_Sms_Report_MT
{
    public Guid Oid { get; set; }

    public string? PacketId { get; set; }

    public string? SendDate { get; set; }

    public string? UserName { get; set; }

    public string? ListType { get; set; }

    public string? SendCount { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }
}
