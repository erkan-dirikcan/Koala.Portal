namespace Koala.Portal.Core.CrmModels;

public partial class MT_Mail_Settings
{
    public Guid Oid { get; set; }

    public string? Email { get; set; }

    public string? DisplayName { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public bool? EnableSSL { get; set; }

    public string? Host { get; set; }

    public int? Port { get; set; }

    public string? Domain { get; set; }

    public string? Signature { get; set; }

    public int? Type { get; set; }

    public bool? IsDefault { get; set; }

    public Guid? User { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? Cc_ { get; set; }

    public string? Bcc_ { get; set; }

    public virtual ST_User? UserNavigation { get; set; }
}
