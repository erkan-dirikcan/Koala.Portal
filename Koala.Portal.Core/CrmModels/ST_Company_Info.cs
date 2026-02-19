namespace Koala.Portal.Core.CrmModels;

public partial class ST_Company_Info
{
    public Guid Oid { get; set; }

    public string? FirmTitle { get; set; }

    public string? TaxOffice { get; set; }

    public string? TaxNo { get; set; }

    public string? EmailAddress1 { get; set; }

    public string? WebAddress { get; set; }

    public Guid? PhoneOid { get; set; }

    public Guid? AddressOid { get; set; }

    public string? FirmId { get; set; }

    public string? AppVersion { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual PO_Address? AddressO { get; set; }

    public virtual PO_Phone_Number? PhoneO { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
