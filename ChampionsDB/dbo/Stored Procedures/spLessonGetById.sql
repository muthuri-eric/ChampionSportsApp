CREATE PROCEDURE [dbo].[spLessonGetById]
@LessonId int
AS
begin
	SELECT * from dbo.Lesson where LessonId = @LessonId
end
