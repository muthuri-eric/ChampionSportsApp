CREATE TABLE [dbo].[Trainee]
(
    [TraineeId] int not null identity,
    [StudentId] INT NOT NULL,
    [SportEventId] INT NOT NULL, 
    [EquipmentDetailId] NCHAR(10) NULL, 
    [Accepted] BIT NOT NULL, 
    [Attended] BIT NOT NULL 
)
