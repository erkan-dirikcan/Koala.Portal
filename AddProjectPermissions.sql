-- Add missing Project permissions to Claims table
-- Run this script to fix the AuthorizationPolicy error for Project.Edit and Project.Delete

-- Find the Project ModuleId first
DECLARE @ProjectModuleId uniqueidentifier

SELECT TOP 1 @ProjectModuleId = Id FROM dbo.Module WHERE Name = 'Project' OR Name LIKE '%Project%'

-- If Project module doesn't exist, we need to create it first
IF @ProjectModuleId IS NULL
BEGIN
    -- Create a Project module
    INSERT INTO dbo.Module (Id, Name, DisplayName, Description, Status, CreateTime, CreateUser)
    SELECT NEWID(), 'Project', 'Proje Yönetimi', 'Proje modülü yetkileri', 1, GETDATE(), 'system'

    SET @ProjectModuleId = (SELECT Id FROM dbo.Module WHERE Name = 'Project')
END

-- Add missing permissions if they don't exist
IF NOT EXISTS (SELECT 1 FROM dbo.Claims WHERE Name = 'Project.Edit')
BEGIN
    INSERT INTO dbo.Claims (Id, ModuleId, Name, DisplayName, Description)
    SELECT NEWID(), @ProjectModuleId, 'Project.Edit', 'Proje Düzenle', 'Proje düzenleme yetkisi'
END

IF NOT EXISTS (SELECT 1 FROM dbo.Claims WHERE Name = 'Project.Delete')
BEGIN
    INSERT INTO dbo.Claims (Id, ModuleId, Name, DisplayName, Description)
    SELECT NEWID(), @ProjectModuleId, 'Project.Delete', 'Proje Sil', 'Proje silme yetkisi'
END

-- Display the results
SELECT 'Project permissions added successfully:' as Result
SELECT Name, DisplayName FROM dbo.Claims WHERE ModuleId = @ProjectModuleId
