using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.CrmViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Koala.Portal.WebUI.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly ICrmSqlService _crmSqlService;
        private readonly ICrmSupportService _crmSupportService;
        private readonly IFirmService _firmService;
        private readonly ICrmFirmService _crmFirmService;
        private readonly ICrmSupportStateService _crmSupportStateService;
        private readonly ICrmDepartmentService _crmSupportDepartmentService;
        private readonly ICrmCategoryService _crmSupportCategoryService;
        private readonly ICrmSelectListService _crmSelectListService;
        private readonly ISupportFileService _supportFileService;

        private readonly UserManager<AppUser> _userManager;
        public DashboardController(ILogger<DashboardController> logger,
                                   UserManager<AppUser> userManager,
                                   ICrmSqlService crmSqlService,
                                   ICrmSupportService crmSuportService,
                                   ICrmSupportStateService crmSupportStateService,
                                   IFirmService firmService,
                                   ICrmDepartmentService crmSupportDepartmentService,
                                   ICrmCategoryService crmSupportCategoryService,
                                   ICrmSelectListService crmSelectListService,
                                   ICrmFirmService crmFirmService,
                                   ISupportFileService supportFileService)
        {
            _logger = logger;
            _crmSqlService = crmSqlService;
            _userManager = userManager;
            _crmSupportService = crmSuportService;
            _crmSupportStateService = crmSupportStateService;
            _firmService = firmService;
            _crmSupportDepartmentService = crmSupportDepartmentService;
            _crmSupportCategoryService = crmSupportCategoryService;
            _crmSelectListService = crmSelectListService;
            _crmFirmService = crmFirmService;
            _supportFileService = supportFileService;
        }

        public async Task<IActionResult> Index()
        {

            var openSupports = await _crmSupportService.Where(x => x.GCRecord == null && x._CreatedDateTime > new DateTime(2021, 01, 01) && x.IsCompleted != true);
            var supportUsers = _crmSqlService.GetCrmUserFullNameInfoList();
            var currentUser = User;
            var user = await _userManager.GetUserAsync(currentUser);
            //var kpis= _crmSqlService.GetCrmDashboardKpi(user!.Oid!);
            var closedChartData = await _crmSqlService.GetCrmDailyClosedSupportCount();
            var openChartData = await _crmSqlService.GetCrmApointedSupportCount();
            var userDepartments = _crmSqlService.GetCrmUserDepartments(user.Oid!);
            var kpis = new CrmDashboardKpiDbViewModel
            {
                WaitingMySupportCount           = openSupports.Data.Count(item => !string.IsNullOrEmpty(item.ActiveWorkingUserOid) && (item.ActiveWorkingUserOid.Equals(user.Oid, StringComparison.OrdinalIgnoreCase)) ||
                                                  (string.IsNullOrEmpty(item.ActiveWorkingUserOid) && item.AssignedToOid.Equals(user.Oid, StringComparison.OrdinalIgnoreCase))),
                WaitingdDepartmentSupportCount  = openSupports.Data.Count(item => userDepartments.Data.Any(x => x.Oid.Equals(item.AssignedDepartmentOid, StringComparison.OrdinalIgnoreCase) &&
                                                  !string.IsNullOrEmpty(item.ActiveWorkingUserOid) && !item.ActiveWorkingUserOid.Equals(user.Oid, StringComparison.OrdinalIgnoreCase) &&
                                                  (!item.AssignedToOid.Equals("F2028B99-C49E-4F4B-B1E7-69FF7ACF869A", StringComparison.OrdinalIgnoreCase) ||
                                                  !item.AssignedToOid.Equals("A0EFF398-D31A-4767-A1DE-445312C9E086", StringComparison.OrdinalIgnoreCase) ||
                                                  !item.AssignedToOid.Equals(user.Oid, StringComparison.OrdinalIgnoreCase)))),
                WaitAnswerSupportCount          = openSupports.Data.Count(item => item.AssignedToOid.Equals("F2028B99-C49E-4F4B-B1E7-69FF7ACF869A",
                                                  StringComparison.OrdinalIgnoreCase) && string.IsNullOrEmpty(item.ActiveWorkingUserOid) &&
                                                  userDepartments.Data.Any(x => x.Oid.Equals(item.AssignedDepartmentOid,
                                                  StringComparison.OrdinalIgnoreCase))),
                WaitOnLogoSupportCount          = openSupports.Data.Count(item => item.TicketStateOid == "439e8fb4-b576-4650-83de-656ee3cfd3e7"),
                WaitWebUserSupportCount         = openSupports.Data.Count(item => item.AssignedToOid.Equals("A0EFF398-D31A-4767-A1DE-445312C9E086", 
                                                  StringComparison.OrdinalIgnoreCase) && string.IsNullOrEmpty(item.ActiveWorkingUserOid) && 
                                                  userDepartments.Data.Any(x => x.Oid.Equals(item.AssignedDepartmentOid, StringComparison.OrdinalIgnoreCase)))
            };
            
            if (!openSupports.IsSuccess)
            {
                _logger.LogError(new Exception(string.Join(", ", openSupports.Errors)), openSupports.Message);
                TempData["Error"] = openSupports;
                return View("Error");
            }

            var retVal = (openSupports.Data.ToList(), supportUsers.Data, userDepartments.Data, closedChartData.Data, kpis, openChartData.Data);
            return View(retVal);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Client, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<JsonResult> GetDashboarChartData()
        {
            var currentUser = User;
            var user = await _userManager.GetUserAsync(currentUser);

            var res = _crmSqlService.GetCrmDashboardKpi(user!.Oid!);
            return Json(!res.IsSuccess
                ? Response<CrmDashboardKpiDbViewModel>.FailData(400, res.Message, res.Errors.Errors, true)
                : Response<CrmDashboardKpiDbViewModel>.SuccessData(200, res.Message, res.Data));
        }



    }
}