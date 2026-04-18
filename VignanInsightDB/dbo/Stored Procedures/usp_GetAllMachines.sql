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
    LEFT JOIN tblMachineOrganization mo ON m.MachineId      = mo.MachineId
    LEFT JOIN tblOrganization        o  ON mo.OrganizationId = o.OrganizationId
    WHERE (@OrgId IS NULL OR mo.OrganizationId = @OrgId)
    ORDER BY m.MachineId;
END
