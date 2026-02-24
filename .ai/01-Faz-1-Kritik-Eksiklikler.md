# Faz 1 - Kritik Eksiklikler ve Acil Tamamlanması Gerekenler

## Öncelik: YÜKSEK 🔴
Bu fazdaki görevler uygulamanın temel işlevselliği için kritiktir ve en kısa sürede tamamlanmalıdır.

---

## 1. ApplicationUpdate Entity'si İçin Migration

### Durum
- **Entity**: `Koala.Portal.Core/Models/ApplicationUpdate.cs` mevcut
- **Migration**: Entity migration snapshot'ında yok ❌
- **Tablo Adı**: `ApplicationUpdate`

### Entity Yapısı
```csharp
public class ApplicationUpdate
{
    public string Id { get; set; }
    public string ApplicationGuid { get; set; }
    public string Version { get; set; }
    public string UpdateDescription { get; set; }
    public string UpdateFiles { get; set; }
    public DateTime CreateDate { get; set; }
    public string CreateUser { get; set; }
}
```

### Görevler
- [ ] `Add-Migration AddApplicationUpdate` komutu ile migration oluştur
- [ ] Migration'ı incele ve doğrula
- [ ] `Update-Database` ile veritabanını güncelle
- [ ] DbContext'e entity'yi ekle (yoksa)

### Tahmini Süre: 15 dakika

---

## 2. ResetPasswordViewModel Tamamlanması

### Durum
- **Konum**: `Koala.Portal/Models/ViewModels/UserViewModels.cs:75-78`
- **Sorun**: Sınıf boş, property eksik ❌

### Mevcut Kod
```csharp
public class ResetPasswordViewModel
{
    // BOŞ - Tamamlanması gerekiyor
}
```

### Gerekli Property'ler
```csharp
public class ResetPasswordViewModel
{
    [Required(ErrorMessage = "E-Posta Alanı Boş Bırakılamaz")]
    [Display(Name = "E-Posta")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Token Alanı Boş Bırakılamaz")]
    public string Token { get; set; }

    [Required(ErrorMessage = "Yeni Şifre Alanı Boş Bırakılamaz")]
    [Display(Name = "Yeni Şifre")]
    [DataType(DataType.Password)]
    [StringLength(100, ErrorMessage = "Şifre en az {2} karakter olmalıdır.", MinimumLength = 8)]
    public string NewPassword { get; set; }

    [Required(ErrorMessage = "Şifre Tekrar Alanı Boş Bırakılamaz")]
    [Display(Name = "Şifre Tekrar")]
    [DataType(DataType.Password)]
    [Compare("NewPassword", ErrorMessage = "Şifreler eşleşmiyor")]
    public string ConfirmPassword { get; set; }
}
```

### Görevler
- [ ] ResetPasswordViewModel sınıfını yukarıdaki property'lerle tamamla
- [ ] Validation attribute'lerini ekle
- [ ] Turkish error messages kullan

### Tahmini Süre: 10 dakika

---

## 3. Duplicate Code Temizliği

### Durum
Aynı sınıflar iki farklı klasörde mevcut ❌

### Duplicate'ler
| Sınıf | Konum 1 | Konum 2 | Aksiyon |
|-------|---------|---------|---------|
| AppUser | `Koala.Portal/Models/AppUser.cs` | `Koala.Portal.Core/Models/AppUser.cs` | Core'i koru, diğerini sil |
| AppRole | `Koala.Portal/Models/AppRole.cs` | `Koala.Portal.Core/Models/AppRole.cs` | Core'i koru, diğerini sil |
| CommonProperty | `Koala.Portal/Models/CommonProperty.cs` | `Koala.Portal.Core/Models/CommonProperty.cs` | Core'i koru, diğerini sil |

### Görevler
- [ ] `Koala.Portal/Models` altındaki duplicate sınıfları sil
- [ ] `Koala.Portal` projesindeki using ifadelerini güncelle
- [ ] Build yaparak hataları kontrol et
- [ ] Test çalıştır (varsa)

