CREATE TABLE [dbo].[Activity]
(
	[ActivityId] INT NOT NULL PRIMARY KEY IDENTITY,
	[TraineeId] INT NOT NULL,
	[Description] nvarchar(50), 
    [IsCompleted] BIT NOT NULL
)
