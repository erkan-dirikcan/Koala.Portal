using Hangfire;
using Koala.Portal.Repository;
using Koala.Portal.WebApi.Extentions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Sadece Identity Serverdan aldýðýnýz token bilgisini Bearer Kullanmadan yapýþtýrýn",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {jwtSecurityScheme, Array.Empty<string>()}
    });

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v01.00",
        Contact = new OpenApiContact
        {
            Email = "info@sistem-bilgi.com",
            Name = "Sistem Bilgisayar",
            Url = new Uri("https://www.sistem-bilgi.com")
        },
        Description = "Sistem Bilgisayar Tarafýnda Kendi Ýhtiyaçlarý Doðrultusunda Oluþturulmuþ uygulama Apisi",
        License = new OpenApiLicense { Name = "Sistem Bilgisayar Tarafýndan Hazýrlanmýþtýr", Url = new Uri("Https://sistem-bilgi.com") },
        Title = "Sistem Bilgisayar Koala Portal"
    });
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "Koala.Portal.WebApi.xml");

    c.IncludeXmlComments(filePath);

});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PortalConnection"));
});
builder.Services.AddDbContext<SistemCrmContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CrmConnection"));
});
builder.Services.AddHangfire(options =>
{
    options.UseSqlServerStorage(builder.Configuration.GetConnectionString("PortalConnection"));
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
    {
        opts.Authority = "http://identity.sistem-koala.com:34982/";
        opts.Audience = "Rs-08001";
        opts.RequireHttpsMetadata = false;
    });

builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy("BaseClaim", policy => { policy.RequireClaim("scope", "Sc-080100"); });
    opts.AddPolicy("3CX", policy => { policy.RequireClaim("scope", "Sc080101"); });
    opts.AddPolicy("LicenceRequest", policy => { policy.RequireClaim("scope", "Sc-080102"); });
});



//builder.Services.AddScoped<IApplicationsRepository, ApplicationsRepository>();
//builder.Services.AddScoped<IUnitOfWork<AppDbContext>, UnitOfWork<AppDbContext>>();
//builder.Services.AddHangfireServer();

builder.Services.AddMappingConfExt();//Mapping Class Tanýmlamarý
builder.Services.AddApplicationServices();//Uygulama servisleri için extention metot
builder.Services.AddApplicationRepositories();//Uygulama Özellikleri için extention metot
builder.Services.AddApplicationProviders();//Uygulama Saðlayýcýlar için extention metot

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
    app.UseSwagger();
    app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "Sistem Bilgisayar Koala Portal Uygulamasý v01.00"));

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
