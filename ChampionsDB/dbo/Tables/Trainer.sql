CREATE TABLE [dbo].[Trainer]
(
	[TrainerId] INT NOT NULL PRIMARY KEY identity,
	[Id] nvarchar(450),
	[StaffNumber] NVARCHAR(10) NOT NULL UNIQUE,
	[Title] nvarchar(5),
	[FirstName] nvarchar(20),
	[LastName] nvarchar(20)

)
