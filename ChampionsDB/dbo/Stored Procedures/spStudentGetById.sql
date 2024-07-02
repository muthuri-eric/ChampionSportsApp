CREATE PROCEDURE [dbo].[spStudentGetById]
@StudentId nvarchar(10) 
AS
begin
	SELECT * FROM dbo.Student where StudentId = @StudentId
end
