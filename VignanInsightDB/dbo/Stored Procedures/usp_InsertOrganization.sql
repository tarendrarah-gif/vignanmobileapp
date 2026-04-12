CREATE PROCEDURE usp_InsertOrganization
    @OrganizationName NVARCHAR(200),
    @OrganizationDescription NVARCHAR(500) = NULL,
    @IsActive BIT,
    @CreatedBy NVARCHAR(100),
    @CreatedOn DATETIME,
    @ModifiedBy NVARCHAR(100) = NULL,
    @ModifiedOn DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO tblOrganization (
        OrganizationName,
        OrganizationDescription,
        IsActive,
        CreatedBy,
        CreatedOn,
        ModifiedBy,
        ModifiedOn
    )
    VALUES (
        @OrganizationName,
        @OrganizationDescription,
        @IsActive,
        @CreatedBy,
        @CreatedOn,
        @ModifiedBy,
        @ModifiedOn
    );

    SELECT SCOPE_IDENTITY() AS OrganizationId;
END