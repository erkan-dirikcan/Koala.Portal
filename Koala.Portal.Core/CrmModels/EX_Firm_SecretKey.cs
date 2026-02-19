namespace Koala.Portal.Core.CrmModels;

public partial class EX_Firm_SecretKey
{
    public Guid Oid { get; set; }

    public Guid FirmOid { get; set; }

    public Guid ApplicationOid { get; set; }

    public string ClientId { get; set; } = null!;

    public string? Secret { get; set; }

    public DateTime? Expiration { get; set; }

    public string? Description { get; set; }

    public DateTime? SecretCreated { get; set; }

    public virtual EX_Firm_Applications ApplicationO { get; set; } = null!;

    public virtual MT_Firm FirmO { get; set; } = null!;
}
