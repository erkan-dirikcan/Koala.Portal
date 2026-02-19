namespace Koala.Portal.Core.CrmModels;

public partial class MT_Proposals_Unit_Conversions
{
    public Guid Oid { get; set; }

    public Guid? RelatedProposalProduct { get; set; }

    public Guid? Unit { get; set; }

    public double? ConvAmount { get; set; }

    public double? MultiplyFactor { get; set; }

    public double? DivideFactor { get; set; }

    public bool? IsMainUnit { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual MT_Proposals_Products? RelatedProposalProductNavigation { get; set; }

    public virtual CT_Units? UnitNavigation { get; set; }
}
