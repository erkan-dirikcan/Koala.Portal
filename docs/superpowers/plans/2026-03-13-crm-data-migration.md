# CRM Data Migration Implementation Plan

> **For agentic workers:** REQUIRED: Use superpowers:subagent-driven-development (if subagents available) or superpowers:executing-plans to implement this plan. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Replace local CRM summary tables with direct CRM database queries via adapter layer

**Architecture:** Adapter Pattern - Create adapters that transform CRM entities (MT_Firm, MT_Contact, PO_Phone_Number) to local models (CrmFirm, CrmFirmContact, CrmPhoneNumber), then modify repositories to use adapters instead of querying AppDbContext.

**Tech Stack:** .NET Core, Entity Framework Core, AutoMapper

---

## File Structure

### New Files to Create
```
Koala.Portal.Core/Adapters/
├── ICrmFirmAdapter.cs
├── CrmFirmAdapter.cs
├── ICrmContactAdapter.cs
├── CrmContactAdapter.cs
├── ICrmPhoneAdapter.cs
└── CrmPhoneAdapter.cs
```

### Files to Modify
```
Koala.Portal.Repository/Repositories/
├── FirmRepository.cs (inject SistemCrmContext + adapters)
└── FirmContactRepository.cs (inject SistemCrmContext + adapters)

Koala.Portal.WebApi/Extentions/StartupExtention.cs
└── Register new adapters in DI

Koala.Portal.Repository/AppDbContext.cs
└── Remove CrmDepartment DbSet (Phase 4)
```

---

## Chunk 1: Create Adapters

### Task 1: Create Phone Adapter

**Files:**
- Create: `Koala.Portal.Core/Adapters/ICrmPhoneAdapter.cs`
- Create: `Koala.Portal.Core/Adapters/CrmPhoneAdapter.cs`

- [ ] **Step 1: Create ICrmPhoneAdapter interface**

```csharp
using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.Adapters
{
    public interface ICrmPhoneAdapter
    {
        CrmPhoneNumber ToLocalEntity(CrmModels.PO_Phone_Number crmPhone);
        IEnumerable<CrmPhoneNumber> ToLocalEntities(IEnumerable<CrmModels.PO_Phone_Number> crmPhones);
    }
}
```

- [ ] **Step 2: Create CrmPhoneAdapter implementation**

```csharp
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.Helpers;
using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.Adapters
{
    public class CrmPhoneAdapter : ICrmPhoneAdapter
    {
        public CrmPhoneNumber ToLocalEntity(PO_Phone_Number crmPhone)
        {
            if (crmPhone == null) return null;

            return new CrmPhoneNumber
            {
                Id = Tools.CreateGuidStr(),
                Oid = crmPhone.Oid.ToString(),
                RelatedFirm = crmPhone.RelatedFirm?.ToString(),
                RelatedContact = crmPhone.RelatedContact?.ToString(),
                AreaCode = crmPhone.AreaCode,
                Number = crmPhone.Number,
                Extension = crmPhone.Extension
            };
        }

        public IEnumerable<CrmPhoneNumber> ToLocalEntities(IEnumerable<PO_Phone_Number> crmPhones)
        {
            if (crmPhones == null) return Enumerable.Empty<CrmPhoneNumber>();

            return crmPhones
                .Where(p => p.GCRecord == null) // Exclude deleted records
                .Select(p => ToLocalEntity(p))
                .Where(p => p != null);
        }
    }
}
```

- [ ] **Step 3: Commit**

```bash
git add Koala.Portal.Core/Adapters/ICrmPhoneAdapter.cs Koala.Portal.Core/Adapters/CrmPhoneAdapter.cs
git commit -m "feat: add CrmPhoneAdapter for CRM phone number transformation"
```

---

### Task 2: Create Contact Adapter

**Files:**
- Create: `Koala.Portal.Core/Adapters/ICrmContactAdapter.cs`
- Create: `Koala.Portal.Core/Adapters/CrmContactAdapter.cs`

- [ ] **Step 1: Create ICrmContactAdapter interface**

