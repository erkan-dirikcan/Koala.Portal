namespace Koala.Portal.Core.CrmModels;

public partial class AA_Sms_Settings
{
    public Guid Oid { get; set; }

    public string? UserName { get; set; }

    public string? CompanyCode { get; set; }

    public string? Password { get; set; }

    public bool? IsTrSupported { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? RejectNotice { get; set; }
}
