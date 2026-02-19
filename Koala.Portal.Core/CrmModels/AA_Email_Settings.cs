namespace Koala.Portal.Core.CrmModels;

public partial class AA_Email_Settings
{
    public Guid Oid { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? ApiKey { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }
}
