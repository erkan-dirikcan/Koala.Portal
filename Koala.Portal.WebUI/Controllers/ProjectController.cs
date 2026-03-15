using Azure;
using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.CrmViewModels;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Koala.Portal.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Koala.Portal.WebUI.Controllers
{
    [Authorize]
    public class ProjectController(
        IProjectLineWorkService workService,
        IProjectService service,
        IProjectLineService lineService,
        UserManager<AppUser> userManager,
        ICrmSqlService crmSqlService,
        ICrmSupportService crmSupportService,
        ICrmSupportStateService crmSupportStateService,
        IFirmService firmService,
        ICrmDepartmentService crmSupportDepartmentService,
        ICrmCategoryService crmSupportCategoryService,
        ICrmSelectListService crmSelectListService,
        ICrmFirmService crmFirmService,
        ISelectListService selectListService,
        ISupportFileService supportFileService,
        IUserService userService,
        IEmailService emailService,
        ITransactionService transactionService,
        IExportService exportService,
        INotificationService notificationService,
        AppDbContext dbContext)
        : Controller
    {
        // ===== Dashboard =====
        [HttpGet]
        [Authorize(Policy = "ProjectManagement.View")]
        public async Task<IActionResult> Dashboard()
        {
            var res = await service.GetProjectListAsync();
            if (!res.IsSuccess)
            {
                TempData["Error"] = res;
                return View("Error");
            }

            var projects = res.Data;

            // Calculate statistics
            var dashboardData = new
            {
                TotalProjects = projects.Count,
                ActiveProjects = projects.Count(p => p.ProjectStatus == ProjectStatusEnum.Started || p.ProjectStatus == ProjectStatusEnum.Testing),
                CompletedProjects = projects.Count(p => p.ProjectStatus == ProjectStatusEnum.Finished),
                CanceledProjects = projects.Count(p => p.ProjectStatus == ProjectStatusEnum.Canceled || p.ProjectStatus == ProjectStatusEnum.Failed),
                ProjectsByStatus = projects.GroupBy(p => p.ProjectStatus)
                    .Select(g => new { Status = g.Key.ToString(), Count = g.Count() })
                    .ToList(),
                ProjectsByManager = projects.Where(p => !string.IsNullOrEmpty(p.ProjectManager))
                    .GroupBy(p => p.ProjectManager)
                    .Select(g => new { Manager = g.Key, Count = g.Count() })
                    .OrderByDescending(g => g.Count)
                    .Take(10)
                    .ToList(),
                UpcomingDeadlines = projects
                    .Where(p => !string.IsNullOrEmpty(p.DueDate) && DateTime.TryParse(p.DueDate, out var due) && due > DateTime.Now)
                    .OrderBy(p => DateTime.Parse(p.DueDate))
                    .Take(5)
                    .ToList(),
                RecentProjects = projects
                    .OrderByDescending(p => p.StartDate)
                    .Take(5)
                    .ToList()
            };

            return View(dashboardData);
        }

        // ===== Index with Filters =====
        [HttpGet]
        [Authorize(Policy = "ProjectManagement.View")]
        public async Task<IActionResult> Index(string? statusFilter, string? managerFilter, string? firmFilter, string? startDate, string? endDate, string? searchTerm)
        {
            // Store filter values for form persistence
            ViewData["StatusFilter"] = statusFilter ?? "";
            ViewData["ManagerFilter"] = managerFilter ?? "";
            ViewData["FirmFilter"] = firmFilter ?? "";
            ViewData["StartDate"] = startDate ?? "";
            ViewData["EndDate"] = endDate ?? "";
            ViewData["SearchTerm"] = searchTerm ?? "";

            // Load select lists
            var users = await selectListService.GetUserSelectList("");


            ViewData["Users"] = users.Data;
            var firms = await crmSelectListService.GetFirmSelectList();
            ViewData["Firms"] = firms.Data;

            var res = await service.GetProjectListAsync();
            if (!res.IsSuccess)
            {
                ViewData["Error"] = res;
                return View("Error");
            }

            var projects = res.Data;

            // Apply filters
            if (!string.IsNullOrEmpty(statusFilter))
            {
                if (Enum.TryParse<ProjectStatusEnum>(statusFilter, true, out var statusEnum))
                {
                    projects = projects.Where(p => p.ProjectStatus == statusEnum).ToList();
                }
            }

            // Manager and firm filters require project detail data - not implemented for list view
            if (!string.IsNullOrEmpty(searchTerm))
            {
                projects = projects.Where(p =>
                    (p.ProjectName != null && p.ProjectName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                    (p.ProjectCode != null && p.ProjectCode.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                ).ToList();
            }

            if (!string.IsNullOrEmpty(startDate) && DateTime.TryParse(startDate, out var start))
            {
                projects = projects.Where(p =>
                {
                    var projectStart = !string.IsNullOrEmpty(p.StartDate) && DateTime.TryParse(p.StartDate, out var ps) ? ps : (DateTime?)null;
                    return projectStart.HasValue && projectStart >= start;
                }).ToList();
            }

            if (!string.IsNullOrEmpty(endDate) && DateTime.TryParse(endDate, out var end))
            {
                projects = projects.Where(p =>
                {
                    var projectDue = !string.IsNullOrEmpty(p.DueDate) && DateTime.TryParse(p.DueDate, out var pd) ? pd : (DateTime?)null;
                    return projectDue.HasValue && projectDue <= end;
                }).ToList();
            }

            return View(projects);
        }


        [HttpGet]
        [Authorize(Policy = "ProjectManagement.Create")]
        public async Task<IActionResult> CreateProject(string firmId = "")
        {
            var firms = await crmSelectListService.GetFirmSelectList();
            TempData["Firms"] = firms.Data;
            var users = await selectListService.GetUserSelectList( "");
            TempData["Users"] = users.Data;
            return View();
        }
        [HttpPost]
        [Authorize(Policy = "ProjectManagement.Create")]
        public async Task<IActionResult> CreateProject(AddProjectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var firms = await crmSelectListService.GetFirmSelectList();
                TempData["Firms"] = firms.Data;
                var users = await selectListService.GetUserSelectList("");
                TempData["Users"] = users.Data;
                return View(model);

            }
            var pUser = User;
            var user = await userManager.GetUserAsync(pUser);
            model.CreateUser = user.Id;
            model.CreateTime = DateTime.Now;
            var res = await service.AddAsync(model);
            //emailService
            if (res.IsSuccess)
            {
                return RedirectToAction("Detail", "Project",new {id=res.Data});
            }
            TempData["Error"] = res;
            return View("Error");
        }

        public async Task<IActionResult> Detail(string id)
        {
            var project =await service.GetProjectByIdAsync(id);
           
            if (!project.IsSuccess)
            {
                TempData["Error"] = project;
                return View("Error");
            }
            var firm = await firmService.GetFirmByIdAsync(project.Data.FirmId);
            if (!firm.IsSuccess)
            {
                TempData["Error"] = firm;
                return View("Error");
            }
            var projectSupports = await crmSupportService.Where(x => x.ProjectCode == project.Data.ProjectCode);
            var supportUsers = crmSqlService.GetCrmUserFullNameInfoList();
            var localUsers = await userManager.Users.Select(x => new SelectListItem(x.GetFullName(), x.Id, false))
                .ToListAsync();
            var currentUser = User;
            var user = await userManager.GetUserAsync(currentUser);
            var userDepartments = crmSqlService.GetCrmUserDepartments(user.Oid!);
            var retVal = (project.Data, firm.Data, projectSupports.Data, supportUsers.Data, userDepartments.Data,localUsers);


            return View(retVal);
        }

        [HttpGet]
        [Authorize(Policy = "ProjectManagement.Create")]
        public async Task<IActionResult> AddProjectLine(string projectId)
        {

            return View();
        }
        [HttpPost]
        [Authorize(Policy = "ProjectManagement.Create")]
        public async Task<IActionResult> AddProjectLine(AddProjectLineViewModel model)
        {
            // Debug: Model null kontrolü
            Console.WriteLine($"=== AddProjectLine çağrıldı ===");
            Console.WriteLine($"Model null mi?: {model == null}");

            if (model == null)
            {
                return Json(new { isSuccess = false, message = "Model null geldi! JSON formatını kontrol edin." });
            }

            Console.WriteLine($"ProjectId: {model.ProjectId}");
            Console.WriteLine($"Title: {model.Title}");
            Console.WriteLine($"Priority: {model.Priority}");
            Console.WriteLine($"RowOrdwer: {model.RowOrder}");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Json(new { isSuccess = false, message = "Geçersiz veri! Hatalar: " + string.Join(", ", errors) });
            }

            var pUser = User;
            var user = await userManager.GetUserAsync(pUser);
            model.CreateUser = user.Id;
            model.CreateTime = DateTime.Now;

            var res = await lineService.AddAsync(model);

            if (res.IsSuccess)
            {
                return Json(res);
            }

            return Json(new { isSuccess = false, message = res.Message ?? "Faz eklenirken bir hata oluştu!" });
        }

        [HttpPost]
        [Authorize(Policy = "ProjectManagement.Update")]
        public async Task<IActionResult> UpdateProjectLine([FromBody] UpdateProjectLineViewModel model)
        {
            // Debug: Model null kontrolü
            Console.WriteLine($"=== UpdateProjectLine çağrıldı ===");
            Console.WriteLine($"Model null mi?: {model == null}");

            if (model == null)
            {
                return Json(new { isSuccess = false, message = "Model null geldi!" });
            }

            Console.WriteLine($"Id: {model.Id}");
            Console.WriteLine($"Title: {model.Title}");
            Console.WriteLine($"Priority: {model.Priority}");
            Console.WriteLine($"RowOrder: {model.RowOrder}");
            Console.WriteLine($"DueDate: {model.DueDate}");
            Console.WriteLine($"LineOfficialId: {model.LineOfficialId}");
            Console.WriteLine($"LineFirmOfficialId: {model.LineFirmOfficialId}");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Json(new { isSuccess = false, message = "Geçersiz veri! Hatalar: " + string.Join(", ", errors) });
            }

            var pUser = User;
            var user = await userManager.GetUserAsync(pUser);
            model.UpdateUser = user.Id;
            model.UpdateTime = DateTime.Now;

            var res = await lineService.UpdateAsync(model, model.Id);

            if (res.IsSuccess)
            {
                return Json(new { isSuccess = true, message = res.Message });
            }

            return Json(new { isSuccess = false, message = res.Message ?? "Faz güncellenirken bir hata oluştu!" });
        }

        // Faz detayını getir (düzenleme için)
        [HttpGet]
        [Authorize(Policy = "ProjectManagement.View")]
        public async Task<IActionResult> GetProjectLine(string id)
        {
            var res = await lineService.GetProjectLineDetailAsync(id);
            if (res.IsSuccess)
            {
                return Json(new { isSuccess = true, data = res.Data });
            }
            return Json(new { isSuccess = false, message = res.Message ?? "Faz bilgileri alınamadı!" });
        }

        [HttpPost]
        [Authorize(Policy = "ProjectManagement.Create")]
        public async Task<IActionResult> DeleteProjectLine(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Json(new { isSuccess = false, message = "ID bilgisi gerekli!" });
            }

            var res = await lineService.DeleteAsync(id);

            if (res.IsSuccess)
            {
                return Json(new { isSuccess = true, message = "Faz başarıyla silindi!" });
            }

            return Json(new { isSuccess = false, message = res.Message ?? "Faz silinirken bir hata oluştu!" });
        }

        [HttpPost]
        [Authorize(Policy = "ProjectManagement.Create")]
        public async Task<IActionResult> ChangeProjectLineStatus([FromBody] ProjectLineChangeStateStatusViewModel model)
        {
            if (model == null)
            {
                return Json(new { isSuccess = false, message = "Model null geldi!" });
            }

            var res = await lineService.ChangeStateStatusAsync(model);

            if (res.IsSuccess)
            {
                return Json(new { isSuccess = true, message = "Faz durumu başarıyla değiştirildi!" });
            }

            return Json(new { isSuccess = false, message = res.Message ?? "Faz durumu değiştirilirken bir hata oluştu!" });
        }

        #region Project CRUD

        [HttpGet]
        [Authorize(Policy = "ProjectManagement.Update")]
        public async Task<IActionResult> UpdateProject(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["ErrorMessage"] = "Id Bilgisi Boş Bırakılamaz";
                return RedirectToAction("Index", "Project");
            }

            var project = await service.GetProjectByIdAsync(id);
            if (!project.IsSuccess || project.Data == null)
            {
                TempData["ErrorMessage"] = "Güncellenmek İstenen Proje Bulunamadı";
                return RedirectToAction("Index", "Project");
            }

            var firms = await crmSelectListService.GetFirmSelectList();
            ViewData["Firms"] = firms.Data;
            var users = await selectListService.GetUserSelectList("");
            ViewData["Users"] = users.Data;

            var updateModel = new UpdateProjectViewModel
            {
                Id = project.Data.Id,
                ProjectName = project.Data.ProjectName,
                Description = project.Data.Description,
                ProjectManagerId = project.Data.ProjectManagerId,
                FirmId = project.Data.Firm?.Oid ?? project.Data.FirmId,
                FirmPersonId = project.Data.FirmPerson?.Oid ?? project.Data.FirmPersonId,
                ServiceHour = project.Data.ServiceHour,
                DueDate = project.Data.DueDate?.ToString("dd-MM-yyyy")
            };

            return View(updateModel);
        }

        [HttpPost]
        [Authorize(Policy = "ProjectManagement.Update")]
        public async Task<IActionResult> UpdateProject(UpdateProjectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var firms = await crmSelectListService.GetFirmSelectList();
                ViewData["Firms"] = firms.Data;
                var users = await selectListService.GetUserSelectList("");
                ViewData["Users"] = users.Data;
                return View(model);
            }

            // Convert CRM Oid to local database Id
            if (!string.IsNullOrEmpty(model.FirmId))
            {
                var crmFirm = await dbContext.CrmFirm.FirstOrDefaultAsync(f => f.Oid == model.FirmId);
                if (crmFirm != null) model.FirmId = crmFirm.Id;
            }

            if (!string.IsNullOrEmpty(model.FirmPersonId))
            {
                var crmContact = await dbContext.CrmFirmContact.FirstOrDefaultAsync(c => c.Oid == model.FirmPersonId);
                if (crmContact != null) model.FirmPersonId = crmContact.Id;
            }

            var user = await userManager.GetUserAsync(User);
            model.UpdateUser = user.Id;
            model.UpdateTime = DateTime.Now;

            var res = await service.UpdateAsync(model, model.Id);
            if (!res.IsSuccess)
            {
                TempData["Error"] = res;
                var firms = await crmSelectListService.GetFirmSelectList();
                ViewData["Firms"] = firms.Data;
                var users = await selectListService.GetUserSelectList("");
                ViewData["Users"] = users.Data;
                return View(model);
            }

            TempData["InfoMessage"] = $"{model.ProjectName} isimli proje başarıyla güncellendi";
            return RedirectToAction("Detail", "Project", new { id = model.Id });
        }

        [HttpPost]
        [Authorize(Policy = "ProjectManagement.Delete")]
        public async Task<IActionResult> DeleteProject(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Json(new { isSuccess = false, message = "ID bilgisi gerekli!" });
            }

            var project = await service.GetProjectByIdAsync(id);
            var res = await service.DeleteAsync(id);

            if (res.IsSuccess)
            {
                return Json(new { isSuccess = true, message = $"{project.Data?.ProjectName} isimli proje başarıyla silindi!" });
            }

            return Json(new { isSuccess = false, message = res.Message ?? "Proje silinirken bir hata oluştu!" });
        }

        #endregion

        #region ProjectLineNote CRUD

        [HttpPost]
        [Authorize(Policy = "ProjectManagement.Create")]
        public async Task<IActionResult> AddProjectLineNote([FromBody] AddProjectLineNoteViewModel model)
        {
            if (model == null)
            {
                return Json(new { isSuccess = false, message = "Model null geldi!" });
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Json(new { isSuccess = false, message = "Geçersiz veri! Hatalar: " + string.Join(", ", errors) });
            }

            var user = await userManager.GetUserAsync(User);
            model.CreateUser = user.Id;
            model.CreateTime = DateTime.Now;
            model.UserId = user.Id;

            var res = await lineService.AddProjectLineNote(model);

            if (res.IsSuccess)
            {
                return Json(new { isSuccess = true, message = "Not başarıyla eklendi!" });
            }

            return Json(new { isSuccess = false, message = res.Message ?? "Not eklenirken bir hata oluştu!" });
        }

        [HttpPost]
        [Authorize(Policy = "ProjectManagement.Update")]
        public async Task<IActionResult> UpdateProjectLineNote([FromBody] UpdateProjectLineNoteViewModel model)
        {
            if (model == null)
            {
                return Json(new { isSuccess = false, message = "Model null geldi!" });
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Json(new { isSuccess = false, message = "Geçersiz veri! Hatalar: " + string.Join(", ", errors) });
            }

            var user = await userManager.GetUserAsync(User);
            model.UpdateUser = user.Id;
            model.UpdateTime = DateTime.Now;

            var res = await lineService.UpdateProjectLineNote(model);

            if (res.IsSuccess)
            {
                return Json(new { isSuccess = true, message = "Not başarıyla güncellendi!" });
            }

            return Json(new { isSuccess = false, message = res.Message ?? "Not güncellenirken bir hata oluştu!" });
        }

        [HttpPost]
        [Authorize(Policy = "ProjectManagement.Delete")]
        public async Task<IActionResult> DeleteProjectLineNote(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Json(new { isSuccess = false, message = "ID bilgisi gerekli!" });
            }

            var res = await lineService.DeleteProjectLineNoteAsync(id);

            if (res.IsSuccess)
            {
                return Json(new { isSuccess = true, message = "Not başarıyla silindi!" });
            }

            return Json(new { isSuccess = false, message = res.Message ?? "Not silinirken bir hata oluştu!" });
        }

        [HttpGet]
        public async Task<IActionResult> GetProjectLineNotes(string projectLineId)
        {
            var res = await lineService.GetProjectLineNotesAsync(projectLineId);
            if (res.IsSuccess)
            {
                return Json(new { isSuccess = true, data = res.Data });
            }
            return Json(new { isSuccess = false, message = res.Message ?? "Notlar alınamadı!" });
        }

        #endregion

        #region ProjectLineWork CRUD

        [HttpPost]
        [Authorize(Policy = "ProjectManagement.Create")]
        public async Task<IActionResult> AddProjectLineWork([FromBody] AddProjectLineWorkViewModel model)
        {
            if (model == null)
            {
                return Json(new { isSuccess = false, message = "Model null geldi!" });
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Json(new { isSuccess = false, message = "Geçersiz veri! Hatalar: " + string.Join(", ", errors) });
            }

            // LineId kontrolü
            if (string.IsNullOrEmpty(model.LineId))
            {
                return Json(new { isSuccess = false, message = "Faz ID bilgisi gerekli!" });
            }

            var user = await userManager.GetUserAsync(User);
            model.CreateUserId = user.Id;

            // Faz durumunu kontrol et - tamamlanmış fazlara iş eklenemez
            var lineResult = await lineService.GetProjectLineDetailAsync(model.LineId);
            if (!lineResult.IsSuccess || lineResult.Data == null)
            {
                return Json(new { isSuccess = false, message = $"Faz bilgileri alınamadı! LineId: {model.LineId}, Hata: {lineResult.Message}" });
            }

            if (lineResult.Data.StateStatus == ProjectLineStatusEnum.Completed)
            {
                return Json(new {
                    isSuccess = false,
                    message = "Tamamlanmış bir faza iş eklenemez! Önce fazı yeniden açmanız gerekiyor.",
                    requireReopen = true,
                    lineId = model.LineId
                });
            }

            // Personel ataması varsa WorkPersons listesine ekle
            if (!string.IsNullOrEmpty(model.AssignedTo))
            {
                model.WorkPersons = new List<AddProjectPersonViewModel>
                {
                    new AddProjectPersonViewModel { UserId = model.AssignedTo }
                };
            }

            // Destek kaydı bilgisi varsa service'e aktar (service içinde oluşturulacak)
            if (model.CreateSupportTicket && !string.IsNullOrEmpty(model.AssignedTo))
            {
                // Proje bilgilerini al
                var projectResult = await service.GetProjectByIdAsync(lineResult.Data.ProjectId);
                if (!projectResult.IsSuccess || projectResult.Data == null)
                {
                    return Json(new { isSuccess = false, message = "Proje bilgileri alınamadı!" });
                }

                // CRM OID'den Portal User ID'yi al
                var initialAssignedToCrmOid = model.AssignedTo;
                var assignedToUserResult = await userService.GetUserInfoByOid(initialAssignedToCrmOid);
                if (!assignedToUserResult.IsSuccess || assignedToUserResult.Data == null)
                {
                    return Json(new { isSuccess = false, message = "Atanan kişinin Portal bilgisi bulunamadı!" });
                }

                // WorkPersons için Portal User ID kullan
                model.AssignedTo = assignedToUserResult.Data.Id;
                model.WorkPersons = new List<AddProjectPersonViewModel>
                {
                    new AddProjectPersonViewModel { UserId = assignedToUserResult.Data.Id }
                };

                // Destek kaydı için CRM OID kullan
                Guid assignedToCrmOid;
                try
                {
                    assignedToCrmOid = Guid.Parse(initialAssignedToCrmOid);
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = $"Geçersiz CRM OID formatı: {initialAssignedToCrmOid}" });
                }

                model.ReleatedSupport = new CrmCreateSupportViewModel
                {
                    //Firm = Guid.Parse(projectResult.Data.Firm.Oid),
                    //Contact = Guid.Parse(projectResult.Data.FirmPerson?.Oid ?? ""),
                    Firm = Guid.Parse(projectResult.Data.Firm.Oid),
                    Contact = Guid.Parse(model.LineFirmOfficialId),
                    Department = string.IsNullOrEmpty(model.DepartmentOid) ? Guid.Empty : Guid.Parse(model.DepartmentOid),
                    AssignedTo = assignedToCrmOid, // CRM OID
                    CallTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm"),
                    Priority = model.Priority,
                    Description = model.Description,
                    CreateUserOid = user.Oid,
                    ProjectCode = projectResult.Data.ProjectCode
                };
            }

            // Service'de hem iş hem destek kaydı oluşturuluyor
            var res = await workService.AddAsync(model);

            if (res.IsSuccess)
            {
                return Json(new { isSuccess = true, message = "İş başarıyla eklendi!" });
            }

            return Json(new { isSuccess = false, message = res.Message ?? "İş eklenirken bir hata oluştu!" });
        }

        [HttpPost]
        [Authorize(Policy = "ProjectManagement.Update")]
        public async Task<IActionResult> UpdateProjectLineWork([FromBody] UpdateProjectLineWorkViewModel model)
        {
            if (model == null)
            {
                return Json(new { isSuccess = false, message = "Model null geldi!" });
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Json(new { isSuccess = false, message = "Geçersiz veri! Hatalar: " + string.Join(", ", errors) });
            }

            var user = await userManager.GetUserAsync(User);
            model.LastUpdateUserId = user.Id;

            var res = await workService.UpdateAsync(model);

            if (res.IsSuccess)
            {
                return Json(new { isSuccess = true, message = "İş başarıyla güncellendi!" });
            }

            return Json(new { isSuccess = false, message = res.Message ?? "İş güncellenirken bir hata oluştu!" });
        }

        [HttpGet]
        [Authorize(Policy = "ProjectManagement.View")]
        public async Task<IActionResult> GetProjectLineWorkList(string projectLineId)
        {
            var res = await workService.GetProjectLineWorkListAsync(projectLineId);
            if (res.IsSuccess)
            {
                return Json(new { isSuccess = true, data = res.Data });
            }
            return Json(new { isSuccess = false, message = res.Message ?? "İşler alınırken bir hata oluştu!" });
        }

        [HttpGet]
        [Authorize(Policy = "ProjectManagement.View")]
        public async Task<IActionResult> GetProjectLineWorkDetail(string id)
        {
            var res = await workService.GetProjectLineWorkDetailAsync(id);
            if (res.IsSuccess)
            {
                return Json(new { isSuccess = true, data = res.Data });
            }
            return Json(new { isSuccess = false, message = res.Message ?? "İş detayı alınırken bir hata oluştu!" });
        }

        

        [HttpPost]
        [Authorize(Policy = "ProjectManagement.Delete")]
        public async Task<IActionResult> DeleteProjectLineWork(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Json(new { isSuccess = false, message = "ID bilgisi gerekli!" });
            }

            var res = await workService.DeleteAsync(id);

            if (res.IsSuccess)
            {
                return Json(new { isSuccess = true, message = "İş başarıyla silindi!" });
            }

            return Json(new { isSuccess = false, message = res.Message ?? "İş silinirken bir hata oluştu!" });
        }

        [HttpGet]
        public async Task<IActionResult> GetProjectLineWork(string id)
        {
            var res = await workService.GetProjectLineWorkDetailAsync(id);
            if (res.IsSuccess)
            {
                return Json(new { isSuccess = true, data = res.Data });
            }
            return Json(new { isSuccess = false, message = res.Message ?? "İş bilgileri alınamadı!" });
        }

        [HttpPost]
        [Authorize(Policy = "ProjectManagement.Create")]
        public async Task<JsonResult> ChangeProjectLineWorkStatus([FromBody] ProjectLineWorkChangeStateViewModel model)
        {
            if (model == null)
            {
                return Json(new { isSuccess = false, message = "Model null geldi!" });
            }

            var user = await userManager.GetUserAsync(User);
            model.UpdateUserId = user.Id;

            var res = await workService.ChangeWorkStateAsync(model);

            if (res.IsSuccess)
            {
                return Json(Core.Dtos.Response.Success(200,""));
            }
            return Json(res);
            
        }

        #endregion

        #region ProjectFile CRUD

        [HttpPost]
        [Authorize(Policy = "ProjectManagement.Create")]
        public async Task<IActionResult> AddProjectFile(AddProjectFilesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { isSuccess = false, message = "Geçersiz veri!" });
            }

            if (model.File == null || model.File.Length == 0)
            {
                return Json(new { isSuccess = false, message = "Lütfen bir dosya seçin!" });
            }

            var projectRes = await service.GetProjectByIdAsync(model.ProjectId);
            if (!projectRes.IsSuccess || projectRes.Data == null)
            {
                return Json(new { isSuccess = false, message = "Proje bulunamadı!" });
            }

            string projectCode = projectRes.Data.ProjectCode;
            if (string.IsNullOrEmpty(model.Name))
            {
                model.Name = model.File.FileName;
            }

            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Project", projectCode);
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.File.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await model.File.CopyToAsync(fileStream);
            }

            model.UrlSlug = $"/Project/{projectCode}/{uniqueFileName}";

            var user = await userManager.GetUserAsync(User);
            model.CreateUser = user.Id;
            model.CreateTime = DateTime.Now;

            var res = await service.AddFileToProject(model);

            if (res.IsSuccess)
            {
                return Json(new { isSuccess = true, message = "Dosya başarıyla yüklendi!" });
            }

            // Clean up file if db save fails
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            return Json(new { isSuccess = false, message = res.Message ?? "Dosya yüklenirken bir hata oluştu!" });
        }

        [HttpPost]
        [Authorize(Policy = "ProjectManagement.Delete")]
        public async Task<IActionResult> DeleteProjectFile(string fileId)
        {
            if (string.IsNullOrEmpty(fileId))
            {
                return Json(new { isSuccess = false, message = "Dosya ID bilgisi gerekli!" });
            }

            var fileInfo = await service.GetProjectFile(fileId);
            if (fileInfo.IsSuccess && fileInfo.Data != null && !string.IsNullOrEmpty(fileInfo.Data.UrlSlug))
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileInfo.Data.UrlSlug.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            var res = await service.DeleteFileToProject(fileId);

            if (res.IsSuccess)
            {
                return Json(new { isSuccess = true, message = "Dosya başarıyla silindi!" });
            }

            return Json(new { isSuccess = false, message = res.Message ?? "Dosya silinirken bir hata oluştu!" });
        }

        [HttpGet]
        public async Task<IActionResult> DownloadProjectFile(string fileId)
        {
            var file = await service.GetProjectFile(fileId);
            if (!file.IsSuccess || file.Data == null)
            {
                return NotFound("Dosya bulunamadı!");
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.Data.UrlSlug.TrimStart('/'));
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Dosya sunucuda bulunamadı!");
            }

            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
            var fileName = file.Data.Name;
            return File(fileBytes, "application/octet-stream", fileName);
        }

        #endregion

        #region Bulk Operations

        [HttpPost]
        [Authorize(Policy = "ProjectManagement.Update")]
        public async Task<IActionResult> BulkChangeProjectLineStatus(List<string> lineIds, int status)
        {
            if (lineIds == null || !lineIds.Any())
            {
                return Json(new { isSuccess = false, message = "Seçili faz bulunamadı!" });
            }

            if (status < 1 || status > 6)
            {
                return Json(new { isSuccess = false, message = "Geçersiz durum değeri!" });
            }

            var statusEnum = (ProjectLineStatusEnum)status;
            var successCount = 0;
            var errorCount = 0;
            var errors = new List<string>();

            foreach (var lineId in lineIds)
            {
                var model = new ProjectLineChangeStateStatusViewModel
                {
                    Id = lineId,
                    Status = statusEnum
                };

                var res = await lineService.ChangeStateStatusAsync(model);
                if (res.IsSuccess)
                {
                    successCount++;
                }
                else
                {
                    errorCount++;
                    errors.Add($"Line {lineId}: {res.Message}");
                }
            }

            if (successCount == lineIds.Count)
            {
                return Json(new { isSuccess = true, message = $"{successCount} faz durumu başarıyla değiştirildi!" });
            }
            else if (successCount > 0)
            {
                return Json(new { isSuccess = true, message = $"{successCount} faz güncellendi, {errorCount} faz hatalı." });
            }
            else
            {
                return Json(new { isSuccess = false, message = "Durum değiştirilemedi: " + string.Join("; ", errors) });
            }
        }

        #endregion

        #region Phase 3: Timeline, Calendar, Reports & Export

        // ===== Timeline View =====
        [HttpGet]
        [Authorize(Policy = "ProjectManagement.View")]
        public async Task<IActionResult> Timeline(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["ErrorMessage"] = "Proje ID gerekli";
                return RedirectToAction("Index", "Project");
            }

            var projectResult = await service.GetProjectByIdAsync(id);
            if (!projectResult.IsSuccess || projectResult.Data == null)
            {
                TempData["Error"] = projectResult;
                return View("Error");
            }

            var project = projectResult.Data;

            // Build timeline data
            var timelineData = new TimelineViewModel
            {
                ProjectId = project.Id,
                ProjectCode = project.ProjectCode,
                ProjectName = project.ProjectName,
                ProjectStartDate = project.StartDate,
                ProjectDueDate = project.DueDate
            };

            if (project.ProjectLines != null)
            {
                foreach (var line in project.ProjectLines.OrderBy(l => l.RowOrder))
                {
                    // Parse string dates to DateTime for timeline
                    DateTime? startDate = null;
                    DateTime? dueDate = null;
                    if (!string.IsNullOrEmpty(line.StartDate) && DateTime.TryParse(line.StartDate, out var parsedStart))
                    {
                        startDate = parsedStart;
                    }
                    if (!string.IsNullOrEmpty(line.DueDate) && DateTime.TryParse(line.DueDate, out var parsedDue))
                    {
                        dueDate = parsedDue;
                    }

                    // LineWorks is not available in ProjectLineListViewModel, setting progress to 0
                    timelineData.Tasks.Add(new TimelineItemViewModel
                    {
                        Id = line.Id,
                        ProjectId = project.Id,
                        Title = line.Title ?? "İsimsiz Faz",
                        StartDate = startDate,
                        DueDate = dueDate,
                        RowOrder = line.RowOrder,
                        Status = line.StateStatus,
                        StatusDisplay = GetLineStatusDisplay(line.StateStatus),
                        Priority = line.Priority,
                        AssignedTo = line.LineOfficial,
                        Progress = 0 // Work items not available in list view
                    });
                }
            }

            return View(timelineData);
        }

        // ===== Calendar View =====
        [HttpGet]
        [Authorize(Policy = "ProjectManagement.View")]
        public async Task<IActionResult> Calendar()
        {
            var projectsResult = await service.GetProjectListAsync();
            if (!projectsResult.IsSuccess)
            {
                TempData["Error"] = projectsResult;
                return View("Error");
            }

            var events = new List<CalendarEventViewModel>();

            foreach (var project in projectsResult.Data)
            {
                if (DateTime.TryParse(project.StartDate, out var startDate))
                {
                    events.Add(new CalendarEventViewModel
                    {
                        Id = project.Id,
                        Title = $"{project.ProjectCode} - {project.ProjectName}",
                        Start = startDate,
                        End = DateTime.TryParse(project.DueDate, out var endDate) ? endDate : startDate.AddDays(7),
                        Url = $"/Project/Detail/{project.Id}",
                        Color = GetStatusColor(project.ProjectStatus),
                        Type = "Project",
                        Status = project.ProjectStatus.ToString()
                    });
                }
            }

            return View(events);
        }

        // ===== Reports =====
        [HttpGet]
        [Authorize(Policy = "ProjectManagement.View")]
        public async Task<IActionResult> Report(string id, string reportType)
        {
            if (string.IsNullOrEmpty(reportType))
            {
                reportType = "completion";
            }

            switch (reportType.ToLower())
            {
                case "completion":
                    return await CompletionReport(id);

                case "workload":
                    return await WorkloadReport();

                case "firm":
                    return await FirmReport(id);

                default:
                    TempData["ErrorMessage"] = "Geçersiz rapor türü";
                    return RedirectToAction("Index", "Project");
            }
        }

        private async Task<IActionResult> CompletionReport(string projectId)
        {
            if (string.IsNullOrEmpty(projectId))
            {
                TempData["ErrorMessage"] = "Proje ID gerekli";
                return RedirectToAction("Index", "Project");
            }

            var projectResult = await service.GetProjectByIdAsync(projectId);
            if (!projectResult.IsSuccess || projectResult.Data == null)
            {
                TempData["Error"] = projectResult;
                return View("Error");
            }

            var project = projectResult.Data;

            var reportData = new ProjectCompletionReportViewModel
            {
                ProjectId = project.Id,
                ProjectCode = project.ProjectCode,
                ProjectName = project.ProjectName,
                Firm = project.Firm?.Title ?? "",
                ProjectManager = project.ProjectManager?.Fullname ?? "",
                ProjectStatus = project.ProjectStatus,
                StatusDisplay = GetProjectStatusDisplay(project.ProjectStatus),
                StartDate = project.StartDate,
                DueDate = project.DueDate,
                ServiceHour = project.ServiceHour,
                EstimatedHour = project.EstimatedHour
            };

            if (project.ProjectLines != null)
            {
                reportData.TotalLines = project.ProjectLines.Count;
                reportData.CompletedLines = project.ProjectLines.Count(l => l.StateStatus == ProjectLineStatusEnum.Completed);
                reportData.InProgressLines = project.ProjectLines.Count(l => l.StateStatus == ProjectLineStatusEnum.InProgress);
                reportData.NotStartedLines = project.ProjectLines.Count(l => l.StateStatus == ProjectLineStatusEnum.NotStarted);
                reportData.CompletionPercentage = reportData.TotalLines > 0
                    ? (decimal)reportData.CompletedLines / reportData.TotalLines * 100
                    : 0;

                // LineWorks is not available in ProjectLineListViewModel - setting to 0
                reportData.TotalWorks = 0;
                reportData.CompletedWorks = 0;
                reportData.InProgressWorks = 0;
            }

            return View("Report", reportData);
        }

        private async Task<IActionResult> WorkloadReport()
        {
            // Get all users with project assignments
            var projectsResult = await service.GetProjectListAsync();
            if (!projectsResult.IsSuccess)
            {
                TempData["Error"] = projectsResult;
                return View("Error");
            }

            // ProjectManagerId is not available in ProjectListViewModel - returning empty list for now
            var workloadData = new List<TeamWorkloadReportViewModel>();

            return View("Report", workloadData);
        }

        private async Task<IActionResult> FirmReport(string firmId)
        {
            // Implementation for firm summary report
            TempData["InfoMessage"] = "Firma raporu yakında aktif olacak";
            return RedirectToAction("Index", "Project");
        }

        // ===== Export Actions =====
        [HttpGet]
        [Authorize(Policy = "ProjectManagement.View")]
        public async Task<IActionResult> ExportToPdf(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Proje ID gerekli");
            }

            var pdfResult = await exportService.ExportProjectToPdfAsync(id);
            if (!pdfResult.IsSuccess)
            {
                TempData["Error"] = pdfResult;
                return RedirectToAction("Detail", "Project", new { id });
            }

            return File(pdfResult.Data, "application/pdf", $"Project_{id}.pdf");
        }

        [HttpGet]
        [Authorize(Policy = "ProjectManagement.View")]
        public async Task<IActionResult> ExportToExcel(string reportType, string? id = null)
        {
            var filters = new ProjectListFiltersViewModel();
            var excelResult = await exportService.ExportProjectsToExcelAsync(filters);
            if (!excelResult.IsSuccess)
            {
                TempData["Error"] = excelResult;
                return RedirectToAction("Index", "Project");
            }

            return File(excelResult.Data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Projects.xlsx");
        }

        // ===== Notification Actions =====
        [HttpGet]
        public async Task<IActionResult> GetNotifications(bool unreadOnly = false)
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return Json(new { isSuccess = false, message = "Kullanıcı bulunamadı" });
            }

            var notificationsResult = await notificationService.GetUserNotificationsAsync(user.Id, unreadOnly);
            if (notificationsResult.IsSuccess)
            {
                return Json(new { isSuccess = true, data = notificationsResult.Data });
            }

            return Json(new { isSuccess = false, message = notificationsResult.Message });
        }

        [HttpGet]
        public async Task<IActionResult> GetUnreadNotificationCount()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return Json(new { isSuccess = false, count = 0 });
            }

            var notificationsResult = await notificationService.GetUserNotificationsAsync(user.Id, true);
            var count = notificationsResult.IsSuccess ? notificationsResult.Data?.Count ?? 0 : 0;

            return Json(new { isSuccess = true, count });
        }

        [HttpPost]
        public async Task<IActionResult> MarkNotificationAsRead(string notificationId)
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return Json(new { isSuccess = false, message = "Kullanıcı bulunamadı" });
            }

            var result = await notificationService.MarkNotificationAsReadAsync(notificationId, user.Id);
            return Json(new { isSuccess = result.IsSuccess, message = result.Message });
        }

        [HttpPost]
        public async Task<IActionResult> MarkAllNotificationsAsRead()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return Json(new { isSuccess = false, message = "Kullanıcı bulunamadı" });
            }

            var result = await notificationService.MarkAllNotificationsAsReadAsync(user.Id);
            return Json(new { isSuccess = result.IsSuccess, message = result.Message });
        }

        // ===== API Actions for Timeline Data =====
        [HttpGet]
        [Authorize(Policy = "ProjectManagement.View")]
        public async Task<IActionResult> GetTimelineData(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Json(new { isSuccess = false, message = "Proje ID gerekli" });
            }

            var projectResult = await service.GetProjectByIdAsync(id);
            if (!projectResult.IsSuccess || projectResult.Data == null)
            {
                return Json(new { isSuccess = false, message = "Proje bulunamadı" });
            }

            var project = projectResult.Data;

            var tasks = new List<object>();
            if (project.ProjectLines != null)
            {
                foreach (var line in project.ProjectLines.OrderBy(l => l.RowOrder))
                {
                    // Parse dates from string format
                    DateTime? startDateParsed = null;
                    DateTime? dueDateParsed = null;
                    DateTime.TryParse(line.StartDate, out var startDt);
                    DateTime.TryParse(line.DueDate, out var dueDt);
                    if (startDt != default) startDateParsed = startDt;
                    if (dueDt != default) dueDateParsed = dueDt;

                    tasks.Add(new
                    {
                        id = line.Id,
                        name = line.Title ?? "İsimsiz Faz",
                        start = startDateParsed?.ToString("yyyy-MM-dd"),
                        end = dueDateParsed?.ToString("yyyy-MM-dd"),
                        progress = line.StateStatus == ProjectLineStatusEnum.Completed ? 100 :
                                   line.StateStatus == ProjectLineStatusEnum.InProgress ? 50 : 0,
                        status = GetLineStatusDisplay(line.StateStatus),
                        priority = line.Priority.ToString(),
                        assignedTo = line.LineOfficial
                    });
                }
            }

            return Json(new
            {
                isSuccess = true,
                data = new
                {
                    project = new
                    {
                        id = project.Id,
                        name = project.ProjectName,
                        code = project.ProjectCode,
                        start = project.StartDate?.ToString("yyyy-MM-dd"),
                        end = project.DueDate?.ToString("yyyy-MM-dd")
                    },
                    tasks = tasks
                }
            });
        }

        // ===== API Actions for Calendar Data =====
        [HttpGet]
        [Authorize(Policy = "ProjectManagement.View")]
        public async Task<IActionResult> GetCalendarData()
        {
            var projectsResult = await service.GetProjectListAsync();
            if (!projectsResult.IsSuccess)
            {
                return Json(new { isSuccess = false, message = "Projeler alınamadı" });
            }

            var events = new List<object>();
            foreach (var project in projectsResult.Data)
            {
                if (DateTime.TryParse(project.StartDate, out var startDate))
                {
                    var endDate = DateTime.TryParse(project.DueDate, out var parsedEnd) ? parsedEnd : startDate.AddDays(7);

                    events.Add(new
                    {
                        id = project.Id,
                        title = $"{project.ProjectCode} - {project.ProjectName}",
                        start = startDate.ToString("yyyy-MM-dd"),
                        end = endDate.ToString("yyyy-MM-dd"),
                        url = $"/Project/Detail/{project.Id}",
                        backgroundColor = GetStatusColor(project.ProjectStatus),
                        borderColor = GetStatusColor(project.ProjectStatus),
                        type = "Project",
                        status = project.ProjectStatus.ToString()
                    });
                }
            }

            return Json(new { isSuccess = true, data = events });
        }

        #endregion

        #region Helper Methods

        private string GetProjectStatusDisplay(ProjectStatusEnum status)
        {
            return status switch
            {
                ProjectStatusEnum.Created => "Oluşturuldu",
                ProjectStatusEnum.Started => "Başladı",
                ProjectStatusEnum.Testing => "Test Ediliyor",
                ProjectStatusEnum.Finished => "Tamamlandı",
                ProjectStatusEnum.Canceled => "İptal Edildi",
                ProjectStatusEnum.Failed => "Başarısız",
                _ => status.ToString()
            };
        }

        private string GetLineStatusDisplay(ProjectLineStatusEnum status)
        {
            return status switch
            {
                ProjectLineStatusEnum.NotStarted => "Başlamadı",
                ProjectLineStatusEnum.InProgress => "Devam Ediyor",
                ProjectLineStatusEnum.Completed => "Tamamlandı",
                ProjectLineStatusEnum.WaitingForSomeoneElse => "Başkasını Bekliyor",
                ProjectLineStatusEnum.Deferred => "Ertelendi",
                ProjectLineStatusEnum.Cancellled => "İptal Edildi",
                _ => status.ToString()
            };
        }

        private string GetStatusColor(ProjectStatusEnum status)
        {
            return status switch
            {
                ProjectStatusEnum.Created => "#6c757d",
                ProjectStatusEnum.Started => "#0d6efd",
                ProjectStatusEnum.Testing => "#ffc107",
                ProjectStatusEnum.Finished => "#198754",
                ProjectStatusEnum.Canceled => "#dc3545",
                ProjectStatusEnum.Failed => "#212529",
                _ => "#6c757d"
            };
        }

        #endregion
    }
}
