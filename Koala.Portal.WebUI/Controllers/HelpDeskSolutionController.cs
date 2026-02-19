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
    public class HelpDeskSolutionController : Controller
    {
        private readonly IHelpDeskSolutionService _service;
        private readonly ISelectListService _selectListService;

        private readonly UserManager<AppUser> _userManager;

        public HelpDeskSolutionController(IHelpDeskSolutionService service, ISelectListService selectListService, UserManager<AppUser> userManager)
        {
            _service = service;
            _selectListService = selectListService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _service.GetHelpDeskSolutionList();
            if (!res.IsSuccess)
            {
                TempData["Error"] = res;
                return View("Error");
            }
            return View(res.Data);
        }

        public async Task<IActionResult> CreateHelpDeskSolution()
        {
            var problemName = await _selectListService.GetProblemSelectList();
            ViewData["ProblemName"] = problemName.Data;
            return View();
        }
        [HttpPost]
        //[ValidateInput(false)]
        public async Task<IActionResult> CreateHelpDeskSolution(HelpDeskSolitionCreateViewModel model)
        {
            var problemName = await _selectListService.GetProblemSelectList();
            ViewData["ProblemName"] = problemName.Data;

            //var sn = await _generatedIdsService.GetNextNumber(model.SolitionNumber);

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
            TempData["InfoMessage"] = "Yardım Masası Çözümü Başarıyla Eklendi";
            return RedirectToAction("Index", "HelpDeskSolution");
        }
        public async Task<IActionResult> UpdateHelpDeskSolution(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["ErrorMessage"] = "Id Bilgisi Boş Bırakılamaz";
                return RedirectToAction("Index", "HelpDeskSolution");
            }
            var problemName = await _selectListService.GetProblemSelectList();
            ViewData["ProblemName"] = problemName.Data;
            var hDS = await _service.GetUpdateInfoAsync(id);
            if (hDS.Data == null)
            {
                TempData["ErrorMessage"] = "Güncellenmek İstenilen Çözüm Bulunamadı";
                return RedirectToAction("Index", "HelpDeskSolution");
            }
            return View(hDS.Data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateHelpDeskSolution(HelpDeskSolitionUpdateViewModel model)
        {
            var problemName = await _selectListService.GetProblemSelectList();
            ViewData["ProblemName"] = problemName.Data;
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
            TempData["InfoMessage"] = $"{model.Title} başlıklı Yardım Masası Çözümü Başarıyla Güncellendi";
            return RedirectToAction("Index", "HelpDeskSolution");
        }
        public async Task<IActionResult> ChangeSolutionStatus(HelpDeskSolitionChangeStatusViewModel model)
        {
            var hDS = await _service.GetByIdAsync(model.Id);
            var res = await _service.ChangeStatusAsync(model);
            if (res.IsSuccess)
            {
                TempData["InfoMessage"] = $"{hDS.Data.Title} Başlıklı Yardım Masası Çözümü Durumu {(model.Status == Core.Dtos.StatusEnum.Active ? "Aktif" : "Silindi")} Olarak Güncellendi";
            }
            else
            {
                TempData["ErrorMessage"] = $"{hDS.Data.Title} İsimli Yardım Masası Çözümü Durumu {(model.Status == Core.Dtos.StatusEnum.Active ? "Aktif" : "Silindi")} Olarak Güncellenirken Bir Sorunla Karşılaşıldı";
            }
            return RedirectToAction("Index", "HelpDeskSolution");
        }
    }
}
