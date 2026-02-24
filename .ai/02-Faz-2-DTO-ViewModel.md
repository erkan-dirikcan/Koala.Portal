# Faz 2 - DTO ve ViewModel'ler

## Öncelik: ORTA 🟡
Bu faz, veri transfer nesnelerinin ve view modellerinin oluşturulmasını içerir.

---

## DTO Oluşturma Rehberi

### Standart DTO Yapısı

**Koala.Portal.Core/Dtos** klasörü altında oluşturulmalıdır.

#### BaseDto (Önerilen)
```csharp
namespace Koala.Portal.Core.Dtos
{
    public class BaseDto
    {
        public string Id { get; set; }
        public DateTime? CreateTime { get; set; }
        public string CreateUser { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string UpdateUser { get; set; }
    }
}
```

---

## Grup 1: Identity ve Kullanıcı Yönetimi

### 1.1 RoleDto
```csharp
public class RoleDto : BaseDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int UserCount { get; set; }  // Derived property
}

public class CreateRoleDto
{
    [Required(ErrorMessage = "Rol Adı Boş Bırakılamaz")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Açıklama Boş Bırakılamaz")]
    public string Description { get; set; }
}

public class UpdateRoleDto
{
    public string Id { get; set; }

    [Required(ErrorMessage = "Rol Adı Boş Bırakılamaz")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Açıklama Boş Bırakılamaz")]
    public string Description { get; set; }
}
```

### Görevler
- [ ] `RoleDto.cs` oluştur
- [ ] `CreateRoleDto.cs` oluştur
- [ ] `UpdateRoleDto.cs` oluştur
- [ ] Validation attribute'lerini ekle

**Tahmini Süre**: 15 dakika

---

## Grup 2: Proje Yönetimi

### 2.1 ProjectDto
```csharp
public class ProjectDto : BaseDto
{
    public string ProjectCode { get; set; }
    public string ProjectName { get; set; }
    public string Description { get; set; }
    public string FirmId { get; set; }
    public string FirmName { get; set; }  // Navigation
    public string ProjectManagerId { get; set; }
    public string ProjectManagerName { get; set; }  // Navigation
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? DueDate { get; set; }
    public int? EstimatedHour { get; set; }
    public int? ServiceHour { get; set; }
    public int ProjectStatus { get; set; }
    public int Status { get; set; }
    public string ProjectStatusText { get; set; }  // Enum to text
    public int LineCount { get; set; }  // Derived
    public int FileCount { get; set; }  // Derived
}

public class CreateProjectDto
{
    [Required(ErrorMessage = "Proje Kodu Boş Bırakılamaz")]
    public string ProjectCode { get; set; }

    [Required(ErrorMessage = "Proje Adı Boş Bırakılamaz")]
    public string ProjectName { get; set; }

    public string Description { get; set; }

    [Required(ErrorMessage = "Firma Seçilmelidir")]
    public string FirmId { get; set; }

    public string ProjectManagerId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? DueDate { get; set; }
    public int? EstimatedHour { get; set; }
}

public class UpdateProjectDto : CreateProjectDto
{
    public string Id { get; set; }
}
```

### 2.2 ProjectLineDto
```csharp
public class ProjectLineDto : BaseDto
{
    public string ProjectId { get; set; }
    public string ProjectName { get; set; }  // Navigation
    public string Title { get; set; }
    public string Description { get; set; }
    public string ReportDescription { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? DueDate { get; set; }
    public int Priority { get; set; }
    public int StateStatus { get; set; }
    public int Status { get; set; }
    public int? ServiceTime { get; set; }
    public int? RowOrder { get; set; }
    public string LineOfficialId { get; set; }
    public string LineFirmOfficialId { get; set; }
    public int WorkCount { get; set; }  // Derived
    public int NoteCount { get; set; }  // Derived
}

public class CreateProjectLineDto
{
    [Required(ErrorMessage = "Proje Seçilmelidir")]
    public string ProjectId { get; set; }

    [Required(ErrorMessage = "Başlık Boş Bırakılamaz")]
    public string Title { get; set; }

    public string Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? DueDate { get; set; }
    public int Priority { get; set; } = 3;  // Default: Normal
    public string LineOfficialId { get; set; }
    public string LineFirmOfficialId { get; set; }
    public int? ServiceTime { get; set; }
}

public class UpdateProjectLineDto : CreateProjectLineDto
{
    public string Id { get; set; }
}
```

