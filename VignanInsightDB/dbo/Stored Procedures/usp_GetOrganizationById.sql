CREATE PROCEDURE [dbo].[usp_GetOrganizationById]
    @OrganizationId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        OrganizationId,
        OrganizationName,
        OrganizationDescription,
        IsActive,
        CreatedBy,
        CreatedOn,
        ModifiedBy,
        ModifiedOn
    FROM tblOrganization
    WHERE OrganizationId = @OrganizationId;
END
