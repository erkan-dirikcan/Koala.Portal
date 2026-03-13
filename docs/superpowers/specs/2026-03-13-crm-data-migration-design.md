# CRM Data Migration Design

> **Goal:** Replace local CRM summary tables (CrmFirm, CrmFirmContact, CrmPhoneNumber) with direct queries to the CRM database via an adapter layer.

**Date:** 2026-03-13
**Status:** Draft
**Approach:** Adapter Pattern (Approach 2)

---

## Problem Statement

The application currently maintains local "summary" copies of CRM entities (`CrmFirm`, `CrmFirmContact`, `CrmPhoneNumber`) in the `AppDbContext`. These were created for performance but are causing confusion and complexity. The CRM database already contains the source of truth for this data.

**Key Issues:**
- Dual data sources (local + CRM) create confusion
- Local tables can become stale
- Unnecessary complexity in the codebase
- `CrmDepartment` local entity exists but is completely unused

---

## Architecture Overview

```
┌─────────────────────────────────────────────────────────────────┐
│                        Controllers                               │
│  (FirmController, ProjectController, SupportController, etc.)    │
└─────────────────────────────┬───────────────────────────────────┘
                              │ unchanged
                              ▼
┌─────────────────────────────────────────────────────────────────┐
│                         Services                                  │
│  IFirmService, IFirmContactService, IFirmService, etc.          │
└─────────────────────────────┬───────────────────────────────────┘
                              │ now uses CRM adapters
                              ▼
┌─────────────────────────────────────────────────────────────────┐
│                     Repositories                                 │
│  IFirmRepository, IFirmContactRepository (modified)             │
└─────────────────────────────┬───────────────────────────────────┘
                              │ queries
                              ▼
┌─────────────────────────────────────────────────────────────────┐
│                    CRM Adapters                                  │
│  ICrmFirmAdapter, ICrmContactAdapter, ICrmPhoneAdapter          │
│  (Transforms SistemCrmContext entities → Local Models)           │
└─────────────────────────────┬───────────────────────────────────┘
                              │ reads
                              ▼
┌─────────────────────────────────────────────────────────────────┐
│                    SistemCrmContext                              │
│  (MT_Firm, MT_Contact, PO_Phone_Number, etc.)                   │
└─────────────────────────────────────────────────────────────────┘
```

---

## Entity Mappings

### CrmDepartment
| Local Property | CRM Source | Notes |
|----------------|------------|-------|
| — | — | **Unused** - no data, no relationships. Will delete entirely. |

### CrmPhoneNumber
| Local Property | CRM Source | Transformation |
|----------------|------------|----------------|
| `Id` | `Tools.CreateGuidStr()` | Generate new local ID |
| `Oid` | `PO_Phone_Number.Oid` | Direct mapping |
| `RelatedFirm` | `PO_Phone_Number.RelatedFirm` | Direct mapping |
| `RelatedContact` | `PO_Phone_Number.RelatedContact` | Direct mapping |
| `AreaCode` | `PO_Phone_Number.AreaCode` | Direct mapping |
| `Number` | `PO_Phone_Number.Number` | Direct mapping |
| `Extension` | `PO_Phone_Number.Extension` | Direct mapping |

### CrmFirm
| Local Property | CRM Source | Transformation |
|----------------|------------|----------------|
| `Id` | `Tools.CreateGuidStr()` | Generate new local ID |
| `Oid` | `MT_Firm.Oid` | Direct mapping |
| `Code` | `MT_Firm.FirmCode` | Direct mapping |
| `Title` | `MT_Firm.FirmTitle` | Direct mapping |
| `Phone` | `PO_Phone_Number.Number` | Join where `RelatedFirm = Firm.Oid` AND `IsDefaultPhone = 1` |
| `InUse` | `MT_Firm.InUse` | Direct mapping |
| `LastUpdate` | — | **Removed** - not used |

### CrmFirmContact
| Local Property | CRM Source | Transformation |
|----------------|------------|----------------|
| `Id` | `Tools.CreateGuidStr()` | Generate new local ID |
| `Oid` | `MT_Contact.Oid` | Direct mapping |
| `FirmId` | `MT_Contact.FirmOid` | Direct mapping |
| `Name` | `MT_Contact.FirstName` + `MT_Contact.MiddleName` | `FirstName + (MiddleName != null ? " {MiddleName}" : "")` |
| `LastName` | `MT_Contact.LastName` | Direct mapping |
| `InUse` | `MT_Contact.InUse` | Direct mapping |
| `SupportTicket` | `MT_Contact._MXN_InUse` | Direct mapping |
| `LastUpdate` | — | **Removed** - not used |

---

## Components

### New Adapters to Create

| Adapter | Responsibility |
|---------|----------------|
| `ICrmFirmAdapter` | `MT_Firm` + `PO_Phone_Number` → `CrmFirm` |
| `ICrmContactAdapter` | `MT_Contact` → `CrmFirmContact` |
| `ICrmPhoneAdapter` | `PO_Phone_Number` → `CrmPhoneNumber` |

### Repositories to Modify

| Repository | Current Behavior | New Behavior |
|------------|------------------|--------------|
| `IFirmRepository` | Queries `AppDbContext.CrmFirm` | Calls `ICrmFirmAdapter` with CRM data |
| `IFirmContactRepository` | Queries `AppDbContext.CrmFirmContact` | Calls `ICrmContactAdapter` with CRM data |

### To Delete Completely

| Component | Reason |
|-----------|--------|
| `CrmDepartment` entity (local) | Unused, no data, no relationships |
| Local `CrmDepartmentRepository` | Replaced by existing CRM version |
| Local `CrmDepartmentService` | Replaced by existing CRM version |
| Related configurations, ViewModels, mappings | No longer needed |

---

## Constraints

- **Existing data stays** - no deletion of local tables (for historical records)
- **FK relationships stay** for now - future task will migrate to use CRM Oid
- **Services return same ViewModels** - calling code unchanged
- **Controllers unchanged** - minimal ripple effects

---

## Implementation Phases

1. **Foundation (Adapter Layer)** - Create adapters
2. **Modify Firm Repository** - Switch to CRM adapter
3. **Modify FirmContact Repository** - Switch to CRM adapter
4. **Delete Local CrmDepartment** - Remove unused stack
5. **Cleanup & Verification** - Final testing

---

## Testing Strategy

### Unit Tests
- Adapter transformation logic (null handling, name concatenation, phone joins)

### Integration Tests
- Repository queries through adapters return correct data

### Manual Verification
- Firm list page loads
- Contact names display correctly
- Phone numbers show properly

---

## Rollback Plan

If issues occur:
1. Revert repository changes to use `AppDbContext` queries
2. Keep adapters in place (harmless)
3. Debug and fix adapters
4. Retry migration