### 2.3 ProjectFileDto
```csharp
public class ProjectFileDto : BaseDto
{
    public string ProjectId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string UrlSlug { get; set; }
    public string FileExtension { get; set; }
    public long FileSize { get; set; }
}
```

### 2.4 ProjectLineNoteDto
```csharp
public class ProjectLineNoteDto : BaseDto
{
    public string ProjectLineId { get; set; }
    public string Title { get; set; }
    public string Note { get; set; }
    public string ReportNote { get; set; }
    public DateTime? Date { get; set; }
    public string UserId { get; set; }
    public string UserName { get; set; }  // Navigation
}

public class CreateProjectLineNoteDto
{
    [Required(ErrorMessage = "Proje Satırı Seçilmelidir")]
    public string ProjectLineId { get; set; }

    public string Title { get; set; }

    [Required(ErrorMessage = "Not Boş Bırakılamaz")]
    public string Note { get; set; }

    public string ReportNote { get; set; }
    public DateTime? Date { get; set; }
}
```

### 2.5 ProjectLineWorkDto
```csharp
public class ProjectLineWorkDto : BaseDto
{
    public string LineId { get; set; }
    public string LineTitle { get; set; }  // Navigation
    public string Name { get; set; }
    public string Description { get; set; }
    public string ReportDescription { get; set; }
    public int Priority { get; set; }
    public int RowOrder { get; set; }
    public int WorkStatus { get; set; }
    public int? TimeSpend { get; set; }
    public bool LetTimeDeduct { get; set; }
    public string DeliveredPersonOid { get; set; }
    public string LineFirmOfficialId { get; set; }
    public string ReleatedSupportId { get; set; }
    public string ReleatedSupportOid { get; set; }
    public int PersonCount { get; set; }  // Derived
}

public class CreateProjectLineWorkDto
{
    [Required(ErrorMessage = "Proje Satırı Seçilmelidir")]
    public string LineId { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public int Priority { get; set; } = 3;
    public int RowOrder { get; set; }
    public int? TimeSpend { get; set; }
    public bool LetTimeDeduct { get; set; }
    public string DeliveredPersonOid { get; set; }
    public string LineFirmOfficialId { get; set; }
}
```

### 2.6 ProjectPersonDto
```csharp
public class ProjectPersonDto
{
    public string Id { get; set; }
    public string ProjectId { get; set; }
    public string ProjectLineId { get; set; }
    public string ProjectLineWorkId { get; set; }
    public string UserId { get; set; }
    public string UserName { get; set; }  // Navigation
    public string UserTitle { get; set; }  // Navigation
}

public class AddProjectPersonDto
{
    [Required(ErrorMessage = "Kullanıcı Seçilmelidir")]
    public string UserId { get; set; }

    public string ProjectId { get; set; }
    public string ProjectLineId { get; set; }
    public string ProjectLineWorkId { get; set; }
}
```

### Görevler - Proje Yönetimi
- [ ] `ProjectDto.cs` oluştur
- [ ] `CreateProjectDto.cs` oluştur
- [ ] `UpdateProjectDto.cs` oluştur
- [ ] `ProjectLineDto.cs` oluştur
- [ ] `CreateProjectLineDto.cs` oluştur
- [ ] `UpdateProjectLineDto.cs` oluştur
- [ ] `ProjectFileDto.cs` oluştur
- [ ] `ProjectLineNoteDto.cs` oluştur
- [ ] `CreateProjectLineNoteDto.cs` oluştur
- [ ] `ProjectLineWorkDto.cs` oluştur
- [ ] `CreateProjectLineWorkDto.cs` oluştur
- [ ] `ProjectPersonDto.cs` oluştur
- [ ] `AddProjectPersonDto.cs` oluştur

