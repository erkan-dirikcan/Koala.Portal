namespace Koala.Portal.Core.CrmModels;

public partial class AA_CompetitorManagement_UserSettings
{
    public Guid Oid { get; set; }

    public Guid? UserOid { get; set; }

    public bool? ProposalChartVisible { get; set; }

    public bool? OpportunityChartVisible { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ST_User? UserO { get; set; }
}
