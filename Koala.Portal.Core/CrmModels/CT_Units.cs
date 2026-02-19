namespace Koala.Portal.Core.CrmModels;

public partial class CT_Units
{
    public Guid Oid { get; set; }

    public string? UnitCode { get; set; }

    public string? UnitDescription { get; set; }

    public bool? IsActive { get; set; }

    public int? UnitType { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<EI_Unit_Relations> EI_Unit_Relations { get; set; } = new List<EI_Unit_Relations>();

    public virtual ICollection<MT_Proposals_Products> MT_Proposals_Products { get; set; } = new List<MT_Proposals_Products>();

    public virtual ICollection<MT_Proposals_Products_Approvals_Details> MT_Proposals_Products_Approvals_Details { get; set; } = new List<MT_Proposals_Products_Approvals_Details>();

    public virtual ICollection<MT_Proposals_Unit_Conversions> MT_Proposals_Unit_Conversions { get; set; } = new List<MT_Proposals_Unit_Conversions>();

    public virtual ICollection<RI_Product_Units_Collections_Properties> RI_Product_Units_Collections_Properties { get; set; } = new List<RI_Product_Units_Collections_Properties>();

    public virtual ICollection<RI_Units_Collections_Properties> RI_Units_Collections_Properties { get; set; } = new List<RI_Units_Collections_Properties>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }

    public virtual ICollection<foProductVariantItem> foProductVariantItem { get; set; } = new List<foProductVariantItem>();
}
