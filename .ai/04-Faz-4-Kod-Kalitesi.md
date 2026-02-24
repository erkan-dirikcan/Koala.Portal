# Faz 4 - Kod Kalitesi ve İyileştirmeler

## Öncelik: DÜŞÜK 🟢
Bu faz, kod kalitesini artırmak için iyileştirmeleri içerir.

---

## 1. Naming Convention Düzeltmeleri

### 1.1 HelpDeskProblemCatogory → HelpDeskProblemCategory

#### Sorun
```csharp
// Şu anki kullanım (Yanlış)
public class HelpDeskProblemCatogory
{
    public string CatogoryId { get; set; }
    public string HelpDeskProblemId { get; set; }
}

// Tablo adı
public DbSet<HelpDeskProblemCatogory> HelpDeskProblemCatogories { get; set; }
```

#### Çözüm Seçenekleri

**Seçenek 1: Yeni Migration ile Tablo Adı Değişikliği**
```csharp
// Migration
migrationBuilder.RenameTable(
    name: "HelpDeskProblemCatogory",
    newName: "HelpDeskProblemCategory");

migrationBuilder.RenameColumn(
    name: "CatogoryId",
    table: "HelpDeskProblemCategory",
    newName: "CategoryId");
```

**Seçenek 2: Attribute ile Tablo Adı Belirleme**
```csharp
[Table("HelpDeskProblemCatogory")]  // Veritabanı adı koruyor
public class HelpDeskProblemCategory  // Sınıf adı düzeltiliyor
{
    [Column("CatogoryId")]
    public string CategoryId { get; set; }

    [Column("HelpDeskProblemId")]
    public string HelpDeskProblemId { get; set; }
}
```

### Görevler
- [ ] Hangi çözümün uygun olduğuna karar ver
- [ ] Sınıf adını düzelt
- [ ] Property adını düzelt
- [ ] Migration oluştur (Seçenek 1) veya Attribute ekle (Seçenek 2)
- [ ] Tüm referansları güncelle

**Tahmini Süre**: 30 dakika

---

### 1.2 HelpDeskSolution Tablo Adı

#### Sorun
```csharp
// Entity sınıfı
public class HelpDeskSolition  // Yanlış yazım

// Tablo adı
modelBuilder.Entity<HelpDeskSolution>()
    .ToTable("HelpDeskSolition");  // Yanlış yazım
```

#### Çözüm
```csharp
// Sınıf adı düzelt
public class HelpDeskSolution

// Migration ile tablo adı düzeltme
migrationBuilder.RenameTable(
    name: "HelpDeskSolition",
    newName: "HelpDeskSolution");
```

### Görevler
- [ ] Sınıf adını `HelpDeskSolution` olarak düzelt
- [ ] Migration oluştur
- [ ] Tüm referansları güncelle

**Tahmini Süre**: 20 dakika

---

## 2. Kod Organizasyonu

### 2.1 ViewModels Klasör Yapısı

#### Mevcut Durum
```
Koala.Portal/Models/ViewModels/UserViewModels.cs  // Sadece User
Koala.Portal.WebUI/Models/ViewModels/              // Yok
```

#### Önerilen Yapı
```
Koala.Portal.Core/ViewModels/
├── Account/
│   ├── LoginViewModel.cs
│   ├── RegisterViewModel.cs
│   ├── ResetPasswordViewModel.cs
│   └── ForgetPasswordViewModel.cs
├── Project/
│   ├── ProjectListViewModel.cs
│   ├── ProjectDetailViewModel.cs
│   ├── CreateProjectViewModel.cs
│   └── UpdateProjectViewModel.cs
├── Agenda/
│   ├── AgendaListViewModel.cs
│   ├── CreateAgendaViewModel.cs
│   └── UpdateAgendaViewModel.cs
├── Vacation/
│   ├── VacationRequestViewModel.cs
│   ├── VacationListViewModel.cs
│   └── VacationHistoryViewModel.cs
└── HelpDesk/
    ├── HelpDeskProblemViewModel.cs
    ├── HelpDeskSolutionViewModel.cs
    └── HelpDeskCategoryViewModel.cs
```

