CREATE TABLE [dbo].[Lesson]
(
	[LessonId] INT NOT NULL PRIMARY KEY IDENTITY,
	[GradeLevelId] INT NOT NULL,
	[SubjectId] INT NOT NULL,
	[LessonDate] datetime2,
	[StartTime] TIME,
	[EndTime] TIME
)
