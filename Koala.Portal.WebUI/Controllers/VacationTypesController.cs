using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Koala.Portal.WebUI.Controllers
{
    [Authorize]
    public class VacationTypesController : Controller
    {
        private readonly IVacationTypesService _service;

        public VacationTypesController(IVacationTypesService service)
        {
            _service = service;
        }

        public async Task<ActionResult> Index()
        {
            var res = await _service.GetAllAsync();
            if (res.IsSuccess) return View(res.Data);
            TempData["Error"] = res;
            return View("Error");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VacationTypesCreateViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var res = await _service.AddAsyc(model);
                if (!res.IsSuccess)
                {
                    TempData["Error"] = res;
                    return View("Error");
                }
                TempData["InfoMessage"] = $"{model.Name} isimli izin tipi başarıylşa eklendi.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = Core.Dtos.Response.Fail(400, "İzin Tipi Eklenirken Bir Sorunla Karşılaşıldı", ex.Message, false);
                return View("Error");
            }
        }

        public async Task<ActionResult> Update(string id)
        {
            var res = await _service.GetByIdAsyc(id);
            if (!res.IsSuccess)
            {
                TempData["Error"] = res;
                return View("Error");
            }
            return View(res.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(VacationTypesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var res = await _service.UpdateAsyc(model, model.Id);
                if (!res.IsSuccess)
                {
                    TempData["Error"] = res;
                    return View("Error");
                }
                else
                {
                    TempData["InfoMessage"] = $"{model.Name} isimli izin tipi başarıylşa eklendi.";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(model);
            }
        }

        public async Task<ActionResult> ChangeStatus(VacationTypesChangeStatusViewModel model)
        {
            var res = await _service.ChangeStatus(model);
            if (res.IsSuccess)
            {
                TempData["InfoMessage"] = res.Message;
            }
            else
            {
                if (res.Errors.IsShow)
                {
                    TempData["ErrorMessage"] = string.Join("<br />", res.Errors.Errors);
                }
                else
                {
                    TempData["ErrorMessage"] = res.Message;
                }
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
