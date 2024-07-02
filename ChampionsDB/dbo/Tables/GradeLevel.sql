CREATE TABLE [dbo].[GradeLevel]
(
	[GradeLevelId] INT NOT NULL PRIMARY KEY IDENTITY,
	[GradeNumber] nvarchar(10) NOT NULL UNIQUE,
	[Description] nvarchar(20)
)
