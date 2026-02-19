using AutoMapper;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Koala.Portal.WebUI.Controllers
{
    [Authorize]
    public class HelpDeskCategoryController : Controller
    {
        private readonly IHelpDeskCategoryService _service;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        public HelpDeskCategoryController(IHelpDeskCategoryService service, IMapper mapper, UserManager<AppUser> userManager)
        {
            _service = service;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _service.GetHelpDeskCategoryList();
            if (!res.IsSuccess)
            {
                TempData["Error"] = res;
                return View("Error");
            }
            return View(res.Data);
        }
        public IActionResult CreateHelpDeskCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateHelpDeskCategory(HelpDeskCategoryCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.GetUserAsync(User);
            model.UpdateUser = user.Id;
            model.CreateUser = user.Id;
            var res = await _service.AddAsync(model);
            if (!res.IsSuccess)
            {
                foreach (var item in res.Errors.Errors)
                {
                    ModelState.AddModelError(string.Empty, item);
                }
                return View(model);
            }
            TempData["InfoMessage"] = "Yardım Masası Kategorisi Başarıyla Eklendi";
            return RedirectToAction("Index", "HelpDeskCategory");
        }
        public async Task<IActionResult> ChangeCategoryStatus(HelpDeskCategoryChangeStatusViewModel model)
        {
            var hDC = await _service.GetByIdAsync(model.Id);
            var res = await _service.ChangeStatusAsync(model);

            if (res.IsSuccess)
            {
                TempData["InfoMessage"] = $"{hDC.Data.Name} isimli Yardım Masası Kategorisi Durumu {(model.Status == Core.Dtos.StatusEnum.Active ? "Aktif" : "Silindi")} Olarak Güncellendi";
            }
            else
            {
                TempData["ErrorMessage"] = $"{hDC.Data.Name} İsimli Yardım Masası Kategorisi Durumu {(model.Status == Core.Dtos.StatusEnum.Active ? "Aktif" : "Silindi")} Olarak Güncellenirken Bir Sorunla Karşılaşıldı";
            }
            return RedirectToAction("Index", "HelpDeskCategory");
        }
        public async Task<IActionResult> UpdateHelpDeskCategory(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["ErrorMessage"] = "Id Bilgisi Boş Bırakılamaz";
                return RedirectToAction("Index", "HelpDeskCategory");
            }
            var hDC = await _service.GetUpdateInfoAsync(id);
            if (hDC.Data ==null)
            {
                TempData["ErrorMessage"] = "Güncellenemek İstenilen Kategori Bulunamadı";
                return RedirectToAction("Index", "HelpDeskCategory");
            }
            return View(hDC.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateHelpDeskCategory(HelpDeskCategoryUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.GetUserAsync(User);
            model.UpdateUser = user.Id;
            var res = await _service.UpdateAsync(model, model.Id);
            if (!res.IsSuccess)
            {
                foreach (var item in res.Errors.Errors)
                {
                    ModelState.AddModelError(string.Empty, item);
                }
                return View(model);
            }
            TempData["InfoMessage"] = $"{model.Name} isimli Yardım Masası Kategorisi Başarıyla Güncellendi";
            return RedirectToAction("Index", "HelpDeskCategory");
        }

    }
}
