CREATE PROCEDURE [dbo].[usp_InsertUser]
    @Username NVARCHAR(100),
    @Password NVARCHAR(100),
    @Role NVARCHAR(50),
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
        Role,
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
        @Role,
        @IsActive,
        @CreatedBy,
        @CreatedOn,
        @ModifiedBy,
        @ModifiedOn
    );

    SELECT SCOPE_IDENTITY() AS UserId;
END