```csharp
using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.Adapters
{
    public interface ICrmContactAdapter
    {
        CrmFirmContact ToLocalEntity(CrmModels.MT_Contact crmContact, string firmOid = null);
        IEnumerable<CrmFirmContact> ToLocalEntities(IEnumerable<CrmModels.MT_Contact> crmContacts);
    }
}
```

- [ ] **Step 2: Create CrmContactAdapter implementation**

```csharp
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.Helpers;
using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.Adapters
{
    public class CrmContactAdapter : ICrmContactAdapter
    {
        private readonly ICrmPhoneAdapter _phoneAdapter;

        public CrmContactAdapter(ICrmPhoneAdapter phoneAdapter)
        {
            _phoneAdapter = phoneAdapter;
        }

        public CrmFirmContact ToLocalEntity(MT_Contact crmContact, string firmOid = null)
        {
            if (crmContact == null) return null;

            // Name = FirstName + (MiddleName != null ? " {MiddleName}" : "")
            string name = crmContact.FirstName ?? "";
            if (!string.IsNullOrWhiteSpace(crmContact.MiddleName))
            {
                name += " " + crmContact.MiddleName.Trim();
            }

            var localContact = new CrmFirmContact
            {
                Id = Tools.CreateGuidStr(),
                Oid = crmContact.Oid.ToString(),
                FirmId = firmOid ?? crmContact.RelatedFirm?.ToString(),
                Name = name.Trim(),
                LastName = crmContact.LastName ?? "",
                InUse = crmContact.InUse ?? false,
                SupportTicket = crmContact._MXN_InUse ?? false,
                LastUpdate = DateTime.Now // Not used, but set for completeness
            };

            // Load phones from navigation property if available
            if (crmContact.PO_Phone_Number != null)
            {
                localContact.Phones = new HashSet<CrmPhoneNumber>(
                    _phoneAdapter.ToLocalEntities(crmContact.PO_Phone_Number)
                );
            }

            return localContact;
        }

        public IEnumerable<CrmFirmContact> ToLocalEntities(IEnumerable<MT_Contact> crmContacts)
        {
            if (crmContacts == null) return Enumerable.Empty<CrmFirmContact>();

            return crmContacts
                .Where(c => c.GCRecord == null) // Exclude deleted records
                .Select(c => ToLocalEntity(c))
                .Where(c => c != null);
        }
    }
}
```

- [ ] **Step 3: Commit**

```bash
git add Koala.Portal.Core/Adapters/ICrmContactAdapter.cs Koala.Portal.Core/Adapters/CrmContactAdapter.cs
git commit -m "feat: add CrmContactAdapter for CRM contact transformation"
```

---

### Task 3: Create Firm Adapter

**Files:**
- Create: `Koala.Portal.Core/Adapters/ICrmFirmAdapter.cs`
- Create: `Koala.Portal.Core/Adapters/CrmFirmAdapter.cs`

- [ ] **Step 1: Create ICrmFirmAdapter interface**

```csharp
using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.Adapters
{
    public interface ICrmFirmAdapter
    {
        CrmFirm ToLocalEntity(CrmModels.MT_Firm crmFirm);
        CrmFirm ToLocalEntityWithPhones(CrmModels.MT_Firm crmFirm, IEnumerable<CrmModels.PO_Phone_Number> phones);
        IEnumerable<CrmFirm> ToLocalEntities(IEnumerable<CrmModels.MT_Firm> crmFirms);
    }
}
```

- [ ] **Step 2: Create CrmFirmAdapter implementation**