**Tahmini Süre**: 1 saat

---

## Grup 3: Takvim ve Randevu (Agenda)

### 3.1 AgendaDto
```csharp
public class AgendaDto : BaseDto
{
    public string AgendaTypeId { get; set; }
    public string AgendaTypeName { get; set; }  // Navigation
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Location { get; set; }
    public string EventCode { get; set; }
    public string ProjectId { get; set; }
    public string FirmOid { get; set; }
    public string TicketOid { get; set; }
    public string TaskId { get; set; }
    public string NoteForCustomer { get; set; }
    public bool IsCanceled { get; set; }
    public bool IsComplated { get; set; }
    public DateTime? CancelDate { get; set; }
    public string CancelDesc { get; set; }
    public string CancelUser { get; set; }
    public DateTime? ComplateDate { get; set; }
    public string ComplatedDesc { get; set; }
    public List<string> UserIds { get; set; }  // Many-to-many
    public List<string> FixtureIds { get; set; }  // Many-to-many
}

public class CreateAgendaDto
{
    [Required(ErrorMessage = "Randevu Türü Seçilmelidir")]
    public string AgendaTypeId { get; set; }

    [Required(ErrorMessage = "Başlık Boş Bırakılamaz")]
    public string Title { get; set; }

    public string Description { get; set; }

    [Required(ErrorMessage = "Başlangıç Tarihi Boş Bırakılamaz")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "Bitiş Tarihi Boş Bırakılamaz")]
    public DateTime EndDate { get; set; }

    public string Location { get; set; }
    public string ProjectId { get; set; }
    public string FirmOid { get; set; }
    public string TicketOid { get; set; }
    public string TaskId { get; set; }
    public string NoteForCustomer { get; set; }
    public List<string> UserIds { get; set; }
    public List<string> FixtureIds { get; set; }
}

public class UpdateAgendaDto : CreateAgendaDto
{
    public string Id { get; set; }
}
```

### 3.2 AgendaTypeDto
```csharp
public class AgendaTypeDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public string BackColor { get; set; }
    public string BorderColor { get; set; }
    public string FontColor { get; set; }
}

public class CreateAgendaTypeDto
{
    [Required(ErrorMessage = "Ad Boş Bırakılamaz")]
    public string Name { get; set; }

    public string Description { get; set; }
    public bool IsActive { get; set; } = true;
    public string BackColor { get; set; } = "#3788d8";
    public string BorderColor { get; set; } = "#3788d8";
    public string FontColor { get; set; } = "#ffffff";
}
```

### Görevler - Agenda
- [ ] `AgendaDto.cs` oluştur
- [ ] `CreateAgendaDto.cs` oluştur
- [ ] `UpdateAgendaDto.cs` oluştur
- [ ] `AgendaTypeDto.cs` oluştur
- [ ] `CreateAgendaTypeDto.cs` oluştur

**Tahmini Süre**: 30 dakika

---

## Grup 4: İzin Yönetimi (Vacation)

### 4.1 VacationRequestDto
```csharp
public class VacationRequestDto : BaseDto
{
    public string UserId { get; set; }
    public string UserName { get; set; }  // Navigation
    public string VacationTypeId { get; set; }
    public string VacationTypeName { get; set; }  // Navigation
    public string Subject { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Status { get; set; }
    public string StatusText { get; set; }  // Enum to text
    public bool PaidVacation { get; set; }
    public bool DropFromAnnualVaccation { get; set; }
    public int DropFromAnnualVaccationAmount { get; set; }
    public int Version { get; set; }
    public string ReqNumber { get; set; }
    public int DayCount { get; set; }  // Derived
}

public class CreateVacationRequestDto
{
    [Required(ErrorMessage = "Kullanıcı Seçilmelidir")]
    public string UserId { get; set; }

    [Required(ErrorMessage = "İzin Türü Seçilmelidir")]
    public string VacationTypeId { get; set; }

    public string Subject { get; set; }

    [Required(ErrorMessage = "Açıklama Boş Bırakılamaz")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Başlangıç Tarihi Boş Bırakılamaz")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "Bitiş Tarihi Boş Bırakılamaz")]
    public DateTime EndDate { get; set; }

    public bool PaidVacation { get; set; }
    public bool DropFromAnnualVaccation { get; set; }
    public int DropFromAnnualVaccationAmount { get; set; }
}

public class UpdateVacationRequestDto : CreateVacationRequestDto
{
    public string Id { get; set; }
}
```

