CREATE PROCEDURE [dbo].[spLessonInsert]
@GradeLevelId int,
@SubjectId int,
@LessonDate datetime2,
@StartTime time(7),
@EndTime time(7)
AS
begin
insert into dbo.Lesson(GradeLevelId, SubjectId, LessonDate, StartTime, EndTime)
values(@GradeLevelId, @SubjectId, @LessonDate, @StartTime, @EndTime)
end