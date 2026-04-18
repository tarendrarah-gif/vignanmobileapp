CREATE PROCEDURE [dbo].[usp_DeleteOrganization]
    @OrganizationId INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Remove mapping tables first; preserve user/machine master records
    DELETE FROM tblMachineOrganization WHERE OrganizationId = @OrganizationId;
    DELETE FROM tblUserOrganization    WHERE OrganizationId = @OrganizationId;
    DELETE FROM tblOrganization        WHERE OrganizationId = @OrganizationId;

    SELECT @@ROWCOUNT AS RowsAffected;
END