### Görevler
- [ ] `Koala.Portal.Core/ViewModels` klasörü oluştur
- [ ] Mevcut `UserViewModels.cs` dosyasını böl
- [ ] Yeni klasör yapısına taşı
- [ ] Namespace'leri güncelle
- [ ] Using ifadelerini güncelle

**Tahmini Süre**: 1 saat

---

### 2.2 DTO Klasör Yapısı

#### Mevcut Durum
```
Koala.Portal.Core/Dtos/
├── SelectListDto.cs
├── UserAgentDto.cs
├── ErrorViewModel.cs
├── ErrorDto.cs
├── EmailDto.cs
├── Response.cs
└── Enums.cs
```

#### Önerilen Yapı
```
Koala.Portal.Core/Dtos/
├── Base/
│   ├── BaseDto.cs
│   ├── BaseViewModel.cs
│   └── PagedDto.cs
├── Account/
│   ├── UserDto.cs
│   ├── RoleDto.cs
│   └── ClaimDto.cs
├── Project/
│   ├── ProjectDto.cs
│   ├── ProjectLineDto.cs
│   ├── ProjectLineWorkDto.cs
│   └── ProjectFileDto.cs
├── Agenda/
│   ├── AgendaDto.cs
│   └── AgendaTypeDto.cs
├── Vacation/
│   ├── VacationRequestDto.cs
│   └── VacationHistoryDto.cs
├── HelpDesk/
│   ├── HelpDeskProblemDto.cs
│   ├── HelpDeskSolutionDto.cs
│   └── HelpDeskCategoryDto.cs
├── Application/
│   ├── ApplicationDto.cs
│   ├── ApplicationLicenceDto.cs
│   └── ApplicationModuleDto.cs
├── Transaction/
│   ├── TransactionDto.cs
│   ├── TransactionItemDto.cs
│   └── TransactionTypeDto.cs
└── Common/
    ├── SelectListDto.cs
    ├── ResponseDto.cs
    ├── ErrorDto.cs
    └── Enums.cs
```

### Görevler
- [ ] Yeni klasör yapısını oluştur
- [ ] Mevcut DTO'ları yeni yapısına taşı
- [ ] Namespace'leri güncelle

**Tahmini Süre**: 45 dakika

---

## 3. Generic Repository Pattern

### Mevcut Durum
Her entity için ayrı repository sınıfı mevcut.

### Önerilen İyileştirme

#### Generic Base Repository
```csharp
public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(string id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(string id);
}

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<T> GetByIdAsync(string id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public virtual async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(string id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
```

#### Specific Repository (Example)
```csharp
public interface IProjectRepository : IRepository<Project>
{
    Task<IEnumerable<Project>> GetByFirmIdAsync(string firmId);
    Task<Project> GetWithLinesAsync(string id);
}

public class ProjectRepository : Repository<Project>, IProjectRepository
{
    public ProjectRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Project>> GetByFirmIdAsync(string firmId)
    {
        return await _dbSet
            .Include(p => p.Firm)
            .Where(p => p.FirmId == firmId)
            .ToListAsync();
    }

    public async Task<Project> GetWithLinesAsync(string id)
    {
        return await _dbSet
            .Include(p => p.ProjectLines)
            .Include(p => p.ProjectFiles)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}
```

### Görevler
- [ ] Generic repository interface oluştur
- [ ] Generic repository base class oluştur
- [ ] Mevcut repository'leri refactor et
- [ ] Service katmanını güncelle

**Tahmini Süre**: 3 saat

---

## 4. Unit of Work Pattern

### Önerilen Uygulama

```csharp
public interface IUnitOfWork : IDisposable
{
    IProjectRepository Projects { get; }
    IProjectLineRepository ProjectLines { get; }
    IUserRepository Users { get; }
    IVacationRepository Vacations { get; }
    // ... diğer repository'ler

    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IDbContextTransaction _transaction;
    private Dictionary<Type, object> _repositories;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        _repositories = new Dictionary<Type, object>();
    }

    public IProjectRepository Projects =>
        GetRepository<IProjectRepository, ProjectRepository>();

    private T GetRepository<T, R>() where R : Repository<T>
    {
        if (_repositories.TryGetValue(typeof(T), out var repo))
            return (T)repo;

        var newRepo = (T)Activator.CreateInstance(
            typeof(R),
            _context);
        _repositories[typeof(T)] = newRepo;
        return newRepo;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await _context.Database.RollbackTransactionAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
```

