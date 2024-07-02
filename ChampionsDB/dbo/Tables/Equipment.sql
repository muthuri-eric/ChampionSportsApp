CREATE TABLE [dbo].[Equipment]
(
	[EquipmentId] INT NOT NULL PRIMARY KEY identity,
    [SportId] INT NOT NULL,
    [Description] NVARCHAR(20) NULL,
    [StockCount] INT NOT NULL
)