```csharp
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.Helpers;
using Koala.Portal.Core.Models;

namespace Koala.Portal.Core.Adapters
{
    public class CrmFirmAdapter : ICrmFirmAdapter
    {
        private readonly ICrmPhoneAdapter _phoneAdapter;
        private readonly ICrmContactAdapter _contactAdapter;

        public CrmFirmAdapter(ICrmPhoneAdapter phoneAdapter, ICrmContactAdapter contactAdapter)
        {
            _phoneAdapter = phoneAdapter;
            _contactAdapter = contactAdapter;
        }

        public CrmFirm ToLocalEntity(MT_Firm crmFirm)
        {
            if (crmFirm == null) return null;

            return new CrmFirm
            {
                Id = Tools.CreateGuidStr(),
                Oid = crmFirm.Oid.ToString(),
                Code = crmFirm.FirmCode ?? "",
                Title = crmFirm.FirmTitle ?? "",
                Phone = null, // Will be loaded separately via ToLocalEntityWithPhones
                InUse = crmFirm.InUse ?? false,
                LastUpdate = DateTime.Now // Not used, but set for completeness
            };
        }

        public CrmFirm ToLocalEntityWithPhones(MT_Firm crmFirm, IEnumerable<PO_Phone_Number> phones)
        {
            var localFirm = ToLocalEntity(crmFirm);
            if (localFirm == null) return null;

            // Get default phone: where RelatedFirm = Firm.Oid AND IsDefaultPhone = true
            var defaultPhone = phones?
                .FirstOrDefault(p => p.RelatedFirm == crmFirm.Oid && p.IsDefaultPhone == true && p.GCRecord == null);

            if (defaultPhone != null)
            {
                localFirm.Phone = defaultPhone.Number;
                localFirm.Phones = new HashSet<CrmPhoneNumber>(
                    phones.Where(p => p.RelatedFirm == crmFirm.Oid && p.GCRecord == null)
                          .Select(p => _phoneAdapter.ToLocalEntity(p))
                );
            }
            else
            {
                localFirm.Phones = new HashSet<CrmPhoneNumber>();
            }

            // Load contacts from navigation property if available
            if (crmFirm.MT_Contact != null)
            {
                localFirm.Contacts = new HashSet<CrmFirmContact>(
                    crmFirm.MT_Contact
                        .Where(c => c.GCRecord == null)
                        .Select(c => _contactAdapter.ToLocalEntity(c, crmFirm.Oid.ToString()))
                );
            }

            return localFirm;
        }

        public IEnumerable<CrmFirm> ToLocalEntities(IEnumerable<MT_Firm> crmFirms)
        {
            if (crmFirms == null) return Enumerable.Empty<CrmFirm>();

            return crmFirms
                .Where(f => f.GCRecord == null) // Exclude deleted records
                .Select(f => ToLocalEntity(f))
                .Where(f => f != null);
        }
    }
}
```

- [ ] **Step 3: Commit**

```bash
git add Koala.Portal.Core/Adapters/ICrmFirmAdapter.cs Koala.Portal.Core/Adapters/CrmFirmAdapter.cs
git commit -m "feat: add CrmFirmAdapter for CRM firm transformation with phone and contact loading"
```

---

## Chunk 2: Register Adapters in DI

### Task 4: Register Adapters

**Files:**
- Modify: `Koala.Portal.WebApi/Extentions/StartupExtention.cs`
- Modify: `Koala.Portal.WebUI/Extentions/StartupExtention.cs`

- [ ] **Step 1: Read existing DI registration files**

```bash
# Check WebApi DI
grep -n "services.AddScoped" Koala.Portal.WebApi/Extentions/StartupExtention.cs | tail -20

# Check WebUI DI
grep -n "services.AddScoped" Koala.Portal.WebUI/Extentions/StartupExtention.cs | tail -20
```

- [ ] **Step 2: Add adapter registrations to WebApi/StartupExtention.cs**

Find the section with other service registrations (after repository registrations) and add:

```csharp
// Adapters for CRM data transformation
services.AddScoped<Core.Adapters.ICrmPhoneAdapter, Adapters.CrmPhoneAdapter>();
services.AddScoped<Core.Adapters.ICrmContactAdapter, Adapters.CrmContactAdapter>();
services.AddScoped<Core.Adapters.ICrmFirmAdapter, Adapters.CrmFirmAdapter>();
```

- [ ] **Step 3: Add adapter registrations to WebUI/StartupExtention.cs**

Same as Step 2, add to WebUI DI configuration.

- [ ] **Step 4: Build to verify no compilation errors**

```bash
dotnet build
```

Expected: BUILD SUCCESS

- [ ] **Step 5: Commit**

```bash
git add Koala.Portal.WebApi/Extentions/StartupExtention.cs Koala.Portal.WebUI/Extentions/StartupExtention.cs
git commit -m "feat: register CRM adapters in dependency injection"
```

---

## Chunk 3: Modify FirmRepository

### Task 5: Modify FirmRepository to Use CRM

