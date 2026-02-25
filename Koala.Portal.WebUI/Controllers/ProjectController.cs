using Azure;
using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.WebUI.Controllers

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
        ITransactionService transactionService)
        : Controller
    {
       
        [HttpGet]
        [Authorize(Policy = "Project.View")]
        public async Task<IActionResult> Index()
        {
            var res = await service.GetProjectListAsync();
            if (!res.IsSuccess)
            {
                TempData["Error"] = res;
                return View("Error");
            }
            return View(res.Data);
        }


        [HttpGet]
        [Authorize(Policy = "Project.Create")]
        public async Task<IActionResult> CreateProject(string firmId = "")
        {
            var firms = await selectListService.GetFirmSelectList();
            TempData["Firms"] = firms.Data;
            var users = await selectListService.GetUserSelectList( "");
            TempData["Users"] = users.Data;
            return View();
        }
        [HttpPost]
        [Authorize(Policy = "Project.Create")]
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
        [Authorize(Policy = "Project.Create")]
        public async Task<IActionResult> AddProjectLine(string projectId)
        {

            return View();
        }
        [HttpPost]
        [Authorize(Policy = "Project.Create")]
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
        [Authorize(Policy = "Project.Create")]
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
        [Authorize(Policy = "Project.View")]
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
        [Authorize(Policy = "Project.Create")]
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
        [Authorize(Policy = "Project.Create")]
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
        [Authorize(Policy = "Project.Edit")]
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
            TempData["Firms"] = firms.Data;
            var users = await selectListService.GetUserSelectList("");
            TempData["Users"] = users.Data;

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
        [Authorize(Policy = "Project.Edit")]
        public async Task<IActionResult> UpdateProject(UpdateProjectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var firms = await selectListService.GetFirmSelectList();
                TempData["Firms"] = firms.Data;
                var users = await selectListService.GetUserSelectList("");
                TempData["Users"] = users.Data;
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
                TempData["Firms"] = firms.Data;
                var users = await selectListService.GetUserSelectList("");
                TempData["Users"] = users.Data;
                return View(model);
            }

            TempData["InfoMessage"] = $"{model.ProjectName} isimli proje başarıyla güncellendi";
            return RedirectToAction("Detail", "Project", new { id = model.Id });
        }

        [HttpPost]
        [Authorize(Policy = "Project.Delete")]
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
        [Authorize(Policy = "Project.Create")]
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
        [Authorize(Policy = "Project.Edit")]
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
        [Authorize(Policy = "Project.Delete")]
        public async Task<IActionResult> DeleteProjectLineNote(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return Json(new { isSuccess = false, message = "ID bilgisi gerekli!" });
            }

            var res = await lineService.DeleteProjectLineNote(id);

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
        [Authorize(Policy = "Project.Create")]
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
        [Authorize(Policy = "Project.Edit")]
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
        [Authorize(Policy = "Project.Delete")]
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
        [Authorize(Policy = "Project.Create")]
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
        [Authorize(Policy = "Project.Create")]
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
        [Authorize(Policy = "Project.Delete")]
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
    }
}
