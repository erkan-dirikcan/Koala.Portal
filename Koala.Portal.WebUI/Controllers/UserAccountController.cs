using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.GetPassServices;
using Koala.Portal.Core.Helpers;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.CrmViewModels;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Koala.Portal.Repository;
using Koala.Portal.WebUI.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Diagnostics;
using System.Globalization;
using System.Numerics;
using System.Security.Claims;

namespace Koala.Portal.WebUI.Controllers
{
    [Authorize]
    public class UserAccountController : Controller
    {
        private readonly ILogger<UserAccountController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SistemCryptorContext _sistemCryptorContext;
        private readonly IEmailService _emailService;
        private readonly IFileProvider _fileProvider;
        private readonly ICrmSqlService _crmSqlService;
        private readonly ICrmSelectListService _crmSelectListService;
        private readonly IGetPassUserService _getPassUserService;
        private readonly IMyDataService _myDataService;
        private readonly IUserService _userService;
        private readonly IModuleService _moduleService;
        private readonly IRoleService _roleService;
        private readonly IClaimService _claimService;
        private readonly IAuthorizationService AuthorizationService;
        private readonly ICrmSupportService _crmSupportService;
        private readonly IVacationHistoryService _vacationHistoryService;

        public UserAccountController(ILogger<UserAccountController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailService, IFileProvider fileProvider, RoleManager<AppRole> roleManager, ICrmSqlService crmSqlService, ICrmSelectListService crmSelectListService, IGetPassUserService getPassUserService, IUserService userService, IModuleService moduleService, IRoleService roleService, IClaimService claimService, IAuthorizationService authorizationService, ICrmSupportService crmSupportService, SistemCryptorContext sistemCryptorContext, IMyDataService myDataService, IVacationHistoryService vacationHistoryService)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _fileProvider = fileProvider;
            _roleManager = roleManager;
            _crmSqlService = crmSqlService;
            _crmSelectListService = crmSelectListService;
            _getPassUserService = getPassUserService;
            _userService = userService;
            _moduleService = moduleService;
            _roleService = roleService;
            _claimService = claimService;
            AuthorizationService = authorizationService;
            _crmSupportService = crmSupportService;
            _sistemCryptorContext = sistemCryptorContext;
            _myDataService = myDataService;
            _vacationHistoryService = vacationHistoryService;
        }

        [Authorize(Roles = "Yönetici,Yazılım")]

