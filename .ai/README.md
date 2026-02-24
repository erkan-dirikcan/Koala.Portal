# Koala.Portal Proje Analizi ve TODO Listesi

Bu klasör, Koala.Portal projesinin kapsamlı analizini ve iyileştirme planını içerir.

## 📁 Dosya Yapısı

```
.ai/
├── README.md                           # Bu dosya - Genel bakış
├── 01-Faz-1-Kritik-Eksiklikler.md      # Kritik ve acil tamamlanması gerekenler
├── 02-Faz-2-DTO-ViewModel.md           # DTO ve ViewModel oluşturma planı
├── 03-Faz-3-Controllers-Views.md       # Controller ve View oluşturma planı
└── 04-Faz-4-Kod-Kalitesi.md            # Kod kalitesi iyileştirmeleri
```

---

## 📊 Genel Durum

| Kategori | Mevcut | Eksik | Tamamlanma |
|----------|--------|-------|------------|
| **Entity'ler** | 38 | 0 | ✅ 100% |
| **Migration'lar** | 16 | 1 | ⚠️ 94% |
| **Repository'ler** | ~30 | 0 | ✅ 100% |
| **Service'ler** | ~30 | 0 | ✅ 100% |
| **DTO'lar** | 7 | ~56 | ❌ 11% |
| **ViewModels** | 5 | ~25 | ❌ 17% |
| **Controllers** | 24 | ~8 | ⚠️ 75% |
| **Views** | ~85 | ~35 | ⚠️ 71% |

**Genel Tamamlanma**: ~%55

---

## 🎯 Önceliklendirilmiş Görevler

### 🔴 Yüksek Öncelik (Kritik)
1. **ApplicationUpdate Migration** - Entity var ama migration yok (15 dk)
2. **ResetPasswordViewModel** - Boş sınıfı tamamlama (10 dk)
3. **Duplicate Code Temizliği** - Aynı sınıflar iki klasörde (20 dk)
4. **EmailTemplate CRUD** - Controller ve Views eksik (2 saat)

### 🟡 Orta Öncelik
5. **ProjectFiles Yönetimi** - Dosya upload/download (1.5 saat)
6. **VacationHistory Sayfası** - Geçmiş görüntüleme (1 saat)
7. **DTO'lar** - ~63 DTO oluşturulması (4.5 saat)
8. **CrmFirm Views** - Firma yönetim sayfaları (1.5 saat)

### 🟢 Düşük Öncelik (İyileştirme)
9. **Generic Repository Pattern** - Kod refactor (3 saat)
10. **Naming Convention** - Yazım hataları düzeltme (50 dk)
11. **Code Documentation** - XML comments ekleme (4 saat)

---

## 📋 Fazlar

### Faz 1 - Kritik Eksiklikler 🔴
**Tahmini Süre**: ~5 saat

Bu fazdaki görevler uygulamanın temel işlevselliği için kritiktir:
- ApplicationUpdate entity'si için migration
- ResetPasswordViewModel tamamlanması
- Duplicate code temizliği
- EmailTemplate CRUD işlemleri
- ProjectFiles dosya yönetimi
- VacationHistory görüntüleme sayfası

➡️ [Detaylar için tıklayın](./01-Faz-1-Kritik-Eksiklikler.md)

---

### Faz 2 - DTO ve ViewModel'ler 🟡
**Tahmini Süre**: ~4.5 saat

Veri transfer nesnelerinin ve view modellerinin oluşturulması:
- Identity/Kullanıcı DTO'ları (3)
- Proje Yönetimi DTO'ları (13)
- Agenda DTO'ları (5)
- İzin Yönetimi DTO'ları (7)
- Yardım Masası DTO'ları (7)
- Uygulama/Lisans DTO'ları (5)
- İşlem Yönetimi DTO'ları (6)
- Diğer DTO'lar (17)

➡️ [Detaylar için tıklayın](./02-Faz-2-DTO-ViewModel.md)

