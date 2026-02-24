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
    }
}
