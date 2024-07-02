CREATE PROCEDURE [dbo].[spTraineeUpdate]
@TraineeId int,
@StudentId int,
@SportEventId int,
@Accepted bit,
@Attended bit
AS
begin
update dbo.Trainee
set StudentId = @StudentId, SportEventId = @SportEventId, Accepted = @Accepted, Attended = @Attended where TraineeId = @TraineeId
end