**Files:**
- Modify: `Koala.Portal.Repository/Repositories/FirmRepository.cs`

- [ ] **Step 1: Read current FirmRepository implementation**

File is at: `Koala.Portal.Repository/Repositories/FirmRepository.cs`

Current methods:
- `AddRangeAsync` - adds firms to local DB
- `GetFirmInfoById` - gets firm by local Id with Includes
- `UpdateFirmAsync` - updates local entity
- `Where` - returns IQueryable with Includes
- `GetAllAsync` - gets all with Includes

- [ ] **Step 2: Replace FirmRepository with CRM-based implementation**

```csharp
using System.Linq.Expressions;
using Koala.Portal.Core.Adapters;
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.Repositories
{
    public class FirmRepository : IFirmRepository
    {
        private readonly SistemCrmContext _crmContext;
        private readonly ICrmFirmAdapter _firmAdapter;
        private readonly ICrmContactAdapter _contactAdapter;

        public FirmRepository(SistemCrmContext crmContext, ICrmFirmAdapter firmAdapter, ICrmContactAdapter contactAdapter)
        {
            _crmContext = crmContext;
            _firmAdapter = firmAdapter;
            _contactAdapter = contactAdapter;
        }

        // NOTE: AddRangeAsync and UpdateFirmAsync are kept for backward compatibility
        // but they will not work with CRM data (CRM is read-only for this app)
        public async Task AddRangeAsync(List<CrmFirm> firms)
        {
            // No-op - CRM is read-only
            await Task.CompletedTask;
        }

        public CrmFirm? GetFirmInfoById(string id)
        {
            // Since we generate random Ids for local entities, we can't query CRM by local Id
            // This method returns null - callers should use Oid-based methods instead
            return null;
        }

        public async Task UpdateFirmAsync(CrmFirm entity)
        {
            // No-op - CRM is read-only
            await Task.CompletedTask;
        }

        public IQueryable<CrmFirm> Where(Expression<Func<CrmFirm, bool>> predicate)
        {
            // Since we need to transform CRM data, we can't return a true IQueryable
            // Load all active firms and return as in-memory queryable
            var firms = _crmContext.MT_Firm
                .Include(f => f.PO_Phone_Number)
                .Include(f => f.MT_Contact)
                    .ThenInclude(c => c.PO_Phone_Number)
                .Where(f => f.InUse == true && f.GCRecord == null)
                .AsEnumerable()
                .Select(f => _firmAdapter.ToLocalEntityWithPhones(
                    f,
                    f.PO_Phone_Number
                ))
                .Where(f => f != null)
                .AsQueryable();

            return firms.Where(predicate);
        }

        public async Task<IEnumerable<CrmFirm>> GetAllAsync()
        {
            try
            {
                var firms = await _crmContext.MT_Firm
                    .Include(f => f.PO_Phone_Number)
                    .Include(f => f.MT_Contact)
                        .ThenInclude(c => c.PO_Phone_Number)
                    .Where(f => f.GCRecord == null)
                    .ToListAsync();

                return firms
                    .Select(f => _firmAdapter.ToLocalEntityWithPhones(f, f.PO_Phone_Number))
                    .Where(f => f != null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
```

- [ ] **Step 3: Build to verify compilation**

```bash
dotnet build
```

Expected: BUILD SUCCESS

- [ ] **Step 4: Commit**

```bash
git add Koala.Portal.Repository/Repositories/FirmRepository.cs
git commit -m "feat: modify FirmRepository to use CRM data via adapters"
```

---

## Chunk 4: Modify FirmContactRepository

### Task 6: Modify FirmContactRepository to Use CRM

**Files:**
- Modify: `Koala.Portal.Repository/Repositories/FirmContactRepository.cs`

- [ ] **Step 1: Read current FirmContactRepository implementation**

File is at: `Koala.Portal.Repository/Repositories/FirmContactRepository.cs`

Current methods:
- `GetAllAsync(string firmId)` - gets contacts by local firmId
- `GetAllByOidAsync(string firmOid)` - gets contacts by firmOid
- `Where` - returns IQueryable with Includes
- `GetByIdAsync` - gets by local Id
- `GetByOidAsync` - gets by Oid

