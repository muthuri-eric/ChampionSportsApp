CREATE PROCEDURE [dbo].[spTraineeGetById]
@TraineeId int
AS
begin
	SELECT * from dbo.Trainee where TraineeId = @TraineeId
end
