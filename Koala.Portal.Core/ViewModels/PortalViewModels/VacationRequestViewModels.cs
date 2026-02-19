using Koala.Portal.Core.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Koala.Portal.Core.ViewModels.PortalViewModels
{
    public class VacationRequestListViewModel
    {
        public string Id { get; set; }
        [Display(Name = "İzin Türü")]
        public string? VacationType { get; set; }
        [Display(Name = "Kullanıcı")]
        public string? User { get; set; }
        [Display(Name = "Talep Numarası")]
        public string? ReqNumber { get; set; }
        [Display(Name = "Başlık")]
        public string? Subject { get; set; }
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Bitiş Tarihi")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Durum")]
        public VacationStatus Status { get; set; }
        [Display(Name = "Revizyon")]
        public int Version { get; set; }
    }
    public class VacationRequestDetailViewModel
    {
        public string Id { get; set; }
        [Display(Name = "İzin Türü")]
        public string? VacationType { get; set; }
        [Display(Name = "Kullanıcı")]
        public string? User { get; set; }
        [Display(Name = "Talep Numarası")]
        public string? ReqNumber { get; set; }
        [Display(Name = "Başlık")]
        public string? Subject { get; set; }
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Bitiş Tarihi")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Durum")]
        public VacationStatus Status { get; set; }       
        [Display(Name = "İptal Açıklaması")]
        public string CancelDescription { get; set; }
        [Display(Name = "Revizyon Açıklaması")]
        public string RevisionDescription { get; set; }
        [Display(Name = "Revizyon")]
        public int Version { get; set; }
        [Display(Name = "Senelik İzinden Düş")]
        public bool DropFromAnnualVaccation { get; set; } = false;
        [Display(Name = "Ücretli İzin")]
        public bool PaidVacation { get; set; } = false;

    }
    public class VacationRequestCreateViewModel
    {
        [Display(Name = "İzin Türü")]
        public string? VacationTypeId { get; set; }
        [Display(Name = "Kullanıcı")]
        public string? UserId { get; set; }
        [Display(Name = "Talep Numarası")]
        public string? ReqNumber { get; set; }
        [Display(Name = "Başlık")]
        public string? Subject { get; set; }
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Bitiş Tarihi")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Senelik İzinden Düş")]
        public bool DropFromAnnualVaccation { get; set; }
    }
    public class VacationRequestRevisionViewModel
    {
        public string Id { get; set; }
        [Display(Name = "İzin Türü")]
        public string? VacationTypeId { get; set; }
        [Display(Name = "Talep Numarası")]
        public string? ReqNumber { get; set; }
        [Display(Name = "Başlık")]
        public string? Subject { get; set; }
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
        [Display(Name = "başlangıç Tarihi")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Bitiş Tarihi")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Senelik İzinden Düş")]
        public bool DropFromAnnualVaccation { get; set; }
    }
    public class VacationRequestRevisionRequestViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Revizyon Açıklaması")]
        public string RevisionDescription { get; set; }
    }
    public class VacationRequestCancelViewModel
    {
        public string Id { get; set; }
        [Display(Name = "İptal Açıklaması")]
        public string CancelDescription { get; set; }
    }

}
