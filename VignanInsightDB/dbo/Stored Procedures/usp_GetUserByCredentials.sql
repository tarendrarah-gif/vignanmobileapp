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
        u.RoleID          AS RoleId,
        r.RoleName,
        u.IsActive,
        u.CreatedBy,
        u.CreatedOn,
        u.ModifiedBy,
        u.ModifiedOn,
        o.OrganizationId,
        o.OrganizationName
    FROM tblUsersMaster u
    LEFT  JOIN tblRoleMaster       r  ON u.RoleID          = r.RoleID
    INNER JOIN tblUserOrganization uo ON u.UserId           = uo.UserId
    INNER JOIN tblOrganization     o  ON uo.OrganizationId  = o.OrganizationId
    WHERE u.Username = @Username
      AND u.Password = @Password
      AND u.IsActive = 1;
END