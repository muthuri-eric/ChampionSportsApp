CREATE TABLE [dbo].[SportEvent]
(
	[SportEventId] INT NOT NULL PRIMARY KEY identity,
    [LessonId] INT NOT NULL,
    [SportId] INT NOT NULL, 
    [TrainerId] INT NOT NULL,
    [MatchDescription] NVARCHAR(20) NULL,
    [Location] NVARCHAR(20) NULL,
    [StartTime] TIME NULL, 
    [EndTime] TIME NULL 
)
