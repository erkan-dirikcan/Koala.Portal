namespace Koala.Portal.Core.CrmModels;

public partial class ZD_Extra_Fields
{
    public Guid Oid { get; set; }

    public string? FieldCaption { get; set; }

    public bool? IsActive { get; set; }

    public bool? DoImmediatePost { get; set; }

    public int? ERPApplication { get; set; }

    public bool? DefaultVisibleInList { get; set; }

    public bool? DefaultVisibleInDetail { get; set; }

    public string? ExtraPropertyName { get; set; }

    public string? TargetClass { get; set; }

    public string? TargetDataType { get; set; }

    public string? TargetDataObjectType { get; set; }

    public string? TargetDataCriterion { get; set; }

    public int? TargetDataSize { get; set; }

    public int? TargetDataEntryType { get; set; }

    public string? RegexValue { get; set; }

    public string? ComboBoxValues { get; set; }

    public string? ComboBoxTexts { get; set; }

    public string? ComboBoxImages { get; set; }

    public int? LookupType { get; set; }

    public string? LookupConnectionString { get; set; }

    public string? LookupSQL { get; set; }

    public string? LookupDataField { get; set; }

    public string? LookupDisplayField { get; set; }

    public Guid? _CreatedBy { get; set; }

    public DateTime? _CreatedDateTime { get; set; }

    public Guid? _LastModifiedBy { get; set; }

    public DateTime? _LastModifiedDateTime { get; set; }

    public string? LayoutGroupId { get; set; }

    public int? LayoutIndex { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public string? FieldDisplayFormat { get; set; }

    public string? OnChangedFields { get; set; }

    public int? FieldMaxLength { get; set; }

    public int? FieldValueLimit { get; set; }

    public bool? ShowMobile { get; set; }

    public int? MobileIndex { get; set; }

    public bool? ShowSummary { get; set; }

    public string? CheckedListSourceType { get; set; }

    public string? CheckedListBoxValues { get; set; }

    public string? CheckedListBoxTexts { get; set; }

    public bool? DefaultVisibleInLookupList { get; set; }

    public string? ComboBoxTextsEnglish { get; set; }

    public string? CheckedListBoxTextsEnglish { get; set; }

    public int? LineCount { get; set; }

    public bool? ShowActualValueInListView { get; set; }

    public bool? ShowActualValueInDetailView { get; set; }

    public bool? IsReadOnly { get; set; }

    public bool? _MXN_ReadOnlyInDetail { get; set; }

    public bool? _MXN_VisibleInDetail { get; set; }

    public bool? _MXN_VisibleInList { get; set; }

    public bool? _MXN_VisibleInPreview { get; set; }

    public string? _MXN_DefaultValue { get; set; }

    public virtual ICollection<ZD_Extra_Fields_Columns> ZD_Extra_Fields_Columns { get; set; } = new List<ZD_Extra_Fields_Columns>();

    public virtual ST_User? _CreatedByNavigation { get; set; }

    public virtual ST_User? _LastModifiedByNavigation { get; set; }
}
