CREATE TABLE [dbo].[Student]
(
	[StudentId] INT NOT NULL PRIMARY KEY IDENTITY,
	[Id] nvarchar(450),
	[StudentNumber] nvarchar(10) NOT NULL UNIQUE,
	[GradeLevelId] INT NOT NULL,
	[Gender] nvarchar(1),
	[FirstName] nvarchar(20),
	[LastName] nvarchar(20)

)
