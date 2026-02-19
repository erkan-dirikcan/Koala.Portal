using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.CrmViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Koala.Portal.WebUI.Controllers
{
    [Authorize]
    public class SupportController : Controller
    {

        private readonly ILogger<DashboardController> _logger;
        private readonly ICrmSqlService _crmSqlService;
        private readonly ICrmSupportService _crmSuportService;
        private readonly ICrmFirmService _crmFirmService;
        private readonly ICrmSelectListService _crmSelectListService;
        private readonly ISupportFileService _supportFileService;

        private readonly UserManager<AppUser> _userManager;

        public SupportController(ILogger<DashboardController> logger, ICrmSqlService crmSqlService, ICrmSupportService crmSuportService, IFirmService firmService, ICrmFirmService crmFirmService, ICrmSupportStateService crmSupportStateService, ICrmDepartmentService crmSupportDepartmentService, ICrmCategoryService crmSupportCategoryService, ICrmSelectListService crmSelectListService, ISupportFileService supportFileService, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _crmSqlService = crmSqlService;
            _crmSuportService = crmSuportService;
            _crmFirmService = crmFirmService;
            _crmSelectListService = crmSelectListService;
            _supportFileService = supportFileService;
            _userManager = userManager;
        }
        [AllowAnonymous]
        public async Task<FileResult> GetRemoteFile()
        {
            var fInfo = System.IO.File.ReadAllBytes("wwwroot/Download/sistem_bilgisayarCMX.exe");
            return File(fInfo, "application/vnd.microsoft.portable-executable", "sistem_bilgisayarCMX.exe");
        }
        [Authorize]
        public async Task<IActionResult> SupportFilter()
        {
            var users = await _crmSelectListService.GetUserSelectList(false, "");
            TempData["Users"] = users.Data;
            var supportTypeList = await _crmSelectListService.GetSupportStateSelectList(new List<string>());
            TempData["SupportTypes"] = supportTypeList.Data;
            var firms = await _crmSelectListService.GetFirmSelectList();
            TempData["Firms"] = firms.Data;
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SupportFilter(CrmUserSupportFilterModel model)
        {
            var users = await _crmSelectListService.GetUserSelectList(false, model.ActiveWorkingUserOid);
            TempData["Users"] = users.Data;
            var firms = await _crmSelectListService.GetFirmSelectList();
            TempData["Firms"] = firms.Data;
            model.Statuses ??= new List<string>();
            var supportTypeList = await _crmSelectListService.GetSupportStateSelectList(model.Statuses);
            TempData["SupportTypes"] = supportTypeList.Data;
            var res = await _crmSuportService.GetFilteredSupports(model);
            if (!res.IsSuccess)
            {
                TempData["Error"] = res;
                return View("Error");
            }
            return View(res.Data);
        }
        //[Authorize]
        //public async Task<IActionResult> DailyWebUserSupport()
        //{
        //    var users = await _crmSelectListService.GetUserSelectList(false, "");
        //    TempData["Users"] = users.Data;
        //    var supportTypeList = await _crmSelectListService.GetSupportStateSelectList(new List<string>());
        //    TempData["SupportTypes"] = supportTypeList.Data;
        //    var firms = await _crmSelectListService.GetFirmSelectList();
        //    TempData["Firms"] = firms.Data;
        //    var start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 1, 0);
        //    var end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 0);
        //    var model = new CrmUserSupportFilterModel
        //    {
        //        AppointedWorkingUserOid = "A0EFF398-D31A-4767-A1DE-445312C9E086",

        //    };
        //    var res = await _crmSuportService.GetFilteredSupports(model);
        //    if (!res.IsSuccess)
        //    {
        //        TempData["Error"] = res;
        //        return View("Error");
        //    }
        //    return View(res.Data);
        //}
        [HttpGet]
        public async Task<JsonResult> GetCreateSupportModalData()
        {
            var firms = await _crmSelectListService.GetFirmSelectList();
            var deps = await _crmSelectListService.GetSupportDepartmentList();
            var categories = await _crmSelectListService.GetSupportCategoryList();
            var priorities = SelectListHelpers.GetPriorityEnumList(null);
            var types = await _crmSelectListService.GetSupportTypeSelectList();

            var retVal = new Dictionary<string, dynamic>
            {
                {"Firms", firms.Data},
                {"Deps", deps.Data},
                {"Categories", categories.Data},
                {"Priorities", priorities},
                {"Types", types.Data}
            };


            return Json(Response<Dictionary<string, dynamic>>.SuccessData(200, "Destek Kaydı Varsayılan Bilgileri Başarıyla Alındı", retVal));
        }
       
        [HttpGet]
        public async Task<JsonResult> GetCreateSupportModalFirmData(string firmOid)
        {
            var contacts = await _crmSelectListService.GetFirmContactListWithOid(firmOid);
            var supports = _crmFirmService.GetFirmSupportStatusInfo(firmOid);
            var retVal = new Dictionary<string, dynamic>
            {
                {"Contacts", contacts.Data},
                {"Supports", supports.Data}
            };
            return Json(Response<Dictionary<string, dynamic>>.SuccessData(200, "Destek Kaydı Varsayılan Bilgileri Başarıyla Alındı", retVal));
        }
        [HttpGet]
        public async Task<JsonResult> GetCreateSupportFirmContactMailAddeses(string contactOid)
        {
            if (string.IsNullOrEmpty(contactOid))
            {
                return Json(Koala.Portal.Core.Dtos.Response.Fail(400, "Yetkili Kimlik Bilgisi Alınamadı", "Yetkili Kimlik Bilgisi Alınamadı", true));
            }

            var res = await _crmSelectListService.GetFirmContactMailList(contactOid);
            return Json(res);
        }
        [HttpGet]
        public async Task<JsonResult> GetCreateSupportDepartmentUsers(string departmentOid)
        {
            if (string.IsNullOrEmpty(departmentOid))
            {
                return Json(Core.Dtos.Response.Fail(400, "Departman Kimlik Bilgisi Alınamadı", "Departman Kimlik Bilgisi Alınamadı", true));
            }
            var res = await _crmSelectListService.GetDepartmentUserSelectList(departmentOid);
            return Json(res);
        }
        [HttpGet]
        public async Task<JsonResult> GetCreateSupportSubCategoryList(string categoryOid)
        {
            if (string.IsNullOrEmpty(categoryOid))
            {
                return Json(Core.Dtos.Response.Fail(400, "Category Bilgisi Alınamadı", "Category Bilgisi Alınamadı", true));
            }

            var res = await _crmSelectListService.GetSupportSubCategoryList(categoryOid);
            return Json(res);
        }
        [HttpPost]
        public async Task<JsonResult> CreateSupport(CrmCreateSupportViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                return Json(Core.Dtos.Response.Fail(400, "Destek Kayıdı Oluşturulurken Bir Sorunla Karşılaşıldı.", errors, false));
            }
            try
            {
                var currentUser = User;
                var user = await _userManager.GetUserAsync(currentUser);
                model.CreateUserOid = user.Oid;
                var res = await _crmSuportService.AddAsyc(model);
                return Json(res);
            }
            catch (Exception ex)
            {
                return Json(Core.Dtos.Response.Fail(400, "Destek Kayıdı Oluşturulurken Bir Sorunla Karşılaşıldı.", ex.Message, false));
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetSupportDetail(string supportId)
        {
            if (string.IsNullOrEmpty(supportId))
            {
                return Json(Koala.Portal.Core.Dtos.Response.Fail(400, "Destek Kaydı Id Bilgisi Zorunludur", "Destek Kaydı Bilgileri Alınamadı. Hata : Id Bilgisi Zorunludur.", true));
            }
            var user = await _userManager.GetUserAsync(User);
            var res = _crmSqlService.GetCrmSupportDetailById(supportId);
            if (res.IsSuccess)
            {
                res.Data.LoginedUserOid = user.Oid;
                //var sDate=Convert.ToDateTime(res.Data.TicketStartDate);
                //if (sDate.Year<2021)
                //{
                //    res.Data.TicketStartDate = "Henüz Başlanmamış";
                //}
                if (!string.IsNullOrEmpty(res.Data.TicketId))
                {
                    var file = await _supportFileService.GetBySupportIdAsyc(res.Data.TicketId);
                    if (file.IsSuccess)
                    {
                        res.Data.FileUrl = file.Data.UrlSlug;
                        res.Data.FileType = file.Data.AttachmentType;
                    }
                }
            }
            return Json(res);

        }
        [HttpPost]
        public async Task<JsonResult> TakeOnSupport(CreateCrmSupportTicketHistoryViewModel model)
        {
            try
            {
                var pUser = User;
                var user = await _userManager.GetUserAsync(pUser);
                model.UserOid = user.Oid;

                if (!ModelState.IsValid)
                {
                    var errors = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value.Errors.Select(e => e.ErrorMessage.ToString()).ToList()
                        );
                    var err = new List<string>();
                    foreach (var item in errors.Values)
                    {
                        err.Add(string.Join(", ", item));
                    }
                    var err1 = string.Join(", ", errors.Keys);
                    return Json(Core.Dtos.Response.Fail(400, string.Join(", ", err), "", true));
                }
                var res = await _crmSuportService.TakeOnAsync(model);

                return Json(res);

            }
            catch (Exception ex)
            {
                return Json(Core.Dtos.Response.Fail(400, "Destek kaydını üzerinize alırken bir sorunla karşılaşıldı.", ex.Message, false));
            }
        }
        [HttpGet]
        public async Task<JsonResult> CheckTakeOnSupport(string oid)
        {
            try
            {
                var pUser = User;
                var user = await _userManager.GetUserAsync(pUser);

                var res = await _crmSuportService.CheckTakeOn(oid, user.Oid);
                return Json(res);
                //return Json(res.IsSuccess ?
                //    Core.Dtos.Response.Success(200, "Destek kaydını Başarıyla ÜZerinize Aldınız") :
                //    Core.Dtos.Response.Fail(res.StatusCode, res.Message, res.Errors));
            }
            catch (Exception ex)
            {
                return Json(Core.Dtos.Response.Fail(400, "Destek kaydını üzerinize alırken bir sorunla karşılaşıldı.", ex.Message, false));
            }
        }
        [HttpPost]
        public async Task<JsonResult> SupportSendToUser(CrmSendToUserViewModel model)
        {
            try
            {
                var pUser = User;
                var user = await _userManager.GetUserAsync(pUser);
                //var user=
                var historyModel = new CreateCrmSupportTicketHistoryViewModel
                {
                    Description = model.Description,
                    TicketOid = model.TicketOid,
                    UserOid = model.UserId,
                    UpdateUser = user!.Oid!
                };
                var res = await _crmSuportService.TakeOnAsync(historyModel);
                return Json(res);
                //return Json(res.IsSuccess ?
                //    Core.Dtos.Response.Success(200, "Destek kaydını Başarıyla ÜZerinize Aldınız") :
                //    Core.Dtos.Response.Fail(res.StatusCode, res.Message, res.Errors));
            }
            catch (Exception ex)
            {
                return Json(Core.Dtos.Response.Fail(400, "Destek Kaydı Kullanıcıya Atanırken Bir Sorunla Karşılaşıldı.", ex.Message, false));
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetUpdateSupportInfo(string supportId)
        {
            if (string.IsNullOrEmpty(supportId))
            {
                return Json(Koala.Portal.Core.Dtos.Response.Fail(400, "Destek Kaydı Id Bilgisi Zorunludur", "Destek Kaydı Bilgileri Alınamadı. Hata : Id Bilgisi Zorunludur.", true));
            }
            var user = await _userManager.GetUserAsync(User);

            var res = await _crmSuportService.GetUpdateSupportInfoAsync(supportId);
            var agrDetail = _crmSqlService.GetCrmSupportDetailById(supportId);
            if (!res.IsSuccess)
            {
                return Json(res);
            }

            var ticketStates = await _crmSelectListService.GetSupportStateSelectList(new List<string> { res.Data.TicketState });
            var ticketTypes = await _crmSelectListService.GetSupportTypeSelectList(res.Data.TicketType);
            var retVal = new Dictionary<string, dynamic>
            {
                { "Support", res.Data },
                { "State", ticketStates.Data },
                {"AgrDet",agrDetail.Data},
                {"Type",ticketTypes.Data}
            };
            return Json(Response<Dictionary<string, dynamic>>.SuccessData(200, "Destek Kaydı Bilgileri Başarıyla Alındı", retVal));

        }
        [HttpPost]
        public async Task<JsonResult> UpdateSupport(CrmUpdateSupportViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                return Json(Core.Dtos.Response.Fail(400, "Destek Kaydı Güncellenirken Bir Sorunla Karşılaşıldı", errors, true));
            }

            var res = await _crmSuportService.UpdateSupportAsync(model);
            return Json(res);
        }
        [HttpGet]
        public async Task<JsonResult> GetFirmOpenSupports(string firmOid)
        {
            var statusClosedList = new List<Guid>{
                new Guid("7AD9A7AE-AD2C-4CAA-BE50-42130D1EB57F"),
                new Guid("F3D3AD27-FFBF-48C2-B2A6-5761BC6E45E0"),
                new Guid("439E8FB4-B576-4650-83DE-656EE3CFD3E7"),
                new Guid("5D982B4A-4D94-43F2-960F-834743CBE1B0"),
                new Guid("56C7DB4D-EFB7-4103-952D-84A719C94020"),
                new Guid("B61F4BCF-B108-4676-8EDE-91AC3538E916"),
                new Guid("B35C770E-7D9E-4523-B3F6-C61BA273B61C"),
                new Guid("C6DAF753-63BF-4825-9476-D38872472727"),
                new Guid("2E1076A9-7B80-418A-A8BD-D72074D577B6")
                };
            var res = await _crmSuportService.GetFirmOpenSupports(firmOid, statusClosedList);
            return Json(res);
        }
    }
}
