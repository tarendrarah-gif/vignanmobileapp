CREATE PROCEDURE [dbo].[usp_GetUserById]
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        u.UserId,
        u.Username,
        u.RoleID          AS RoleId,
        r.RoleName,
        u.IsActive,
        u.CreatedBy,
        u.CreatedOn,
        u.ModifiedBy,
        u.ModifiedOn,
        (SELECT TOP 1 uo2.OrganizationId
         FROM tblUserOrganization uo2
         WHERE uo2.UserId = u.UserId)                       AS OrganizationId,
        (SELECT TOP 1 o2.OrganizationName
         FROM tblUserOrganization uo2
         INNER JOIN tblOrganization o2 ON uo2.OrganizationId = o2.OrganizationId
         WHERE uo2.UserId = u.UserId)                       AS OrganizationName
    FROM tblUsersMaster u
    LEFT JOIN tblRoleMaster r ON u.RoleID = r.RoleID
    WHERE u.UserId = @UserId;
END
