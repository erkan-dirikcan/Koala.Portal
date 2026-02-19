namespace Koala.Portal.Core.CrmModels;

public partial class EI_Service_Fields
{
    public Guid Oid { get; set; }

    public string? IntegrationSetOid { get; set; }

    public string? Description { get; set; }

    public string? ERPFieldName { get; set; }

    public bool? ERPExtensionFieldId { get; set; }

    public string? ERPExtensionFieldInsertSQL { get; set; }

    public string? ERPExtensionFieldUpdateSQL { get; set; }

    public string? ERPExtensionFieldSelectSQL { get; set; }

    public string? CRMFieldName { get; set; }

    public string? CRMOriginalFieldName { get; set; }

    public string? CRMSubQuery { get; set; }

    public int? CRMFieldSource { get; set; }

    public int? CRMFieldType { get; set; }

    public int? SyncDirection { get; set; }

    public int? SyncOption { get; set; }

    public string? XMLPath { get; set; }

    public string? InputMatchValues { get; set; }

    public string? OutputMatchValues { get; set; }

    public string? CompareXMLPath { get; set; }

    public string? CompareFieldName { get; set; }

    public string? CompareFieldValue { get; set; }

    public int? CompareMethod { get; set; }

    public string? CompareFieldNameCRM { get; set; }

    public string? CompareFieldValueCRM { get; set; }

    public int? CompareMethodCRM { get; set; }

    public string? CRMJoinSQLs { get; set; }

    public string? CRMJoinFields { get; set; }

    public string? LookupSQL { get; set; }

    public string? LookupSQLField { get; set; }

    public string? LayoutGroupId { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public short? InternalOrder { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? ERPExtensionTableName { get; set; }

    public bool? IsActive { get; set; }

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