### 4.2 VacationHistoryDto
```csharp
public class VacationHistoryDto
{
    public string Id { get; set; }
    public string VacationId { get; set; }
    public string Description { get; set; }
    public bool IsAdded { get; set; }
    public string ReleatedUserId { get; set; }
    public string ReleatedUserName { get; set; }  // Navigation
}
```

### 4.3 VacationTypesDto
```csharp
public class VacationTypesDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Status { get; set; }
}

public class CreateVacationTypeDto
{
    [Required(ErrorMessage = "Ad Boş Bırakılamaz")]
    public string Name { get; set; }

    public string Description { get; set; }
}

public class UpdateVacationTypeDto : CreateVacationTypeDto
{
    public string Id { get; set; }
}
```

### Görevler - Vacation
- [ ] `VacationRequestDto.cs` oluştur
- [ ] `CreateVacationRequestDto.cs` oluştur
- [ ] `UpdateVacationRequestDto.cs` oluştur
- [ ] `VacationHistoryDto.cs` oluştur
- [ ] `VacationTypesDto.cs` oluştur
- [ ] `CreateVacationTypeDto.cs` oluştur
- [ ] `UpdateVacationTypeDto.cs` oluştur

**Tahmini Süre**: 30 dakika

---

## Grup 5: Yardım Masası (HelpDesk)

### 5.1 HelpDeskCategoryDto
```csharp
public class HelpDeskCategoryDto : BaseDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Status { get; set; }
    public int ProblemCount { get; set; }  // Derived
}

public class CreateHelpDeskCategoryDto
{
    [Required(ErrorMessage = "Ad Boş Bırakılamaz")]
    public string Name { get; set; }

    public string Description { get; set; }
}

public class UpdateHelpDeskCategoryDto : CreateHelpDeskCategoryDto
{
    public string Id { get; set; }
}
```

### 5.2 HelpDeskProblemDto
```csharp
public class HelpDeskProblemDto : BaseDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string CategoryId { get; set; }
    public string CategoryName { get; set; }  // Navigation
    public int Status { get; set; }
    public int Views { get; set; }
    public int SolutionCount { get; set; }  // Derived
}

public class CreateHelpDeskProblemDto
{
    [Required(ErrorMessage = "Başlık Boş Bırakılamaz")]
    public string Title { get; set; }

    [Required(ErrorMessage = "İçerik Boş Bırakılamaz")]
    public string Content { get; set; }

    public string CategoryId { get; set; }
}
```

### 5.3 HelpDeskSolutionDto
```csharp
public class HelpDeskSolutionDto : BaseDto
{
    public string HelpDeskProblemId { get; set; }
    public string ProblemTitle { get; set; }  // Navigation
    public string Title { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public string SolitionNumber { get; set; }
    public bool CustomerCanSee { get; set; }
    public int Like { get; set; }
    public int DisLike { get; set; }
    public int Status { get; set; }
}

public class CreateHelpDeskSolutionDto
{
    [Required(ErrorMessage = "Problem Seçilmelidir")]
    public string HelpDeskProblemId { get; set; }

    [Required(ErrorMessage = "Başlık Boş Bırakılamaz")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Açıklama Boş Bırakılamaz")]
    public string Description { get; set; }

    [Required(ErrorMessage = "İçerik Boş Bırakılamaz")]
    public string Content { get; set; }

    public bool CustomerCanSee { get; set; } = true;
}
```

