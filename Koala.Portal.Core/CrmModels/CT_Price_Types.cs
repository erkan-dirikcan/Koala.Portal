namespace Koala.Portal.Core.CrmModels;

public partial class CT_Price_Types
{
    public Guid Oid { get; set; }

    public string? PriceTypeDescription { get; set; }

    public bool? IsActive { get; set; }

    public int? PriceTypeClass { get; set; }

    public bool? InUseWith_Proposals { get; set; }

    public bool? InUseWith_Contracts { get; set; }

    public bool? InUseWith_Leads { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<MT_Product_Prices> MT_Product_Prices { get; set; } = new List<MT_Product_Prices>();

    public virtual ICollection<MT_Proposals_Products> MT_Proposals_Products { get; set; } = new List<MT_Proposals_Products>();

    public virtual ICollection<MT_Proposals_Products_Approvals_Details> MT_Proposals_Products_Approvals_Details { get; set; } = new List<MT_Proposals_Products_Approvals_Details>();

    public virtual ICollection<RL_Price_Types_Users> RL_Price_Types_Users { get; set; } = new List<RL_Price_Types_Users>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
