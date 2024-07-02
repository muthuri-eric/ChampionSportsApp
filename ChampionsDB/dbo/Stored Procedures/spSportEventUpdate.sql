CREATE PROCEDURE [dbo].[spSportEventUpdate]
@SportEventId int,
@LessonId int,
@SportId int,
@TrainerId int,
@MatchDescription nvarchar(20),
@Location nvarchar(20),
@StartTime time(7),
@EndTime time(7)
AS
begin
	update dbo.SportEvent
	set LessonId = @LessonId, SportId = @SportId, TrainerId = @TrainerId, 
	MatchDescription = @MatchDescription, Location = @Location, StartTime = @StartTime, EndTime = @EndTime
	where SportEventId = @SportEventId
end
