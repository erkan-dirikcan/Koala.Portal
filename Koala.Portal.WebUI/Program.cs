using Hangfire;
using Koala.Portal.Core.Services;
using Koala.Portal.Repository;
using Koala.Portal.WebUI.Extentions;
using Koala.Portal.WebUI.Requirements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;


//var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
//logger.Debug("Init Main");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.Configure<EmailSettingViewModel>(builder.Configuration.GetSection("EmailSettings"));
//builder.Host.UseNLog();


builder.Services.AddDbContext<AppDbContext>(options =>
{

    options.UseSqlServer(builder.Configuration.GetConnectionString("PortalConnection"),o=>o.UseCompatibilityLevel(150));
});
builder.Services.AddDbContext<SistemCrmContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CrmConnection"), o => o.UseCompatibilityLevel(150));
    options.UseLazyLoadingProxies();
});
builder.Services.AddDbContext<SistemCryptorContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GetPassConnection"));
});

builder.Services.AddHangfire(options =>
{
    options.UseSqlServerStorage(builder.Configuration.GetConnectionString("PortalConnection"));
});


var context = builder.Services.BuildServiceProvider()
                       .GetService<AppDbContext>();

builder.Services.AddDataProtection();//Id bilgisini þifrelemek için, Þu anda kullanýlmýyor
builder.Services.AddMappingConfExt();//Mapping Class Tanýmlamarý
builder.Services.AddIdentityConfExt(builder.Configuration);//Identity Ayarlarý
builder.Services.AddIdentityWithExt();// Identity Üyelik Ayarlarý için
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();//Dýþarýdan context e eriþim için
builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));//Dosya yükleme iþlemleri için
builder.Services.AddApplicationServices();//Uygulama servisleri için extention metot
builder.Services.AddApplicationRepositories();//Uygulama Özellikleri için extention metot
builder.Services.AddApplicationProviders();//Uygulama Yetki Kurallarýný Yüklemek için extention metot
builder.Services.AddAuthorizationRules(context);//Uygulama Saðlayýcýlar için extention metot

//builder.Services.AddScoped<IClaimsTransformation, UserClaimProvider>();
builder.Services.AddScoped<IAuthorizationHandler, DepartmentRequirementHandler>();



var app = builder.Build();

//Seed Data
//using (var scope = app.Services.CreateScope())
//{
//    var roleManager = scope.ServiceProvider.GetService<RoleManager<AppRole>>();
//    var userManager = scope.ServiceProvider.GetService<UserManager<AppUser>>();
//    await PermitionSeed.Seed(roleManager!, userManager!);
//    //await ModuleSeed.Seed();
//}
app.MapHangfireDashboard("/Hangfire");

using (var scope = app.Services.CreateScope())
{
    var hangfireService = scope.ServiceProvider.GetService<IBackgroundServices>();
    hangfireService.SencronFirmJob();
    //await ModuleSeed.Seed();
}
//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetService<AppDbContext>();
//    builder.Services.AddAuthorizationRules(context);
//    await PermitionSeed.Seed(roleManager!, userManager!);
//}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Dashboard/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();


//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(
//        Path.Combine(builder.Environment.ContentRootPath, "Template")),
//    RequestPath = "/Template"
//});
app.UseStaticFiles();//Root klasörünü kullanýma açar
app.UseRouting();
//app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
