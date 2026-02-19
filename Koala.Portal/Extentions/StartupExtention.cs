using Koala.Portal.WebUI.Models;

namespace Koala.Portal.WebUI.Extentions
{
    public static class StartupExtention
    {
        public static void AddIdentityWithExt(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;

                options.Password.RequireDigit=true;
                options.Password.RequireLowercase=true;
                options.Password.RequireUppercase=true;
                options.Password.RequireNonAlphanumeric=true;
                options.Password.RequiredUniqueChars=3;
                options.Password.RequiredLength=8;

                options.Lockout.MaxFailedAccessAttempts =3;
                options.Lockout.DefaultLockoutTimeSpan =TimeSpan.FromMinutes(15);
            }).AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
