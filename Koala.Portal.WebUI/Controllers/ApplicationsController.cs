using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

namespace Koala.Portal.WebUI.Controllers
{
    //[Authorize(Roles = "Yönetici, Yazılım")]
    [Authorize]
    public class ApplicationsController : Controller
    {
        private readonly IApplicationsService _applicationsService;
        private readonly IApplicationLicencesService _applicationLicencesService;
        private readonly IApplicationModulesService _applicationModulesService;
        private readonly IApplicationFirmService _applicationFirmService;
        private readonly UserManager<AppUser> _userManager;

        public ApplicationsController(IApplicationsService applicationsService, IApplicationLicencesService applicationLicencesService, UserManager<AppUser> userManager, IApplicationModulesService applicationModulesService, IApplicationFirmService applicationFirmService)
        {
            _applicationsService = applicationsService;
            _applicationLicencesService = applicationLicencesService;
            _userManager = userManager;
            _applicationModulesService = applicationModulesService;
            _applicationFirmService = applicationFirmService;
        }
        [Authorize(Policy = "AppLicationManagement.View")]
        public async Task<IActionResult> Index()
        {
            var res = await _applicationsService.GetApplicationList();
            if (!res.IsSuccess)
            {
                TempData["Error"] = res;
                return View("Error");
            }

            var updateCount = 0;
            foreach (var item in res.Data.Where(item => item.ExpDate < DateTime.Now && item.Status != StatusEnum.Expiration))
            {
                await _applicationsService.ChangeStatusAsync(new ApplicationsChangeStatusViewModel
                { Id = item.Id, Status = StatusEnum.Expiration });
                updateCount++;
            }
            if (updateCount > 0)
            {
                return RedirectToAction("Index", "Applications");
            }
            return View(res.Data);
        }
        [Authorize(Policy = "AppLicationManagement.Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Policy = "AppLicationManagement.Create")]
        public async Task<IActionResult> Create(CreateApplicationsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = await _applicationsService.AddAsync(model);
            if (!res.IsSuccess)
            {
                var errorMessage = string.Join("<br/>", res.Errors.Errors);
                TempData["ErrorMessage"] = errorMessage;
                return RedirectToAction("Index", "Applications");
            }
            TempData["InfoMessage"] = "Uygulama Bilgisi Başarıyla Eklendi";
            return RedirectToAction("Index", "Applications");
        }
        [Authorize(Policy = "AppLicationManagement.Update")]
        public async Task<IActionResult> Update(string id)
        {
            var res = await _applicationsService.GetUpdateDataAsync(id);
            if (!res.IsSuccess)
            {
                TempData["Error"] = res;
                return View("Error");
            }
            return View(res.Data);
        }
        [HttpPost]
        [Authorize(Policy = "AppLicationManagement.Update")]
        public async Task<IActionResult> Update(UpdateApplicationsViewModel model)
        {
            var res = await _applicationsService.UpdateAsync(model);
            if (!res.IsSuccess)
            {
                TempData["Error"] = res;
            }
            return RedirectToAction("Index", "Applications");
        }
        [Authorize(Policy = "AppLicationManagement.ManageLicance")]
        public async Task<IActionResult> ChangeStatus(string id, StatusEnum status)
        {
            var application = await _applicationsService.GetByIdAsync(id);
            var res = await _applicationsService.ChangeStatusAsync(new ApplicationsChangeStatusViewModel
            { Id = id, Status = status });
            if (res.IsSuccess)
            {
                TempData["InfoMessage"] = $"{application.Data.Name} İsimli Uygualama durumu {(status == StatusEnum.Active ? "Aktif" : "Pasif")} Olarak Güncellendi";
            }
            else
            {
                TempData["errorMessage"] = $"{application.Data.Name} İsimli Uygualama durumu {(status == StatusEnum.Active ? "Aktif" : "Pasif")} Olarak Güncellenirken Bir Sorunla Karşılaşıldı";
            }
            return RedirectToAction("Index", "Applications");
        }
        [Authorize(Policy = "AppLicationManagement.AddExpDate")]
        public async Task<IActionResult> AddExpDate(string id)
        {
            var res = await _applicationsService.GetExpDateInfoAsync(id);
            if (res.IsSuccess) return View(res.Data);
            TempData["Error"] = res;
            return View("Error");
        }
        [HttpPost]
        [Authorize(Policy = "AppLicationManagement.AddExpDate")]
        public async Task<IActionResult> AddExpDate(ApplicationsAddExpDateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var res = await _applicationsService.UpdateExpDateInfoAsync(model);
            if (!res.IsSuccess)
            {
                TempData["Error"] = res;
                return View("Error");
            }
            TempData["InfoMessage"] = $"{model.Name} İsimli Uygualama Son Kullanım Tarihi {model.ExpDate:dd-MM-yyyy HH:mm} Olarak Güncellendi";
            return RedirectToAction("Index", "Applications");
        }

        [Authorize(Policy = "AppLicationManagement.ManageLicance")]
        public async Task<IActionResult> LiceceAccept()
        {
            var licences = await _applicationLicencesService.GetWaitingLicences();
            if (!licences.IsSuccess)
            {
                TempData["Error"] = licences;
                return View("Error");
            }

            return View(licences.Data);
        }
        [HttpGet]
        public async Task<IActionResult> CreateApplicationModule()
        {
            try
            {
                var moduleList = await _applicationsService.GetApplicationList();
                if (!moduleList.IsSuccess)
                {
                    TempData["Error"] = moduleList;
                    return View("Error");
                }
                var moduleSelectList = new List<SelectListItem>();
                foreach (var item in moduleList.Data)
                {
                    moduleSelectList.Add(new SelectListItem
                    {
                        Selected = false,
                        Text = item.Name,
                        Value = item.Id
                    });

                }
                TempData["modules"] = moduleSelectList;
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = Core.Dtos.Response.Fail(400, "Sayfa verileri hazırlanırken Bir Sorunla Karşılaşıldı", ex.Message, false);
                return View("Error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateApplicationModule(CreateApplicationModulesViewModel model)
        {
            try
            {
                var moduleList = await _applicationsService.GetApplicationList();
                if (!moduleList.IsSuccess)
                {
                    TempData["Error"] = moduleList;
                    return View("Error");
                }
                var moduleSelectList = new List<SelectListItem>();
                foreach (var item in moduleList.Data)
                {
                    moduleSelectList.Add(new SelectListItem
                    {
                        Selected = false,
                        Text = item.Name,
                        Value = item.Id
                    });

                }
                TempData["modules"] = moduleSelectList;
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = Core.Dtos.Response.Fail(400, "Sayfa verileri hazırlanırken Bir Sorunla Karşılaşıldı", ex.Message, false);
                return View("Error");
            }
        }
        public async Task<IActionResult> ApplicationFirms(string id)
        {
            var application = await _applicationsService.GetByIdAsync(id);
            TempData["AppName"] = application.Data.Name;
            if (!application.IsSuccess)
            {
                TempData["Error"] = application;
                return View("Error");
            }
            if (!application.Data.IsPackageApplication) return View("Index");
            if (application.Data == null) return View("Index");

            var appFirms = await _applicationFirmService.GetApplicationFirms(id);
            if (!appFirms.IsSuccess)
            {
                TempData["Error"] = appFirms;
                return View("Error");
            }
            return View(appFirms.Data);
        }

        [Authorize(Policy = "AppLicationManagement.ManageLicance")]
        public async Task<JsonResult> LiceceAcceptConfirm(string id, StatusEnum status)
        {
            var licences = await _applicationLicencesService.GetWaitingLicences();
            if (!licences.IsSuccess)
            {
                //TempData["Error"] = licences;
                //return View("Error");
            }

            //TempData["Out Of Range"] = false;
            var userPrincipal = User;
            var user = await _userManager.GetUserAsync(userPrincipal);

            var model = new ConfirmApplicationLicencesViewModel
            {
                ApprovedByUserId = user!.Id,
                Id = id,
                Status = status,
                ApplicationLicenceStatus = status == StatusEnum.Active ? ApplicationLicenceStatusEnum.Accepted : ApplicationLicenceStatusEnum.Rejected


            };
            var res = await _applicationLicencesService.ConfirmLicence(model);
            if (res.IsSuccess)
            {

            }

            return Json(res); //RedirectToAction("Index", "Applications");
        }

        [Authorize(Policy = "AppLicationManagement.ManageLicance")]
        public async Task<JsonResult> GetApplicationLicanceCount(string id)
        {
            var res = await _applicationLicencesService.GetApplicationLicanceCount(id);
            return Json(res);
        }

        [Authorize(Policy = "AppLicationManagement.ManageLicance")]
        public async Task<JsonResult> GetApplicationModuleList(string applicationId)
        {
            var res = await _applicationModulesService.GetApplicationModulesListAsync(applicationId);
            return Json(res);
        }
        [HttpPost]
        public JsonResult AddFirmToApplication(AddApplicationFirmsViewModel model)
        {
            var res = _applicationFirmService.AddAsync(model).Result;
            return Json(res);
        }
        [HttpGet]
        public JsonResult GetFirmCode(string id)
        {
            try
            {
                var res = id.Encryption();
                return Json(Response<string>.SuccessData(200, "Firma Kodu Başarıyla Üretildi", res));
            }
            catch (Exception ex)
            {
                return Json(Response<string>.FailData(200, "Firma Kodu Üretilirken Bir Sorunla Karşılaşıldı", ex.Message, false));

            }
        }
        [HttpPost]
        public async Task<JsonResult> UpdateFirmExpDate(UpdateExpDateApplicationFirmsJsonModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.ExpDate))
                {
                    return Json(Core.Dtos.Response.Fail(400, "Güncellenecek Tarih Girilmesi Zorunludur", "Firma lisans süresinin güncellenebilmesi için bir tarih girilmesi zorunludur.", false));

                }
                var date = DateTime.ParseExact(model.ExpDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                var res = await _applicationFirmService.UpdateExpDate(new UpdateExpDateApplicationFirmsViewModel
                {
                    Id = model.Id,
                    ExpDate = date,
                    ApplicationId = model.ApplicationId,
                    FirmId = model.FirmId
                });
                return Json(res);
            }
            catch (Exception ex)
            {
                return Json(Core.Dtos.Response.Fail(400, "Firma Lisans Son Kullanım Tarihi Güncellenirken Bir Sorunla Karşılaşıldı", ex.Message, false));

            }

        }
    }
}
