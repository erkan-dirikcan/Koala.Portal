using Koala.Portal.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Koala.Portal.WebUI.Controllers
{
    [Authorize]
    public class HelpDeskController : Controller
    {
        private readonly IHelpDeskSolutionService _solutionService;
        private readonly IHelpDeskCategoryService _categoryService;
        private readonly IHelpDeskProblemService _problemService;

        public HelpDeskController(IHelpDeskSolutionService solutionService, IHelpDeskCategoryService categoryService, IHelpDeskProblemService problemService)
        {
            _solutionService = solutionService;
            _categoryService = categoryService;
            _problemService = problemService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetHelpDeskCategoryList();
            var views = await _problemService.GetHelpDeskProblemViewOrderList();
            var latest = await _problemService.GetHelpDeskProblemLastAddedList();
            var retVal = (categories.Data, views.Data, latest.Data);

            return View(retVal);
        }

        [HttpGet]
        public async Task<IActionResult> SearchResult(string tag)
        {
            if (string.IsNullOrEmpty(tag))
            {
                return RedirectToAction("Index", "HelpDesk");
            }
            var search = await _problemService.GetHelpDeskFilterList(tag);
            return View(search.Data);
        }

        public async Task<IActionResult> HelpDeskProblems(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                return RedirectToAction("Index","HelpDesk");
            }
            var problems = await _problemService.GetHelpDeskProblemWithCategory(category);
            if (!problems.IsSuccess)
            {
                TempData["Error"] = problems;
                return View("Error");
            }
            var categoryId = await _categoryService.GetByIdAsync(category);
            ViewData["CategoryName"] = $"{categoryId.Data.Name}";
            return View(problems.Data);

        }
        public async Task<IActionResult> Problem(string problemId)
        {
            if (string.IsNullOrEmpty(problemId))
            {
                return RedirectToAction("Index", "HelpDesk");
            }
            var hDeskProblem = await _problemService.DetailInfo(problemId);
            
            return View(hDeskProblem.Data);
        }
    }
}