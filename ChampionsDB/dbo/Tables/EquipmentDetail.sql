CREATE TABLE [dbo].[EquipmentDetail]
(
	[EquipmentDetailId] INT NOT NULL PRIMARY KEY IDENTITY,
	[EquipmentId] INT NOT NULL,
	[TraineeId] INT NOT NULL, 
	[SportEventId] INT NOT NULL,
	[SerialNumber] nvarchar(15),
	[IssueDate] datetime2,
	[ReturnDate] datetime2,
    [Status] bit
)
