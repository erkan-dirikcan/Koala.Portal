namespace Koala.Portal.Core.CrmModels;

public partial class X1_SecurityUserBase
{
    public Guid Oid { get; set; }

    public string? StoredPassword { get; set; }

    public bool? ChangePasswordOnFirstLogon { get; set; }

    public string? UserName { get; set; }

    public bool? IsActive { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }
}
