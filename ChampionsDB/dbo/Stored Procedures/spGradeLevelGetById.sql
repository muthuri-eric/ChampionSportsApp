CREATE PROCEDURE [dbo].[spGradeLevelGetById]
@GradeLevelId int
AS
begin
	SELECT * from dbo.GradeLevel where GradeLevelId = @GradeLevelId
end
