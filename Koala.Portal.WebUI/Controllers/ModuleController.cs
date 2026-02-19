using AutoMapper;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Koala.Portal.WebUI.Controllers
{
    [Authorize]
    public class ModuleController : Controller
    {
        private readonly IModuleService _moduleService;
        private readonly IClaimService _claimService;
        private readonly IMapper _mapper;
        public ModuleController(IModuleService moduleService, IMapper mapper, IClaimService claimService)
        {
            _moduleService = moduleService;
            _mapper = mapper;
            _claimService = claimService;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _moduleService.GetModuleList();

            if (!res.IsSuccess)
            {
                TempData["Error"] = res;
                return View("Error");
            }
            return View(res.Data);
        }
        public IActionResult CreateModule()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateModule(CreateModuleListViewModels model)
        { 
            var res = await _moduleService.AddAsync(model);
            if (!res.IsSuccess)
            {
                foreach (var item in res.Errors.Errors)
                {
                    ModelState.AddModelError(string.Empty, item);
                }
                return View(model);
            }

            TempData["InfoMessage"] = "Modül başarıyla eklendi";
            return RedirectToAction("Index", "Module");
        }
        public async Task<IActionResult> UpdateModule(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["ErrorMessage"] = "Id Bilgisi Boş Bırakılamaz";
                return RedirectToAction("Index", "Module");
            }

            var module = await _moduleService.GetUpdateInfoAsync(id);
            if (module.Data == null)
            {
                TempData["ErrorMessage"] = "Güncellenmek İstenilen Modül Bulunamadı";
                return RedirectToAction("Index", "Module");
            }
            if (!module.IsSuccess)
            {
                TempData["ErrorMessage"] = "Güncellenmek İstenilen Modül Bulunamadı";
                return RedirectToAction("Index", "Module");
            }

            return View(module.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateModule(UpdateModuleViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }
            var res = await _moduleService.UpdateAsync(model, model.Id);
            if (!res.IsSuccess)
            {
                foreach (var item in res.Errors.Errors)
                {
                    ModelState.AddModelError(string.Empty, item);
                }
                return View(model);
            }
            TempData["InfoMessage"] = $"{model.Name} isimli Modül başarıyla güncellendi";
            return RedirectToAction("Index", "Module");
        }

        public async Task<IActionResult> AddClaim(string id)
        {
            //var res = await _moduleService.GetModuleList();
            if (string.IsNullOrEmpty(id))
            {
                TempData["ErrorMessage"] = "Id Bilgisi Boş Bırakılamaz";

                return RedirectToAction("Index", "Module");
            }
            var module = await _moduleService.GetByIdAsync(id);
            if (!module.IsSuccess)
            {
                TempData["Error"] = module;
                return View("Error");
            }
            ViewData["ModuleInfo"] = $"{module.Data.Name}";

            return View(new CreateClaimViewModels { ModuleId = id });
        }
        [HttpPost]
        public async Task<IActionResult> AddClaim(CreateClaimViewModels model)
        {
            var module = await _moduleService.GetByIdAsync(model.ModuleId);
            ViewData["ModuleInfo"] = $"{module.Data.Name}";
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = await _moduleService.AddClaimToModule(model);
            if (!res.IsSuccess)
            {
                TempData["Error"] = res;
                return View("Error");
            }
            TempData["InfoMessage"] = $"{model.Name} isimli yetki başarıyla eklendi";
            return RedirectToAction("Index", "Module");
        }
        public async Task<IActionResult> ClaimDetail(string id)
        {
            var res = await _claimService.GetClaimToModuleList(id);
            if (string.IsNullOrEmpty(id))
            {
                TempData["ErrorMessage"] = "Id Bilgisi Boş Bırakılamaz";

                return RedirectToAction("Index", "Module");
            }
            var module = await _moduleService.GetByIdAsync(id);
            ViewData["ClaimInfo"] = $"{module.Data.DisplayName}";
            //TODO : Buraya dönüş tipi eklenecek
            return View(res.Data);
        }
        public async Task<IActionResult> UpdateClaim(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["ErrorMessage"] = "Id Bilgisi Boş Bırakılamaz";
                return RedirectToAction("Index", "Module");
            }

            var claims = await _claimService.GetUpdateInfoAsync(id);

            ViewData["ClaimInfo"] = $"{claims.Data.DisplayName}";

            return View(claims.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateClaim(UpdateClaimViewModels model)
        {
            var claims = await _claimService.GetUpdateInfoAsync(model.Id);
            ViewData["ClaimInfo"] = $"{claims.Data.DisplayName}";
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = await _claimService.UpdateAsync(model, model.Id);
            if (!res.IsSuccess)
            {
                return RedirectToAction("ClaimDetail", "Module", new { id = model.ModuleId });
            }
            return RedirectToAction("ClaimDetail", "Module", new { id = model.ModuleId });
        }

        [HttpPost]
        public async Task<JsonResult> DeleteModuleClaim(string id)
        {
            try
            {
                var res = await _claimService.DeleteAsync(id);
                

                return Json(res);
            }
            catch (Exception ex)
            {
                return Json(Core.Dtos.Response.Fail(400, "Yetki Silinirken Bir Sorunla Karşılaşıldı", ex.Message, false));
            }
        }
    }
}
