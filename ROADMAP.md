# Project Module - Development Roadmap

## Overview
This roadmap outlines the current state and planned improvements for the Project management module in Koala.Portal.

## Module Structure Definition

### Project Entity Hierarchy
```
Project (Proje)
├── ProjectManager (AppUser) - Proje Yöneticisi
├── Firm (CrmFirm) - Projenin yapıldığı firma
├── FirmPerson (CrmFirmContact) - Firma yetkilisi
├── ProjectFiles (ProjectFiles[]) - Proje dosyaları
└── ProjectLines (ProjectLine[]) - Fazlar

ProjectLine (Faz)
├── LineOfficial (AppUser) - Faz yöneticisi
├── LineFirmOfficial (CrmFirmContact) - Firma yetkilisi
├── Status - Durum (NotStarted, InProgress, Completed, etc.)
├── LineWorks (ProjectLineWork[]) - İşler
└── LineNotes (ProjectLineNote[]) - Notlar

ProjectLineWork (İş)
├── SupportTicket (Ticket) - Destek kaydı
├── Status - Durum
└── Assigned Personnel

ProjectFiles (Dosyalar)
├── File Type - PDF, Image, Archive
└── Description - Teklif, kullanma klavuzu, yol haritası, etc.
```

---

## Current Status Assessment

### ✅ Completed Components

| Component | Status | Notes |
|-----------|--------|-------|
| **Data Models** | ✅ Complete | All entities defined with proper relationships |
| **DbContext** | ✅ Complete | All DbSets configured |
| **EF Configurations** | ✅ Complete | FluentAPI configurations for all entities |
| **Repositories** | ✅ Complete | Repository pattern implemented for all entities |
| **Services** | ✅ Complete | Business logic layer implemented |
| **ViewModels** | ✅ Complete | All required ViewModels defined |
| **JavaScript Files** | ✅ Complete | Basic JS files for main pages |
| **Enums** | ✅ Complete | Status and priority enums defined |

### ⚠️ Partially Completed Components

| Component | Status | Missing Parts |
|-----------|--------|---------------|
| **ProjectController** | ⚠️ Partial | Update, Delete, File management actions |
| **Views** | ⚠️ Partial | Edit, Delete, File/Note/Work management views |
| **ProjectLineController** | ⚠️ Partial | Full CRUD for Line, Note, Work management |

### ❌ Missing Components

| Component | Priority | Description |
|-----------|----------|-------------|
| **File Management UI** | High | Upload, download, delete project files |
| **Note Management UI** | High | Create, edit, delete project line notes |
| **Work Management UI** | High | Create, edit, delete work items |
| **Project Edit/Update** | High | Edit project basic information |
| **Project Delete** | Medium | Delete project with confirmation |
| **Dashboard** | Medium | Project overview with statistics |
| **Timeline Visualization** | Low | Gantt chart or timeline view |
| **Reports** | Low | Project progress reports |

---

## Development Roadmap

### Phase 1: Complete Core CRUD Operations (High Priority)

#### 1.1 Project Management
- [ ] **Update Project**
  - [ ] Create `EditProject.cshtml` view
  - [ ] Implement `UpdateProject` (GET/POST) actions in `ProjectController`
  - [ ] Add validation for project updates
  - [ ] Handle status transitions properly

- [ ] **Delete Project**
  - [ ] Implement soft delete mechanism
  - [ ] Create delete confirmation view
  - [ ] Handle cascade delete for related entities
  - [ ] Add undo/restore functionality

#### 1.2 ProjectLine (Faz) Management
- [ ] **Edit ProjectLine**
  - [ ] Create `EditProjectLine.cshtml` view
  - [ ] Implement update actions
  - [ ] Add line official assignment

- [ ] **Delete ProjectLine**
  - [ ] Add delete confirmation
  - [ ] Handle related works and notes

#### 1.3 ProjectLineNote (Not) Management
- [ ] **Create Note**
  - [ ] Create `AddProjectLineNote.cshtml` view
  - [ ] Implement controller action
  - [ ] Add AJAX support for inline note creation

- [ ] **Edit Note**
  - [ ] Create edit functionality
  - [ ] Add modal or inline editing

