-- Create tblRoleMaster and update tblUsersMaster to reference RoleID
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

IF OBJECT_ID('dbo.tblRoleMaster', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.tblRoleMaster (
        RoleID INT IDENTITY(1,1) PRIMARY KEY,
        RoleName NVARCHAR(100) NOT NULL,
        Description NVARCHAR(500) NULL,
        IsActive BIT NOT NULL CONSTRAINT DF_tblRoleMaster_IsActive DEFAULT(1),
        CreatedDate DATETIME NOT NULL CONSTRAINT DF_tblRoleMaster_CreatedDate DEFAULT(GETDATE()),
        UpdatedDate DATETIME NULL
    );
END
GO

-- Seed predefined roles (ignore if already exists)
IF NOT EXISTS (SELECT 1 FROM dbo.tblRoleMaster WHERE RoleName = 'Admin')
    INSERT INTO dbo.tblRoleMaster (RoleName, Description, IsActive) VALUES ('Admin', 'System administrator', 1);
IF NOT EXISTS (SELECT 1 FROM dbo.tblRoleMaster WHERE RoleName = 'Client')
    INSERT INTO dbo.tblRoleMaster (RoleName, Description, IsActive) VALUES ('Client', 'Client role', 1);
IF NOT EXISTS (SELECT 1 FROM dbo.tblRoleMaster WHERE RoleName = 'User')
    INSERT INTO dbo.tblRoleMaster (RoleName, Description, IsActive) VALUES ('User', 'Standard user role', 1);
GO

-- 1) Add RoleID column to tblUsersMaster (nullable initially)
IF COL_LENGTH('dbo.tblUsersMaster', 'RoleID') IS NULL
BEGIN
    ALTER TABLE dbo.tblUsersMaster ADD RoleID INT NULL;
END
GO

-- 2) Try to migrate existing textual Role values into RoleID where possible
-- This assumes there is a text column named Role (older schema). If not present, this step is skipped.
IF COL_LENGTH('dbo.tblUsersMaster', 'Role') IS NOT NULL
BEGIN
    UPDATE U
    SET RoleID = R.RoleID
    FROM dbo.tblUsersMaster U
    INNER JOIN dbo.tblRoleMaster R ON U.Role = R.RoleName;
END
GO

-- 3) If any RoleID is still NULL, set to default role 'User'
DECLARE @defaultRoleId INT;
SELECT @defaultRoleId = RoleID FROM dbo.tblRoleMaster WHERE RoleName = 'User';
IF @defaultRoleId IS NULL
BEGIN
    SELECT @defaultRoleId = MIN(RoleID) FROM dbo.tblRoleMaster; -- fallback
END

UPDATE dbo.tblUsersMaster SET RoleID = @defaultRoleId WHERE RoleID IS NULL;
GO

-- 4) Make RoleID NOT NULL and add FK constraint
IF COL_LENGTH('dbo.tblUsersMaster', 'RoleID') IS NOT NULL
BEGIN
    -- add index on RoleID
    IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_tblUsersMaster_RoleID' AND object_id = OBJECT_ID('dbo.tblUsersMaster'))
    BEGIN
        CREATE INDEX IX_tblUsersMaster_RoleID ON dbo.tblUsersMaster(RoleID);
    END

    -- add foreign key if not exists
    IF NOT EXISTS (
        SELECT 1 FROM sys.foreign_keys WHERE parent_object_id = OBJECT_ID('dbo.tblUsersMaster') AND referenced_object_id = OBJECT_ID('dbo.tblRoleMaster')
    )
    BEGIN
        ALTER TABLE dbo.tblUsersMaster ALTER COLUMN RoleID INT NOT NULL;
        ALTER TABLE dbo.tblUsersMaster ADD CONSTRAINT FK_tblUsersMaster_tblRoleMaster_RoleID FOREIGN KEY (RoleID) REFERENCES dbo.tblRoleMaster(RoleID);
    END
END
GO

-- 5) Drop old Role text column if exists
IF COL_LENGTH('dbo.tblUsersMaster', 'Role') IS NOT NULL
BEGIN
    ALTER TABLE dbo.tblUsersMaster DROP COLUMN [Role];
END
GO

-- 6) Update stored procedure usp_InsertUser to accept RoleID instead of Role
IF OBJECT_ID('dbo.usp_InsertUser', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE dbo.usp_InsertUser;
END
GO

CREATE PROCEDURE [dbo].[usp_InsertUser]
    @Username NVARCHAR(100),
    @Password NVARCHAR(100),
    @RoleID INT,
    @IsActive BIT,
    @CreatedBy NVARCHAR(100),
    @CreatedOn DATETIME,
    @ModifiedBy NVARCHAR(100) = NULL,
    @ModifiedOn DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO tblUsersMaster
    (
        Username,
        Password,
        RoleID,
        IsActive,
        CreatedBy,
        CreatedOn,
        ModifiedBy,
        ModifiedOn
    )
    VALUES
    (
        @Username,
        @Password,
        @RoleID,
        @IsActive,
        @CreatedBy,
        @CreatedOn,
        @ModifiedBy,
        @ModifiedOn
    );

    SELECT CAST(SCOPE_IDENTITY() AS INT) AS UserId;
END
GO
