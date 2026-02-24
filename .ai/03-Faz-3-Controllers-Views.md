# Faz 3 - Controllers ve Views

## Öncelik: ORTA 🟡
Bu faz, eksik controller'ların ve view sayfalarının oluşturulmasını içerir.

---

## 1. EmailTemplate Controller ve Views

### Controller Oluşturma
**Konum**: `Koala.Portal.WebUI/Controllers/EmailTemplateController.cs`

```csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Koala.Portal.Service.Services;

namespace Koala.Portal.WebUI.Controllers
{
    [Authorize]
    public class EmailTemplateController : Controller
    {
        private readonly MailTemplateService _mailTemplateService;

        public EmailTemplateController(MailTemplateService mailTemplateService)
        {
            _mailTemplateService = mailTemplateService;
        }

        public IActionResult Index()
        {
            var templates = _mailTemplateService.GetAll();
            return View(templates);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateEmailTemplateViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create logic
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(string id)
        {
            var template = _mailTemplateService.GetById(id);
            if (template == null) return NotFound();
            return View(template);
        }

        [HttpPost]
        public IActionResult Edit(UpdateEmailTemplateViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Update logic
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(string id)
        {
            var template = _mailTemplateService.GetById(id);
            if (template == null) return NotFound();
            return View(template);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            _mailTemplateService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(string id)
        {
            var template = _mailTemplateService.GetById(id);
            if (template == null) return NotFound();
            return View(template);
        }
    }
}
```

### Views Oluşturma
**Konum**: `Koala.Portal.WebUI/Views/EmailTemplate/`

#### Index.cshtml
- Liste görünümü
- Tablo ile tüm şablonlar
- Yeni ekle butonu
- Düzenle ve silme aksiyonları

#### Create.cshtml
- Form ile yeni şablon oluşturma
- Content alanı için rich text editor
- Validation mesajları

#### Edit.cshtml
- Create.cshtml ile benzer
- Mevcut veri ile dolu form

#### Delete.cshtml
- Silme onayı sayfası
- Şablon detayları

#### Details.cshtml
- Şablon detay görüntüleme
- Content alanı HTML render

