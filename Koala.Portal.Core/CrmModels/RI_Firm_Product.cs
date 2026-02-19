namespace Koala.Portal.Core.CrmModels;

public partial class RI_Firm_Product
{
    public Guid Oid { get; set; }

    public Guid? Firm { get; set; }

    public Guid? RelatedProduct { get; set; }

    public double? Amount { get; set; }

    public string? NotesAndDescription { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public DateTime? GarantiBitisTarih { get; set; }

    public DateTime? GuncellemeTarihi { get; set; }

    public string? Key { get; set; }

    public DateTime? SatisTarihi { get; set; }

    public string? SeriNo { get; set; }

    public string? UrunTuru { get; set; }

    public Guid? MarkaModel { get; set; }

    public string? OfficeKey { get; set; }

    public string? WindowsKey { get; set; }

    public string? Windows { get; set; }

    public string? Office { get; set; }

    public string? CihazKodu { get; set; }

    public bool? Kullanimda { get; set; }

    public bool? _Logo { get; set; }

    public bool? _Teknik { get; set; }

    public string? _Versiyon { get; set; }

    public virtual MT_Firm? FirmNavigation { get; set; }

    public virtual ICollection<MT_Ticket> MT_Ticket { get; set; } = new List<MT_Ticket>();

    public virtual GK_Firm_Category01? MarkaModelNavigation { get; set; }

    public virtual MT_Product? RelatedProductNavigation { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
