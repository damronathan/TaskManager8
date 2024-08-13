CREATE PROCEDURE [dbo].[sp_GetTaskById]
    @TaskID INT
AS
BEGIN
    SELECT [ID], [Title], [Description], [IsComplete]
    FROM [dbo].[TaskItem]
    WHERE [ID] = @TaskID;
END