### Görevler - HelpDesk
- [ ] `HelpDeskCategoryDto.cs` oluştur
- [ ] `CreateHelpDeskCategoryDto.cs` oluştur
- [ ] `UpdateHelpDeskCategoryDto.cs` oluştur
- [ ] `HelpDeskProblemDto.cs` oluştur
- [ ] `CreateHelpDeskProblemDto.cs` oluştur
- [ ] `HelpDeskSolutionDto.cs` oluştur
- [ ] `CreateHelpDeskSolutionDto.cs` oluştur

**Tahmini Süre**: 35 dakika

---

## Grup 6: Uygulama ve Lisans Yönetimi

### 6.1 ApplicationsDto
```csharp
public class ApplicationsDto
{
    public string Id { get; set; }
    public string AppId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? ExpDate { get; set; }
    public bool IsMultiModuleApplication { get; set; }
    public bool IsPackageApplication { get; set; }
    public int MaxUserCount { get; set; }
    public int Status { get; set; }
    public int LicenceCount { get; set; }  // Derived
    public int ModuleCount { get; set; }  // Derived
    public int FirmCount { get; set; }  // Derived
}

public class CreateApplicationsDto
{
    [Required(ErrorMessage = "Uygulama ID Boş Bırakılamaz")]
    public string AppId { get; set; }

    [Required(ErrorMessage = "Ad Boş Bırakılamaz")]
    public string Name { get; set; }

    public string Description { get; set; }
    public DateTime? ExpDate { get; set; }
    public bool IsMultiModuleApplication { get; set; }
    public bool IsPackageApplication { get; set; }
    public int MaxUserCount { get; set; }
    public int Status { get; set; } = 1;
}
```

### 6.2 ApplicationLicencesDto
```csharp
public class ApplicationLicencesDto
{
    public string Id { get; set; }
    public string ApplicationId { get; set; }
    public string ApplicationName { get; set; }  // Navigation
    public string LicenceCode { get; set; }
    public string CpuId { get; set; }
    public string MainboardId { get; set; }
    public string PcName { get; set; }
    public DateTime CreateDate { get; set; }
    public string ApprovedByUserId { get; set; }
    public string ApprovedByUserName { get; set; }  // Navigation
    public string LisansFirmId { get; set; }
    public string LisansFirmName { get; set; }  // Navigation
    public int Status { get; set; }
    public int licenceStatus { get; set; }
}

public class CreateApplicationLicenceDto
{
    [Required(ErrorMessage = "Uygulama Seçilmelidir")]
    public string ApplicationId { get; set; }

    public string LicenceCode { get; set; }
    public string CpuId { get; set; }
    public string MainboardId { get; set; }
    public string PcName { get; set; }
    public string LisansFirmId { get; set; }
}

public class ApproveLicenceDto
{
    [Required(ErrorMessage = "Lisans ID Boş Bırakılamaz")]
    public string Id { get; set; }

    public bool Approved { get; set; }
    public string RejectReason { get; set; }
}
```

### Görevler - Applications
- [ ] `ApplicationsDto.cs` oluştur
- [ ] `CreateApplicationsDto.cs` oluştur
- [ ] `ApplicationLicencesDto.cs` oluştur
- [ ] `CreateApplicationLicenceDto.cs` oluştur
- [ ] `ApproveLicenceDto.cs` oluştur

**Tahmini Süre**: 25 dakika

---

## Grup 7: İşlem Yönetimi (Transaction)

### 7.1 TransactionDto
```csharp
public class TransactionDto : BaseDto
{
    public string TransactionNumber { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string TransactionTypeId { get; set; }
    public string TransactionTypeName { get; set; }  // Navigation
    public string UserId { get; set; }
    public string UserName { get; set; }  // Navigation
    public bool IsComplated { get; set; }
    public List<TransactionItemDto> Items { get; set; }
}

public class CreateTransactionDto
{
    [Required(ErrorMessage = "İşlem Türü Seçilmelidir")]
    public string TransactionTypeId { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public string UserId { get; set; }
}
```

### 7.2 TransactionItemDto
```csharp
public class TransactionItemDto
{
    public string Id { get; set; }
    public string TransactionId { get; set; }
    public string Description { get; set; }
    public bool IsSuccess { get; set; }
}
```

