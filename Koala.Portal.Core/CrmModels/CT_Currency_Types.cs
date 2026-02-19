namespace Koala.Portal.Core.CrmModels;

public partial class CT_Currency_Types
{
    public Guid Oid { get; set; }

    public string? ShortNotation { get; set; }

    public string? CurrencySign { get; set; }

    public string? Description { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public bool? IsActive { get; set; }

    public string? TCMBNotation { get; set; }

    public bool? IsLocalCurrency { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? CentsNotation { get; set; }

    public bool? IsSystemPredefined { get; set; }

    public virtual ICollection<MT_Product_Prices> MT_Product_Prices { get; set; } = new List<MT_Product_Prices>();

    public virtual ICollection<MT_Proposals> MT_Proposals { get; set; } = new List<MT_Proposals>();

    public virtual ICollection<MT_Proposals_Additional_Cost> MT_Proposals_Additional_Cost { get; set; } = new List<MT_Proposals_Additional_Cost>();

    public virtual ICollection<MT_Proposals_Approvals_Details> MT_Proposals_Approvals_Details { get; set; } = new List<MT_Proposals_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Products> MT_Proposals_ProductsCurrencyNavigation { get; set; } = new List<MT_Proposals_Products>();

    public virtual ICollection<MT_Proposals_Products> MT_Proposals_ProductsProposalCurrencyNavigation { get; set; } = new List<MT_Proposals_Products>();

    public virtual ICollection<MT_Proposals_Products_Approvals_Details> MT_Proposals_Products_Approvals_DetailsCurrencyNavigation { get; set; } = new List<MT_Proposals_Products_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Products_Approvals_Details> MT_Proposals_Products_Approvals_DetailsProposalCurrencyNavigation { get; set; } = new List<MT_Proposals_Products_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Revisals> MT_Proposals_Revisals { get; set; } = new List<MT_Proposals_Revisals>();

    public virtual ICollection<ST_Exchange_Rates> ST_Exchange_Rates { get; set; } = new List<ST_Exchange_Rates>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
