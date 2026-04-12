CREATE PROCEDURE usp_GetAllOrganizations
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
    ORDER BY OrganizationName;
END