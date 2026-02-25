using Azure;
using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.PortalViewModels;
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
        INotificationService notificationService)
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
            var firms = await selectListService.GetFirmSelectList();
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
            var firms = await selectListService.GetFirmSelectList();
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
                var firms = await selectListService.GetFirmSelectList();
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
        [Authorize(Policy = "ProjectManagement.Create")]
        public async Task<IActionResult> UpdateProjectLine([FromBody] UpdateProjectLineViewModel model)
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

            var firms = await selectListService.GetFirmSelectList();
            ViewData["Firms"] = firms.Data;
            var users = await selectListService.GetUserSelectList("");
            ViewData["Users"] = users.Data;

            var updateModel = new UpdateProjectViewModel
            {
                Id = project.Data.Id,
                ProjectName = project.Data.ProjectName,
                Description = project.Data.Description,
                ProjectManagerId = project.Data.ProjectManagerId,
                FirmId = project.Data.FirmId,
                FirmPersonId = project.Data.FirmPersonId,
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
                var firms = await selectListService.GetFirmSelectList();
                ViewData["Firms"] = firms.Data;
                var users = await selectListService.GetUserSelectList("");
                ViewData["Users"] = users.Data;
                return View(model);
            }

            var user = await userManager.GetUserAsync(User);
            model.UpdateUser = user.Id;
            model.UpdateTime = DateTime.Now;

            var res = await service.UpdateAsync(model, model.Id);
            if (!res.IsSuccess)
            {
                TempData["Error"] = res;
                var firms = await selectListService.GetFirmSelectList();
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

            // DeleteProjectLineNote method is not implemented in IProjectLineService
            return Json(new { isSuccess = false, message = "Not silme özelliği yakında aktif olacak!" });
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

            var user = await userManager.GetUserAsync(User);
            model.CreateUserId = user.Id;

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

        [HttpPost]
        [Authorize(Policy = "ProjectManagement.Delete")]
        public async Task<IActionResult> DeleteProjectLineWork(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Json(new { isSuccess = false, message = "ID bilgisi gerekli!" });
            }

            // DeleteAsync method is not implemented in IProjectLineWorkService
            return Json(new { isSuccess = false, message = "İş silme özelliği yakında aktif olacak!" });
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
        public async Task<IActionResult> ChangeProjectLineWorkStatus([FromBody] ProjectLineWorkChangeStateViewModel model)
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
                return Json(new { isSuccess = true, message = "İş durumu başarıyla değiştirildi!" });
            }

            return Json(new { isSuccess = false, message = res.Message ?? "İş durumu değiştirilirken bir hata oluştu!" });
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

            var user = await userManager.GetUserAsync(User);
            model.CreateUser = user.Id;
            model.CreateTime = DateTime.Now;

            var res = await service.AddFileToProject(model);

            if (res.IsSuccess)
            {
                return Json(new { isSuccess = true, message = "Dosya başarıyla yüklendi!" });
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