### Görevler
- [ ] IUnitOfWork interface oluştur
- [ ] UnitOfWork class oluştur
- [ ] Service katmanında UnitOfWork kullan
- [ ] Transaction yönetimini ekle

**Tahmini Süre**: 2 saat

---

## 5. Exception Handling

### Global Exception Handler

```csharp
public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Unhandled exception occurred");

        var response = httpContext.Response;
        response.ContentType = "application/json";

        var errorResponse = new ErrorResponse
        {
            StatusCode = response.StatusCode,
            Message = exception.Message,
            Detail = exception.StackTrace
        };

        switch (exception)
        {
            case NotFoundException:
                response.StatusCode = 404;
                errorResponse.Message = "Resource not found";
                break;
            case ValidationException:
                response.StatusCode = 400;
                errorResponse.Message = "Validation failed";
                break;
            case UnauthorizedAccessException:
                response.StatusCode = 401;
                errorResponse.Message = "Unauthorized access";
                break;
            default:
                response.StatusCode = 500;
                errorResponse.Message = "An internal server error occurred";
                break;
        }

        await response.WriteAsJsonAsync(errorResponse, cancellationToken);
        return true;
    }
}

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string Detail { get; set; }
}
```

### Custom Exceptions
```csharp
public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
    public NotFoundException(string resourceName, string id)
        : base($"{resourceName} with id {id} not found") { }
}

public class ValidationException : Exception
{
    public ValidationException(string message) : base(message) { }
    public ValidationException(Dictionary<string, string[]> errors)
        : base("Validation failed") { }
}

public class BusinessRuleException : Exception
{
    public BusinessRuleException(string message) : base(message) { }
}
```

### Görevler
- [ ] GlobalExceptionHandler oluştur
- [ ] Custom exception sınıfları oluştur
- [ ] Program.cs'ye handler ekle
- [ ] Service katmanında exception kullan

**Tahmini Süre**: 1.5 saat

---

## 6. Logging İyileştirmesi

### Structured Logging

```csharp
public class ProjectService : BaseService<Project>
{
    private readonly ILogger<ProjectService> _logger;

    public ProjectService(
        IRepository<Project> repository,
        IUnitOfWork unitOfWork,
        ILogger<ProjectService> logger) : base(repository, unitOfWork)
    {
        _logger = logger;
    }

    public override async Task<bool> CreateAsync(CreateProjectDto dto)
    {
        _logger.LogInformation("Creating project with code: {ProjectCode}", dto.ProjectCode);

        try
        {
            var result = await base.CreateAsync(dto);

            _logger.LogInformation(
                "Project created successfully with ID: {ProjectId}",
                result.Id);

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "Failed to create project with code: {ProjectCode}",
                dto.ProjectCode);
            throw;
        }
    }
}
```

### Görevler
- [ ] Tüm service'lere ILogger ekle
- [ ] Critical işlemlerde log ekle
- [ ] Structured logging kullan
- [ ] Log seviyelerini doğru ayarla

**Tahmini Süre**: 2 saat

---

## 7. Configuration Management

### appsettings.json Yapısı

```json
{
  "ConnectionStrings": {
    "PortalConnection": "...",
    "CrmConnection": "..."
  },
  "EmailSettings": {
    "SmtpServer": "smtp.example.com",
    "Port": 587,
    "UseSsl": true,
    "Username": "user@example.com",
    "Password": "",
    "FromEmail": "noreply@example.com",
    "FromName": "Koala Portal"
  },
  "FileStorageSettings": {
    "UploadPath": "wwwroot/uploads",
    "MaxFileSizeMB": 10,
    "AllowedExtensions": [".jpg", ".png", ".pdf", ".doc", ".docx"]
  },
  "SecuritySettings": {
    "PasswordRequirement": {
      "MinLength": 8,
      "RequireUppercase": true,
      "RequireLowercase": true,
      "RequireDigit": true,
      "RequireSpecialChar": true
    },
    "JwtSettings": {
      "SecretKey": "",
      "ExpiryMinutes": 60
    }
  },
  "ExternalServices": {
    "CrmService": {
      "BaseUrl": "https://crm.example.com/api",
      "ApiKey": "",
      "Timeout": 30
    },
    "GoogleCalendar": {
      "ClientId": "",
      "ClientSecret": ""
    }
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```

