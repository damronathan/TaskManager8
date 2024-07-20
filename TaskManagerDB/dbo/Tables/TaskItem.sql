CREATE TABLE [dbo].[TaskItems]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
    [Title] NVARCHAR(100) NOT NULL, 
    [Description] NVARCHAR(500) NULL, 
    [IsComplete] BIT NOT NULL
)
