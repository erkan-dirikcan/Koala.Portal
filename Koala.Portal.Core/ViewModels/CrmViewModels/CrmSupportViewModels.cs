using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.ViewModels.PortalViewModels;

namespace Koala.Portal.Core.ViewModels.CrmViewModels;

public class CrmSupportListViewModel
{
    public Guid Oid { get; set; }
    public string? TicketId { get; set; }
    public string? Title { get; set; }
    public DateTime? TicketAramaTarihi { get; set; }
    public DateTime? TicketStartDate { get; set; }
    public DateTime? _CreatedDateTime { get; set; }

    public string? AssignedToOid { get; set; }//
    public string? ActiveWorkingUserOid { get; set; }//
    public string? ActiveWorkingUser { get; set; }//
    public string? TicketStateOid { get; set; }//
    public string? AssignedDepartmentOid { get; set; }//
    public string? TicketYapilanIslem { get; set; }
    public string? TicketFirmOid { get; set; }
    public string? TicketContactOid { get; set; }

    public string? Notes { get; set; }
    public string? Notlar { get; set; }
    public string? FirmSpecCode5 { get; set; }
    public int? Priority { get; set; }
    public CrmDepartmentInfoViewModel? AssignedDepartmentNavigation { get; set; }
    public CrmSupportStatesInfoViewModel? TicketStateNavigation { get; set; }
    public SupportListInfoCrmFirmViewModel? TicketFirmNavigation { get; set; }
    public DetailedInfoCrmFirmContactViewModel? TicketContactNavigation { get; set; }

}

public class CrmCreateSupportViewModel
{
    public string? TicketId { get; set; }
    [Required(ErrorMessage = "Firma Seçilmesi Zorunludur.")]
    public Guid Firm { get; set; }
    [Required(ErrorMessage = "Firma Yetkilisi Seçilmesi Zorunludur.")]
    public Guid Contact { get; set; }
    [Required(ErrorMessage = "Firma Yetkilisinin Mail Adresi Seçilmesi Zorunludur.")]
    public string ContactMail { get; set; }
    public Guid? Contact2 { get; set; }
    public string? Contact2Mail { get; set; }
    [Required(ErrorMessage = "Departman Seçilmesi Zorunludur.")]
    public Guid Department { get; set; }
    [Required(ErrorMessage = "Atanan Personel Seçilmesi Zorunludur.")]
    public Guid AssignedTo { get; set; }
    public Guid? MainCategory { get; set; }
    public Guid? SubCategory { get; set; }
    public Guid? SupportType { get; set; }
    public string CallTime { get; set; } = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
    public PriorityEnum Priority { get; set; } = PriorityEnum.Normal;
    public string? Description { get; set; }
    public string? CreateUserOid { get; set; }
    public bool? DevamEdiyor { get; set; } = false;
    public string? ProjectCode { get; set; }

    public string? ProjectLineId { get; set; }

    public string? ProjectLineWorkId { get; set; }
    public DateTime? CallDateTime()
    {
        var res = string.IsNullOrEmpty(CallTime) ? DateTime.Now : DateTime.ParseExact(CallTime, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
        return res;
    }
}

public class CrmDetailViewModel
{
    public string Oid { get; set; }
    public string? TicketId { get; set; }
    public string? TicketState { get; set; }
    public string? TicketMainCategory { get; set; }
    public string? TicketSubCategory { get; set; }
    public string? TicketType { get; set; }
    public string? AssignedDepartment { get; set; }
    public string? AssignedTo { get; set; }
    public string? AssignedToOid { get; set; }
    public string? ActiveWorkingUser { get; set; }
    public string? ActiveWorkingUserOid { get; set; }
    public string? LoginedUserOid { get; set; }
    public string? TicketAramaTarihi { get; set; }
    public string? TicketStartDate { get; set; }
    public string? ProjectCode { get; set; }
    public string? ProjectLineId { get; set; }
    public string? ProjectLineWorkId { get; set; }
    public string? Notes { get; set; }
    public string? Note { get; set; }
    public string? FileUrl { get; set; }
    public AttachmentType? FileType { get; set; }
    public string? TicketFirm { get; set; }
    public string? TicketFirmPhone { get; set; }
    public string? TicketContact { get; set; }
    public string? TicketContactPhone { get; set; }
    public int? TicketPriority { get; set; }
    public string? FirmSpecCode5 { get; set; }

