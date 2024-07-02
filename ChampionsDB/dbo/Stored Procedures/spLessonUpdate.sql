CREATE PROCEDURE [dbo].[spLessonUpdate]
@LessonId int,
@GradeLevelId int,
@SubjectId int,
@LessonDate datetime2,
@StartTime time(7),
@EndTime time(7)
AS
BEGIN
	update dbo.Lesson
	set GradeLevelId = @GradeLevelId, SubjectId = @SubjectId, LessonDate = @LessonDate, StartTime = @StartTime, EndTime = @StartTime
	where LessonId = @LessonId
END
