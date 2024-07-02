CREATE PROCEDURE [dbo].[spSportEventInsert]
@LessonId int,
@SportId int,
@TrainerId int,
@MatchDescription nvarchar(20),
@Location nvarchar(20),
@StartTime time(7),
@EndTime time(7)
AS
begin
insert into dbo.SportEvent(LessonId, SportId, TrainerId, MatchDescription, Location, StartTime, EndTime)
values(@LessonId, @SportId, @TrainerId, @MatchDescription, @Location, @StartTime, @EndTime)
end