    public FirmSupportStatusViewModel FirmSupportStatus { get; set; }
}

public class TakeOnSupportViewModel
{
    public string Oid { get; set; }
    public string WorkUserOid { get; set; }
    public string Description { get; set; }
}
public class CheckTakeOnSupportResponseViewModel
{
    public string Oid { get; set; }
    public string ModalTitle { get; set; }
    public string ContentTitle { get; set; }
    public string ContentDescription { get; set; }
    public bool IsUpdated { get; set; }
}

public class CrmUserSupportFilterModel
{
    public string? ActiveWorkingUserOid { get; set; }
    public string? AppointedWorkingUserOid { get; set; }

    public string? StartDate { get; set; }
    public string? EndDate { get; set; }
    public string? Firm { get; set; }
    public List<string> Statuses { get; set; }=new List<string>();
}

public class CrmUpdateSupportInfoViewModel
{
    public string? TicketId { get; set; }
    //DestekAçıklama
    public string? TicketDescription { get; set; }
    //Destek Ana Kategori
    public string? TicketMainCategory { get; set; }
    //Destek Alt Kategori
    public string? TicketSubCategory { get; set; }
    //Destek Türü
    public string? TicketType { get; set; }
    //Firma
    public string TicketFirm { get; set; }
    //Yetkili
    public string? TicketContact { get; set; }
    //Öncelik
    public int? Priority { get; set; }
    //Atanan Personel
    public string? AssignedTo { get; set; }
    //Atanan Departman
    public string? AssignedDepartment { get; set; }
    //Logoda Bekliyor
    public string? JiraOrSupportCode { get; set; }
    //Logoda Bekliyor
    public DateTime? RegisterDate { get; set; }
    //Logoda Bekliyor
    public string? Version { get; set; }
    //Tüm Durumlarda Müşteri Notu
    public string? Notlar { get; set; }
    public string? Notes{ get; set; }
    //Zorunlu
    public string TicketState { get; set; }
}
public class CrmUpdateSupportViewModel
{
    public string Oid { get; set; }
    // Güncelleyen Kullanıcı
    public string _LastModifiedBy { get; set; }
    // Ücretli Kapandı, Tamamlandı
    public string? TicketStartDate { get; set; }
    // Ücretli Kapandı, Tamamlandı
    public string? TicketCompletedDate { get; set; }
    // Ücretli Kapandı, Tamamlandı
    public string? TicketYapilanIslem { get; set; }
    // Ücretli Kapandı
    public string? TicketUcret { get; set; }
    // Ücretli Kapandı
    public string? CurrencyType { get; set; }
    //Logoda Bekliyor
    public string? JiraOrSupportCode { get; set; }
    //Logoda Bekliyor
    public string? RegisterDate { get; set; }
    //Logoda Bekliyor
    public string? Version { get; set; }
    //Tüm Durumlarda Müşteri Notu
    public string? Notlar { get; set; }
    //Zorunlu Destek Durumu
    public string TicketState { get; set; }
    //Zorunlu Destek Tipi
    public string TicketType { get; set; }

}

public class CrmDailySupportChartViewModel:PieChartViewModel
{
    public string UserId { get; set; }
    public string TicketNumbers { get; set; }
    public string Avatar { get; set; }
    public List<CrmUserDailySupportInfoViewModel> UserSupportDeatils { get; set; }

}
public class CrmOpenSupportChartSqlViewModel
{
    public string UserId { get; set; }
    public string Firm { get; set; }
    public string TicketNumbers { get; set; }
    public string UserName { get; set; }
    public string PassingDay { get; set; }

}

public class CrmUserDailySupportInfoViewModel
{
    public string UserId { get; set; }
    public string UserFullName { get; set; }
    public string Firm { get; set; }
    public string Time { get; set; }

}
public class CrmFirmOpenSupportViewModel
{
    public Guid Oid { get; set; }
    public string? TicketId { get; set; }
    public DateTime? TicketAramaTarihi { get; set; }
    public string? AssignedTo { get; set; }//
    public string? Description { get; set; }//
}
public class CrmSendToUserViewModel
{
    public string TicketOid { get; set; }
    public string UserId { get; set; }
    public string Description { get; set; }
}