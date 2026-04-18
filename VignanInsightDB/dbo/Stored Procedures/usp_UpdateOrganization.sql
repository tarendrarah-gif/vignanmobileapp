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
