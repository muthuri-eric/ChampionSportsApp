CREATE PROCEDURE [dbo].[spEquipmentUpdate]
@EquipmentId int,
@StockCount int
AS
begin
	update dbo.Equipment 
	set StockCount = @StockCount
	where EquipmentId = @EquipmentId
end