        public async Task<IActionResult> Index()
        {

            var url = Request.Host;
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
        [Authorize(Roles = "Yönetici,Yazılım")]

        public async Task<IActionResult> CreateUser()
        {
            try
            {
                var crmUsers = await _crmSelectListService.GetUserSelectList(true);
                var getPassUsers = await _getPassUserService.GetUserSkeySelectListAsync();
                ViewData["CrmUsers"] = crmUsers.Data;
                ViewData["GetPassUsers"] = getPassUsers.Data;
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = Koala.Portal.Core.Dtos.Response.Fail(400, "Form Verileri Doldurulurken Bir Sorunla KArşılaşıldı", ex.Message, false);
                return View("Error");
            }
        }
        [Authorize(Roles = "Yönetici,Yazılım")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var crmUsers = await _crmSelectListService.GetUserSelectList(true, model!.Oid!);
            var getPassUsers = await _getPassUserService.GetUserSkeySelectListAsync();
            ViewData["GetPassUsers"] = getPassUsers.Data;
            ViewData["CrmUsers"] = crmUsers.Data;

            Debug.Assert(model.Password != null, "model.Password != null");
            var res = await _userManager.CreateAsync(new()
            {
                Id = Tools.CreateGuidStr(),
                Email = model.Email,
                Lastname = model.Lastname,
                UserName = model.Email,
                Name = model.Name,
                Title = model.Title,
                PhoneNumber = model.PhoneNumber,
                Oid = model.Oid,
                SKey = !string.IsNullOrEmpty(model.SKey) ? Tools.GuidStringToBigIntPositive(model.SKey).ToString() : ""
            }, model.Password);

            if (res.Succeeded)
            {
                TempData["InfoMessage"] = $"{model.Name} {model.Lastname} isimli kullanıcı başarıyla eklendi";

                TempData["SuccessMessage"] = "Kullanıcı Başarıyla Eklendi";
                return RedirectToAction("Index", "UserAccount");
            }


            ModelState.AddModelErrorList(res.Errors.Select(x => x.Description).ToList());


            return View(model);
        }

        [AllowAnonymous]
        public IActionResult? Login(string returnUrl = "/")
        {

            var model = (new LoginViewModel(), new ForgetPasswordViewModel());
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([Bind(Prefix = "Item1")] LoginViewModel loginModel, [Bind(Prefix = "Item2")] ForgetPasswordViewModel forgetModel, string returnUrl = "/")
        {
            var model = (loginModel, forgetModel);
            var user = await _userManager.FindByNameAsync(loginModel.Email ?? "");
            //var model = (loginModel, forgetModel);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı Bilgilerinizi kontrol ederek tekrar deneyiniz");
                return View(model);
            }

            if (user.Status != UserStatusEnum.Active)
            {
                switch (user.Status)
                {
                    case UserStatusEnum.Passive:
                    case UserStatusEnum.Blocked:
                        ModelState.AddModelError("", "Lütfen aktif bir kullanıcı ile giriş yapmayı deneyin.");
                        return View(model);
                    case UserStatusEnum.Removed:
                        ModelState.AddModelError("", "Giriş yapmak istediğiniz kullanıcı bilgilerine ulaşılamadı.");
                        return View(model);
                }
            }
            //TODO : Try Catch eklenecek

            var res = await _signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe, true);
            if (res.IsLockedOut)
            {
                ModelState.AddModelErrorList(new List<string> { "Hesabınız Kilitli, 15 dakika boyunca giriş yapamazsınız. Lütfen daha sonra tekrar deneyiniz." });
                return View(model);
            }

            if (res.IsNotAllowed)
            {
                ModelState.AddModelErrorList(new List<string> { "Erişim Yetkiniz bulunmamaktadır." });
                return View(model);
            }

            if (res.RequiresTwoFactor)
            {
                //TODO : Bu alan daha sonra doldurulacak
            }

            if (res.Succeeded)
            {
                if (!string.IsNullOrEmpty(user.Oid))
                {
                    var deps = _crmSqlService.GetCrmUserDepartments(user!.Oid!);
                    var claims = deps.Data.Select(item => new Claim("Department", item.DepartmentName)).ToList();

                    await _signInManager.SignInWithClaimsAsync(user, loginModel.RememberMe,
                        claims);
                }


                //var res = await _signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe, true);
                returnUrl = returnUrl ?? Url.Action("Index", "Dashboard");
                return Redirect(returnUrl);

            }

            ModelState.AddModelError(string.Empty, "Kullanıcı Bilgilerinizi kontrol ederek tekrar deneyiniz");
            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ForgetPassword([Bind(Prefix = "Item1")] LoginViewModel loginModel, [Bind(Prefix = "Item2")] ForgetPasswordViewModel forgetModel)
        {
            var url = Request.Host;
            var model = (loginModel, forgetModel);
            //TODO : Try Catch eklenecek

            if (string.IsNullOrEmpty(forgetModel.Email))
            {
                ModelState.AddModelError(forgetModel.Email, "E-Posta Adresi Boş Bırakılamaz");
                return RedirectToAction("CreateUser", "UserAccount", model);
            }

            var user = await _userManager.FindByEmailAsync(forgetModel.Email);
            if (user == null)
            {
                ModelState.AddModelError(forgetModel.Email, "E-Posta Adresi Boş Bırakılamaz");
                TempData["Eposta"] = forgetModel.Email;
                return RedirectToAction("ForgetConfirm", "UserAccount");
            }

            var passwordResetTokenstring = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetUrl = "https://" + url.Value + Url.Action("ResetPassword", "UserAccount", new { userId = user.Id, token = passwordResetTokenstring });
            TempData["Eposta"] = forgetModel.Email;
            await _emailService.SendResetPasswordEmailAsync(new ResetPasswordEmailDto
            { Email = user.Email, Name = user.Name, Lastname = user.Lastname, ResetLink = resetUrl });
            //TODO : Mail Gönderilecek

            return RedirectToAction("ForgetConfirm", "UserAccount");
        }
        [AllowAnonymous]
        public IActionResult ResetPassword(string userId, string token)
        {
            TempData["UserId"] = userId;
            TempData["Token"] = token;

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //TODO : Try Catch eklenecek

            var userId = TempData["UserId"];
            var token = TempData["Token"];
            if (userId == null || token == null)
            {
                throw new Exception("İşlem sırasında bir hata meydana geldi");
            }
            var user = await _userManager.FindByIdAsync(userId!.ToString());
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı bilgilerine ulaşılamadı.");
                return View(model);
            }

            var res = await _userManager.ResetPasswordAsync(user, token!.ToString(), model.Password);
            if (res.Succeeded)
            {
                await _emailService.SendChangePasswordEmailAsync(new CustomEmailDto
                { Email = user.Email, Lastname = user.Lastname, Name = user.Name });
                return RedirectToAction("Index", "Dashboard");
            }

            ModelState.AddModelError(string.Empty, "Şifreniz değiştirilirken bazı sorunlarla karşılaşıldı");
            foreach (var error in res.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Code + " - " + error.Description);

            }
            return View(model);

        }
        [AllowAnonymous]
        public IActionResult ForgetConfirm()
        {
            var model = new ForgetPasswordViewModel { Email = TempData["Eposta"]?.ToString() };
            return View(model);
        }

        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //TODO : Try Catch eklenecek
            var currentUser = User;
            var user = await _userManager.GetUserAsync(User);

            try
            {
                var res = await _userManager.ChangePasswordAsync(user!, model.OldPassword, model.Password);
                if (!res.Succeeded)
                {
                    foreach (var identityError in res.Errors)
                    {
                        ModelState.AddModelError(string.Empty, identityError.Code + " - " + identityError.Description);
                    }
                }
                TempData["SuccessMessage"] = "Şifreniz Başarıyla değiştirildi";
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Şifre Değiştirilirken Bir Sorunla Karşılaşıldı");
                return View(model);
            }

            await _signInManager.SignOutAsync();
            return View();
        }
        public async Task<IActionResult> GetPass()
        {
            var currentUser = User;
            var userId = _userManager.GetUserId(currentUser);
            var user = await _userManager.FindByIdAsync(userId);

            var userSecret = BigInteger.Parse(user.SKey);
            var sKey=  Tools.BigIntToGuidStringPositive(userSecret).Replace("-", "");
            var getpassUser = await _getPassUserService.GetUserInfoBysKeyAsync(Tools.BigIntToGuidStringPositive(userSecret));
            var res = await _myDataService.GetMydataAsync(getpassUser.Data.Id, userSecret);
            
            if (!res.IsSuccess)
            {
                TempData["Error"] = res;
                return View("Error");
            }
            return View(res.Data);
        }
        public async Task<IActionResult> UserProfile()
        {
            var currentUser = User;
            var user = await _userManager.GetUserAsync(User);
            var model = new UserProfilInfoViewModel
            {
                Email = user.Email,
                Lastname = user.Lastname,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                Title = user.Title,
                TwoFactorEnebled = user.TwoFactorEnabled,

            };
            if (user.BirthDate != null)
            {
                model.BirthDate = user.BirthDate?.ToString("dd-MM-yyyy");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UserProfile(UserProfilInfoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var currentUser = User;
            var user = await _userManager.GetUserAsync(User);

            user!.Lastname = model.Lastname;
            user!.Name = model.Name;
            user!.PhoneNumber = model.PhoneNumber;
            user!.Title = model.Title;
            user!.Email = model.Email;
            if (!string.IsNullOrEmpty(model.BirthDate))
            {
                user!.BirthDate = DateTime.ParseExact(model.BirthDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                user!.BirthDate = null;
            }
            if (model.Avatar != null && model.Avatar.Length > 0)
            {
                var rootFolder = _fileProvider.GetDirectoryContents("wwwroot");

                var fileName = $"{Tools.CreateGuidStr()}{Path.GetExtension(model.Avatar.FileName)}";
                var newPath = Path.Combine(rootFolder.First(x => x.Name == "media").PhysicalPath!, $"avatar\\{fileName}");
                await using var stream = new FileStream(newPath, FileMode.Create);
                await model.Avatar.CopyToAsync(stream);
                user.Avatar = fileName;
                stream.Close();
            }
            //TODO : Try Catch eklenecek
            try
            {
                var res = await _userManager.UpdateAsync(user);
                if (res.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(user);
                    await _signInManager.SignOutAsync();

                    var deps = _crmSqlService.GetCrmUserDepartments(user!.Oid!);
                    var claims = deps.Data.Select(item => new Claim("Department", item.DepartmentName)).ToList();

                    await _signInManager.SignInWithClaimsAsync(user, true, claims);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Profil güncellenirken bir sorunla karşılaşıldı");
            }
            return View();
        }
        public async Task<IActionResult> DashboardPage(CrmSupportListViewModel model)
        {
            var openSupports = await _crmSupportService.Where(x => x.GCRecord == null && x._CreatedDateTime > new DateTime(2021, 01, 01) && x.IsCompleted != true);
            var supportUsers = _crmSqlService.GetCrmUserFullNameInfoList();
            var user = await _userManager.GetUserAsync(User);
            var userDepartments = _crmSqlService.GetCrmUserDepartments(user.Oid);
            if (!openSupports.IsSuccess)
            {
                _logger.LogError(new Exception(string.Join(", ", openSupports.Errors)), openSupports.Message);
                TempData["Error"] = openSupports;
                return View("Error");
            }

            var retVal = (openSupports.Data.ToList(), supportUsers.Data,userDepartments.Data);
            return View(retVal);
        }
        public async Task<IActionResult> UpdateUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı Bilgilerine Ulaşılamadı";
                return RedirectToAction("Index", "UserAccount");
            }
            var userSkey = string.IsNullOrEmpty(user!.SKey) ? "" : Tools.BigIntToGuidStringPositive(BigInteger.Parse(user!.SKey));
            var crmUsers = await _crmSelectListService.GetUserSelectList(true, user!.Oid!);
            ViewData["CrmUsers"] = crmUsers.Data;
            var getPassUsers = await _getPassUserService.GetUserSkeySelectListAsync(userSkey);
            ViewData["GetPassUsers"] = getPassUsers.Data;
            var model = new UpdateUserVievModel()
            {
                Name = user.Name,
                Email = user.Email,
                Lastname = user.Lastname,
                Title = user.Title,
                Id = user.Id
            };
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Yönetici,Yazılım")]
        public async Task<IActionResult> UpdateUser(UpdateUserVievModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(model.Id);
            var userSkey = string.IsNullOrEmpty(user!.SKey) ? "" : Tools.BigIntToGuidStringPositive(BigInteger.Parse(user!.SKey));
            var crmUsers = await _crmSelectListService.GetUserSelectList(true, user!.Oid!);
            var getPassUsers = await _getPassUserService.GetUserSkeySelectListAsync(userSkey);
            ViewData["GetPassUsers"] = getPassUsers.Data;
            ViewData["CrmUsers"] = crmUsers.Data;
            user.Name = model.Name;
            user.Email = model.Email;
            user.Lastname = model.Lastname;
            user.Title = model.Title;
            if (!string.IsNullOrEmpty(model.SKey))
            {
                user.SKey = Tools.GuidStringToBigIntPositive(model!.SKey!).ToString();
            }
            var res = await _userManager.UpdateAsync(user);
            if (res.Succeeded)
            {
                TempData["InfoMessage"] = $"{user.Name} {user.Lastname} isimli kullanıcı başarıyla güncellendi";
                return RedirectToAction("Index", "UserAccount");
            }
            else
            {
                ModelState.AddModelError("", string.Join(", ", res.Errors));
                return View(model);
            }

        }


        [Authorize(Roles = "Yönetici,Yazılım")]
        public async Task<IActionResult> ChangeUserStatus(string userId, UserStatusEnum status)
        {
            var user = await _userManager.FindByIdAsync(userId);
            user.Status = status;
            var res = await _userManager.UpdateAsync(user);
            if (!res.Succeeded)
            {
                TempData["ErrorMessage"] = string.Join(", ", res.Errors);
                return RedirectToAction("Index", "UserAccount");
            }
            TempData["InfoMessage"] = $"{user.Name} {user.Lastname} isimli kullanıcının durumu başarıyla değiştirildi";
            return RedirectToAction("Index", "UserAccount");
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
        [Authorize(Roles = "Yönetici,Yazılım")]
        public async Task<IActionResult> Roles()
        {
            var roles = await _roleManager.Roles
                .Select(x => new RoleListViewModel { Name = x.Name, Description = x.Description, Id = x.Id }).ToListAsync();
            return View(roles);
        }
        [Authorize(Roles = "Yönetici,Yazılım")]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Yönetici,Yazılım")]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var res = await _roleManager.CreateAsync(new AppRole { Name = model.Name, Description = model.Description, Id = Tools.CreateGuidStr() });

            if (res.Succeeded)
            {
                TempData["InfoMessage"] = $"{model.Name} rolü başarıyla eklendi";
                return RedirectToAction("Roles", "UserAccount");
            }
            else
            {
                ModelState.AddModelError(string.Empty, string.Join(", ", res.Errors));
                return View(model);
            }
        }

        [Authorize(Roles = "Yönetici,Yazılım")]
        public async Task<IActionResult> RoleUpdate(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                TempData["ErrorMessage"] = "Güncellenmek istenilen Rol Bilgilerine Ulaşılamadı";
                return RedirectToAction("Roles", "UserAccount");
            }

            var model = new UpdateRoleViewModel
            {
                Name = role.Name,
                Description = role.Description,
                Id = role.Id
            };
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Yönetici,Yazılım")]
        public async Task<IActionResult> RoleUpdate(UpdateRoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                TempData["ErrorMessage"] = "Güncellenmek istenilen Rol Bilgilerine Ulaşılamadı. Siz güncelleme yaparken silinmiş olabilir.";
                return RedirectToAction("Roles", "UserAccount");
            }

            role.Description = model.Description;
            role.Name = model.Name;
            var res = await _roleManager.UpdateAsync(role);
            if (res.Succeeded)
            {
                TempData["InfoMessage"] = "Rol başarıyla Güncellendi";
                return RedirectToAction("Roles", "UserAccount");
            }
            else
            {
                ModelState.AddModelError(string.Empty, string.Join(", ", res.Errors));
                return View(model);
            }
        }
        [Authorize(Roles = "Yönetici,Yazılım")]
        public async Task<IActionResult> DeleteRole(string roleId)
        {

            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                TempData["InfoMessage"] = "Role Başarıyla Silindi";
                return RedirectToAction("Roles", "UserAccount");
            }

            var res = await _roleManager.DeleteAsync(role);
            if (res.Succeeded)
            {
                TempData["InfoMessage"] = "Role Başarıyla Silindi";
                return RedirectToAction("Roles", "UserAccount");
            }
            else
            {
                TempData["InfoMessage"] = string.Join(", ", res.Errors);
                return RedirectToAction("Roles", "UserAccount");
            }
        }

        [Authorize(Roles = "Yönetici,Yazılım")]
        public async Task<IActionResult> AsignRoleToUser(string userId)
        {
            ViewBag.UserId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            var roles = await _roleManager.Roles.ToListAsync();
            var model = new List<AsignRoleToUserViewModel>();
            ViewData["UserInfo"] = $"{user.Name} {user.Lastname}";
            foreach (var item in roles)
            {
                var modelItem = new AsignRoleToUserViewModel
                {
                    Name = item.Name,
                    Description = item.Description,
                    Id = item.Id
                };
                var useRoles = await _userManager.GetRolesAsync(user!);
                modelItem.IsExist = useRoles.Contains(item.Name!);
                model.Add(modelItem);
            }
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Yönetici,Yazılım")]
        public async Task<IActionResult> AsignRoleToUser(List<AsignRoleToUserViewModel> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            ViewData["UserInfo"] = $"{user.Name} {user.Lastname}";
            foreach (var item in model)
            {
                if (item.IsExist)
                {
                    await _userManager.AddToRoleAsync(user!, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user!, item.Name);
                }
            }

            TempData["InfoMessage"] = "Kullanıcı Rolleri Başarıyla Güncellendi";
            return RedirectToAction("Index", "UserAccount");
        }
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [Authorize(Roles = "Yönetici,Yazılım")]
        public async Task<IActionResult> Claims()
        {
            var claimList = User.Claims.Select(x => new ClaimListViewModel
            {
                Issuer = x.Issuer,
                ClaimType = x.Type,
                ClaimValue = x.Value
            }).ToList();
            return View(claimList);
        }

        [Authorize(Roles = "Yönetici,Yazılım")]
        public async Task<IActionResult> AddClaimToUser(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["Error"] = Core.Dtos.Response.Fail(404, "User ID Bilgisi Alınamadı", "User ID Bilgisi Alınamadı", true);
                return View("Error");
            }
            var claims = await _claimService.GetAllAsync();
            var retVal = new List<SelectListItem>();

            foreach (var item in claims.Data)
            {
                retVal.Add(new SelectListItem { Text = item.Description, Value = item.Name, Selected = AuthorizationService.AuthorizeAsync(User, item.Name).Result.Succeeded });
            }
            //var user = await _userManager.FindByIdAsync(id);
            //var userRolles = await _userManager.GetRolesAsync(user);
            //var userClaims = await _userManager.GetClaimsAsync(user);
            //var claims = new List<string>();

            //foreach (var item in userRolles)
            //{
            //    var role = await _roleManager.FindByNameAsync(item);
            //    var roleClaims = await _roleManager.GetClaimsAsync(role);
            //    claims.AddRange(roleClaims.Select(x => x.Value));
            //}
            //claims.AddRange(userClaims.Select(x => x.Value));
            //claims = claims.Distinct().ToList();

            //var unSelectedClaims = (await _claimService.GetAllAsync()).Data.Where(x => !claims.Contains(x.Name)).ToList();


            TempData["CliamList"] = retVal;

            return View();

        }
        [HttpPost]
        [Authorize(Roles = "Yönetici,Yazılım")]
        public async Task<IActionResult> AddClaimToUser(AddClaimToUserViewModel model)
        {
            throw new Exception();
        }


        #region JsonResults
        [HttpGet]
        public async Task<JsonResult> GetUserInfoById(string id)
        {
            try
            {
                var user = _userService.GetUserInfoById(id);
                return Json(user);
            }
            catch (Exception ex)
            {
                return Json(Core.Dtos.Response.Fail(400, "Kullanıcı Bilgileri Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false));
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetUserInfoEmail(string eMail)
        {
            try
            {
                var user = _userService.GetUserInfoByEmail(eMail);
                return Json(user);
            }
            catch (Exception ex)
            {
                return Json(Core.Dtos.Response.Fail(400, "Kullanıcı Bilgileri Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false));
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetUserInfoByOid(string oid)
        {
            try
            {
                var user = _userService.GetUserInfoById(oid);
                return Json(user);
            }
            catch (Exception ex)
            {
                return Json(Core.Dtos.Response.Fail(400, "Kullanıcı Bilgileri Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false));
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetUserList(string id)
        {
            try
            {
                var users = _userService.GetUserActiveList();
                return Json(users);
            }
            catch (Exception ex)
            {
                return Json(Core.Dtos.Response.Fail(400, "Kullanıcı Listesi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false));
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetLineInfoGetPass(string lineId)
        {
            var currentUser = User;
            var userId = _userManager.GetUserId(currentUser);
            var user = await _userManager.FindByIdAsync(userId);

            var userSecret = BigInteger.Parse(user.SKey);
            var res = await _myDataService.GetPassGetLineInfoAsync(lineId, userSecret);
            if (!res.IsSuccess)
            {
                TempData["Error"] = res;
                return Json("Error");
            }
            return Json(res);
        }
        [HttpGet]
        public async Task<JsonResult> GetCrmUserSelectList(string selected = "")
        {
            try
            {
                var res = await _crmSelectListService.GetUserSelectList(false, selected);
                return Json(res);
            }
            catch (Exception ex)
            {
                return Json(Response<List<SelectListItem>>.FailData(400, "Kullanıcı Listesi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false));
            }
        }

        [HttpPost]
        public async Task<JsonResult> AddUserVacation(AddVacationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(Core.Dtos.Response.Fail(400, "Kayıt Sırasında Bir Hata İle Karşılaıldı", "", true));
            }
            try
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if (user == null)
                {
                    return Json(Response<List<SelectListItem>>.FailData(404, "Kullanıcı Listesi Alınırken Bir Sorunla Karşılaşıldı", "Kullanıcı Bilgilerine Ulaşılamadı", true));
                }
                var amount = Convert.ToDecimal(model.Amount.Replace('.', ','));
                user.Vacation = user.Vacation + amount;
                await _userManager.UpdateAsync(user);
                var historyModel = new AddVacationHistoryViewModel
                {
                    IsAdded = true,
                    Description = model.Description,
                    ReleatedUserId = user.Id,
                    VacationId = null,
                };
                var res = _vacationHistoryService.AddVacationHistoryAsync(historyModel);
                return Json(Core.Dtos.Response.Success(200, "Kullanıcı Listesi Alınırken Bir Sorunla Karşılaşıldı"));
            }
            catch (Exception ex)
            {
                return Json(Response<List<SelectListItem>>.FailData(400, "Kullanıcı Listesi Alınırken Bir Sorunla Karşılaşıldı", ex.Message, false));
            }
        }
        #endregion
    }
}