### Settings Classes
```csharp
public class EmailSettings
{
    public string SmtpServer { get; set; }
    public int Port { get; set; }
    public bool UseSsl { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string FromEmail { get; set; }
    public string FromName { get; set; }
}

public class FileStorageSettings
{
    public string UploadPath { get; set; }
    public int MaxFileSizeMB { get; set; }
    public string[] AllowedExtensions { get; set; }
}

// Program.cs
builder.Services.Configure<EmailSettings>(
    builder.Configuration.GetSection("EmailSettings"));
builder.Services.Configure<FileStorageSettings>(
    builder.Configuration.GetSection("FileStorageSettings"));
```

### Görevler
- [ ] appsettings.json'yu reorganize et
- [ ] Settings sınıfları oluştur
- [ ] Program.cs'ye configuration ekle
- [ ] Service'lerde settings kullan

**Tahmini Süre**: 1.5 saat

---

## 8. API Documentation (Swagger)

### Swagger Configuration

```csharp
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Koala Portal API",
        Version = "v1",
        Description = "Koala Portal Web API Documentation",
        Contact = new OpenApiContact
        {
            Name = "Koala Software",
            Email = "info@koala.com.tr",
            Url = new Uri("https://koala.com.tr")
        }
    });

    // JWT Authentication
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

    // XML Comments
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Koala Portal API v1");
    options.RoutePrefix = "api/docs";
});
```

### Görevler
- [ ] Swagger configuration ekle
- [ ] XML documentation comments ekle
- [ ] API action'larına attribute'leri ekle
- [ ] Test edin

**Tahmini Süre**: 1 saat

---

## 9. Code Documentation

### XML Documentation Comments

```csharp
/// <summary>
/// Proje yönetim işlemlerini gerçekleştiren service sınıfı
/// </summary>
public class ProjectService : BaseService<Project>
{
    /// <summary>
    /// Firma ID'sine göre projeleri getiren metot
    /// </summary>
    /// <param name="firmId">Firma unique identifier</param>
    /// <param name="includeDeleted">Silinen projeler dahil edilsin mi</param>
    /// <returns>Proje listesi</returns>
    /// <exception cref="NotFoundException">Firma bulunamazsa</exception>
    public async Task<IEnumerable<ProjectDto>> GetByFirmIdAsync(
        string firmId,
        bool includeDeleted = false)
    {
        // Implementation
    }
}
```

### Görevler
- [ ] Tüm service'lere XML comments ekle
- [ ] Tüm DTO'lara XML comments ekle
- [ ] Controller'lara XML comments ekle
- [ ] Entity'lere XML comments ekle

**Tahmini Süre**: 4 saat

---

## 10. Performance Improvements

### 10.1 Caching

```csharp
// Distributed Cache (Redis)
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
    options.InstanceName = "KoalaPortal_";
});

// In-Memory Cache
builder.Services.AddMemoryCache();

// Service'de kullanımı
public class SelectListService
{
    private readonly IMemoryCache _cache;
    private readonly TimeSpan _cacheDuration = TimeSpan.FromHours(1);

    public async Task<IEnumerable<SelectListDto>> GetVacationTypesAsync()
    {
        return await _cache.GetOrCreateAsync("VacationTypes", async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = _cacheDuration;
            return await _vacationTypesRepository.GetAllAsync();
        });
    }
}
```

### 10.2 Response Caching

```csharp
[ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
public IActionResult GetSelectLists()
{
    // Implementation
}
```

