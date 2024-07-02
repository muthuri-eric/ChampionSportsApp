CREATE PROCEDURE [dbo].[spEquipmentDetailInsert]
	@EquipmentId INT,
	@TraineeId  INT,
	@SportEventId INT,
	@SerialNumber nvarchar(15),
	@IssueDate datetime2,
    @Status bit
AS
begin
	insert into dbo.EquipmentDetail(EquipmentId, TraineeId, SportEventId, SerialNumber, IssueDate, Status)
	values (@EquipmentId, @TraineeId, @SportEventId, @SerialNumber, @IssueDate, @Status)
end
