-- Add missing Project permissions to Claims table
-- Run this script to fix the AuthorizationPolicy error for ProjectManagement.Edit and ProjectManagement.Delete

-- Find the ProjectManagement ModuleId first
DECLARE @ProjectModuleId uniqueidentifier

SELECT TOP 1 @ProjectModuleId = Id FROM dbo.Module WHERE Name = 'ProjectManagement' OR Name LIKE '%ProjectManagement%'

-- If ProjectManagement module doesn't exist, we need to create it first
IF @ProjectModuleId IS NULL
BEGIN
    -- Create a ProjectManagement module
    INSERT INTO dbo.Module (Id, Name, DisplayName, Description, Status, CreateTime, CreateUser)
    SELECT NEWID(), 'ProjectManagement', 'Proje Yönetimi', 'Proje modülü yetkileri', 1, GETDATE(), 'system'

    SET @ProjectModuleId = (SELECT Id FROM dbo.Module WHERE Name = 'ProjectManagement')
END

-- Add missing permissions if they don't exist
IF NOT EXISTS (SELECT 1 FROM dbo.Claims WHERE Name = 'ProjectManagement.Edit')
BEGIN
    INSERT INTO dbo.Claims (Id, ModuleId, Name, DisplayName, Description)
    SELECT NEWID(), @ProjectModuleId, 'ProjectManagement.Edit', 'Proje Düzenle', 'Proje düzenleme yetkisi'
END

IF NOT EXISTS (SELECT 1 FROM dbo.Claims WHERE Name = 'ProjectManagement.Delete')
BEGIN
    INSERT INTO dbo.Claims (Id, ModuleId, Name, DisplayName, Description)
    SELECT NEWID(), @ProjectModuleId, 'ProjectManagement.Delete', 'Proje Sil', 'Proje silme yetkisi'
END

-- Display the results
SELECT 'Project permissions added successfully:' as Result
SELECT Name, DisplayName FROM dbo.Claims WHERE ModuleId = @ProjectModuleId
