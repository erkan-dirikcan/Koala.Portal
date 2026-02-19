namespace Koala.Portal.Core.CrmModels;

public partial class AA_GoogleMaps_GeoPoint
{
    public Guid Oid { get; set; }

    public string? MapName { get; set; }

    public string? MapAddress { get; set; }

    public string? MarkerIcon { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longtitude { get; set; }

    public decimal? ZoomValue { get; set; }

    public string? MapTypeId { get; set; }

    public Guid? UserTemp { get; set; }

    public bool? IsMyLocation { get; set; }

    public Guid? RelatedAddress { get; set; }

    public Guid? Firm { get; set; }

    public Guid? Contact { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public double? AllowedCheckInMaxDistance { get; set; }

    public virtual MT_Contact? ContactNavigation { get; set; }

    public virtual MT_Firm? FirmNavigation { get; set; }

    public virtual PO_Address? RelatedAddressNavigation { get; set; }
}
