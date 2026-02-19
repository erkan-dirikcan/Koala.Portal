namespace Koala.Portal.Core.CrmModels;

public partial class PO_Phone_Number
{
    public Guid Oid { get; set; }

    public Guid? RelatedFirm { get; set; }

    public Guid? RelatedContact { get; set; }

    public Guid? CountryCode { get; set; }

    public string? AreaCode { get; set; }

    public string? Number { get; set; }

    public string? Extension { get; set; }

    public Guid? PhoneType { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public bool? AutoAddedFromFirm { get; set; }

    public bool? IsDefaultPhone { get; set; }

    public virtual PO_Country? CountryCodeNavigation { get; set; }

    public virtual PO_Phone_Type? PhoneTypeNavigation { get; set; }

    public virtual ICollection<RI_Contact_PhoneNumber> RI_Contact_PhoneNumber { get; set; } = new List<RI_Contact_PhoneNumber>();

    public virtual ICollection<RI_Firm_PhoneNumber> RI_Firm_PhoneNumber { get; set; } = new List<RI_Firm_PhoneNumber>();

    public virtual MT_Contact? RelatedContactNavigation { get; set; }

    public virtual MT_Firm? RelatedFirmNavigation { get; set; }

    public virtual ICollection<ST_Company_Info> ST_Company_Info { get; set; } = new List<ST_Company_Info>();


    public string NumberFormat()
    {
        return AreaCode?.Replace(" ", "") + Number?.Replace(" ", "");
    }
    public string GetUrl()
    {
        var url = RelatedFirm!=null?$"http://crm.sistem-bilgi.com:8090/LOGOCRM/Default.aspx#ViewID=MT_Firm_DetailView&ObjectKey={RelatedFirm}":"";
        return url;
    }
}
