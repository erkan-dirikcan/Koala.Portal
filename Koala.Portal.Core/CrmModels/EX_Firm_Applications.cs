namespace Koala.Portal.Core.CrmModels;

public partial class EX_Firm_Applications
{
    public Guid Oid { get; set; }

    public Guid FirmOid { get; set; }

    public Guid ContactOid { get; set; }

    public string ApplicationId { get; set; } = null!;

    public string ClientId { get; set; } = null!;

    public string? ClientName { get; set; }

    public string? Description { get; set; }

    public string? ClientUri { get; set; }

    public string? CreateUser { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? UpdateUser { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? SettingSKey { get; set; }

    public string? ApiBaseAddress { get; set; }

    public virtual MT_Contact ContactO { get; set; } = null!;

    public virtual ICollection<EX_Firm_Applications_payment> EX_Firm_Applications_payment { get; set; } = new List<EX_Firm_Applications_payment>();

    public virtual ICollection<EX_Firm_SecretKey> EX_Firm_SecretKey { get; set; } = new List<EX_Firm_SecretKey>();

    public virtual MT_Firm FirmO { get; set; } = null!;
}