---

### Faz 3 - Controllers ve Views 🟡
**Tahmini Süre**: ~14 saat

Eksik controller'ların ve view sayfalarının oluşturulması:
- EmailTemplate Controller & Views
- CrmDepartment Controller & Views
- CrmFirm Controller & Views
- Project Files Management
- Agenda CRUD Views
- Licence Approval System
- Vacation History Page
- ve 7 diğer controller/view seti

➡️ [Detaylar için tıklayın](./03-Faz-3-Controllers-Views.md)

---

### Faz 4 - Kod Kalitesi 🟢
**Tahmini Süre**: ~19 saat

Kod kalitesini artırmak için iyileştirmeler:
- Naming convention düzeltmeleri
- Kod organizasyonu
- Generic Repository Pattern
- Unit of Work Pattern
- Exception Handling
- Logging iyileştirmeleri
- Configuration Management
- API Documentation
- Code Documentation
- Performance Improvements

➡️ [Detaylar için tıklayın](./04-Faz-4-Kod-Kalitesi.md)

---

## 🚀 Önerilen Çalışma Sırası

1. **Hafta 1**: Faz 1 - Kritik Eksiklikler
2. **Hafta 2-3**: Faz 2 - DTO ve ViewModel'ler
3. **Hafta 4-6**: Faz 3 - Controllers ve Views
4. **Hafta 7+**: Faz 4 - Kod Kalitesi (Aralıklı olarak)

---

## 📝 Proje Yapısı Özeti

### Solution Projeleri
```
Koala.Portal/
├── Koala.Portal                    # Ana MVC Web UI
├── Koala.Portal.Core               # Core library (Models, DTOs, Enums)
├── Koala.Portal.Repository         # Data access layer
├── Koala.Portal.Service            # Business logic layer
├── Koala.Portal.WebApi             # API project
└── Koala.Portal.WebUI              # Alternative UI project
```

### Entity Grupları
- **Identity**: AppUser, AppRole, Claims
- **CRM**: CrmFirm, CrmFirmContact, CrmDepartment, CrmPhoneNumber
- **Project**: Project, ProjectLine, ProjectLineWork, ProjectLineNote, ProjectFiles, ProjectPerson
- **Agenda**: Agenda, AgendaType, AgendaUsers, AgendaFixtures, AgendaFirmOfficials, Fixture
- **Vacation**: VacationRequest, VacationHistory, VacationTypes
- **HelpDesk**: HelpDeskCategory, HelpDeskProblem, HelpDeskProblemCatogory, HelpDeskSolution
- **Application**: Applications, ApplicationLicences, ApplicationFirms, ApplicationModules, ApplicationUpdate
- **Transaction**: Transaction, TransactionItem, TransactionType
- **Diğer**: Module, GeneratedIds, EmailTemplate, SupportFile

---

## ⚠️ Bilinen Sorunlar

### 1. Naming Issues
- `HelpDeskProblemCatogory` → `HelpDeskProblemCategory` olmalı
- `HelpDeskSolition` → `HelpDeskSolution` olmalı

### 2. Duplicate Code
- `AppUser.cs` hem `Koala.Portal/Models` hem `Koala.Portal.Core/Models`'te
- `AppRole.cs` her iki klasörde de mevcut
- `CommonProperty.cs` her iki klasörde de mevcut

### 3. Empty Implementation
- `ResetPasswordViewModel` sınıfı boş

---

## 🔧 Teknoloji Stack

- **Framework**: .NET 9.0
- **ORM**: Entity Framework Core
- **Authentication**: ASP.NET Core Identity
- **Database**: SQL Server
- **Architecture**: Clean Architecture / Layered Architecture
- **Patterns**: Repository, Unit of Work, Service Layer

---

## 📞 İletişim

Bu analiz ile ilgili sorularınız için proje yöneticisi ile iletişime geçiniz.

---

**Son Güncelleme**: 2025-01-19
**Analiz Versionu**: 1.0