- [ ] **Delete Note**
  - [ ] Add delete action
  - [ ] Include confirmation

- [ ] **View Notes**
  - [ ] Display notes in project detail
  - [ ] Add note filtering/sorting

#### 1.4 ProjectLineWork (İş) Management
- [ ] **Create Work Item**
  - [ ] Create `AddProjectLineWork.cshtml` view
  - [ ] Link to support tickets
  - [ ] Assign personnel

- [ ] **Edit Work Item**
  - [ ] Edit work details
  - [ ] Update status
  - [ ] Reassign personnel

- [ ] **Delete Work Item**
  - [ ] Delete with confirmation
  - [ ] Handle related support tickets

- [ ] **Work Status Management**
  - [ ] Change status workflow
  - [ ] Add status change history

#### 1.5 ProjectFiles (Dosya) Management
- [ ] **Upload Files**
  - [ ] Create file upload interface
  - [ ] Support multiple file types (PDF, images, archives)
  - [ ] Add file description
  - [ ] Implement file size validation

- [ ] **Download Files**
  - [ ] Secure file download
  - [ ] File access permissions

- [ ] **Delete Files**
  - [ ] Delete with confirmation
  - [ ] Clean up physical files

- [ ] **File Preview**
  - [ ] Preview PDF files
  - [ ] Display images

---

### Phase 2: Enhanced UI/UX Features (Medium Priority)

#### 2.1 Dashboard & Overview
- [ ] **Project Dashboard**
  - [ ] Show active projects count
  - [ ] Display projects by status
  - [ ] Show upcoming deadlines
  - [ ] Recent activity feed

- [ ] **Project Detail Enhancements**
  - [ ] Tabbed interface for Lines, Works, Notes, Files
  - [ ] Progress bars for project completion
  - [ ] Team member avatars
  - [ ] Status badges with color coding

#### 2.2 Filtering & Search
- [ ] **Advanced Project List**
  - [ ] Filter by status
  - [ ] Filter by project manager
  - [ ] Filter by firm
  - [ ] Search by project name/code
  - [ ] Date range filtering

#### 2.3 Status Management
- [ ] **Bulk Status Changes**
  - [ ] Change multiple lines status at once
  - [ ] Change multiple works status at once

- [ ] **Status Workflow**
  - [ ] Enforce status transition rules
  - [ ] Show allowed next statuses
  - [ ] Add comments on status change

---

### Phase 3: Advanced Features (Low Priority)

#### 3.1 Visualization
- [ ] **Timeline View**
  - [ ] Gantt chart for project lines
  - [ ] Work item timeline
  - [ ] Milestone markers

- [ ] **Calendar View**
  - [ ] Show project start/end dates
  - [ ] Display work deadlines

#### 3.2 Reporting
- [ ] **Project Reports**
  - [ ] Project completion report
  - [ ] Team workload report
  - [ ] Firm project summary

- [ ] **Export Functions**
  - [ ] Export to PDF
  - [ ] Export to Excel

#### 3.3 Notifications
- [ ] **Email Notifications**
  - [ ] Notify on project assignment
  - [ ] Notify on status change
  - [ ] Notify on work assignment

- [ ] **In-App Notifications**
  - [ ] Notification center
  - [ ] Real-time updates

#### 3.4 API Endpoints
- [ ] **REST API**
  - [ ] GET /api/projects
  - [ ] POST /api/projects
  - [ ] PUT /api/projects/{id}
  - [ ] DELETE /api/projects/{id}
  - [ ] Project lines CRUD
  - [ ] Works CRUD
  - [ ] Notes CRUD

---

### Phase 4: Quality & Polish

#### 4.1 Testing
- [ ] **Unit Tests**
  - [ ] Service layer tests
  - [ ] Repository tests
  - [ ] Business logic tests

- [ ] **Integration Tests**
  - [ ] Controller tests
  - [ ] End-to-end flows

#### 4.2 Documentation
- [ ] **Code Documentation**
  - [ ] XML documentation for public methods
  - [ ] Inline comments for complex logic

- [ ] **User Documentation**
  - [ ] User guide for project management
  - [ ] Admin guide

