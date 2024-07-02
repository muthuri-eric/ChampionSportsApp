CREATE PROCEDURE [dbo].[spEquipmentInsert]
@SportId int,
@Description nvarchar (20),
@StockCount int
AS
begin 
insert into dbo.Equipment(SportId, Description, StockCount)
values(@SportId, @Description, @StockCount)
end
