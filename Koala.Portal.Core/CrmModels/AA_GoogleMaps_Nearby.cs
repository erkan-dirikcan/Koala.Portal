namespace Koala.Portal.Core.CrmModels;

public partial class AA_GoogleMaps_Nearby
{
    public Guid Oid { get; set; }

    public Guid? CurrentUser { get; set; }

    public bool? ShowNearbyFirms { get; set; }

    public bool? ShowNearbyContacts { get; set; }

    public bool? ShowNearbyOngoingProposals { get; set; }

    public bool? ShowNearbyOngoingOpportunities { get; set; }

    public bool? ShowEventsToday { get; set; }

    public bool? ShowOtherEventsToday { get; set; }

    public bool? ShowUnsolvedTickets { get; set; }

    public decimal? DistanceLimit { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ST_User? CurrentUserNavigation { get; set; }
}
