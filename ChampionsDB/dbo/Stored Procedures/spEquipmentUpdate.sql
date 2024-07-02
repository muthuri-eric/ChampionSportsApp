CREATE PROCEDURE [dbo].[spEquipmentUpdate]
@EquipmentId int,
@SportId int,
@Description nvarchar (20),
@StockCount int
AS
begin
	update dbo.Equipment 
	set SportId = @SportId, Description = @Description, StockCount = @StockCount
	where EquipmentId = @EquipmentId
end
