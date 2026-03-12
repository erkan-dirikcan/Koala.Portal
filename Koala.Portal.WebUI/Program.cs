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
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
    });
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

builder.Services.AddDataProtection();//Id bilgisini �ifrelemek i�in, �u anda kullan�lm�yor
builder.Services.AddMappingConfExt();//Mapping Class Tan�mlamar�
builder.Services.AddIdentityConfExt(builder.Configuration);//Identity Ayarlar�
builder.Services.AddIdentityWithExt();// Identity �yelik Ayarlar� i�in
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();//D��ar�dan context e eri�im i�in
builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));//Dosya y�kleme i�lemleri i�in
builder.Services.AddApplicationServices();//Uygulama servisleri i�in extention metot
builder.Services.AddApplicationRepositories();//Uygulama �zellikleri i�in extention metot
builder.Services.AddApplicationProviders();//Uygulama Yetki Kurallar�n� Y�klemek i�in extention metot
builder.Services.AddAuthorizationRules(context);//Uygulama Sa�lay�c�lar i�in extention metot

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
app.UseStaticFiles();//Root klas�r�n� kullan�ma a�ar
app.UseRouting();
//app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
