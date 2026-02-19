using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Koala.Portal.WebUI.Controllers
{
    [Authorize]
    public class FirmController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ICrmFirmService _crmFirmService;
        private readonly ICrmSqlService _crmSqlService;
        private readonly IFirmService _firmService;
        private readonly ICrmSupportService _crmSupportService;
        private readonly IBackgroundServices _backgroundService;
        private readonly ICrmSelectListService _crmSelectListService;
        private readonly ISelectListService _selectListService;
        private readonly UserManager<AppUser> _userManager;
        public FirmController(IHttpContextAccessor httpContextAccessor,
                              ICrmFirmService crmFirmService,
                              IFirmService firmService,
                              ICrmSupportService crmSupportService,
                              IBackgroundServices backgroundService,
                              ICrmSqlService crmSqlService,
                              ICrmSelectListService crmSelectListService,
                              UserManager<AppUser> userManager, 
                              ISelectListService selectListService)
        {
            _contextAccessor = httpContextAccessor;
            _crmFirmService = crmFirmService;
            _firmService = firmService;
            _crmSupportService = crmSupportService;
            _backgroundService = backgroundService;
            _crmSqlService = crmSqlService;
            _userManager = userManager;
            _selectListService = selectListService;
            _crmSelectListService = crmSelectListService;
        }
        public async Task<IActionResult> Index()
        {
            var firms = await _firmService.GetFirmList();
            return !firms.IsSuccess ? View("Error") : View(firms.Data);
        }

        //public async Task<IActionResult> SencronFirm()
        //{
        //    var currentFirms = await _firmService.GetAllAsync();
        //    if (!currentFirms.IsSuccess)
        //    {
        //        return View("Error");
        //    }
        //    var fOids = currentFirms.Data.Select(x => x.Oid).ToList();

        //    var newCrmFirms = _crmFirmService.Where(x => fOids.All(y => y != x.Oid.ToString()));
        //    if (!newCrmFirms.IsSuccess)
        //    {
        //        TempData["Error"] = newCrmFirms;
        //        return View("Error");
        //    }
        //    var addres = await _firmService.AddRangeAsync(newCrmFirms.Data);
        //    //var firms = _crmFirmService.Where(x=>x.O)
        //    return View();
        //}

        public async Task<IActionResult> FirmInfo(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Firm");
            }

            var firm = await _firmService.GetFirmByIdAsync(id);
            if (!firm.IsSuccess)
            {
                TempData["Error"] = firm;
                return View("Error");
            }
            var firmSupports = await _crmSupportService.Where(x => x.TicketFirm == new Guid(firm.Data.Oid));
            var supportUsers = _crmSqlService.GetCrmUserFullNameInfoList();
            var currentUser = User;
            var user = await _userManager.GetUserAsync(currentUser);
            var userDepartments = _crmSqlService.GetCrmUserDepartments(user.Oid!);
            var retVal = (firm.Data, firmSupports.Data, supportUsers.Data, userDepartments.Data);

            //TODO : Firma Proje Bilgisi7
            return View(retVal);
        }

        public async Task<IActionResult> FirmDetail(string id)
        {
            var firmId = _crmFirmService.GetFirmInfoByCode(id);
            return RedirectToAction("FirmInfo", "Firm", new { id = firmId.Data.Oid });
        }

        public async Task<IActionResult> FirmDetailWithPhone(string id)
        {
            if (id.Substring(0, 1) == "0")
            {
                id = id.Substring(1);
            }
            var firmId = _crmSqlService.GetFirmOidByPhone(id);
            if (firmId.IsSuccess)
            {
                return RedirectToAction("FirmInfo", "Firm", new { id = firmId.Data });

            }
            else
            {
                //var errors = (Koala.Portal.Core.Dtos.Response)TempData["Error"];
                TempData["Error"] = Koala.Portal.Core.Dtos.Response.Fail(404,
                    $"{id} Telefon Numarasına Ait Firma Bilgilerine Ulaşılamadı", "Firma Bulunamadı", true);
                return View("Error");
            }
        }
        //[HttpGet]
        //public async Task<JsonResult> GetFirmDetail(string id) 
        //{
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        return Json(Core.Dtos.Response.Fail(400, "Firma Id Bilgisi Zorunludur", "Firma Bilgileri Alınamadı", true));
        //    }
        //    var firm = await _firmService.UpdateFirmAsync(id);
        //    return Json(firm);
        //}
        [HttpPost]
        public  JsonResult SencronFirmResult()
        {
            var currentFirms = _crmFirmService.GetAllLocalFirm().Result;
            if (!currentFirms.IsSuccess)
            {
                return Json(Core.Dtos.Response.Fail(currentFirms.StatusCode, currentFirms.Message,
                    currentFirms.Errors));

            }
            var fOids = currentFirms.Data;

            var newCrmFirms = _crmFirmService.Where(x => fOids.Select(z => z.Oid.ToUpper()).All(y => y != x.Oid.ToString().ToUpper()));
            if (!newCrmFirms.IsSuccess)
            {
                return Json(Core.Dtos.Response.Fail(newCrmFirms.StatusCode, newCrmFirms.Message,
                    newCrmFirms.Errors));
            }
            try
            {
                var addres = _firmService.AddRangeAsync(newCrmFirms.Data).Result;
                return Json(Core.Dtos.Response.Success(200, "Firmalar Başarıyla Senkron Edildi"));
            }
            catch (Exception ex)
            {
                return Json(Core.Dtos.Response.Fail(400, "Firmalar Senkronize Edilirken Bir Sorunla Karşılaşıldı",
                    ex.Message, false));
            }

            //return Json(_backgroundService.SencronFirm());
        }



        #region Helpers

        [HttpGet]
        public async Task<JsonResult> GetFirmContactsSelectList(string firmId, string selected = "")
        {
            var contacts = await _selectListService.GetFirmContactSelectList(firmId, selected);

            return Json(contacts);
        }
        //[HttpGet]
        //public async Task<JsonResult> GetFirmContactmailInfo(string contactOid)
        //{
        //    var contacts = await _selectListService.GetFirmContactSelectList();

        //    return Json(contacts);
        //}

        #endregion
    }
}
