CREATE PROCEDURE [dbo].[spEquipmentDetailUpdate]
    @EquipmentDetailId int,
	@EquipmentId INT,
	@TraineeId  INT,
	@SportEventId INT,
	@SerialNumber nvarchar(15),
	@IssueDate datetime2,
	@ReturnDate datetime2,
    @Status bit
AS
begin
	update dbo.EquipmentDetail
	set  EquipmentId = @EquipmentId,TraineeId = @TraineeId, SportEventId = @SportEventId, 
	SerialNumber = @SerialNumber, IssueDate=@IssueDate, ReturnDate=@ReturnDate, Status = @Status
	where EquipmentDetailId = @EquipmentDetailId
end
