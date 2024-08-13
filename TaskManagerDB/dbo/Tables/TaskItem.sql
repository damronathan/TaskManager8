CREATE TABLE [dbo].[TaskItem]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NULL,
    [Title] NVARCHAR(100) NOT NULL, 
    [Description] NVARCHAR(500) NULL, 
    [IsComplete] BIT NOT NULL,      
    CONSTRAINT [FK_TaskItems_User] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId]) 
)
