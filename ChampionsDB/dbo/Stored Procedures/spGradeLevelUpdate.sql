CREATE PROCEDURE [dbo].[spGradeLevelUpdate]
@GradeLevelId int,
@GradeNumber nvarchar(10),
@Description nvarchar (20)
AS
begin
update dbo.GradeLevel
set GradeNumber = @GradeNumber, Description = @Description
WHERE GradeLevelId = @GradeLevelId
end
