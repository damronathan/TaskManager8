CREATE PROCEDURE [dbo].[sp_GetUserById]
    @UserID INT
AS
BEGIN
    SELECT [UserId], [Username], [Password]
    FROM [dbo].[User]
    WHERE [UserId] = @UserID;
END
