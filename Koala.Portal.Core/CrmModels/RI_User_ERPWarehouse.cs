namespace Koala.Portal.Core.CrmModels;

public partial class RI_User_ERPWarehouse
{
    public Guid Oid { get; set; }

    public Guid? IntegrationSet { get; set; }

    public Guid? RelatedUser { get; set; }

    public string? WarehouseNumber { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual EI_Integration_Sets? IntegrationSetNavigation { get; set; }

    public virtual ST_User? RelatedUserNavigation { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
