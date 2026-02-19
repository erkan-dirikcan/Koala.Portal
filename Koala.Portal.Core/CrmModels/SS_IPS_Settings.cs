namespace Koala.Portal.Core.CrmModels;

public partial class SS_IPS_Settings
{
    public Guid Oid { get; set; }

    public bool? IsActive { get; set; }

    public int? IPPBXType { get; set; }

    public string? IPAddress { get; set; }

    public string? ServiceIPAddress { get; set; }

    public string? Click2CallUrl { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