#### 4.3 Performance
- [ ] **Optimization**
  - [ ] Database query optimization
  - [ ] Caching for frequently accessed data
  - [ ] Lazy loading optimization

---

## Implementation Priority Matrix

| Feature | Impact | Effort | Priority |
|---------|--------|--------|----------|
| Project Edit/Update | High | Low | 🔴 P0 |
| ProjectLine Work Management | High | Medium | 🔴 P0 |
| ProjectLine Note Management | High | Low | 🔴 P0 |
| File Upload/Management | High | Medium | 🔴 P0 |
| Project Delete | Medium | Low | 🟡 P1 |
| Dashboard | Medium | Medium | 🟡 P1 |
| Advanced Filtering | Medium | Low | 🟡 P1 |
| Bulk Operations | Medium | Medium | 🟡 P1 |
| Timeline/Gantt Chart | Low | High | 🟢 P2 |
| Reports | Low | High | 🟢 P2 |
| Notifications | Medium | High | 🟢 P2 |
| REST API | Medium | High | 🟢 P2 |

---

## File Structure Reference

### Current Structure
```
Koala.Portal/
├── Models/
│   ├── Project.cs
│   ├── ProjectLine.cs
│   ├── ProjectLineNote.cs
│   ├── ProjectLineWork.cs
│   ├── ProjectFiles.cs
│   └── ProjectPerson.cs
├── Data/
│   └── AppDbContext.cs
├── Configurations/
│   ├── ProjectConfiguration.cs
│   ├── ProjectFilesConfiguration.cs
│   ├── ProjectLineConfiguration.cs
│   ├── ProjectLineNoteConfiguration.cs
│   ├── ProjectLineWorkConfiguration.cs
│   └── ProjectPersonConfiguration.cs
├── Repositories/
│   ├── IProjectRepository.cs
│   ├── ProjectRepository.cs
│   ├── IProjectFileRepository.cs
│   ├── ProjectFileRepository.cs
│   ├── IProjectLineRepository.cs
│   ├── ProjectLineRepository.cs
│   ├── IProjectLineNoteRepository.cs
│   ├── ProjectLineNoteRepository.cs
│   ├── IProjectLineWorkRepository.cs
│   └── ProjectLineWorkRepository.cs
├── Services/
│   ├── IProjectService.cs
│   ├── ProjectService.cs
│   ├── IProjectLineService.cs
│   ├── ProjectLineService.cs
│   ├── IProjectLineWorkService.cs
│   └── ProjectLineWorkService.cs
├── Controllers/
│   └── ProjectController.cs
├── ViewModels/
│   ├── ProjectViewModels.cs
│   ├── ProjectLineViewModels.cs
│   ├── ProjectLineWorksViewModels.cs
│   ├── ProjectFilesViewModels.cs
│   ├── ProjectLineNoteViewModels.cs
│   └── ProjectPersonViewModels.cs
├── Views/Project/
│   ├── Index.cshtml
│   ├── CreateProject.cshtml
│   ├── Detail.cshtml
│   └── AddProjectLine.cshtml
└── wwwroot/js/
    ├── ProjectCreatePage.js
    ├── ProjectDetailPage.js
    └── ProjectListPage.js
```

### Files to Create (Priority Order)
1. `Views/Project/EditProject.cshtml`
2. `Views/Project/_DeleteProjectConfirmation.cshtml`
3. `Views/Project/AddProjectLineWork.cshtml`
4. `Views/Project/EditProjectLineWork.cshtml`
5. `Views/Project/AddProjectLineNote.cshtml`
6. `Views/Project/EditProjectLineNote.cshtml`
7. `Views/Project/UploadProjectFile.cshtml`
8. `Views/Project/_ProjectFilesList.cshtml`
9. `Views/Project/_ProjectLineNotes.cshtml`
10. `Views/Project/_ProjectLineWorks.cshtml`

---

## Notes

- The backend foundation is solid with complete repository and service layers
- Focus should be on completing the UI/UX for all CRUD operations
- Status management needs proper workflow enforcement
- File handling needs security considerations
- Consider adding audit logging for all changes

---

*Last Updated: 2026-02-25*
*Version: 1.0*
