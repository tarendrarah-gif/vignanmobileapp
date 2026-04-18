CREATE PROCEDURE [dbo].[usp_UpdateUser]
    @UserId     INT,
    @Username   NVARCHAR(100),
    @RoleID     INT,
    @IsActive   BIT,
    @ModifiedBy NVARCHAR(100) = NULL,
    @ModifiedOn DATETIME      = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE tblUsersMaster
    SET Username   = @Username,
        RoleID     = @RoleID,
        IsActive   = @IsActive,
        ModifiedBy = @ModifiedBy,
        ModifiedOn = @ModifiedOn
    WHERE UserId = @UserId;

    SELECT @@ROWCOUNT AS RowsAffected;
END