### 7.3 TransactionTypeDto
```csharp
public class TransactionTypeDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public string ColorClass { get; set; }
    public int Status { get; set; }
}

public class CreateTransactionTypeDto
{
    [Required(ErrorMessage = "Ad Boş Bırakılamaz")]
    public string Name { get; set; }

    public string Description { get; set; }
    public string Icon { get; set; }
    public string ColorClass { get; set; }
}

public class UpdateTransactionTypeDto : CreateTransactionTypeDto
{
    public string Id { get; set; }
}
```

### Görevler - Transaction
- [ ] `TransactionDto.cs` oluştur
- [ ] `CreateTransactionDto.cs` oluştur
- [ ] `TransactionItemDto.cs` oluştur
- [ ] `TransactionTypeDto.cs` oluştur
- [ ] `CreateTransactionTypeDto.cs` oluştur
- [ ] `UpdateTransactionTypeDto.cs` oluştur

**Tahmini Süre**: 25 dakika

---

## Grup 8: Diğer DTO'lar

### 8.1 CrmFirmDto
```csharp
public class CrmFirmDto
{
    public string Id { get; set; }
    public string Oid { get; set; }
    public string Code { get; set; }
    public string Title { get; set; }
    public string Phone { get; set; }
    public bool InUse { get; set; }
    public DateTime LastUpdate { get; set; }
    public int ContactCount { get; set; }  // Derived
    public int ProjectCount { get; set; }  // Derived
}
```

### 8.2 CrmFirmContactDto
```csharp
public class CrmFirmContactDto
{
    public string Id { get; set; }
    public string Oid { get; set; }
    public string FirmId { get; set; }
    public string FirmName { get; set; }  // Navigation
    public string Name { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }  // Computed
    public bool InUse { get; set; }
    public bool SupportTicket { get; set; }
    public DateTime LastUpdate { get; set; }
    public List<string> PhoneNumbers { get; set; }  // Navigation
}
```

### 8.3 EmailTemplateDto
```csharp
public class EmailTemplateDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public DateTime CreateTime { get; set; }
    public string CreateUser { get; set; }
    public DateTime UpdateTime { get; set; }
    public string UpdateUser { get; set; }
    public int Status { get; set; }
}

public class CreateEmailTemplateDto
{
    [Required(ErrorMessage = "Ad Boş Bırakılamaz")]
    public string Name { get; set; }

    public string Description { get; set; }

    [Required(ErrorMessage = "İçerik Boş Bırakılamaz")]
    public string Content { get; set; }
}

public class UpdateEmailTemplateDto : CreateEmailTemplateDto
{
    public string Id { get; set; }
}
```

### 8.4 ModuleDto
```csharp
public class ModuleDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public int Status { get; set; }
    public int ClaimCount { get; set; }  // Derived
    public int GeneratedIdCount { get; set; }  // Derived
}

public class CreateModuleDto
{
    [Required(ErrorMessage = "Ad Boş Bırakılamaz")]
    public string Name { get; set; }

    public string DisplayName { get; set; }

    [Required(ErrorMessage = "Açıklama Boş Bırakılamaz")]
    public string Description { get; set; }
}

public class UpdateModuleDto : CreateModuleDto
{
    public string Id { get; set; }
}
```

### 8.5 FixtureDto
```csharp
public class FixtureDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public bool IsVehicle { get; set; }
}

public class CreateFixtureDto
{
    [Required(ErrorMessage = "Ad Boş Bırakılamaz")]
    public string Name { get; set; }

    public string Description { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsVehicle { get; set; }
}

public class UpdateFixtureDto : CreateFixtureDto
{
    public string Id { get; set; }
}
```