- [ ] **Step 2: Replace FirmContactRepository with CRM-based implementation**

```csharp
using System.Linq.Expressions;
using Koala.Portal.Core.Adapters;
using Koala.Portal.Core.CrmModels;
using Koala.Portal.Core.Models;
using Koala.Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Koala.Portal.Repository.Repositories
{
    public class FirmContactRepository : IFirmContactRepository
    {
        private readonly SistemCrmContext _crmContext;
        private readonly ICrmContactAdapter _contactAdapter;
        private readonly ICrmPhoneAdapter _phoneAdapter;

        public FirmContactRepository(SistemCrmContext crmContext, ICrmContactAdapter contactAdapter, ICrmPhoneAdapter phoneAdapter)
        {
            _crmContext = crmContext;
            _contactAdapter = contactAdapter;
            _phoneAdapter = phoneAdapter;
        }

        public async Task<IEnumerable<CrmFirmContact>> GetAllAsync(string firmId)
        {
            // firmId is local Id which doesn't exist in CRM
            // Return empty - callers should use GetAllByOidAsync instead
            return await Task.FromResult(Enumerable.Empty<CrmFirmContact>());
        }

        public async Task<IEnumerable<CrmFirmContact>> GetAllByOidAsync(string firmOid)
        {
            if (!Guid.TryParse(firmOid, out Guid firmGuid))
            {
                return Enumerable.Empty<CrmFirmContact>();
            }

            var contacts = await _crmContext.MT_Contact
                .Include(c => c.PO_Phone_Number)
                .Where(c => c.RelatedFirm == firmGuid && c.GCRecord == null)
                .ToListAsync();

            return contacts
                .Select(c => _contactAdapter.ToLocalEntity(c, firmOid))
                .Where(c => c != null);
        }

        public IQueryable<CrmFirmContact> Where(Expression<Func<CrmFirmContact, bool>> predicate)
        {
            var contacts = _crmContext.MT_Contact
                .Include(c => c.PO_Phone_Number)
                .Where(c => c.GCRecord == null)
                .AsEnumerable()
                .Select(c => _contactAdapter.ToLocalEntity(c))
                .Where(c => c != null)
                .AsQueryable();

            return contacts.Where(predicate);
        }

        public async Task<CrmFirmContact?> GetByIdAsync(string id)
        {
            // Local Id doesn't exist in CRM
            return await Task.FromResult<CrmFirmContact>(null);
        }

        public async Task<CrmFirmContact?> GetByOidAsync(string oid)
        {
            if (!Guid.TryParse(oid, out Guid contactGuid))
            {
                return null;
            }

            var contact = await _crmContext.MT_Contact
                .Include(c => c.PO_Phone_Number)
                .FirstOrDefaultAsync(c => c.Oid == contactGuid && c.GCRecord == null);

            if (contact == null) return null;

            return _contactAdapter.ToLocalEntity(contact);
        }
    }
}
```

- [ ] **Step 3: Build to verify compilation**

```bash
dotnet build
```

Expected: BUILD SUCCESS

- [ ] **Step 4: Commit**

```bash
git add Koala.Portal.Repository/Repositories/FirmContactRepository.cs
git commit -m "feat: modify FirmContactRepository to use CRM data via adapters"
```

---

## Chunk 5: Testing and Verification

### Task 7: Verify Build and Run Tests

- [ ] **Step 1: Build entire solution**

```bash
dotnet build
```

Expected: BUILD SUCCESS

- [ ] **Step 2: Run existing tests**

```bash
dotnet test
```

Expected: All existing tests pass (or only expected failures)

- [ ] **Step 3: Check for any compilation errors in WebApi/WebUI**

```bash
dotnet build Koala.Portal.WebApi
dotnet build Koala.Portal.WebUI
```

Expected: Both build successfully

---

### Task 8: Manual Verification

- [ ] **Step 1: Start the application**

```bash
dotnet run --project Koala.Portal.WebUI
```

- [ ] **Step 2: Verify Firm list page loads**

Navigate to Firm list page in browser
Expected: Page loads without errors

- [ ] **Step 3: Verify Contact list page loads**

Navigate to Contact list page in browser
Expected: Page loads without errors

