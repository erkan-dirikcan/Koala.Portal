using Koala.Portal.Core.Models;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;


namespace Koala.Portal.WebUI.Controllers
{
    [Authorize]
    public class HelpDeskProblemController : Controller
    {
        private readonly IHelpDeskProblemService _service;
        private readonly ISelectListService _selectListService;
        private readonly UserManager<AppUser> _userManager;

        public HelpDeskProblemController(IHelpDeskProblemService service,UserManager<AppUser> userManager, ISelectListService selectListService)
        {
            _service = service;
            _userManager = userManager;
            _selectListService = selectListService;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _service.GetHelpDeskProblemList();
            if (!res.IsSuccess)
            {
                TempData["Error"] = res;
                return View("Error");
            }
            return View(res.Data);
        }
        public async Task<IActionResult> CreateHelpDeskProblem()
        {
            var categoryName = await _selectListService.GetCategorySelectList();
            ViewData["CategoryName"] = categoryName.Data;
            return View();
        }
        
        [HttpPost]
        //[ValidateInput(false)]
        public async Task<IActionResult> CreateHelpDeskProblem(HelpDeskProblemCreateViewModel model)
        {
            var categoryName = await _selectListService.GetCategorySelectList();
            ViewData["CategoryName"] = categoryName.Data;
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
            TempData["InfoMessage"] = "Yardım Masası Problemi Başarıyla Eklendi";
            return RedirectToAction("Index", "HelpDeskProblem");
        }
        public async Task<IActionResult> UpdateHelpDeskProblem(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["ErrorMessage"] = "Id Bilgisi Boş Bırakılamaz";
                return RedirectToAction("Index", "HelpDeskProblem");
            }

            var categoryName = await _selectListService.GetCategorySelectList();
            ViewData["CategoryName"] = categoryName.Data;
            var hDC = await _service.GetUpdateInfoAsync(id);
            if (hDC.Data == null)
            {
                TempData["ErrorMessage"] = "Güncellenemek İstenilen Problem Bulunamadı";
                return RedirectToAction("Index", "HelpDeskProblem");
            }
            return View(hDC.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateHelpDeskProblem(HelpDeskProblemUpdateViewModel model)
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
            TempData["InfoMessage"] = $"{model.Title} başlıklı Yardım Masası Problemi Başarıyla Güncellendi";
            return RedirectToAction("Index", "HelpDeskProblem");
        }
        public async Task<IActionResult> ChangeProblemStatus(HelpDeskProblemChangeStatusViewModel model)
        {
            var hDeskProblem = await _service.GetByIdAsync(model.Id);
            var res = await _service.ChangeStatusAsync(model);

            if (res.IsSuccess)
            {
                TempData["InfoMessage"] = $"{hDeskProblem.Data.Title} Başlıklı Yardım Masası Problemi Durumu {(model.Status == Core.Dtos.StatusEnum.Active ? "Aktif" : "Silindi")} Olarak Güncellendi";
            }
            else
            {
                TempData["ErrorMessage"] = $"{hDeskProblem.Data.Title} İsimli Yardım Masası Problemi Durumu {(model.Status == Core.Dtos.StatusEnum.Active ? "Aktif" : "Silindi")} Olarak Güncellenirken Bir Sorunla Karşılaşıldı";
            }
            return RedirectToAction("Index", "HelpDeskProblem");
        }
    }
}