### Görevler
- [ ] EmailTemplateController oluştur
- [ ] Views/EmailTemplate klasörü oluştur
- [ ] Index.cshtml oluştur
- [ ] Create.cshtml oluştur
- [ ] Edit.cshtml oluştur
- [ ] Delete.cshtml oluştur
- [ ] Details.cshtml oluştur
- [ ] ViewModels oluştur (Faz 2'de tanımlı)

**Tahmini Süre**: 2 saat

---

## 2. CrmDepartment Controller ve Views

### Controller
**Konum**: `Koala.Portal.WebUI/Controllers/CrmDepartmentController.cs`

```csharp
[Authorize]
public class CrmDepartmentController : Controller
{
    private readonly CrmDepartmentService _crmDepartmentService;

    public CrmDepartmentController(CrmDepartmentService crmDepartmentService)
    {
        _crmDepartmentService = crmDepartmentService;
    }

    public IActionResult Index()
    {
        var departments = _crmDepartmentService.GetAll();
        return View(departments);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateCrmDepartmentViewModel model)
    {
        if (ModelState.IsValid)
        {
            _crmDepartmentService.Create(model);
            return RedirectToAction("Index");
        }
        return View(model);
    }

    public IActionResult Edit(string id)
    {
        var dept = _crmDepartmentService.GetById(id);
        return View(dept);
    }

    [HttpPost]
    public IActionResult Edit(UpdateCrmDepartmentViewModel model)
    {
        // Update logic
        return RedirectToAction("Index");
    }

    public IActionResult Delete(string id)
    {
        // Delete logic
        return RedirectToAction("Index");
    }
}
```

### Views
**Konum**: `Koala.Portal.WebUI/Views/CrmDepartment/`

- [ ] Index.cshtml - Departman listesi
- [ ] Create.cshtml - Yeni departman
- [ ] Edit.cshtml - Düzenle

**Tahmini Süre**: 1 saat

---

## 3. CrmFirm Controller ve Views (Detaylı)

### Controller
**Konum**: `Koala.Portal.WebUI/Controllers/CrmFirmController.cs`

```csharp
[Authorize]
public class CrmFirmController : Controller
{
    private readonly CrmFirmService _crmFirmService;
    private readonly FirmContactService _firmContactService;

    public IActionResult Index(int page = 1, string search = "")
    {
        var firms = _crmFirmService.GetPaged(page, search);
        return View(firms);
    }

    public IActionResult Details(string id)
    {
        var firm = _crmFirmService.GetByIdWithContacts(id);
        if (firm == null) return NotFound();
        return View(firm);
    }

    public IActionResult Contacts(string id)
    {
        var contacts = _firmContactService.GetByFirmId(id);
        return PartialView("_ContactsList", contacts);
    }

    public IActionResult SyncFromCrm()
    {
        // CRM'den senkronizasyon
        _crmFirmService.SyncFromCrm();
        return RedirectToAction("Index");
    }
}
```

### Views
**Konum**: `Koala.Portal.WebUI/Views/CrmFirm/`

- [ ] Index.cshtml - Firma listesi (arama ile)
- [ ] Details.cshtml - Firma detayı, kişiler, projeler
- [ ] _ContactsList.cshtml - Kişi listesi partial
- [ ] _ProjectsList.cshtml - Proje listesi partial

**Tahmini Süre**: 1.5 saat

---

## 4. ProjectController - Dosya Yönetimi Ekleme

### Mevcut Controller'a Ekleme
**Konum**: `Koala.Portal.WebUI/Controllers/ProjectController.cs`

```csharp
public class ProjectController : Controller
{
    // ... mevcut kodlar ...

    #region File Management

    public IActionResult Files(string id)
    {
        var project = _projectService.GetFiles(id);
        return View(project);
    }

    [HttpPost]
    public IActionResult UploadFile(string projectId, IFormFile file, string description)
    {
        if (file != null && file.Length > 0)
        {
            _projectService.UploadFile(projectId, file, description);
        }
        return RedirectToAction("Files", new { id = projectId });
    }

    public IActionResult DownloadFile(string id)
    {
        var file = _projectService.GetFile(id);
        if (file == null) return NotFound();
        return File(file.Content, file.ContentType, file.Name);
    }

    [HttpPost]
    public IActionResult DeleteFile(string id, string projectId)
    {
        _projectService.DeleteFile(id);
        return RedirectToAction("Files", new { id = projectId });
    }

    #endregion
}
```

### Views
**Konum**: `Koala.Portal.WebUI/Views/Project/`

- [ ] Files.cshtml - Dosya listesi ve upload formu
- [ ] _FileRow.cshtml - Dosya satırı partial
- [ ] _FileUpload.cshtml - Upload formu partial

**Tahmini Süre**: 1 saat

---

## 5. AgendaController - Tam CRUD

### Mevcut Controller'a Ekleme
**Konum**: `Koala.Portal.WebUI/Controllers/AgendaController.cs`

```csharp
public class AgendaController : Controller
{
    // ... mevcut Index var ...

    public IActionResult Create()
    {
        ViewBag.AgendaTypes = _agendaTypeService.GetAll();
        ViewBag.Users = _userService.GetAll();
        ViewBag.Fixtures = _fixtureService.GetAll();
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateAgendaViewModel model)
    {
        if (ModelState.IsValid)
        {
            _agendaService.Create(model);
            return RedirectToAction("Index");
        }
        // Populate ViewBag again
        return View(model);
    }

    public IActionResult Edit(string id)
    {
        var agenda = _agendaService.GetById(id);
        if (agenda == null) return NotFound();
        // Populate ViewBag
        return View(agenda);
    }

    [HttpPost]
    public IActionResult Edit(UpdateAgendaViewModel model)
    {
        // Update logic
        return RedirectToAction("Index");
    }

    public IActionResult Delete(string id)
    {
        var agenda = _agendaService.GetById(id);
        return View(agenda);
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(string id)
    {
        _agendaService.Delete(id);
        return RedirectToAction("Index");
    }

    public IActionResult Details(string id)
    {
        var agenda = _agendaService.GetByIdWithDetails(id);
        return View(agenda);
    }
}
```

### Views
**Konum**: `Koala.Portal.WebUI/Views/Agenda/`

- [ ] Create.cshtml - Yeni randevu (calendar ile tarih seçimi)
- [ ] Edit.cshtml - Randevu düzenleme
- [ ] Delete.cshtml - Silme onayı
- [ ] Details.cshtml - Randevu detayı

**Tahmini Süre**: 1.5 saat

---

## 6. ApplicationLicences - Onay/Red Sistemi

### Controller Ekleme
**Konum**: `Koala.Portal.WebUI/Controllers/ApplicationsController.cs`

```csharp
public class ApplicationsController : Controller
{
    // ... mevcut kodlar ...

    #region Licence Management

    public IActionResult LicencesWaitingApproval()
    {
        var licences = _applicationLicencesService.GetWaitingApproval();
        return View(licences);
    }

    public IActionResult ApproveLicence(string id)
    {
        var licence = _applicationLicencesService.GetById(id);
        return View(licence);
    }

    [HttpPost]
    public IActionResult ApproveLicence(ApproveLicenceViewModel model)
    {
        if (model.Approved)
        {
            _applicationLicencesService.Approve(model.Id, User.Identity.Name);
        }
        else
        {
            _applicationLicencesService.Reject(model.Id, model.RejectReason);
        }
        return RedirectToAction("LicencesWaitingApproval");
    }

    public IActionResult LicenceDetails(string id)
    {
        var licence = _applicationLicencesService.GetByIdWithDetails(id);
        return View(licence);
    }

    #endregion
}
```

### Views
**Konum**: `Koala.Portal.WebUI/Views/Applications/`

- [ ] LicencesWaitingApproval.cshtml - Onay bekleyen lisanslar
- [ ] ApproveLicence.cshtml - Onay/red formu
- [ ] LicenceDetails.cshtml - Lisans detayı

**Tahmini Süre**: 1.5 saat

---

## 7. VacationController - History Sayfası

### Controller Ekleme
**Konum**: `Koala.Portal.WebUI/Controllers/VacationController.cs`

```csharp
public class VacationController : Controller
{
    // ... mevcut kodlar ...

    public IActionResult History(string userId = null)
    {
        if (string.IsNullOrEmpty(userId))
        {
            userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        var history = _vacationHistoryService.GetByUserId(userId);
        return View(history);
    }

    public IActionResult UserVacationBalance(string userId)
    {
        var balance = _vacationService.GetUserBalance(userId);
        return PartialView("_VacationBalance", balance);
    }
}
```

### Views
**Konum**: `Koala.Portal.WebUI/Views/Vacation/`

- [ ] History.cshtml - İzin geçmişi tablosu
- [ ] _VacationBalance.cshtml - Kullanıcı izin bakiyesi partial

**Tahmini Süre**: 45 dakika

---

## 8. SupportFileController

### Yeni Controller
**Konum**: `Koala.Portal.WebUI/Controllers/SupportFileController.cs`

```csharp
[Authorize]
public class SupportFileController : Controller
{
    private readonly SupportFileService _supportFileService;

    public SupportFileController(SupportFileService supportFileService)
    {
        _supportFileService = supportFileService;
    }

    [HttpPost]
    public IActionResult Upload(CreateSupportFileDto model)
    {
        if (model.File != null && model.File.Length > 0)
        {
            _supportFileService.Upload(model);
        }
        return RedirectToAction("Details", "Support", new { id = model.TicketId });
    }

    public IActionResult Download(string id)
    {
        var file = _supportFileService.GetById(id);
        if (file == null) return NotFound();
        return File(file.Content, file.ContentType, file.FileName);
    }

    [HttpPost]
    public IActionResult Delete(string id, string ticketId)
    {
        _supportFileService.Delete(id);
        return RedirectToAction("Details", "Support", new { id = ticketId });
    }
}
```

### Views
**Konum**: `Koala.Portal.WebUI/Views/Shared/`

- [ ] _FileUpload.cshtml - Generic file upload partial
- [ ] _FileList.cshtml - Generic file list partial

**Tahmini Süre**: 45 dakika

---

## 9. ProjectPersonController

### Yeni Controller
**Konum**: `Koala.Portal.WebUI/Controllers/ProjectPersonController.cs`

```csharp
[Authorize]
public class ProjectPersonController : Controller
{
    private readonly ProjectService _projectService;

    [HttpPost]
    public IActionResult AddPerson(AddProjectPersonViewModel model)
    {
        _projectService.AddPerson(model);
        return RedirectToAction("Detail", "Project", new { id = model.ProjectId });
    }

    [HttpPost]
    public IActionResult RemovePerson(string id, string projectId, string projectLineId, string projectLineWorkId)
    {
        _projectService.RemovePerson(id);
        return RedirectToAction("Detail", "Project", new { id = projectId });
    }

    public IActionResult GetAvailableUsers(string search)
    {
        var users = _projectService.GetAvailableUsers(search);
        return Json(users);
    }
}
```

### Views
**Konum**: `Koala.Portal.WebUI/Views/Project/`

- [ ] _PersonSelector.cshtml - Kişi seçici partial (autocomplete)
- [ ] _PersonList.cshtml - Atanan kişiler listesi partial

**Tahmini Süre**: 45 dakika

---

## 10. ProjectLineNoteController

### Yeni Controller
**Konum**: `Koala.Portal.WebUI/Controllers/ProjectLineNoteController.cs`

```csharp
[Authorize]
public class ProjectLineNoteController : Controller
{
    private readonly ProjectLineNoteService _noteService;

    [HttpPost]
    public IActionResult AddNote(CreateProjectLineNoteViewModel model)
    {
        _noteService.Create(model);
        return RedirectToAction("Detail", "ProjectLine", new { id = model.ProjectLineId });
    }

    public IActionResult Edit(string id)
    {
        var note = _noteService.GetById(id);
        return PartialView("_NoteEdit", note);
    }

    [HttpPost]
    public IActionResult Edit(UpdateProjectLineNoteViewModel model)
    {
        _noteService.Update(model);
        return Json(new { success = true });
    }

    [HttpPost]
    public IActionResult Delete(string id, string projectLineId)
    {
        _noteService.Delete(id);
        return RedirectToAction("Detail", "ProjectLine", new { id = projectLineId });
    }
}
```

### Views
**Konum**: `Koala.Portal.WebUI/Views/ProjectLine/`

- [ ] _NotesList.cshtml - Notlar listesi partial
- [ ] _NoteEdit.cshtml - Not düzenleme modal partial
- [ ] _NoteAdd.cshtml - Not ekleme formu partial

**Tahmini Süre**: 45 dakika

---

## 11. VacationHistoryController

### Yeni Controller
**Konum**: `Koala.Portal.WebUI/Controllers/VacationHistoryController.cs`

```csharp
[Authorize]
public class VacationHistoryController : Controller
{
    private readonly VacationHistoryService _historyService;

    public IActionResult Index(string userId = null, int page = 1)
    {
        if (string.IsNullOrEmpty(userId))
        {
            userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        var history = _historyService.GetPaged(userId, page);
        return View(history);
    }

    public IActionResult Details(string id)
    {
        var item = _historyService.GetById(id);
        return View(item);
    }
}
```

### Views
**Konum**: `Koala.Portal.WebUI/Views/VacationHistory/`

- [ ] Index.cshtml - Geçmiş listesi (pagination ile)
- [ ] Details.cshtml - Geçmiş detayı

**Tahmini Süre**: 30 dakika

---

## 12. ApplicationUpdateController

### Yeni Controller
**Konum**: `Koala.Portal.WebUI/Controllers/ApplicationUpdateController.cs`

```csharp
[Authorize]
public class ApplicationUpdateController : Controller
{
    private readonly ApplicationUpdateService _updateService;

    public IActionResult Index(string applicationId)
    {
        var updates = _updateService.GetByApplicationId(applicationId);
        return View(updates);
    }

    public IActionResult Create(string applicationId)
    {
        ViewBag.ApplicationId = applicationId;
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateApplicationUpdateViewModel model)
    {
        if (ModelState.IsValid)
        {
            _updateService.Create(model);
            return RedirectToAction("Index", new { applicationId = model.ApplicationGuid });
        }
        return View(model);
    }

    public IActionResult DownloadUpdate(string id)
    {
        var update = _updateService.GetById(id);
        // File download logic
        return File(update.Files, "application/zip", $"Update_{update.Version}.zip");
    }
}
```

### Views
**Konum**: `Koala.Portal.WebUI/Views/ApplicationUpdate/`

- [ ] Index.cshtml - Güncelleme listesi
- [ ] Create.cshtml - Yeni güncelleme

**Tahmini Süre**: 45 dakika

---

## 13. ApplicationModulesController

### Yeni Controller
**Konum**: `Koala.Portal.WebUI/Controllers/ApplicationModulesController.cs`

```csharp
[Authorize]
public class ApplicationModulesController : Controller
{
    private readonly ApplicationModulesService _modulesService;

    public IActionResult Index(string applicationId)
    {
        var modules = _modulesService.GetByApplicationId(applicationId);
        ViewBag.ApplicationId = applicationId;
        return View(modules);
    }

    public IActionResult Create(string applicationId)
    {
        ViewBag.ApplicationId = applicationId;
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateApplicationModuleViewModel model)
    {
        _modulesService.Create(model);
        return RedirectToAction("Index", new { applicationId = model.ApplicationId });
    }

    public IActionResult Edit(string id)
    {
        var module = _modulesService.GetById(id);
        return View(module);
    }

    [HttpPost]
    public IActionResult Edit(UpdateApplicationModuleViewModel model)
    {
        _modulesService.Update(model);
        return RedirectToAction("Index", new { applicationId = model.ApplicationId });
    }

    [HttpPost]
    public IActionResult Delete(string id, string applicationId)
    {
        _modulesService.Delete(id);
        return RedirectToAction("Index", new { applicationId });
    }
}
```

### Views
**Konum**: `Koala.Portal.WebUI/Views/ApplicationModules/`

- [ ] Index.cshtml - Modül listesi
- [ ] Create.cshtml - Yeni modül
- [ ] Edit.cshtml - Modül düzenle

**Tahmini Süre**: 45 dakika

---

## 14. CrmPhoneNumberController

### Yeni Controller
**Konum**: `Koala.Portal.WebUI/Controllers/CrmPhoneNumberController.cs`

```csharp
[Authorize]
public class CrmPhoneNumberController : Controller
{
    private readonly CrmPhoneService _phoneService;

    [HttpPost]
    public IActionResult Add(CreatePhoneNumberViewModel model)
    {
        _phoneService.Create(model);
        return RedirectToAction("Edit", "CrmFirmContact", new { id = model.RelatedContact });
    }

    public IActionResult Edit(string id)
    {
        var phone = _phoneService.GetById(id);
        return PartialView("_PhoneEdit", phone);
    }

    [HttpPost]
    public IActionResult Edit(UpdatePhoneNumberViewModel model)
    {
        _phoneService.Update(model);
        return Json(new { success = true });
    }

    [HttpPost]
    public IActionResult Delete(string id, string contactId)
    {
        _phoneService.Delete(id);
        return RedirectToAction("Edit", "CrmFirmContact", new { id = contactId });
    }
}
```

### Views
**Konum**: `Koala.Portal.WebUI/Views/Shared/`

- [ ] _PhoneList.cshtml - Telefon listesi partial
- [ ] _PhoneEdit.cshtml - Telefon düzenleme modal partial

**Tahmini Süre**: 30 dakika

---

## Faz 3 Özeti

| Controller | Action Sayısı | View Sayısı | Tahmini Süre | Durum |
|------------|--------------|-------------|--------------|-------|
| EmailTemplate | 6 | 5 | 2 saat | ⬜ |
| CrmDepartment | 5 | 3 | 1 saat | ⬜ |
| CrmFirm | 4 | 4 | 1.5 saat | ⬜ |
| Project (Files) | 4 | 3 | 1 saat | ⬜ |
| Agenda (CRUD) | 5 | 4 | 1.5 saat | ⬜ |
| Applications (Licences) | 3 | 3 | 1.5 saat | ⬜ |
| Vacation (History) | 2 | 2 | 45 dk | ⬜ |
| SupportFile | 3 | 2 | 45 dk | ⬜ |
| ProjectPerson | 3 | 2 | 45 dk | ⬜ |
| ProjectLineNote | 4 | 3 | 45 dk | ⬜ |
| VacationHistory | 2 | 2 | 30 dk | ⬜ |
| ApplicationUpdate | 4 | 2 | 45 dk | ⬜ |
| ApplicationModules | 6 | 3 | 45 dk | ⬜ |
| CrmPhoneNumber | 4 | 2 | 30 dk | ⬜ |

**Toplam Action Sayısı**: ~60
**Toplam View Sayısı**: ~40
**Toplam Tahmini Süre**: ~14 saat

---

### Sonraki Fazlar
- [Faz 1 - Kritik Eksiklikler](./01-Faz-1-Kritik-Eksiklikler.md)
- [Faz 2 - DTO ve ViewModel'ler](./02-Faz-2-DTO-ViewModel.md)
- [Faz 4 - Kod Kalitesi](./04-Faz-4-Kod-Kalitesi.md)
