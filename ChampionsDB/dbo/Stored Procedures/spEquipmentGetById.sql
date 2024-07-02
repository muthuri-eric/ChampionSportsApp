CREATE PROCEDURE [dbo].[spEquipmentGetById]
@EquipmentId int
AS
begin
	SELECT * from dbo.Equipment WHERE EquipmentId = @EquipmentId
end
