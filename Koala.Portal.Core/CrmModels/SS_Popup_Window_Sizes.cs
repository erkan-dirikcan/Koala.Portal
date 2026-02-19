namespace Koala.Portal.Core.CrmModels;

public partial class SS_Popup_Window_Sizes
{
    public Guid Oid { get; set; }

    public Guid? OwnerUser { get; set; }

    public string? ViewId { get; set; }

    public int? PopupWidth { get; set; }

    public int? PopupHeight { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ST_User? OwnerUserNavigation { get; set; }
}