### Tahmini Süre: 20 dakika

---

## 4. EmailTemplate CRUD İşlemleri

### Durum
- **Entity**: `EmailTemplate` mevcut ✅
- **Repository**: `MailTemplateRepository` mevcut ✅
- **Service**: `MailTemplateService` mevcut ✅
- **Controller**: ❌ Eksik
- **Views**: ❌ Eksik

### Entity Yapısı
```csharp
public class EmailTemplate
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public DateTime CreateTime { get; set; }
    public string CreateUser { get; set; }
    public DateTime UpdateTime { get; set; }
    public string UpdateUser { get; set; }
    public int Status { get; set; }
}
```

### Görevler

#### Controller Oluştur
- [ ] `EmailTemplateController.cs` oluştur
- [ ] Action'lar: Index, Create, Edit, Delete, Details
- [ ] Authorize attribute'leri ekle

#### Views Oluştur
- [ ] `Views/EmailTemplate/Index.cshtml` - Liste sayfası
- [ ] `Views/EmailTemplate/Create.cshtml` - Oluşturma sayfası
- [ ] `Views/EmailTemplate/Edit.cshtml` - Düzenleme sayfası
- [ ] `Views/EmailTemplate/Delete.cshtml` - Silme onayı
- [ ] `Views/EmailTemplate/Details.cshtml` - Detay sayfası

#### ViewModels Oluştur
- [ ] `EmailTemplateListViewModel`
- [ ] `CreateEmailTemplateViewModel`
- [ ] `UpdateEmailTemplateViewModel`

### Tahmini Süre: 2 saat

---

## 5. ProjectFiles Dosya Yönetimi

### Durum
- **Entity**: `ProjectFiles` mevcut ✅
- **Repository**: `ProjectFileRepository` mevcut ✅
- **Controller**: ❌ Eksik (ProjectController var ama dosya işlemleri eksik)
- **Views**: ❌ Eksik

### Görevler
- [ ] ProjectController'a dosya yükleme action'ı ekle: `UploadFile`
- [ ] Dosya indirme action'ı ekle: `DownloadFile`
- [ ] Dosya silme action'ı ekle: `DeleteFile`
- [ ] `Views/Project/Files.cshtml` - Dosya listesi
- [ ] Dosya yükleme formu (partial view)
- [ ] Dosya yönetimi için modal/popup

### Tahmini Süre: 1.5 saat

---

## 6. VacationHistory Görüntüleme Sayfası

### Durum
- **Entity**: `VacationHistory` mevcut ✅
- **Repository**: `VacationHistoryRepository` mevcut ✅
- **Service**: `VacationHistoryService` mevcut ✅
- **Controller**: ❌ Eksik
- **Views**: ❌ Eksik

### Görevler
- [ ] VacationController'a `History` action'ı ekle
- [ ] `Views/Vacation/History.cshtml` oluştur
- [ ] Kullanıcı izin geçmişini gösteren tablo
- [ ] Filtreleme (tarih aralığı, izin türü)

### Tahmini Süre: 1 saat

---

## Faz 1 Özeti

| Görev | Öncelik | Tahmini Süre | Durum |
|-------|---------|--------------|-------|
| ApplicationUpdate Migration | 🔴 Kritik | 15 dk | ⬜ Bekliyor |
| ResetPasswordViewModel | 🔴 Kritik | 10 dk | ⬜ Bekliyor |
| Duplicate Code Temizliği | 🔴 Kritik | 20 dk | ⬜ Bekliyor |
| EmailTemplate CRUD | 🔴 Yüksek | 2 saat | ⬜ Bekliyor |
| ProjectFiles Yönetimi | 🔴 Yüksek | 1.5 saat | ⬜ Bekliyor |
| VacationHistory Sayfası | 🔴 Yüksek | 1 saat | ⬜ Bekliyor |

**Toplam Tahmini Süre**: ~5 saat

---

### Sonraki Faz
- [Faz 2 - DTO ve ViewModel'ler](./02-Faz-2-DTO-ViewModel.md)
