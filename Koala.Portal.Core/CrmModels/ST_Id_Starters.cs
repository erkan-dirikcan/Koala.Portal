namespace Koala.Portal.Core.CrmModels;

public partial class ST_Id_Starters
{
    public Guid Oid { get; set; }

    public string? ProposalId { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }
}
