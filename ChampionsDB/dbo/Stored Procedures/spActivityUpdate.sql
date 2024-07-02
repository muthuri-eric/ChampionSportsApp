CREATE PROCEDURE [dbo].[spActivityUpdate]
@ActivityId int,
@TraineeId int,
@Description nvarchar(50),
@IsCompleted bit
AS
begin
update dbo.Activity
set TraineeId =@TraineeId, Description = @Description, IsCompleted = @IsCompleted where ActivityId = @ActivityId
end