- [ ] **Step 4: Verify Contact names display correctly**

Check that Contact names show "FirstName MiddleName LastName" format
Expected: Names display correctly

- [ ] **Step 5: Verify Phone numbers display**

Check that Firm and Contact phone numbers display
Expected: Phone numbers show correctly

---

### Task 9: Cleanup and Documentation

- [ ] **Step 1: Update CLAUDE.md with new architecture**

Add a note about the adapter pattern for CRM data:

```markdown
## CRM Data Access

CRM data (Firms, Contacts, Phones) is accessed via adapters that transform
CRM entities (MT_Firm, MT_Contact, PO_Phone_Number) to local models.

Adapters: ICrmFirmAdapter, ICrmContactAdapter, ICrmPhoneAdapter
CRM Context: SistemCrmContext

Local entities (CrmFirm, CrmFirmContact, CrmPhoneNumber) are retained for
historical data but are not used for new queries.
```

- [ ] **Step 2: Commit documentation changes**

```bash
git add CLAUDE.md
git commit -m "docs: update architecture documentation for CRM adapter pattern"
```

---

## Chunk 6: Remove Unused CrmDepartment (Optional)

### Task 10: Remove Local CrmDepartment Stack

**Note:** Only do this if ICrmDepartmentService (CRM version) is confirmed to be used everywhere.

- [ ] **Step 1: Search for local CrmDepartment usage**

```bash
grep -r "CrmDepartment" Koala.Portal.Core/ Koala.Portal.Service/ Koala.Portal.WebUI/ Koala.Portal.WebApi/ --exclude-dir=bin --exclude-dir=obj
```

- [ ] **Step 2: If safe to proceed, delete local files**

```bash
# Delete local entity
rm Koala.Portal.Core/Models/CrmDepartment.cs

# Delete local repository interface and implementation (if exists)
rm Koala.Portal.Core/Repositories/*CrmDepartmentRepository.cs 2>/dev/null || true
rm Koala.Portal.Repository/Repositories/*CrmDepartmentRepository.cs 2>/dev/null || true

# Delete local service interface and implementation (if exists)
rm Koala.Portal.Core/Services/*CrmDepartmentService.cs 2>/dev/null || true
rm Koala.Portal.Service/Services/*CrmDepartmentService.cs 2>/dev/null || true

# Delete configuration
rm Koala.Portal.Repository/Configurations/CrmDepartmentConfiguration.cs 2>/dev/null || true

# Delete ViewModels
rm Koala.Portal.Core/ViewModels/CrmViewModels/CrmDepartmentViewModels.cs 2>/dev/null || true

# Delete mapping profile
rm Koala.Portal.Service/Mapping/CrmDepartmentProfile.cs 2>/dev/null || true
```

- [ ] **Step 3: Remove from AppDbContext**

Edit `Koala.Portal.Repository/AppDbContext.cs`:
Remove line: `public DbSet<CrmDepartment> CrmDepartment { get; set; }`

- [ ] **Step 4: Create migration**

```bash
dotnet ef migrations add RemoveLocalCrmDepartment --project Koala.Portal.Repository
```

- [ ] **Step 5: Apply migration**

```bash
dotnet ef database update --project Koala.Portal.Repository
```

- [ ] **Step 6: Commit**

```bash
git add .
git commit -m "refactor: remove unused local CrmDepartment entity"
```

---

## Rollback Plan

If issues occur after implementation:

1. **Revert repository changes:**
   ```bash
   git revert HEAD~3..HEAD  # Reverts the last 3 commits (repos + adapters)
   ```

2. **Keep adapters** - they're harmless if not used

3. **Debug and fix** - Investigate what went wrong

4. **Retry migration** - Apply fixes and try again

---

## Summary

This plan:
1. ✅ Creates adapter layer for CRM → Local transformation
2. ✅ Modifies FirmRepository to use CRM data
3. ✅ Modifies FirmContactRepository to use CRM data
4. ✅ Optionally removes unused CrmDepartment
5. ✅ Maintains backward compatibility (same interfaces, same ViewModels)
6. ✅ Keeps local entities for historical data (not deleted)

**Total estimated tasks:** 10
**Total estimated chunks:** 6
