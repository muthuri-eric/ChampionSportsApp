CREATE PROCEDURE [dbo].[spTrainerUpdate]
@TrainerId int,
@Id nvarchar(450),
@StaffNumber nvarchar(10),
@Title nvarchar(5),
@FirstName nvarchar(20),
@LastName nvarchar(20)
AS
begin
	update dbo.Trainer
	set  Id = @Id, StaffNumber = @StaffNumber, Title = @Title, FirstName = @FirstName, LastName = @LastName
	where TrainerId = @TrainerId
end
