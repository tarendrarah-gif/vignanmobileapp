-- =====================================================================
-- 002_CRUD_StoredProcedures.sql
-- Full CRUD stored procedures for User, Machine, Organization
-- Run AFTER 001_Create_tblRoleMaster_and_update_users.sql
-- =====================================================================

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- =====================================================================
-- 1. usp_GetAllUsers  (updated: JOIN RoleMaster, optional OrgId filter)
-- =====================================================================
IF OBJECT_ID('dbo.usp_GetAllUsers', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_GetAllUsers;
GO
CREATE PROCEDURE [dbo].[usp_GetAllUsers]
    @OrgId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        u.UserId,
        u.Username,
        u.RoleID   AS RoleId,
        r.RoleName,
        u.IsActive,
        u.CreatedBy,
        u.CreatedOn,
        u.ModifiedBy,
        u.ModifiedOn,
        (SELECT TOP 1 uo2.OrganizationId
         FROM tblUserOrganization uo2
         WHERE uo2.UserId = u.UserId)                                         AS OrganizationId,
        (SELECT TOP 1 o2.OrganizationName
         FROM tblUserOrganization uo2
         INNER JOIN tblOrganization o2 ON uo2.OrganizationId = o2.OrganizationId
         WHERE uo2.UserId = u.UserId)                                         AS OrganizationName
    FROM tblUsersMaster u
    LEFT JOIN tblRoleMaster r ON u.RoleID = r.RoleID
    WHERE (@OrgId IS NULL
        OR EXISTS (SELECT 1 FROM tblUserOrganization uo
                   WHERE uo.UserId = u.UserId AND uo.OrganizationId = @OrgId))
    ORDER BY u.UserId ASC;
END
GO

-- =====================================================================
-- 2. usp_GetUserByCredentials  (updated: return RoleName via JOIN)
-- =====================================================================
IF OBJECT_ID('dbo.usp_GetUserByCredentials', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_GetUserByCredentials;
GO
CREATE PROCEDURE [dbo].[usp_GetUserByCredentials]
    @Username NVARCHAR(100),
    @Password NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        u.UserId,
        u.Username,
        u.Password,
        u.RoleID   AS RoleId,
        r.RoleName,
        u.IsActive,
        u.CreatedBy,
        u.CreatedOn,
        u.ModifiedBy,
        u.ModifiedOn,
        o.OrganizationId,
        o.OrganizationName
    FROM tblUsersMaster u
    LEFT JOIN tblRoleMaster r ON u.RoleID = r.RoleID
    INNER JOIN tblUserOrganization uo ON u.UserId = uo.UserId
    INNER JOIN tblOrganization o ON uo.OrganizationId = o.OrganizationId
    WHERE u.Username = @Username
      AND u.Password = @Password
      AND u.IsActive = 1;
END
GO

-- =====================================================================
-- 3. usp_GetUserById
-- =====================================================================
IF OBJECT_ID('dbo.usp_GetUserById', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_GetUserById;
GO
CREATE PROCEDURE [dbo].[usp_GetUserById]
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        u.UserId,
        u.Username,
        u.RoleID AS RoleId,
        r.RoleName,
        u.IsActive,
        u.CreatedBy,
        u.CreatedOn,
        u.ModifiedBy,
        u.ModifiedOn,
        (SELECT TOP 1 uo2.OrganizationId
         FROM tblUserOrganization uo2 WHERE uo2.UserId = u.UserId) AS OrganizationId,
        (SELECT TOP 1 o2.OrganizationName
         FROM tblUserOrganization uo2
         INNER JOIN tblOrganization o2 ON uo2.OrganizationId = o2.OrganizationId
         WHERE uo2.UserId = u.UserId)                               AS OrganizationName
    FROM tblUsersMaster u
    LEFT JOIN tblRoleMaster r ON u.RoleID = r.RoleID
    WHERE u.UserId = @UserId;
END
GO

-- =====================================================================
-- 4. usp_UpdateUser
-- =====================================================================
IF OBJECT_ID('dbo.usp_UpdateUser', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_UpdateUser;
GO
CREATE PROCEDURE [dbo].[usp_UpdateUser]
    @UserId     INT,
    @Username   NVARCHAR(100),
    @RoleID     INT,
    @IsActive   BIT,
    @ModifiedBy NVARCHAR(100) = NULL,
    @ModifiedOn DATETIME      = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tblUsersMaster
    SET Username   = @Username,
        RoleID     = @RoleID,
        IsActive   = @IsActive,
        ModifiedBy = @ModifiedBy,
        ModifiedOn = @ModifiedOn
    WHERE UserId = @UserId;

    SELECT @@ROWCOUNT AS RowsAffected;
END
GO

-- =====================================================================
-- 5. usp_DeleteUser
-- =====================================================================
IF OBJECT_ID('dbo.usp_DeleteUser', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_DeleteUser;
GO
CREATE PROCEDURE [dbo].[usp_DeleteUser]
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM tblUserOrganization WHERE UserId = @UserId;
    DELETE FROM tblUsersMaster      WHERE UserId = @UserId;
    SELECT @@ROWCOUNT AS RowsAffected;
END
GO

-- =====================================================================
-- 6. usp_GetAllMachines  (new, with optional OrgId filter)
-- =====================================================================
IF OBJECT_ID('dbo.usp_GetAllMachines', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_GetAllMachines;
GO
CREATE PROCEDURE [dbo].[usp_GetAllMachines]
    @OrgId INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        m.MachineId,
        m.MachineName,
        m.MachineDescription,
        m.IsActive,
        m.CreatedBy,
        m.CreatedOn,
        m.ModifiedBy,
        m.ModifiedOn,
        o.OrganizationId,
        o.OrganizationName
    FROM tblMachines m
    LEFT JOIN tblMachineOrganization mo ON m.MachineId = mo.MachineId
    LEFT JOIN tblOrganization o         ON mo.OrganizationId = o.OrganizationId
    WHERE (@OrgId IS NULL OR mo.OrganizationId = @OrgId)
    ORDER BY m.MachineId;
END
GO

-- =====================================================================
-- 7. usp_GetMachineById
-- =====================================================================
IF OBJECT_ID('dbo.usp_GetMachineById', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_GetMachineById;
GO
CREATE PROCEDURE [dbo].[usp_GetMachineById]
    @MachineId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        m.MachineId, m.MachineName, m.MachineDescription, m.IsActive,
        m.CreatedBy, m.CreatedOn, m.ModifiedBy, m.ModifiedOn,
        o.OrganizationId, o.OrganizationName
    FROM tblMachines m
    LEFT JOIN tblMachineOrganization mo ON m.MachineId = mo.MachineId
    LEFT JOIN tblOrganization o         ON mo.OrganizationId = o.OrganizationId
    WHERE m.MachineId = @MachineId;
END
GO

-- =====================================================================
-- 8. usp_UpdateMachine
-- =====================================================================
IF OBJECT_ID('dbo.usp_UpdateMachine', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_UpdateMachine;
GO
CREATE PROCEDURE [dbo].[usp_UpdateMachine]
    @MachineId          INT,
    @MachineName        NVARCHAR(100),
    @MachineDescription NVARCHAR(255) = NULL,
    @IsActive           BIT,
    @OrganizationId     INT,
    @ModifiedBy         NVARCHAR(100) = NULL,
    @ModifiedOn         DATETIME      = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE tblMachines
    SET MachineName        = @MachineName,
        MachineDescription = @MachineDescription,
        IsActive           = @IsActive,
        ModifiedBy         = @ModifiedBy,
        ModifiedOn         = @ModifiedOn
    WHERE MachineId = @MachineId;

    -- Update organisation mapping (remove old, add new)
    DELETE FROM tblMachineOrganization WHERE MachineId = @MachineId;
    INSERT INTO tblMachineOrganization (MachineId, OrganizationId)
    VALUES (@MachineId, @OrganizationId);

    SELECT @@ROWCOUNT AS RowsAffected;
END
GO

-- =====================================================================
-- 9. usp_DeleteMachine
-- =====================================================================
IF OBJECT_ID('dbo.usp_DeleteMachine', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_DeleteMachine;
GO
CREATE PROCEDURE [dbo].[usp_DeleteMachine]
    @MachineId INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM tblMachineOrganization WHERE MachineId = @MachineId;
    DELETE FROM tblMachines            WHERE MachineId = @MachineId;
    SELECT @@ROWCOUNT AS RowsAffected;
END
GO

-- =====================================================================
-- 10. usp_GetOrganizationById
-- =====================================================================
IF OBJECT_ID('dbo.usp_GetOrganizationById', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_GetOrganizationById;
GO
CREATE PROCEDURE [dbo].[usp_GetOrganizationById]
    @OrganizationId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT OrganizationId, OrganizationName, OrganizationDescription,
           IsActive, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn
    FROM tblOrganization
    WHERE OrganizationId = @OrganizationId;
END
GO

-- =====================================================================
-- 11. usp_UpdateOrganization
-- =====================================================================
IF OBJECT_ID('dbo.usp_UpdateOrganization', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_UpdateOrganization;
GO
CREATE PROCEDURE [dbo].[usp_UpdateOrganization]
    @OrganizationId          INT,
    @OrganizationName        NVARCHAR(200),
    @OrganizationDescription NVARCHAR(500) = NULL,
    @IsActive                BIT,
    @ModifiedBy              NVARCHAR(100) = NULL,
    @ModifiedOn              DATETIME      = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tblOrganization
    SET OrganizationName        = @OrganizationName,
        OrganizationDescription = @OrganizationDescription,
        IsActive                = @IsActive,
        ModifiedBy              = @ModifiedBy,
        ModifiedOn              = @ModifiedOn
    WHERE OrganizationId = @OrganizationId;

    SELECT @@ROWCOUNT AS RowsAffected;
END
GO

-- =====================================================================
-- 12. usp_DeleteOrganization
-- =====================================================================
IF OBJECT_ID('dbo.usp_DeleteOrganization', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_DeleteOrganization;
GO
CREATE PROCEDURE [dbo].[usp_DeleteOrganization]
    @OrganizationId INT
AS
BEGIN
    SET NOCOUNT ON;
    -- Remove from mapping tables only; user/machine records are preserved
    DELETE FROM tblMachineOrganization WHERE OrganizationId = @OrganizationId;
    DELETE FROM tblUserOrganization    WHERE OrganizationId = @OrganizationId;
    DELETE FROM tblOrganization        WHERE OrganizationId = @OrganizationId;
    SELECT @@ROWCOUNT AS RowsAffected;
END
GO
