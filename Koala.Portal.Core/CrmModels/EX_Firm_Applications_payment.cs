namespace Koala.Portal.Core.CrmModels;

public partial class EX_Firm_Applications_payment
{
    public Guid Oid { get; set; }

    public Guid FirmOid { get; set; }

    public Guid ApplicationOid { get; set; }

    public DateTime? PaymentDate { get; set; }

    public bool? IsPaid { get; set; }

    public double? PaymentAmount { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public virtual EX_Firm_Applications ApplicationO { get; set; } = null!;

    public virtual MT_Firm FirmO { get; set; } = null!;
}
