using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Helpers;
using Koala.Portal.WebUI.Models;
using Koala.Portal.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.WebUI.Controllers
{
    [Authorize]
    public class UserAccountController : Controller
    {
        private readonly ILogger<UserAccountController> _logger;
        private readonly UserManager<AppUser> _userManager;

        public UserAccountController(ILogger<UserAccountController> logger, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {


            var users = await _userManager.Users.Where(x => x.Status != UserStatusEnum.Removed).ToListAsync();
            var model = new List<UserListViewModel>();
            foreach (var item in users)
            {
                model.Add(item: new UserListViewModel
                {
                    Email = item.Email,
                    Fullname = item.Name + " " + item.Lastname,
                    PhoneNumber = item.PhoneNumber,
                    Title = item.Title,
                    Id = item.Id,
                    Status = (int)item.Status
                });
            }
            return View(model);
        }



        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = await _userManager.CreateAsync(new()
            {
                Id = Tools.CreateGuid(),
                Email = model.Email,
                Lastname = model.Lastname,
                UserName = model.Email,
                Name = model.Name,
                Title = model.Title,
                PhoneNumber = model.PhoneNumber,
                Oid = ""
            }, model.Password);
            if (res.Succeeded)
            {
                TempData["SuccessMessage"] = "Kullanıcı Başarıyla Eklendi";
                return RedirectToAction(nameof(UserAccountController.CreateUser));
            }

            foreach (var identityError in res.Errors)
            {
                ModelState.AddModelError(string.Empty, identityError.Description);
            }
            return View(model);
        }


        public IActionResult Login(string returnUrl)
        {
            var model = (new LoginViewModel(), new ForgetPasswordViewModel());
            return View();
        }
        [HttpPost]
        //[Bind(Prefix = "Item1")] LoginViewModel loginModel, [Bind(Prefix = "Item2")] ForgetPasswordViewModel forgetModel,
        public async Task<IActionResult> Login(string returnUrl, LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            //var model = (loginModel, forgetModel);
            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı Bilgilerinizi kontrol ederek tekrar deneyiniz");
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public IActionResult ForgetPassword([Bind(Prefix = "Item1")] LoginViewModel loginModel, [Bind(Prefix = "Item2")] ForgetPasswordViewModel forgetModel)
        {
            return RedirectToAction("Login");
        }

    }
}
