CREATE PROCEDURE [dbo].[spGradeLevelInsert]
@GradeNumber nvarchar(10),
@Description nvarchar(20)
AS
begin
	insert into dbo.GradeLevel (GradeNumber, Description)
	values(@GradeNumber, @Description)
end
