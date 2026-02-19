namespace Koala.Portal.Core.CrmModels;

public partial class PO_Address
{
    public Guid Oid { get; set; }

    public Guid? AddressType { get; set; }

    public string? Street { get; set; }

    public string? Street2 { get; set; }

    public Guid? Parish_ { get; set; }

    public Guid? District_ { get; set; }

    public Guid? County_ { get; set; }

    public Guid? City_ { get; set; }

    public string? StateProvince { get; set; }

    public string? ZipPostal { get; set; }

    public Guid? Country { get; set; }

    public bool? IsShipmentAddress { get; set; }

    public string? Shipment_Code { get; set; }

    public string? Shipment_Description { get; set; }

    public string? Shipment_Fax { get; set; }

    public string? Shipment_Phone1 { get; set; }

    public string? Shipment_Phone2 { get; set; }

    public string? Shipment_RelatedPerson { get; set; }

    public string? Shipment_RelatedEMail { get; set; }

    public string? Shipment_TaxNo { get; set; }

    public string? Shipment_TaxOffice { get; set; }

    public string? Shipment_VatNo { get; set; }

    public double? Shipment_Latitude { get; set; }

    public double? Shipment_Longtitude { get; set; }

    public Guid? RelatedFirm { get; set; }

    public Guid? RelatedContact { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? ShipAdr_Auxiliary_Code1 { get; set; }

    public string? ShipAdr_InUse { get; set; }

    public string? ShipAdr_AuthCode { get; set; }

    public string? ShipAdr_TradingGroup { get; set; }

    public bool? AutoAddedFromFirm { get; set; }

    public bool? IsDefaultShipmentAddress { get; set; }

    public virtual ICollection<AA_GoogleMaps_GeoPoint> AA_GoogleMaps_GeoPoint { get; set; } = new List<AA_GoogleMaps_GeoPoint>();

    public virtual PO_Address_Type? AddressTypeNavigation { get; set; }

    public virtual PO_City? City_Navigation { get; set; }

    public virtual PO_Country? CountryNavigation { get; set; }

    public virtual PO_County? County_Navigation { get; set; }

    public virtual PO_District? District_Navigation { get; set; }

    public virtual ICollection<EI_Shipment_Address_Relations> EI_Shipment_Address_Relations { get; set; } = new List<EI_Shipment_Address_Relations>();

    public virtual ICollection<MT_Activity> MT_Activity { get; set; } = new List<MT_Activity>();

    public virtual ICollection<MT_Proposals> MT_ProposalsInvoiceAddressNavigation { get; set; } = new List<MT_Proposals>();

    public virtual ICollection<MT_Proposals> MT_ProposalsShipmentAddressNavigation { get; set; } = new List<MT_Proposals>();

    public virtual ICollection<MT_Proposals_Approvals_Details> MT_Proposals_Approvals_DetailsInvoiceAddressNavigation { get; set; } = new List<MT_Proposals_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Approvals_Details> MT_Proposals_Approvals_DetailsShipmentAddressNavigation { get; set; } = new List<MT_Proposals_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Revisals> MT_Proposals_RevisalsInvoiceAddressNavigation { get; set; } = new List<MT_Proposals_Revisals>();

    public virtual ICollection<MT_Proposals_Revisals> MT_Proposals_RevisalsShipmentAddressNavigation { get; set; } = new List<MT_Proposals_Revisals>();

    public virtual PO_Parish? Parish_Navigation { get; set; }

    public virtual MT_Contact? RelatedContactNavigation { get; set; }

    public virtual MT_Firm? RelatedFirmNavigation { get; set; }

    public virtual ICollection<ST_Company_Info> ST_Company_Info { get; set; } = new List<ST_Company_Info>();
}
