CREATE PROCEDURE [dbo].[usp_DeleteUser]
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM tblUserOrganization WHERE UserId = @UserId;
    DELETE FROM tblUsersMaster      WHERE UserId = @UserId;

    SELECT @@ROWCOUNT AS RowsAffected;
END
