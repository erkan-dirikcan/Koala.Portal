namespace Koala.Portal.Core.CrmModels;

public partial class RL_Price_Types_Users
{
    public Guid Oid { get; set; }

    public Guid? User_ { get; set; }

    public Guid? PriceType_ { get; set; }

    public bool? CanUse_InProposals { get; set; }

    public bool? CanUse_InContracts { get; set; }

    public bool? CanUse_InLeads { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual CT_Price_Types? PriceType_Navigation { get; set; }

    public virtual ST_User? User_Navigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
