using System.Text;
using AutoMapper;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Koala.Portal.WebUI.Controllers
{
    [Authorize]
    public class FixtureController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly IFixtureService _fixtureService;
        public FixtureController(ILogger<DashboardController> logger, IFixtureService fixtureService, IMapper mapper)
        {
            _logger = logger;
            _fixtureService = fixtureService;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _fixtureService.GetAllAsync();

            if (res.IsSuccess)
                return View(res.Data);

            TempData["Error"] = Core.Dtos.Response.Fail(res.StatusCode, res.Message, res.Errors);
            return View("Error");
        }

        public IActionResult CreateFixture()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFixture(CreateFixtureViewModel model)
        {
            var res = await _fixtureService.AddAsyc(model);
            if (res.IsSuccess)
            {
                TempData["InfoMessage"] = "Demirbaş başarıyla eklendi";
                return RedirectToAction("Index", "Fixture");
            }

            foreach (var item in res.Errors.Errors)
            {
                ModelState.AddModelError(string.Empty, item);
            }
            return View(model);
        }

        public async Task<IActionResult> UpdateFixture(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index", "Fixture");
            }

            var fixture = await _fixtureService.GetUpdateDataAsyc(id);
            if (fixture == null)
            {
                TempData["ErrorMessage"] = "Güncellenmek istenilen demirbaş bilgilerine ulaşılamadı";
                return RedirectToAction("Index", "Fixture");

            }

            if (fixture.IsSuccess) return View(fixture.Data);


            var sb = new StringBuilder();
            sb.AppendLine("<ul>");
            foreach (var item in fixture.Errors.Errors)
            {

                sb.Append($"<li>{item}</li>");
            }

            sb.Append("</ul>");
            return RedirectToAction("Index", "Fixture");

        }
        [HttpPost]
        public async Task<IActionResult> UpdateFixture(UpdateFixtureViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var res = await _fixtureService.Update(model, model.Id);
            if (!res.IsSuccess)
            {
                foreach (var item in res.Errors.Errors)
                {
                    ModelState.AddModelError(string.Empty, item);
                }
                return View(model);
            }

            TempData["InfoMessage"] = $"{model.Name} isimli demirbaş başarıyla güncellendi";
            return RedirectToAction("Index", "Fixture");
        }

        public async Task<IActionResult> FixtureChangeStatus(string id, bool status)
        {
            var fixture = await _fixtureService.GetUpdateDataAsyc(id);
            if (fixture == null)
            {
                TempData["ErrorMessage"] = "Demirbaş durumu güncellenirken bir sorunla karşılaşıldı";
                return RedirectToAction("Index", "Fixture");
            }

            if (!fixture.IsSuccess)
            {
                var sb = new StringBuilder();
                sb.AppendLine("<ul>");
                foreach (var item in fixture.Errors.Errors)
                {

                    sb.Append($"<li>{item}</li>");
                }

                sb.Append("</ul>");
                return RedirectToAction("Index", "Fixture");
            }
            fixture.Data.IsActive = status;
            //TODO:Servise Güncelleme için updatemodeli dönen get metodu yazılacak.
            var res = await _fixtureService.Update(fixture.Data, id);
            TempData["InfoMessage"] = "Demirbaş durumu başarıyla güncellendi.";
            return RedirectToAction("Index", "Fixture");
        }
    }
}