### 8.6 GeneratedIdsDto
```csharp
public class GeneratedIdsDto
{
    public string Id { get; set; }
    public string ModuleId { get; set; }
    public string ModuleName { get; set; }  // Navigation
    public string Name { get; set; }
    public string Prefix { get; set; }
    public int Digit { get; set; }
    public int StartNumber { get; set; }
    public int LastNumber { get; set; }
    public string Description { get; set; }
}

public class CreateGeneratedIdsDto
{
    [Required(ErrorMessage = "Modül Seçilmelidir")]
    public string ModuleId { get; set; }

    [Required(ErrorMessage = "Ad Boş Bırakılamaz")]
    public string Name { get; set; }

    public string Prefix { get; set; }

    [Required(ErrorMessage = "Basamak Sayısı Boş Bırakılamaz")]
    public int Digit { get; set; }

    [Required(ErrorMessage = "Başlangıç Numarası Boş Bırakılamaz")]
    public int StartNumber { get; set; }

    public string Description { get; set; }
}

public class UpdateGeneratedIdsDto : CreateGeneratedIdsDto
{
    public string Id { get; set; }
}
```

### 8.7 ClaimDto
```csharp
public class ClaimDto
{
    public string Id { get; set; }
    public string ModuleId { get; set; }
    public string ModuleName { get; set; }  // Navigation
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
}
```

### 8.8 SupportFileDto
```csharp
public class SupportFileDto
{
    public string Id { get; set; }
    public string TicketId { get; set; }
    public string FileName { get; set; }
    public string UrlSlug { get; set; }
    public string Endwith { get; set; }
    public int AttachmentType { get; set; }
    public int AddedByType { get; set; }
    public string AddedByOid { get; set; }
    public DateTime CreateDate { get; set; }
    public int Status { get; set; }
}

public class CreateSupportFileDto
{
    [Required(ErrorMessage = "Dosya Seçilmelidir")]
    public IFormFile File { get; set; }

    [Required(ErrorMessage = "Ticket ID Boş Bırakılamaz")]
    public string TicketId { get; set; }

    public int AttachmentType { get; set; } = 1;  // Default: File
}
```

### Görevler - Diğer
- [ ] `CrmFirmDto.cs` oluştur
- [ ] `CrmFirmContactDto.cs` oluştur
- [ ] `EmailTemplateDto.cs` oluştur
- [ ] `CreateEmailTemplateDto.cs` oluştur
- [ ] `UpdateEmailTemplateDto.cs` oluştur
- [ ] `ModuleDto.cs` oluştur
- [ ] `CreateModuleDto.cs` oluştur
- [ ] `UpdateModuleDto.cs` oluştur
- [ ] `FixtureDto.cs` oluştur
- [ ] `CreateFixtureDto.cs` oluştur
- [ ] `UpdateFixtureDto.cs` oluştur
- [ ] `GeneratedIdsDto.cs` oluştur
- [ ] `CreateGeneratedIdsDto.cs` oluştur
- [ ] `UpdateGeneratedIdsDto.cs` oluştur
- [ ] `ClaimDto.cs` oluştur
- [ ] `SupportFileDto.cs` oluştur
- [ ] `CreateSupportFileDto.cs` oluştur

**Tahmini Süre**: 45 dakika

---

## Faz 2 Özeti

| Grup | DTO Sayısı | Tahmini Süre | Durum |
|------|-----------|--------------|-------|
| Identity/Kullanıcı | 3 | 15 dk | ⬜ Bekliyor |
| Proje Yönetimi | 13 | 1 saat | ⬜ Bekliyor |
| Agenda | 5 | 30 dk | ⬜ Bekliyor |
| İzin Yönetimi | 7 | 30 dk | ⬜ Bekliyor |
| Yardım Masası | 7 | 35 dk | ⬜ Bekliyor |
| Uygulama/Lisans | 5 | 25 dk | ⬜ Bekliyor |
| İşlem Yönetimi | 6 | 25 dk | ⬜ Bekliyor |
| Diğer | 17 | 45 dk | ⬜ Bekliyor |

**Toplam DTO Sayısı**: ~63
**Toplam Tahmini Süre**: ~4.5 saat

---

### Sonraki Fazlar
- [Faz 1 - Kritik Eksiklikler](./01-Faz-1-Kritik-Eksiklikler.md)
- [Faz 3 - Controllers ve Views](./03-Faz-3-Controllers-Views.md)
- [Faz 4 - Kod Kalitesi](./04-Faz-4-Kod-Kalitesi.md)
