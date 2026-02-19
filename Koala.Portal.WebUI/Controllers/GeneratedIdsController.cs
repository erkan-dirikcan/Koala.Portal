using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Koala.Portal.WebUI.Controllers
{
    [Authorize]
    public class GeneratedIdsController : Controller
    {
        private readonly IGeneratedIdsService _service;
        private readonly ISelectListService _selectListService;

        public GeneratedIdsController(IGeneratedIdsService service, ISelectListService selectListService)
        {
            _service = service;
            _selectListService = selectListService;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _service.GetGeneratedIdsList();
            if (!res.IsSuccess)
            {
                TempData["Error"] = res;
                return View("Error");
            }
            return View(res.Data);
        }
        public async Task<IActionResult> CreateGeneratedIds()
        {
            var moduleName = await _selectListService.GetModuleSelectList();
            ViewData["ModuleName"] = moduleName.Data;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateGeneratedIds(CreateGeneratedIdsViewModel model)
        {
            var moduleName = await _selectListService.GetModuleSelectList();
            ViewData["ModuleName"] = moduleName.Data;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = await _service.AddAsync(model);
            if (!res.IsSuccess)
            {
                foreach (var item in res.Errors.Errors)
                {
                    ModelState.AddModelError(string.Empty, item);
                }
                return View(model);
            }
            TempData["InfoMessage"] = "Yeni Kimlik Başarıyla Eklendi";
            return RedirectToAction("Index", "GeneratedIds");
        }
        public async Task<IActionResult> UpdateGeneratedIds(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["ErrorMessage"] = "Id Bilgisi Boş Bırakılamaz";
                return RedirectToAction("Index", "GeneratedIds");
            }
            var moduleName = await _selectListService.GetModuleSelectList();
            ViewData["ModuleName"] = moduleName.Data;
            var gId = await _service.GetUpdateInfoAsync(id);
            if (gId.Data == null)
            {
                TempData["ErrorMessage"] = "Güncellenmek İstenilen Kimlik Bulunamadı";
                return RedirectToAction("Index", "GeneratedIds");
            }
            return View(gId.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGeneratedIds(UpdateGeneratedIdsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = await _service.UpdateAsync(model, model.Id);
            
            if (!res.IsSuccess)
            {
                foreach (var item in res.Errors.Errors)
                {
                    ModelState.AddModelError(string.Empty, item);
                }
                return View(model);
            }
            TempData["InfoMessage"] = $"{model.Prefix} Prefixli Kimlik Başarıyla Güncellendi";
            return RedirectToAction("Index", "GeneratedIds");
        }
    }
}
