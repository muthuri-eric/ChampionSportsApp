CREATE PROCEDURE [dbo].[spTrainerGetById]
@TrainerId int
AS
begin
	SELECT * from dbo.Trainer where TrainerId = @TrainerId
end
