CREATE PROCEDURE [dbo].[spActivityGetByTrainee]
@TraineeId int
AS
Begin
	SELECT * FROM dbo.Activity where TraineeId = @TraineeId
end
