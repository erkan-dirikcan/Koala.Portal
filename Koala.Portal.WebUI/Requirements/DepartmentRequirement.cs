using Koala.Portal.Core.CrmServices;
using Koala.Portal.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Koala.Portal.WebUI.Requirements
{
    public class DepartmentRequirement : IAuthorizationRequirement
    {
        public string Department { get; set; }

    }

    public class DepartmentRequirementHandler : AuthorizationHandler<DepartmentRequirement>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICrmSqlService _crmSqlService;

        public DepartmentRequirementHandler(UserManager<AppUser> userManager, ICrmSqlService crmSqlService)
        {
            _userManager = userManager;
            _crmSqlService = crmSqlService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DepartmentRequirement requirement)
        {
            if (!context.User.HasClaim(x=>x.Type=="Department"))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var departments = context.User.FindAll("Department");
            if (departments.Any(x => x.Value == requirement.Department))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
            context.Fail();
            return Task.CompletedTask;
            //var userPrincipal = context.User;
            //var user = _userManager.GetUserAsync(userPrincipal).Result;
            //if (string.IsNullOrEmpty(user!.Oid))
            //{
            //    context.Fail();
            //    return Task.CompletedTask;
            //}

            //context.Succeed(requirement);
            //return Task.CompletedTask;

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
        }
    }
}
