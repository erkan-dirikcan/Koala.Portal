namespace Koala.Portal.WebUI.ClaimProviders
{
    //public class UserClaimProvider : IClaimsTransformation
    //{
    //    private readonly UserManager<AppUser> _userManager;
    //    private readonly ICrmSqlService _crmSqlService;

    //    public UserClaimProvider(UserManager<AppUser> userManager, ICrmSqlService crmSqlService)
    //    {
    //        _userManager = userManager;
    //        _crmSqlService = crmSqlService;
    //    }

    //    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    //    {
    //        var identityUser = principal.Identity as ClaimsIdentity;
    //        var user = await _userManager.FindByNameAsync(identityUser!.Name!);
    //        if (user == null)
    //        {
    //            return principal;
    //        }
    //        if (user.Oid == null)
    //        {
    //            return principal;
    //        }
    //        if (!principal.HasClaim(x => x.Type == "Department"))
    //        {
    //            var deps = _crmSqlService.GetCrmUserDepartments(user!.Oid!);
    //            if (!deps.IsSuccess)
    //            {
    //                return principal;
    //            }
    //            var departments = new List<Claim>();
    //            foreach (var item in deps.Data)
    //            {
    //                departments.Add(new Claim("Department", item.DepartmentName));
    //            }
    //            identityUser.AddClaims(departments);
    //        }


    //        return principal;
    //    }
    //}
}
