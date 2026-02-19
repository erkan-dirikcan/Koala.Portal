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
        public async Task<IActionResult> AddProjectLine(AddProjectLineViewModel projectId)
        {

            return View();
        }
    }
}