### Görevler
- [ ] Redis cache configuration ekle
- [ ] SelectListService'e cache ekle
- [ ] Static data için cache kullan
- [ ] Response caching ekle

**Tahmini Süre**: 2 saat

---

## Faz 4 Özeti

| Konu | Tahmini Süre | Öncelik | Durum |
|------|--------------|---------|-------|
| Naming Convention Düzeltmeleri | 50 dk | Orta | ⬜ |
| Kod Organizasyonu | 1.75 saat | Orta | ⬜ |
| Generic Repository Pattern | 3 saat | Düşük | ⬜ |
| Unit of Work Pattern | 2 saat | Düşük | ⬜ |
| Exception Handling | 1.5 saat | Orta | ⬜ |
| Logging İyileştirmesi | 2 saat | Orta | ⬜ |
| Configuration Management | 1.5 saat | Düşük | ⬜ |
| API Documentation (Swagger) | 1 saat | Düşük | ⬜ |
| Code Documentation | 4 saat | Düşük | ⬜ |
| Performance Improvements | 2 saat | Düşük | ⬜ |

**Toplam Tahmini Süre**: ~19 saat

---

## Proje Tamamlama Kontrol Listesi

### Faz 1 - Kritik Eksiklikler
- [ ] ApplicationUpdate Migration
- [ ] ResetPasswordViewModel
- [ ] Duplicate Code Temizliği
- [ ] EmailTemplate CRUD
- [ ] ProjectFiles Yönetimi
- [ ] VacationHistory Sayfası

### Faz 2 - DTO ve ViewModel'ler
- [ ] Identity/Kullanıcı DTO'ları (3)
- [ ] Proje Yönetimi DTO'ları (13)
- [ ] Agenda DTO'ları (5)
- [ ] İzin Yönetimi DTO'ları (7)
- [ ] Yardım Masası DTO'ları (7)
- [ ] Uygulama/Lisans DTO'ları (5)
- [ ] İşlem Yönetimi DTO'ları (6)
- [ ] Diğer DTO'lar (17)

### Faz 3 - Controllers ve Views
- [ ] EmailTemplate Controller & Views
- [ ] CrmDepartment Controller & Views
- [ ] CrmFirm Controller & Views
- [ ] Project Files Management
- [ ] Agenda CRUD Views
- [ ] Licence Approval System
- [ ] Vacation History Page
- [ ] Support File Management
- [ ] Project Person Management
- [ ] Project Line Note Management
- [ ] Application Updates
- [ ] Application Modules
- [ ] Phone Number Management

### Faz 4 - Kod Kalitesi
- [ ] Naming Convention Düzeltmeleri
- [ ] Kod Organizasyonu
- [ ] Generic Repository Pattern
- [ ] Unit of Work Pattern
- [ ] Exception Handling
- [ ] Logging İyileştirmesi
- [ ] Configuration Management
- [ ] API Documentation
- [ ] Code Documentation
- [ ] Performance Improvements

---

### Genel İstatistikler

| Kategori | Toplam | Tamamlanan | % |
|----------|--------|------------|---|
| **Entity'ler** | 38 | 38 | 100% |
| **Migration'lar** | 17 | 16 | 94% |
| **Repository'ler** | ~30 | ~30 | 100% |
| **Service'ler** | ~30 | ~30 | 100% |
| **DTO'lar** | ~63 | 7 | 11% |
| **ViewModels** | ~30 | 5 | 17% |
| **Controllers** | ~32 | 24 | 75% |
| **Views** | ~120 | ~85 | 71% |

**Genel Tamamlanma**: ~%55

---

### Sonraki Fazlar
- [Faz 1 - Kritik Eksiklikler](./01-Faz-1-Kritik-Eksiklikler.md)
- [Faz 2 - DTO ve ViewModel'ler](./02-Faz-2-DTO-ViewModel.md)
- [Faz 3 - Controllers ve Views](./03-Faz-3-Controllers-Views.md)

---

**Not**: Bu analiz ve fazlar, mevcut kod yapısına dayanmaktadır. Gerçek ihtiyaçlara göre öncelikler değişebilir. Her faz tamamlandıktan sonra bir sonraki faza geçilmesi önerilir.
