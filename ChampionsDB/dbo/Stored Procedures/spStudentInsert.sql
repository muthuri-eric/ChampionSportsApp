CREATE PROCEDURE [dbo].[spStudentInsert]
@Id nvarchar(450),
@StudentNumber int,
@GradeLevelId int,
@Gender nvarchar(1),
@FirstName nvarchar(20),
@LastName nvarchar(20)
AS
begin
	insert into dbo.Student (StudentNumber, Id, GradeLevelId, Gender, FirstName, LastName)
	values(@StudentNumber, @Id, @GradeLevelId, @Gender, @FirstName, @LastName)
END
