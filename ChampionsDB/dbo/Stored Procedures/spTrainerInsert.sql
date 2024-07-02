CREATE PROCEDURE [dbo].[spTrainerInsert]
@Id nvarchar(450),
@StaffNumber nvarchar(10),
@Title nvarchar(5),
@FirstName nvarchar(20),
@LastName nvarchar(20)
AS
begin
	insert into dbo.Trainer (Id, StaffNumber, Title, FirstName, LastName)
	values(@Id, @StaffNumber, @Title, @FirstName, @LastName)
end
