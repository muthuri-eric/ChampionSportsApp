CREATE PROCEDURE [dbo].[spStudentUpdate]
@StudentId int,
@Id nvarchar(450),
@Gender nvarchar(1),
@GradeLevelId int,
@StudentNumber nvarchar(10),
@FirstName nvarchar(20),
@LastName nvarchar(20)
AS
begin
update dbo.Student
set Id = @Id, Gender = @Gender, GradeLevelId = @GradeLevelId, StudentNumber =@StudentNumber, FirstName = @FirstName, LastName = @LastName where StudentId = @StudentId
end
